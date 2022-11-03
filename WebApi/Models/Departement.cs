using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Departement
    {
        public Departement()
        {

        }

        public Departement(int id, string name, int divisionId)
        {
            Id = id;
            Name = name;
            DivisionId = divisionId;
          
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Division")]
        public int DivisionId { get; set; }
        [JsonIgnore] // membuat property Division tidak di serialize menjadi JSON object
        public Division? Division { get; set; } 
   
    }
}
