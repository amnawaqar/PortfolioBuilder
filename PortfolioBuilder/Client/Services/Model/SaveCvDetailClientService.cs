
namespace PortfolioBuilder.Client.Services.Model
{
using PortfolioBuilder.Client.Services.Interfaces;
using PortfolioBuilder.Shared;
using System.Net.Http.Json;
using System.Net;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
    using System.Text.Json;

    public class SaveCvDetailClientService: ICvDetailClientService
    {
       
        string ErrorMessage = "An error occurred while generating the CV. Please try again later.";
        private readonly HttpClient httpClient;
        
        public SaveCvDetailClientService(HttpClient http)
        {

            httpClient = http;
        }
       async Task<string> ICvDetailClientService.SaveCV(CvDto cvDto)
        {
                try
                {

                    var httpResponse = await httpClient.PostAsJsonAsync("api/GenerateCv", cvDto);


                    if (httpResponse.IsSuccessStatusCode)
                    {

                        bool apiResponse = await httpResponse.Content.ReadFromJsonAsync<bool>();

                        if (apiResponse)
                        {
                            return "Data Savesuccessfully";
                        }
                        else
                        {
                            return ErrorMessage;
                        }
                    }
                    else
                    {
                        return ErrorMessage;
                    }
                }
                catch (Exception ex)
                {
                    return ErrorMessage + ex.Message;
                }

            }

       async Task<CvDto?> ICvDetailClientService.GetCV(int id)
        {


            HttpResponseMessage response = await httpClient.GetAsync($"api/GenerateCv/{id}");

            if (response.IsSuccessStatusCode)
            {
                string jsonContent = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                CvDto cvDtoget = JsonSerializer.Deserialize<CvDto>(jsonContent,options);

                return cvDtoget;
            }
            return null;
        }

        
      
    }
    

       
    }
