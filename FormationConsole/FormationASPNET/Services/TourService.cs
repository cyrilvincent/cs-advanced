using FormationASPNET.Entities;

namespace FormationASPNET.Services
{
    public interface ITourService
    {
        Shelf AddShelfToMagazine(Shelf shelf, Magazine magazine);
        Magazine? GetMagazineById(long id);
        IQueryable<Magazine> GetMagazines();
        Shelf? GetShelfById(long id);
        IQueryable<Shelf> GetShelfByMagazine(Magazine magazine);
    }

    public class TourService : ITourService
    {
        private FormationDbContext _context;
        public TourService(FormationDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Magazine> GetMagazines()
        {
            return this._context.Magazines;
        }
        public Magazine? GetMagazineById(long id)
        {
            return null;
        }

        public IQueryable<Shelf> GetShelfByMagazine(Magazine magazine)
        {
            return null;
        }

        public Shelf? GetShelfById(long id)
        {
            return null;
        }

        public Shelf AddShelfToMagazine(Shelf shelf, Magazine magazine)
        {
            return shelf;
        }



    }
}
