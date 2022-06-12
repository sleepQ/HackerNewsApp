namespace HackerNewsApp.Models
{
    public class HackerNewsItem
    {
        //id - The item's unique id.
        public int Id { get; set; }
        //deleted - true if the item is deleted.
        public bool? Deleted { get; set; }
        //type - The type of item. One of "job", "story", "comment", "poll", or "pollopt".
        public string? Type { get; set; }
        //by - The username of the item's author.
        public string? By { get; set; }
        //time - Creation date of the item, in Unix Time.
        public int? Time { get; set; }
        //text - The comment, story or poll text. HTML.
        public string? Text { get; set; }
        //dead - true if the item is dead.
        public bool? Dead { get; set; }
        //parent - The comment's parent: either another comment or the relevant story.
        public int? Parent { get; set; }
        //poll - The pollopt's associated poll.
        public int? Poll { get; set; }
        //kids - The ids of the item's comments, in ranked display order.
        public IEnumerable<int>? Kids { get; set; }
        //url - The URL of the story.
        public Uri? Url { get; set; }
        //score - The story's score, or the votes for a pollopt.
        public int? Score { get; set; }
        //title - The title of the story, poll or job.HTML.
        public string? Title { get; set; }
        //parts - A list of related pollopts, in display order.
        public IEnumerable<int>? Parts { get; set; }
        //descendants - In the case of stories or polls, the total comment count.
        public int? Descendants { get; set; }
    }
}
