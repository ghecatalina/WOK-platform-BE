using Domain.Enums;

namespace API.DTOs.Messages
{
    public class MessagePostModel
    {
        public MessageType Type { get; set; }
        public int TableNo { get; set; }
        public int? Tip { get; set; }
        public PayType? Pay { get; set; }
    }
}
