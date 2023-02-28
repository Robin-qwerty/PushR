<?php
	header("Access-Control-Allow-Origin: *");
	header('Access-Control-Allow-Methods: POST GET');
	require ("./dbconnect.php");
	date_default_timezone_set('Europe/Amsterdam');


  $id = 1;

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
?>
