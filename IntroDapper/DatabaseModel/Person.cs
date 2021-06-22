namespace IntroDapper.DatabaseModel
{
    class Person 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlaceId { get; set; }

        public override string ToString()
        {
            return $"{Name} (Id={Id}) Sted: {PlaceId}";
        }
    }
}
