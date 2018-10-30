using System;

namespace WebApplication1.Models
{
    public class EntityOne
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public EntityOne()
        {
            ID=new Random().Next();
            Name = $"Entity One with ID {ID}.";
        }
    }
}