
using Microsoft.Data.SqlClient;
using PortfolioBuilder.Shared;
using System.Net;


namespace PortfolioBuilder.Server.DataBase
{

    public class DataInDb
    {
        SqlConnection connectionString;

        public DataInDb()
        {
            var configuation = GetConfiguration();
            connectionString = new SqlConnection(configuation.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }
        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
        public async Task<CvDto> GetDataAsync(int id)
        {
            connectionString.Open();
            CvDto cvDto = new CvDto();
          
            string query = "SELECT LastName, FirstName, Address, ContactNo, Degree, Email, Institute, JobTitle, Company, FromDate, ToDate, Skills, Description " +
                           "FROM Cvdata WHERE Id = @CvId"; 

            using (SqlCommand command = new SqlCommand(query, connectionString))
            {
               
                command.Parameters.AddWithValue("@CvId", id);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                      
                        cvDto.LastName = reader["LastName"].ToString();
                        cvDto.FirstName = reader["FirstName"].ToString();
                        cvDto.Address = reader["Address"].ToString();
                        cvDto.ContactNo = reader["ContactNo"].ToString();
                        cvDto.Degree = reader["Degree"].ToString();
                        cvDto.Email = reader["Email"].ToString();
                        cvDto.Institute = reader["Institute"].ToString();
                        cvDto.JobTitle = reader["JobTitle"].ToString();
                        cvDto.Company = reader["Company"].ToString();
                        cvDto.FromDate = reader["FromDate"].ToString();
                        cvDto.ToDate = reader["ToDate"].ToString();
                        cvDto.Skills = reader["Skills"].ToString();
                        cvDto.Description = reader["Description"].ToString();
                    }
                }
            }
         


        return cvDto;
    }


        public async Task<bool> SaveDataAsync(CvDto cvDto)
        {
            
                connectionString.Open();

            string query = " INSERT INTO CvData (Email,LastName, FirstName, Address, ContactNo, Degree, Institute, JobTitle, Company, FromDate, ToDate, Skills, Description) VALUES (@Email,@LastName, @FirstName, @Address, @ContactNo, @Degree, @Institute, @JobTitle, @Company, @FromDate, @ToDate, @Skills, @Description);";
       
                using (SqlCommand cmd = new SqlCommand(query, connectionString))
                {
               
                cmd.Parameters.AddWithValue("@LastName", cvDto.LastName);
                cmd.Parameters.AddWithValue("@FirstName", cvDto.FirstName);
                cmd.Parameters.AddWithValue("@Address", cvDto.Address);
                cmd.Parameters.AddWithValue("@ContactNo", cvDto.ContactNo);
                cmd.Parameters.AddWithValue("@Degree", cvDto.Degree);
                cmd.Parameters.AddWithValue("@Institute", cvDto.Institute);
                cmd.Parameters.AddWithValue("@JobTitle", cvDto.JobTitle);
                cmd.Parameters.AddWithValue("@Company", cvDto.Company);
                cmd.Parameters.AddWithValue("@FromDate", cvDto.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", cvDto.ToDate);
                cmd.Parameters.AddWithValue("@Skills", cvDto.Skills);
                cmd.Parameters.AddWithValue("@Description", cvDto.Description);
                cmd.Parameters.AddWithValue("@Email", cvDto.Email);
                int rowsAffected = await cmd.ExecuteNonQueryAsync();
                    return rowsAffected > 0 ? true : false ;
                }
            
        }
    }

}
