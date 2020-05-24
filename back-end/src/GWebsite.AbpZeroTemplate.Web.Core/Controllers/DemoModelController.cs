using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using GWebsite.AbpZeroTemplate.Web.Core.DemoModels;

namespace GWebsite.AbpZeroTemplate.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DemoModelController : GWebsiteControllerBase
    {
        private readonly IDemoModelAppService demoModelAppService;

        

        public DemoModelController(IDemoModelAppService demoModelAppService)
        {
            this.demoModelAppService = demoModelAppService;
        }

        [HttpGet]
        public PagedResultDto<DemoModelDto> GetDemoModelsByFilter(DemoModelFilter demoModelFilter)
        {
            return demoModelAppService.GetDemoModels(demoModelFilter);
        }


        [HttpPost]
        public List<DemoModelDto> DEMO_MODEL_Search([FromBody]DemoModelDto input)
        {
            return demoModelAppService.DEMO_MODEL_Search(input);
        }

        [HttpGet]
        public DemoModelInput GetDemoModelForEdit(int id)
        {
            return demoModelAppService.GetDemoModelForEdit(id);
        }

        [HttpPost]
        public DemoModelDto CreateOrEditDemoModel([FromBody] DemoModelInput input)
        {
            return demoModelAppService.CreateOrEditDemoModel(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDemoModel(int id)
        {
            demoModelAppService.DeleteDemoModel(id);
        }

        [HttpPost]
        public DemoModelDto CreateDemo([FromBody] DemoModelInput input)
        {
            return demoModelAppService.CreateDemo(input);
        }

        [HttpDelete("{id}")]
        public void DeleteDemo(int id)
        {
            demoModelAppService.DeleteDemo(id);
        }
    }
}
