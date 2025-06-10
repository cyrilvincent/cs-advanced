namespace FormationASPNET.Entities
{
    public class Magazine : IEntity
    {
        public long Id { get; set; }

        public int Height { get; set; }
        public int? Stack { get; set; }

        public ICollection<Shelf> Shelves { get; set; } = [];

    }
}
