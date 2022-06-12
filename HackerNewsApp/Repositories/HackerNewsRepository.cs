using HackerNewsApp.Interfaces;
using HackerNewsApp.Models;
using System.Text.Json;

namespace HackerNewsApp.Repositories
{
    public class HackerNewsRepository : IHackerNewsRepository
    {
        static HttpClient client = new HttpClient();
        private readonly string url = "https://hacker-news.firebaseio.com/v0";

        public async Task<IEnumerable<HackerNewsItem>> GetHackerNews(string topic = "", string postStatus = "topstories")
        {
            var data = new List<HackerNewsItem>();

            // v0/topstories.json - v0/newstories.json - v0/beststories.json
            // ?orderBy="$key"&limitToFirst=30
            var itemIdsPath = $"{url}/{postStatus}.json?orderBy=\"$key\"&limitToFirst=30";

            HttpResponseMessage response = await client.GetAsync(itemIdsPath);
            if (response.IsSuccessStatusCode)
            {
                var itemIds = await response.Content.ReadFromJsonAsync<IEnumerable<int>?>();
                if (itemIds != null)
                {
                    foreach (var itemId in itemIds)
                    {
                        var itemPath = $"{url}/item/{itemId}.json";

                        HttpResponseMessage itemResponse = await client.GetAsync(itemPath);
                        if (itemResponse.IsSuccessStatusCode)
                        {
                            var item = await itemResponse.Content.ReadFromJsonAsync<HackerNewsItem?>(new JsonSerializerOptions
                            {
                                PropertyNameCaseInsensitive = true
                            });

                            if (item != null)
                            {
                                data.Add(item);
                            }
                        }
                    }
                }
            } 

            return data;
        }
    }
}
