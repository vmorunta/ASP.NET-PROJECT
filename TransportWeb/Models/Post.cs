
using System.ComponentModel.DataAnnotations;

namespace TransportWeb.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }

        public DateTime CreatedDateTime {  get; set; }

    }
}
