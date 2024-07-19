using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;
using System.Runtime.InteropServices;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Interfaces
{
    public interface IAnagraficaDAO
    {
        AnagraficaEntity Create(AnagraficaEntity trasgressore);
        AnagraficaEntity Read(int id);

        IEnumerable<AnagraficaEntity> GetAll();


    }
}
