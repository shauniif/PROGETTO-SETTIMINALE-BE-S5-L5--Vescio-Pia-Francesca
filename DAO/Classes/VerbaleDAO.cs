using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Interfaces;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Services;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Classes
{
    public class VerbaleDAO : SqlServerServiceBase, IVerbaleDAO
    {
        private const string CREATE_VB = "INSERT INTO Verbale (DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, IdAnagrafica, IdViolazione, Importo, DecurtamentoPunti) " +
           "OUTPUT INSERTED.IdVerbale " +
           "VALUES(@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @DataTrascrizioneVerbale, @IdAnagrafica, @IdViolazione, @Importo, @DecurtamentoPunti)";
        private const string READ_VB = "SELECT IdVerbale, DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, IdAnagrafica, IdViolazione, Importo, DecurtamentoPunti FROM Verbale WHERE IdVerbale = @id";
        private const string UPDATE_VB = "UPDATE Verbale SET DataViolazione = @DataViolazione, IndirizzoViolazione = @IndirizzoViolazione, NominativoAgente = @NominativoAgente, DataTrascrizioneVerbale = @DataTrascrizioneVerbale, IdAnagrafica = @IdAnagrafica, IdViolazione = @IdViolazione, Importo = @Importo,  DecurtamentoPunti = @DecurtamentoPunti  WHERE IdVerbale = @id";
        private const string DELETE_VB = "DELETE FROM Verbale WHERE IdVerbale = @id";
        private const string READ_ALL = "SELECT IdVerbale, DataViolazione, IndirizzoViolazione, NominativoAgente, DataTrascrizioneVerbale, IdAnagrafica, IdViolazione, Importo, DecurtamentoPunti FROM Verbale";
        public VerbaleDAO(IConfiguration config) : base(config)
        {
        }

        public VerbaleEntity CreateReader(DbDataReader reader)
        {
            return new VerbaleEntity
            {
                Id = reader.GetInt32(0),
                DataViolazione = reader.GetDateTime(1),
                IndirizzoViolazione = reader.GetString(2),
                NominativoAgente = reader.GetString(3),
                DataTrascrizioneVerbale = reader.GetDateTime(4),
                IdAnagrafica = reader.GetInt32(5),
                IdViolazione = reader.GetInt32(6),
                Importo = reader.GetDecimal(7),
                DecurtamentoPunti = reader.GetInt32(8),

            };
        }
        public VerbaleEntity Create(VerbaleEntity verbale)
        {
            var cmd = GetCommand(CREATE_VB);
            using var conn = GetConnection();
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@DataViolazione", verbale.DataViolazione));
            cmd.Parameters.Add(new SqlParameter("@IndirizzoViolazione", verbale.IndirizzoViolazione));
            cmd.Parameters.Add(new SqlParameter("@NominativoAgente", verbale.NominativoAgente));
            cmd.Parameters.Add(new SqlParameter("@DataTrascrizioneVerbale", verbale.DataTrascrizioneVerbale));
            cmd.Parameters.Add(new SqlParameter("@IdAnagrafica", verbale.IdAnagrafica));
            cmd.Parameters.Add(new SqlParameter("@IdViolazione", verbale.IdViolazione));
            cmd.Parameters.Add(new SqlParameter("@Importo", verbale.Importo));
            cmd.Parameters.Add(new SqlParameter("@DecurtamentoPunti", verbale.DecurtamentoPunti));
            verbale.Id = (int)cmd.ExecuteScalar();
            return verbale;
        }



        public IEnumerable<VerbaleEntity> GetAll()
        {
            List<VerbaleEntity> ListaVerbali = new List<VerbaleEntity>();
            var cmd = GetCommand(READ_ALL);
            using var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ListaVerbali.Add(CreateReader(reader));
            }
            return ListaVerbali;
        }

        public VerbaleEntity Read(int id)
        {
            var cmd = GetCommand(READ_VB);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            var conn = GetConnection();
            conn.Open();
            var reader = cmd.ExecuteReader();
            VerbaleEntity verbale = new VerbaleEntity();
            if (reader.Read())
                verbale = CreateReader(reader);
            conn.Close();
            return verbale;
        }


    }

}
