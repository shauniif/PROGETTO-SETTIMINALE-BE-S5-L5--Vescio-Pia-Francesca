using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Interfaces
{
    public interface ITipoViolazioneDAO
    {
        TipoViolazioneEntity Create(TipoViolazioneEntity tipoViolazione);
        TipoViolazioneEntity Read(int id);

        IEnumerable<TipoViolazioneEntity> GetAll();
    }
}
