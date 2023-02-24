<?php
	header("Access-Control-Allow-Origin: *");
	header('Access-Control-Allow-Methods: POST GET');
	require ("./dbconnect.php");
	date_default_timezone_set('Europe/Amsterdam');


	if (isset($_POST['Register']))
	{
		$json = $_POST['Register'];
		$json = json_decode($json, true);

		$name = $json['Name'];
		$pwd = $json['Password'];
		$nickname = $json['NickName'];

		$sql = "SELECT nickname FROM users WHERE nickname='$nickname'";
	 	$result = $conn->query($sql);


		if ($result !== false && $result -> num_rows > 0)
		{
				echo "NOK";
		}
		else
		{
			try {
				$sql = "insert INTO users (`name`, `password`, `nickname`, `archive`) VALUES ('$name', '$pwd', '$nickname', '0')";
				$result = $conn->query($sql);

				$user_id = $conn->insert_id;
				echo $user_id;
			} catch (\Exception $e) {
				echo $e;
			}
		}
	}

	if (isset($_POST['Login']))
	{
		$json = $_POST['Login'];
		$json = json_decode($json, true);

		$nickname = $json['NickName'];
		$pwd = $json['Password'];

		$sql = "SELECT id FROM users WHERE archive=0 AND nickname='$nickname' AND password='$pwd'";
		$result = $conn->query($sql);

		if ($result !== false && $result -> num_rows > 0)
		{
			if ($row = $result->fetch_assoc())
			{
				echo $row['id'];
			}
		}
		else
		{
			echo "NOK";
		}
	}

	if (isset($_POST['AllUsers']))
	{
		$id = $_POST['AllUsers'];

		$sql = "SELECT id, nickname FROM users WHERE archive=0 and id <> '$id'";
		$result = $conn->query($sql);

		if ($result !== false && $result -> num_rows > 0)
		{
			$arr=[];
			$inc=0;

			while ($row = $result->fetch_assoc())
			{
				$jsonArrayObject = (array('Id' => $row['id'],
                      						'NickName' => $row['nickname']
			 										 ));
				 $arr[$inc] = $jsonArrayObject;
				 $inc++;
			}
		 $json_array = json_encode($arr);
		 echo $json_array;
		}
	}


	if (isset($_POST['UserChat']))
	{
		$json = $_POST['UserChat'];
		$json = json_decode($json, true);

		$from_id = $json['From_Id'];
		$to_id = $json['To_Id'];

		$sql = "SELECT message, from_id, to_id FROM messages WHERE (from_id='$from_id' AND to_id='$to_id') OR (from_id='$to_id' AND to_id='$from_id')";
		$result = $conn->query($sql);

		if ($result !== false && $result -> num_rows > 0)
		{
			$arr=[];
			$inc=0;

			while ($row = $result->fetch_assoc())
			{
				$jsonArrayObject = (array('From_Id' => $row['from_id'],
																	'To_Id' => $row['to_id'],
																	'Message' => $row['message']
													 ));
				 $arr[$inc] = $jsonArrayObject;
				 $inc++;
			}
		 $json_array = json_encode($arr);
		 echo $json_array;
		}
		else {
			echo "nok";
		}
	}

?>
