﻿using Abp.AspNetCore.Mvc.Controllers;
using Abp.Dependency;
using Group12.AbpZeroTemplate.Application.Share.Cars.Dto;
using Group12.AbpZeroTemplate.Web.Core.Cars;
using GSoft.AbpZeroTemplate.Sessions.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group12.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CensorshipCarController : AbpController
    {
        private readonly ICarAppService carAppService;

        public CensorshipCarController(ICarAppService carAppService)
        {
            this.carAppService = carAppService;
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Upd([FromBody] CensorshipCarDto input)
        {
            return carAppService.CAR_Upd(input);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_App(int id, string checkerId)
        {
            return carAppService.CAR_App(id, checkerId);
        }
        [HttpPost]
        public CensorshipCarDto CAR_ById(int id)
        {
            return carAppService.CAR_ById(id);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Ins([FromBody] CensorshipCarDto input)
        {
            return carAppService.CAR_Ins(input);
        }
        [HttpPost]
        public IDictionary<string, object> CAR_Del(int id)
        {
            return carAppService.CAR_Del(id);
        }
        [HttpPost]
        public List<CensorshipCarDto> CAR_Search([FromBody] CensorshipCarDto input)
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
