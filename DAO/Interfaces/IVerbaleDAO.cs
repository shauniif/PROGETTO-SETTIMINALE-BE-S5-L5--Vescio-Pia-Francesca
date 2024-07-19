using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Interfaces
{
    public interface IVerbaleDAO
    {
        VerbaleEntity Create(VerbaleEntity verbale);
        VerbaleEntity Read(int id);


        IEnumerable<VerbaleEntity> GetAll();
    }
}
