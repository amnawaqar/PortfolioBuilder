namespace PortfolioBuilder.Server.Services.Interfaces
{
using PortfolioBuilder.Shared;

public interface ICvDetailService
    {

        Task<bool> SaveCV(CvDto cvDto);
        Task<CvDto> GetCV(int id);

    }
}
