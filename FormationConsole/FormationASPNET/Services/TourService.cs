using FormationASPNET.Adapters;
using FormationASPNET.DTOs;
using FormationASPNET.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormationASPNET.Services
{
    public interface ITourService
    {
        Shelf AddShelfToMagazine(Shelf shelf, Magazine magazine);
        MagazineDTO? GetMagazineById(long id);
        IQueryable<MagazineDTO> GetMagazines();
        Shelf? GetShelfById(long id);
        IEnumerable<Shelf> GetShelfByMagazine(Magazine magazine);
    }

    public class TourService : ITourService
    {
        private FormationDbContext _context;
        public TourService(FormationDbContext context)
        {
            this._context = context;
        }

        public IQueryable<MagazineDTO> GetMagazines()
        {
            return this._context.Magazines.Select(m => m.ToMagazineDTO());
        }
        public MagazineDTO? GetMagazineById(long id)
        {
            return this._context.Magazines.Include(m => m.Shelves).Where(m => m.Id == id).FirstOrDefault()?.ToMagazineDTO();
        }

        public IEnumerable<Shelf> GetShelfByMagazine(Magazine magazine)
        {
            return magazine.Shelves;
        }

        public Shelf? GetShelfById(long id)
        {
            return this._context.Shelves.FirstOrDefault(s => s.Id == id);
        }

        public Shelf AddShelfToMagazine(Shelf shelf, Magazine magazine)
        {

            magazine.Shelves.Add(shelf);
            this._context.SaveChanges();
            return shelf;
        }



    }
}
