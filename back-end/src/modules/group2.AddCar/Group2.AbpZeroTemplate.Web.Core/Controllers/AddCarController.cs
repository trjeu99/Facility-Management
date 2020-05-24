using Abp.AspNetCore.Mvc.Controllers;
using Abp.Dependency;
using Group2.AbpZeroTemplate.Application.Share.Cars.Dto;
using Group2.AbpZeroTemplate.Web.Core.Cars;
using GSoft.AbpZeroTemplate.Sessions.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group2.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AddCarController : AbpController
    {
        private readonly ICarAppService carAppService;

        public AddCarController(ICarAppService carAppService)
        {
            this.carAppService = carAppService;
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Upd([FromBody] AddCarDto input)
        {
            return carAppService.CAR_Upd(input);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_App(int id, string checkerId)
        {
            return carAppService.CAR_App(id, checkerId);
        }
        [HttpPost]
        public AddCarDto CAR_ById(int id)
        {
            return carAppService.CAR_ById(id);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Ins([FromBody] AddCarDto input)
        {
            return carAppService.CAR_Ins(input);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Del(int id)
        {
            return carAppService.CAR_Del(id);
        }
        [HttpPost]
        public List<AddCarDto> CAR_Search([FromBody] AddCarDto input)
        {
            return carAppService.CAR_Search(input);
        }

        [HttpGet]
        public string GetCurrentUserName()
        {
            return carAppService.GetCurrentUserName();
        }
    }
}
