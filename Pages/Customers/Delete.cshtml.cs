using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace crmapp.Pages.Customers
{
    public class Delete : PageModel
    {


        public void OnGet()
        {
        }

        public void OnPost(int id) {
            deleteCustomer(id);
            Response.Redirect("/Customers/Index");
        }

        private void deleteCustomer(int id) {
            try {
                string connectionString = "Server=crmdbserver1.database.windows.net;Database=crmdb;User Id=crmadmin;Password=Password1!";

                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();

                    //delete the customer from the database.

                    string sql = "DELETE FROM customers WHERE id=@id";
                    using (SqlCommand command = new SqlCommand(sql, connection)) {

                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }

            catch(Exception ex) {
                Console.WriteLine("Cannot delete customer: " + ex.Message);
            }
        }
    }
}