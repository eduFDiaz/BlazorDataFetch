using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Nancy.Json;

namespace WebApplication1.Data
{
    public class PostService
    {
        public Task<Post[]> GetPostsAsync() => Task.Run(async () =>
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"https://jsonplaceholder.typicode.com");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string json = await client.GetStringAsync("/posts");
                JavaScriptSerializer ser = new JavaScriptSerializer();
                var posts = ser.Deserialize<Post[]>(json);
                return posts;
            }
        });
    }
}