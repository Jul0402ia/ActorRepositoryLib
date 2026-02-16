namespace ActorRepositoryLib
{
    public class Actor
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int BirthYear { get; set; }

        public override string ToString()
        {
           return $"ID: {ID}, Name: {Name}, Birth Year: {BirthYear}";
        }
    }
}
