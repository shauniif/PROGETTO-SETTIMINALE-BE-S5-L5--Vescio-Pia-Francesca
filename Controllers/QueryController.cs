using Microsoft.AspNetCore.Mvc;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DBContext;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Models;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Services;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Controllers
{
    public class QueryController : Controller
    {
        private readonly ILogger<QueryController> _logger;
        private readonly IQueryService _queryService;
        private readonly DbContext _dBContext;


        public QueryController(ILogger<QueryController> logger, IQueryService queryService, DbContext dBContext)
        {
            _logger = logger;
            _queryService = queryService;
            _dBContext = dBContext;
        }
        public IActionResult TotaliVerbaliPerTrasgressore()
        {
           var TotalePerTrasgr = _queryService.TotaliVerbaliPerTrasgressore();
            return View(TotalePerTrasgr);
        }
        public IActionResult PuntiDecurtatiPerTrasgressore()
        {
            var puntiDecurtatiPerTrasgr = _queryService.PuntiDecurtatiPerTrasgressore();
            return View(puntiDecurtatiPerTrasgr);
        }
        public IActionResult ViolazioniConDecurtamentoMaggioriDi10()
        {
            var ViolazioniMagg5 = _queryService.ViolazioniConDecurtamentoMaggioriDi10();

            return View(ViolazioniMagg5);
        }
        public IActionResult ViolazioniMaggioridi400Euro()
        {
            var violazioniMagg400 = _queryService.ViolazioniMaggioridi400Euro();
            return View(violazioniMagg400);
        }
    }
}
