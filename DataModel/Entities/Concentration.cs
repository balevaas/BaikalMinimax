namespace DataModel.Entities
{
    public class Concentration
    {
        public int Id { get; set; }
        public int Month { get; set; }
        public double Pollution { get; set; }
        public Point Point { get; set; } = null!;
    }
}
