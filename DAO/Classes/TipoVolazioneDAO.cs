using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Interfaces;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Services;
using System.Data.Common;
using System.Data.SqlClient;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Classes
{
    public class TipoVolazioneDAO : SqlServerServiceBase, ITipoViolazioneDAO
    {
        public TipoVolazioneDAO(IConfiguration config) : base(config)
        {
        }
        private const string CREATE_TV = "INSERT INTO TipoViolazione(Descrizione) " +
            "OUTPUT INSERTED.IdViolazione " +
            "VALUES(@Descrizione)";
        private const string READ_TV = "SELECT IdViolazione, Descrizione FROM TipoViolazione WHERE IdViolazione = @id";
        private const string UPDATE_TV = "UPDATE TipoViolazione SET Descrizione = @Descrizione WHERE IdViolazione = @id";
        private const string DELETE_TV = "DELETE FROM TipoViolazione WHERE IdViolazione = @id";
        private const string READ_ALL = "SELECT IdViolazione, Descrizione " +
            "FROM TipoViolazione";


        public TipoViolazioneEntity CreateReader(DbDataReader reader)
        {
            return new TipoViolazioneEntity
            {
                Id = reader.GetInt32(0),
               Descrizione = reader.GetString(1),
            };
        }

        public TipoViolazioneEntity Create(TipoViolazioneEntity tipoViolazione)
        {
            var cmd = GetCommand(CREATE_TV);
            using var conn = GetConnection();
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@Descrizione", tipoViolazione.Descrizione));

            tipoViolazione.Id = (int)cmd.ExecuteScalar();
            return tipoViolazione;
        }


        public IEnumerable<TipoViolazioneEntity> GetAll()
        {
            List<TipoViolazioneEntity> ListaTrasgressori = new List<TipoViolazioneEntity>();
            var cmd = GetCommand(READ_ALL);
            using var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListaTrasgressori.Add(CreateReader(reader));
            }
            return ListaTrasgressori;
        }

        public TipoViolazioneEntity Read(int id)
        {
            var cmd = GetCommand(READ_TV);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            var conn = GetConnection();
            conn.Open();
            var reader = cmd.ExecuteReader();
            TipoViolazioneEntity anagraficaEntity = new TipoViolazioneEntity();
            if (reader.Read())
                anagraficaEntity = CreateReader(reader);
            conn.Close();
            return anagraficaEntity;
        }

       

    }
}
