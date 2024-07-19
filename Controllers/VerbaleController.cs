using Microsoft.AspNetCore.Mvc;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DBContext;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Models;

namespace provadellaprova.Controllers
{
    public class VerbaleController : Controller

    {
        private readonly ILogger<VerbaleController> _logger;
        private readonly DbContext _dBContext;
        public VerbaleController(ILogger<VerbaleController> logger, DbContext dBContext)
        {
            _logger = logger;
            _dBContext = dBContext;
        }
        public IActionResult ListaVerbali()
        {
            var verbali = _dBContext.Verbale.GetAll();

            var verbaliModel = verbali.Select(t => new VerbaleModel
            {
                Id = t.Id,
                DataViolazione = t.DataViolazione,
                IndirizzoViolazione = t.IndirizzoViolazione,
                NominativoAgente = t.NominativoAgente,
                DataTrascrizioneVerbale = t.DataTrascrizioneVerbale,
                Anagrafica = _dBContext.Anagrafica.Read(t.IdAnagrafica),
                Violazione = _dBContext.TipoViolazione.Read(t.IdViolazione),
                Importo = t.Importo,
                DecurtamentoPunti = t.DecurtamentoPunti
            });
           
            return View(verbaliModel);
        }

        public IActionResult Create()
        {
            ViewBag.Trasgressori = _dBContext.Anagrafica.GetAll();
            ViewBag.TipoViolazioni = _dBContext.TipoViolazione.GetAll();
            return View(new VerbaleEntity());
        }

        [HttpPost]
        public IActionResult Create(VerbaleEntity verbale)
        {
            _dBContext.Verbale.Create(verbale);
            return RedirectToAction("ListaVerbali", "Verbale");
        }

        public IActionResult Read(int id)
        {
            var trasgressore = _dBContext.Verbale.Read(id);
            return View(trasgressore);
        }
    }
}
