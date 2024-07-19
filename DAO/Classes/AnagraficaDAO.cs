using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Interfaces;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Services;
using System.Data.Common;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.DAO.Classes
{
    public class AnagraficaDAO : SqlServerServiceBase, IAnagraficaDAO
    {
        private const string CREATE_AN = "INSERT INTO Anagrafica(Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale) " +
            "OUTPUT INSERTED.IdAnagrafica " +
            "VALUES(@Cognome, @Nome, @Indirizzo, @Citta, @CAP, @CodiceFiscale)";
        private const string READ_AN = "SELECT IdAnagrafica, Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale FROM Anagrafica WHERE IdAnagrafica = @id";
        private const string UPDATE_AN = "UPDATE Anagrafica SET Cognome = @Cognome, Nome = @Nome, Indirizzo = @Indirizzo, Citta = @Citta, CAP = @CAP, CodiceFiscale = @CF WHERE IdAnagrafica = @id";
        private const string DELETE_AN = "DELETE FROM Anagrafica WHERE IdAnagrafica = @id";
        private const string READ_ALL = "SELECT IdAnagrafica, Cognome, Nome, Indirizzo, Citta, CAP, CodiceFiscale " +
            "FROM Anagrafica";



        public AnagraficaDAO(IConfiguration config) : base(config)
        {
        }



        public AnagraficaEntity CreateReader(DbDataReader reader)
        {
            return new AnagraficaEntity
            {
                Id = reader.GetInt32(0),
                Cognome = reader.GetString(1),
                Nome = reader.GetString(2),
                Indirizzo = reader.GetString(3),
                Citta = reader.GetString(4),
                CAP = reader.GetString(5),
                CodiceFiscale = reader.GetString(6),
            };
        }

        public AnagraficaEntity Create(AnagraficaEntity trasgressore)
        {
            var cmd = GetCommand(CREATE_AN);
            using var conn = GetConnection();
            conn.Open();
            cmd.Parameters.Add(new SqlParameter("@Cognome", trasgressore.Cognome));
            cmd.Parameters.Add(new SqlParameter("@Nome", trasgressore.Nome));
            cmd.Parameters.Add(new SqlParameter("@Indirizzo", trasgressore.Indirizzo));
            cmd.Parameters.Add(new SqlParameter("@Citta", trasgressore.Citta));
            cmd.Parameters.Add(new SqlParameter("@CAP", trasgressore.CAP));
            cmd.Parameters.Add(new SqlParameter("@CodiceFiscale", trasgressore.CodiceFiscale));
            trasgressore.Id = (int)cmd.ExecuteScalar();
            return trasgressore;
        }

        public IEnumerable<AnagraficaEntity> GetAll()
        {
            List<AnagraficaEntity> ListaTrasgressori = new List<AnagraficaEntity>();
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

        public AnagraficaEntity Read(int id)
        {
            var cmd = GetCommand(READ_AN);
            cmd.Parameters.Add(new SqlParameter("@id", id));
            var conn = GetConnection();
            conn.Open();
            var reader = cmd.ExecuteReader();
            AnagraficaEntity anagraficaEntity = new AnagraficaEntity();
            if (reader.Read())
                anagraficaEntity = CreateReader(reader);
            conn.Close();
            return anagraficaEntity;
        }
    }
}
