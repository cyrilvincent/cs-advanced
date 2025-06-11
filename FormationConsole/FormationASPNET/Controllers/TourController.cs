using FormationASPNET.DTOs;
using FormationASPNET.Services;
using Microsoft.AspNetCore.Mvc;

namespace FormationASPNET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TourController : ControllerBase
    {
        private ITourService _tourService;
        public TourController(ITourService tourService) {
            _tourService = tourService;
        }

        [HttpGet("mock/{id}")]
        public MagazineDTO GetMock(long id)
        {
            return new MagazineDTO { Id = id, Diameter = 0, Height = 0 };
        }

        [HttpGet("magazine/{id}")]
        public MagazineDTO? GetMagazineById(long id)
        {
            return _tourService.GetMagazineById(id);
        }

        [HttpGet("magazine/all")]
        public List<MagazineDTO> GetMagazines()
        {
            return _tourService.GetMagazines().ToList();
        }

    }
}
