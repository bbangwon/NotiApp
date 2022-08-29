
using Microsoft.Data;

namespace NotiApp.Models
{
    public class MyNotification
    {
        public int Id { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string? Message { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }
        public int UserId { get; set; }
        public bool IsComplete { get; set; }
    }
}