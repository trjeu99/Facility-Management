using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Helpers;
using GSoft.AbpZeroTemplate.Sessions;
using Group0.AbpZeroTemplate.Application.Share.Cars.Dto;
using Microsoft.AspNetCore.Builder;
using Abp.Application.Services;
using Abp.Runtime.Session;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Sessions;
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace Group0.AbpZeroTemplate.Web.Core.Cars
{
    public interface ICarAppService : IApplicationService
    {
        IDictionary<string, object> CAR_Upd(CarDto input);
        IDictionary<string, object> CAR_App(int id, string checkerId);
        CarDto CAR_ById(int id);
        IDictionary<string,object> CAR_Ins(CarDto input);
        IDictionary<string, object> CAR_Del(int id);
        List<CarDto> CAR_Search(CarDto input);
        string GetCurrentUserName();
    }
    public class CarAppService : BaseService, ICarAppService
    {
        public CarAppService()
        {
            
        }
        public IDictionary<string, object> CAR_App(int id, string checkerId)
        {
            return procedureHelper.GetData<dynamic>("CAR_App", new {
                Id = id,
                CheckerId = checkerId
            }).FirstOrDefault();
        }

        public CarDto CAR_ById(int id)
        {
            return procedureHelper.GetData<CarDto>("CAR_ById", new
            {
                Id = id
            }).FirstOrDefault();
        }

        public IDictionary<string, object> CAR_Del(int id)
        {
            return procedureHelper.GetData<dynamic>("CAR_Del", new
            {
                Id = id
            }).FirstOrDefault();
        }

        public IDictionary<string, object> CAR_Ins(CarDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Ins", input).FirstOrDefault();
        }

        public List<CarDto> CAR_Search(CarDto input)
        {
            return procedureHelper.GetData<CarDto>("CAR_Search", input);
        }

        public IDictionary<string, object> CAR_Upd(CarDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Upd", input).FirstOrDefault();
        }

 
    }
}
