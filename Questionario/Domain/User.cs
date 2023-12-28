using System.ComponentModel.DataAnnotations;

namespace Questionario.Domain
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty; 
        public string Password { get; set; } = string.Empty;

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}
