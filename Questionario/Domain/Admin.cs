using System.ComponentModel.DataAnnotations;

namespace Questionario.Domain
{
    public class Admin
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<Form> Forms{ get; set; } = new List<Form>();
    }
}
