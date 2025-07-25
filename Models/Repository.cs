namespace WebMVC.Models
{
    public abstract class Repository
    {

        protected string connectionString;
        protected Repository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("WebDb")
                                ?? throw new Exception("Not found WebDb");
        }
    }
}
