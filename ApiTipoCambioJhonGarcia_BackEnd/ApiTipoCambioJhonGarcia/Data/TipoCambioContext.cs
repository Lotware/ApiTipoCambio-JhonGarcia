using Microsoft.EntityFrameworkCore;
using ApiTipoCambioJhonGarcia.Models;

namespace ApiTipoCambioJhonGarcia.Data
{
    public class TipoCambioContext : DbContext
    {
        public TipoCambioContext(DbContextOptions<TipoCambioContext> options) : base(options)
        {
        }

        public DbSet<TipoCambio> TiposDeCambio { get; set; }




    }


}
