using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MTZapocet.DataManagers
{
    public class RestManager
    {
        HttpClient client;
        string url;


        public RestManager()
        {

            url = "https://gorest.co.in/public/v2/";
            client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "2b35e5dc854f2a8f8701719747fc6a46503265b1cd74f03e697ab67db23f803b");
        }

        public async Task<string> Get(string addParams)
        {
            HttpResponseMessage response = await client.GetAsync(url + addParams.ToLower());
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
                return string.Empty;
        }
        














    }


}
