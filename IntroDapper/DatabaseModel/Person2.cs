using System;

namespace IntroDapper.DatabaseModel
{
    class Person2
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PlaceId { get; set; }

        public override string ToString()
        {
            return $"{Name} (Id={Id}) Sted: {PlaceId}";
        }

        public Person2()
        {
            Id = Guid.NewGuid();
        }
    }
}
