using System.ComponentModel.DataAnnotations;

namespace APILayer.DataAccess
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
