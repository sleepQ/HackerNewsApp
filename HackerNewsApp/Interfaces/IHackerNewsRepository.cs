using HackerNewsApp.Models;

namespace HackerNewsApp.Interfaces
{
    public interface IHackerNewsRepository
    {
        public Task<IEnumerable<HackerNewsItem>> GetHackerNews(string topic = "", string postStatus = "topstories");
    }
}
