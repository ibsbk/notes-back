namespace WebApplication7.Models
{
    public class Note
    {
        public int id { get; set; }
        public string note { get; set; }
        public DateTime notification_time { get; set; }
        public int user_id { get; set; }
    }
}
