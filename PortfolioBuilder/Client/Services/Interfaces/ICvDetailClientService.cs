namespace PortfolioBuilder.Client.Services.Interfaces
{
using PortfolioBuilder.Shared;

public interface ICvDetailClientService
    {

        Task<string> SaveCV(CvDto cvDto);
        Task<CvDto?> GetCV(int id);
       

    }
}
