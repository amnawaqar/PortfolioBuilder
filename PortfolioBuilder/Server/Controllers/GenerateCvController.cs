using Microsoft.AspNetCore.Mvc;
using PortfolioBuilder.Shared;
using PortfolioBuilder.Server.Services.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioBuilder.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateCvController : ControllerBase
    {
        private readonly ICvDetailService _cvDetail;
        public GenerateCvController(ICvDetailService cvDetail)
        {
            _cvDetail = cvDetail;
        }
        // GET: api/<GenerateCvController>
        [HttpGet]
       

        // GET api/<GenerateCvController>/5
        [HttpGet("{id}")]
        public async Task<CvDto> Get(int id)
        {
           return await _cvDetail.GetCV(id);
        }

        // POST api/<GenerateCvController>
        [HttpPost]
        public async Task<bool> Post(CvDto cvDto)
        {
            return await _cvDetail.SaveCV(cvDto);
        }


        // PUT api/<GenerateCvController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GenerateCvController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
