using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PushR.Util
{
    public class HandleApiCall
    {
        static HttpClient client;

        public HandleApiCall()
        {
            client = new HttpClient();
        }
        public async Task<string> DoCall(string function, string txtJSON)
        {
            var responseString = string.Empty;
            var values = new Dictionary<string, string> { { function, txtJSON } };

            try
            {
                var content = new FormUrlEncodedContent(values);

                var post = await client.PostAsync("http://192.168.1.100/pushr/pushr.php", content);

                responseString = await post.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return responseString;
        }
    }
}
