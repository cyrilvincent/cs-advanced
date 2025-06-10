namespace FormationASPNET.Entities
{
    public class Shelf : IEntity
    {
        public long Id { get; set; }
        public double Diameter { get; set; }
        public double Height { get; set; }
        public Magazine? Magazine { get; set; }
        public long MagazineId { get; set; }
    }
}
