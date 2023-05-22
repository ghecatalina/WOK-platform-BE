using Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Message
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(32)")]
        public MessageType Type { get; set; }
        public int TableNo { get; set; }
        [Column(TypeName = "varchar(32)")]
        public PayType? Pay { get; set; }
        public int? Tip { get; set; }
        public DateTime Created { get; set; }
    }
}
