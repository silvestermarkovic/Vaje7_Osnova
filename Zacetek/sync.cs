using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Zacetek
{
    class sync
    {    public async void test()
        {
            //string result = Get(queryString).Result;
            string result = await vrniStranAsync("https://moodle.fis.unm.si");

            Console.WriteLine(result);
        }

        public async Task<string> vrniStranAsync(string p_url)
        {
            HttpClient _httpClient = new HttpClient();
            string url = p_url;

            // The actual Get method
            using (var result = await _httpClient.GetAsync($"{url}"))
            {
                string content = await result.Content.ReadAsStringAsync();
                return content;
            }
        }
    }
}
