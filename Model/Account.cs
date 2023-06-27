using System.ComponentModel.DataAnnotations;

namespace Wrap.Model
{
    public class Account
    {
        public int id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
    }
}
