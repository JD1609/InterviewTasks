namespace WebCalculator.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ExpressionResult> ExpressionResults { get; set; }
    }
}
