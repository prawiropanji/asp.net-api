﻿namespace WebApi.Models
{
    public class Division
    {


        public int Id { get; set; }
        public string Name { get; set; }


        public Division(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Division()
        {

        }
    }
}
