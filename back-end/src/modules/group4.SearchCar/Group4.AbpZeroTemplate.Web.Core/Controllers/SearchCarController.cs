using Abp.AspNetCore.Mvc.Controllers;
using Abp.Dependency;
using Group4.AbpZeroTemplate.Application.Share.Cars.Dto;
using Group4.AbpZeroTemplate.Web.Core.Cars;
using GSoft.AbpZeroTemplate.Sessions.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group4.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SearchCarController : AbpController
    {
        private readonly ICarAppService carAppService;

        public SearchCarController(ICarAppService carAppService)
        {
            this.carAppService = carAppService;
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Upd([FromBody] SearchCarDto input)
        {
            return carAppService.CAR_Upd(input);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_App(int id, string checkerId)
        {
            return carAppService.CAR_App(id, checkerId);
        }
        [HttpPost]
        public SearchCarDto CAR_ById(int id)
        {
            return carAppService.CAR_ById(id);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Ins([FromBody] SearchCarDto input)
        {
            return carAppService.CAR_Ins(input);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Del(int id)
        {
            return carAppService.CAR_Del(id);
        }
        [HttpPost]
        public List<SearchCarDto> CAR_Search([FromBody] SearchCarDto input)
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
