using Microsoft.AspNetCore.Mvc;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DBContext;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;

namespace provadellaprova.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly ILogger<TipoViolazioneController> _logger;
        private readonly DbContext _dBContext;

        public TipoViolazioneController(ILogger<TipoViolazioneController> logger, DbContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        public IActionResult ListaTipoViolazioni()
        {
            var tragressori = _dBContext.TipoViolazione.GetAll();

            return View(tragressori);
        }

        public IActionResult Create()
        {
            return View(new TipoViolazioneEntity());
        }

        [HttpPost]
        public IActionResult Create(TipoViolazioneEntity anagrafica)
        {
            _dBContext.TipoViolazione.Create(anagrafica);
            return RedirectToAction("ListaTipoViolazioni", "TipoViolazione");
        }

        public IActionResult Read(int id)
        {
            var trasgressore = _dBContext.TipoViolazione.Read(id);
            return View(trasgressore);
        }


    }
}
