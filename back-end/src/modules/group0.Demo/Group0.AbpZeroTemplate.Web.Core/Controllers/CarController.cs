using Abp.AspNetCore.Mvc.Controllers;
using Abp.Dependency;
using Group0.AbpZeroTemplate.Application.Share.Cars.Dto;
using Group0.AbpZeroTemplate.Web.Core.Cars;
using GSoft.AbpZeroTemplate.Sessions.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group0.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CarController : AbpController
    {
        private readonly ICarAppService carAppService;

        public CarController(ICarAppService carAppService)
        {
            this.carAppService = carAppService;
        }
        [HttpPost]
        public IDictionary<string, object> Xe_Upd([FromBody]CarDto input)
        {
            return carAppService.Xe_Upd(input);
        }
        [HttpPost]
        public IDictionary<string, object> XeProposal_App(int ma, string xe_NguoiTao)
        {
            return carAppService.XeProposal_App(ma, xe_NguoiTao);
        }
        [HttpPost]
        public CarDto Xe_ByMa(int ma)
        {
            return carAppService.Xe_ByMa(ma);
        }
        [HttpPost]
        public IDictionary<string, object> Xe_Ins([FromBody]CarDto input)
        {
            return carAppService.Xe_Ins(input);
        }
       

        //[HttpPost]
        //public IDictionary<string, object> CAR_Del(int id)
        //{
        //    return carAppService.CAR_Del(id);
        //}
        //[HttpPost]
        //public List<CarDto> CAR_Search([FromBody]CarDto input)
        //{
        //    return carAppService.CAR_Search(input);
        //}

        //[HttpGet]
        //public string GetCurrentUserName()
        //{
        //    return carAppService.GetCurrentUserName();
        //}
    }
}
