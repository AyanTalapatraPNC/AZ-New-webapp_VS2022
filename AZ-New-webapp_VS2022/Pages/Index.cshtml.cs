using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AZ_New_webapp_VS2022.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _config;
        public IndexModel(ILogger<IndexModel> logger,IConfiguration config)
        {
            _logger = logger;
            this._config = config;
        }
        public void OnPostClick()
        {
            // This code runs when the button is clicked
            Console.WriteLine("Button clicked!");
            var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()  // Load from secrets.json
            .Build();

            // Get the connection string
            var connectionString = config.GetConnectionString("ConnectionString");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //Console.WriteLine("Connected to Azure SQL Database!");

                    string query = "SELECT * FROM Employees";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Example: read first two columns
                            Response.ContentType = "text/plain";
                            Response.WriteAsync($"{reader[0]} - {reader[1]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public void OnGet()
        {
            
            ViewData["Greeting"]= _config["Greeting"];
            

            

        }
    }
}
