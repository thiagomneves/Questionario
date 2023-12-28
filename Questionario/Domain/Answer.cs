using System.ComponentModel.DataAnnotations;

namespace Questionario.Domain
{
    public class Answer
    {
        [Key]
        public long Id { get; set; }
        public long UserId { get; set; }
        public User? User { get; set; }
        public long FormId { get; set; }
        public Form? Form { get; set; }
        public string Answers { get; set; }
    }
}
