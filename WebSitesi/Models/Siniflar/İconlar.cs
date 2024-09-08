using System.ComponentModel.DataAnnotations;

namespace WebSitesi.Models.Siniflar
{
    public class İconlar
    {
        [Key]
        public int id { get; set; }
        public string ikon { get; set; }
        public string link { get; set; }
    }
}