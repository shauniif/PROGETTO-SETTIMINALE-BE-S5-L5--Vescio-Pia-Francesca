using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Interfaces;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DBContext
{
    public class DbContext
    {
        public IAnagraficaDAO Anagrafica { get; set; }

        public IVerbaleDAO Verbale { get; set; }

        public ITipoViolazioneDAO TipoViolazione { get; set; }
        public DbContext(IAnagraficaDAO anagraficaDAO, IVerbaleDAO verbaleDAO, ITipoViolazioneDAO tipoViolazioneDAO) {
        
            Anagrafica = anagraficaDAO;
            Verbale = verbaleDAO;
            TipoViolazione = tipoViolazioneDAO;
        }
    }
}
