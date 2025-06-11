namespace FormationASPNET.DTOs
{
    public class MagazineDTO : IDTO
    {
        public long Id { get; set; }
        public int Height { get; set; }
        public int? SubStack { get; set; }

        public double Diameter { get; set; }

    }
}
