using AZ_New_webapp_VS2022.Models;
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
        public string? ErrorMessage { get; set; }
        public IndexModel(ILogger<IndexModel> logger,IConfiguration config)
        {
            _logger = logger;
            this._config = config;
        }

        public List<Employee> EmployeeList { get; set; } = new();

        public void OnPostClick()
        {


            // Get the connection string
            var connectionString = this._config["connectionString"];
       
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    //Console.WriteLine("Connected to Azure SQL Database!");

                    string query = "SELECT * FROM Employees";
                    string output = "";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Example: read first two columns
                            var emp = new Employee();
                            emp.Id = (int)reader[0];
                            emp.FirstName = (string)reader[1];
                            emp.LastName = (string)reader[2];
                            emp.BirthDate = (DateTime)reader[3];
                            emp.HireDate = (DateTime)reader[4];
                            emp.Salary = (decimal)reader[5];
                            EmployeeList.Add(emp);
                        }
                        
                    }
                }
                catch (Exception ex)
                {
                    ErrorMessage = ex.Message;
                }
            }
        }
        public void OnGet()
        {
            
            ViewData["Greeting"]= _config["Greeting"];
            

            

        }
    }
}
