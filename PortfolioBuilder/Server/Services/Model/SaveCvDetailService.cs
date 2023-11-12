
namespace PortfolioBuilder.Server.Services.Model
{
using PortfolioBuilder.Server.Services.Interfaces;
using PortfolioBuilder.Shared;
    using PortfolioBuilder.Server.DataBase;
using System.Net.Http.Json;
using System.Threading.Tasks;

    public class SaveCvDetailService: ICvDetailService
    {
        DataInDb data = new DataInDb();

        public async Task<CvDto> GetCV(int id)
        {
            return await data.GetDataAsync(id);
        }

        public async Task<bool> SaveCV(CvDto cvDto)
        {
            return await data.SaveDataAsync(cvDto);

        }


    }
}
