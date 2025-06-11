using FormationASPNET.DTOs;
using FormationASPNET.Entities;

namespace FormationASPNET.Adapters
{
    public static class TourAdapters
    {
        public static MagazineDTO ToMagazineDTO(this Magazine magazine)
        {
            var dto = new MagazineDTO
            {
                Id = magazine.Id,
                Height = magazine.Height,
                SubStack = magazine.Stack,
                Diameter = magazine.Shelves.FirstOrDefault()?.Diameter ?? 0,
            };
            return dto;
        }
    }
}
