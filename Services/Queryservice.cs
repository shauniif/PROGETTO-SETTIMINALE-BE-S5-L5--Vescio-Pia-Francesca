

using Humanizer;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;
using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Models;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Services
{
    public class Queryservice : SqlServerServiceBase, IQueryService

    {
        /// <summary>
        /// 1: Visualizzare il totale dei verbali trascritti raggruppati per trasgressore
        /// </summary>
        private const string ALL_VERB_FOR_TRASG =  "SELECT CONCAT(a.Nome, ' ', a.Cognome) AS Trasgressore, COUNT(*) AS NumeroVerbali " +
            "FROM Verbale AS v " +
            "JOIN Anagrafica AS a ON v.IdAnagrafica = a.IdAnagrafica " +
            "GROUP BY CONCAT(a.Nome, ' ', a.Cognome) " +
            "ORDER BY CONCAT(a.Nome, ' ', a.Cognome) ASC";

        /// <summary>
        /// 2: Visualizzare il totale dei punti decurtati raggruppati per trasgressore
        /// </summary>
        private const string ALL_PUNTI_DEC_FOR_TRASGR = "SELECT CONCAT(a.Nome, ' ', a.Cognome) AS Trasgressore , SUM(v.DecurtamentoPunti) AS DecurtamentoPunti " +
            "FROM VERBALE AS v " +
            "JOIN Anagrafica AS a ON v.IdAnagrafica = a.IdAnagrafica " +
            "GROUP BY CONCAT(a.Nome, ' ', a.Cognome)";

        /// <summary>
        /// 3: Visualizzare importo, cognome, nome, data di violazione e decurtamento punti delle violazioni che superano i 10 punti
        /// </summary>
        private const string ALL_VIOLAZIONI_MAGG_5 = "SELECT  CONCAT(a.Nome, ' ', a.Cognome) AS Trasgressore, " +
            "a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti " +
            "FROM Verbale AS v JOIN Anagrafica AS a ON v.IdAnagrafica = a.IdAnagrafica WHERE v.DecurtamentoPunti > 10";
        /// <summary>
        /// 4: Le violazioni il cui importo è maggiore di 400 euro.
        /// </summary>
        private const string VIOLAZIONI_MAGG_400 = "SELECT  CONCAT(a.Nome, ' ', a.Cognome) AS Trasgressore, a.Indirizzo, v.DataViolazione, v.Importo, v.DecurtamentoPunti " +
            "FROM Verbale AS v " +
            "JOIN Anagrafica AS a ON v.IdAnagrafica = a.IdAnagrafica " +
            "WHERE v.Importo > 400 ";
        public Queryservice(IConfiguration config) : base(config)
        {
        }

        /// <summary>
        /// 1: visualizzare il totale dei verbali trascritti raggruppati per trasgressore,
        /// </summary>
        /// <returns>Una collezione di coppia chiave-valore, per ogni trasgressore il totale di verbali intestato a quest'ultimo.</returns>
        public Dictionary<string, int> TotaliVerbaliPerTrasgressore()
        {
            var TotaliVerbaliPerTrasgr = new Dictionary<string, int>();
            var cmd = GetCommand(ALL_VERB_FOR_TRASG);
            var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read()) 
            {
                string trasgressore = reader.GetString(0);
                int NumeroVerbali = reader.GetInt32(1);
                TotaliVerbaliPerTrasgr[trasgressore] = NumeroVerbali;
            }
            conn.Close();
            return TotaliVerbaliPerTrasgr;
        }
        /// <summary>
        /// 2: Visualizzare il totale dei punti decurtati raggruppati per trasgressore
        /// </summary>
        /// <returns>Una collezione di coppia chiave-valore, per ogni trasgressore, tutti i punti decurtati dai vari verbali</returns>
        public Dictionary<string, int> PuntiDecurtatiPerTrasgressore()
        {
            var PuntiDecurtatiPerTrasgr = new Dictionary<string, int>();
            var cmd = GetCommand(ALL_PUNTI_DEC_FOR_TRASGR);
            var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string trasgressore = reader.GetString(0);
                int PuntiDecurtati = reader.GetInt32(1);
                PuntiDecurtatiPerTrasgr[trasgressore] = PuntiDecurtati;
            }
            conn.Close();
            return PuntiDecurtatiPerTrasgr;
        }

        /// <summary>
        /// 3: Visualizzare importo, cognome, nome, data di violazione e decurtamento punti delle violazioni che superano i 10 punti,
        /// </summary>
        /// <returns> Collezione di oggetti che rappresentano i dati dei trasgressori le cui violazioni superano il decuramento di 10 punti.</returns>
        public IEnumerable<AnagraficaQueryModel> ViolazioniConDecurtamentoMaggioriDi10()
        {
           var ViolazioniConDecurtamentoMaggDi5 = new List<AnagraficaQueryModel>();
            var cmd = GetCommand(ALL_VIOLAZIONI_MAGG_5);
            var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                ViolazioniConDecurtamentoMaggDi5.Add(new AnagraficaQueryModel
                {
                    Trasgressore = reader.GetString(0),
                    Indirizzo = reader.GetString(1),
                    DataViolazione = reader.GetDateTime(2),
                    Importo = reader.GetDecimal(3),
                    DecurtamentoPunti = reader.GetInt32(4)
                });
            }
            conn.Close();
            return ViolazioniConDecurtamentoMaggDi5;


        }

        /// <summary>
        /// 4: Le violazioni il cui importo è maggiore di 400 euro.
        /// </summary>
        /// <returns> Collezione di oggetti che rappresentano le violazioni che superano 400€</returns>

        public IEnumerable<AnagraficaQueryModel> ViolazioniMaggioridi400Euro()
        {
           var ViolazioniMaggioriDi400 = new List<AnagraficaQueryModel>();
            var cmd = GetCommand(VIOLAZIONI_MAGG_400);
            var conn = GetConnection();
            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ViolazioniMaggioriDi400.Add(new AnagraficaQueryModel
                {
                    Trasgressore = reader.GetString(0),
                    Indirizzo = reader.GetString(1),
                    DataViolazione = reader.GetDateTime(2),
                    Importo = reader.GetDecimal(3),
                    DecurtamentoPunti = reader.GetInt32(4)
                });
            }
                return ViolazioniMaggioriDi400;
        }
    }
}
