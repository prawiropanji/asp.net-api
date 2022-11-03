namespace WebApi.Models
{
    public class Division
    {
        public Division(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Division()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
