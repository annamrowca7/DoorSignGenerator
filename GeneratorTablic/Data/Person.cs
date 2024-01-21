namespace GeneratorTablic.Data
{
    public class Person
    {
        public string Name { get; set; }
        public string Position { get; set; }

        // Inne właściwości, jeśli są potrzebne

        public override string ToString()
        {
            return $"{Name} - {Position}";
        }
    }
}