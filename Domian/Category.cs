using System.ComponentModel.DataAnnotations;

namespace Domian
{
    public class Category
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<Post> Postes { get; set; }
    }

}
