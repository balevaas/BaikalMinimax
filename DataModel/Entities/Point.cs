namespace DataModel.Entities
{
    public class Point
    {
        public int Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public City City { get; set; } = null!;
    }
}
