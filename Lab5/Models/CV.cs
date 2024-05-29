using Microsoft.EntityFrameworkCore;

namespace Lab5.Models
{
    public class CV
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime BDay { get; set; }
        public string Nationality { get; set; }
        public string Sex { get; set; }
        public List<string> Skills { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string url { get; set; }
    }
}
