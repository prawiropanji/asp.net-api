using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Role
    {
  


        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Role()
        {

        }

    }
}
