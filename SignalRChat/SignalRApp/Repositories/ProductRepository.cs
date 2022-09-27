
namespace SignalRApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        #region Constructor
        private readonly IHubContext<SignalServer> _context;
        private readonly IConfiguration _configuration;

        public ProductRepository(IHubContext<SignalServer> context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        } 
        #endregion

        public List<Product> GetAll()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
           List<Product> products = new List<Product>();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                if (connection.State==ConnectionState.Closed) connection.Open();
                SqlDependency.Start(connectionString);

                SqlCommand cmd = new SqlCommand("select [Id],[ProductName],[Description],[UnitsInStock],[Price] from products", connection);

                SqlDependency dependency = new SqlDependency(cmd);                
                dependency.OnChange += Dependency_OnChange;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        Id=reader.GetInt32("id"),
                        ProductName=reader.GetString("productName"),
                        Description=reader.GetString("description"),
                        Price=reader.GetDecimal("price"),
                        UnitsInStock=reader.GetInt16("unitsInStock")
                    });
                }
            }

            return products;
        }

        private void Dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            _context.Clients.All.SendAsync("refreshEmployees");
        }
    }
}
