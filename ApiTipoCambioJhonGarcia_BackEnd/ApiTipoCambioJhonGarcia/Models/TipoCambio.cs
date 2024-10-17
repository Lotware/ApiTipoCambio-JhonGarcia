namespace ApiTipoCambioJhonGarcia.Models
{
    public class TipoCambio
    {

        public int Id { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public decimal ValorCambio { get; set; }

    }
}
