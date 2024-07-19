using PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity;

namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Models
{
    public class VerbaleModel
    {
        public int Id { get; set; }

        public DateTime DataViolazione { get; set; }

        public string IndirizzoViolazione { get; set; }

        public string NominativoAgente { get; set; }

        public DateTime DataTrascrizioneVerbale { get; set; }

        public AnagraficaEntity Anagrafica { get; set; }

        public TipoViolazioneEntity Violazione { get; set; }

        public decimal Importo { get; set; }

        public int DecurtamentoPunti { get; set; }
    }
}
