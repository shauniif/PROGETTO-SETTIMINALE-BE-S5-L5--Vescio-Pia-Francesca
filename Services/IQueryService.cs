using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Models;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Services
{
    public interface IQueryService
    {
        Dictionary<string, int> TotaliVerbaliPerTrasgressore();

        Dictionary<string, int> PuntiDecurtatiPerTrasgressore();

        IEnumerable<AnagraficaQueryModel> ViolazioniConDecurtamentoMaggioriDi10();

        IEnumerable<AnagraficaQueryModel> ViolazioniMaggioridi400Euro();

    }
}
