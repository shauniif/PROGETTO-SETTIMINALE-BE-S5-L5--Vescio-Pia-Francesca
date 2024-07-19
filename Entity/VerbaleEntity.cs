namespace PROGETTO_SETTIMINALE_BE_S5_L5__Vescio_Pia_Francesca.Entity
{
    public class VerbaleEntity
    {
        public int Id { get; set; }

        public DateTime DataViolazione { get; set; }

        public string IndirizzoViolazione { get; set; }

        public string NominativoAgente { get; set; }

        public DateTime DataTrascrizioneVerbale { get; set; }

        public int IdAnagrafica { get; set; }

        public int IdViolazione { get; set; }

        public decimal Importo { get; set; }

        public int DecurtamentoPunti { get; set; }


    }
}
