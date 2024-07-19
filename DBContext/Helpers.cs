using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Classes;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Interfaces;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DBContext
{
    public static class Helpers
    {
        public static IServiceCollection AllDao(this IServiceCollection services)
        {
            return services
                .AddScoped<IAnagraficaDAO, AnagraficaDAO>()
                .AddScoped<IVerbaleDAO, VerbaleDAO>()
                .AddScoped<ITipoViolazioneDAO, TipoVolazioneDAO>()
                ;
        }
    }

}
