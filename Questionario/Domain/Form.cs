using System.ComponentModel.DataAnnotations;

namespace Questionario.Domain
{
    public class Form
    {
        [Key]
        public long Id { get; set; }
        public long AdminId { get; set; }
        public Admin? Admin { get; set; }
        public string Perguntas { get; set; } = string.Empty;
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
