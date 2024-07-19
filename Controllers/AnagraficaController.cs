using Microsoft.AspNetCore.Mvc;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DBContext;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly ILogger<AnagraficaController> _logger;
        private readonly DbContext _dBContext;

        public AnagraficaController(ILogger<AnagraficaController> logger, DbContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        public IActionResult ListaTrasgressori()
        {
            var tragressori = _dBContext.Anagrafica.GetAll();
            
            return View(tragressori);
        }

        public IActionResult Create()
        {
            return View(new AnagraficaEntity());
        }

        [HttpPost]
        public IActionResult Create(AnagraficaEntity anagrafica)
        {
            _dBContext.Anagrafica.Create(anagrafica);
            return RedirectToAction("ListaTrasgressori", "Anagrafica");
        }

        public IActionResult Read(int id)
        {
            var trasgressore = _dBContext.Anagrafica.Read(id);
            return View(trasgressore);
        }

    }
}
