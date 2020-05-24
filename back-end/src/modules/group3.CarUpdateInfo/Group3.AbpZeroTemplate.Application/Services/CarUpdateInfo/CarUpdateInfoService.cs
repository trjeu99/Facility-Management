using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Helpers;
using GSoft.AbpZeroTemplate.Sessions;
using Group3.AbpZeroTemplate.Application.Share.Cars.Dto;
using Microsoft.AspNetCore.Builder;
using Abp.Application.Services;
using Abp.Runtime.Session;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace Group3.AbpZeroTemplate.Web.Core.Cars
{
    public interface ICarAppService : IApplicationService
    {
        IDictionary<string, object> CAR_Upd(CarUpdateInfoDto input);
        IDictionary<string, object> CAR_App(int id, string checkerId);
        CarUpdateInfoDto CAR_ById(int id);
        IDictionary<string, object> CAR_Ins(CarUpdateInfoDto input);
        IDictionary<string, object> CAR_Del(int id);
        List<CarUpdateInfoDto> CAR_Search(CarUpdateInfoDto input);
        string GetCurrentUserName();
    }
    public class CarAppService : BaseService, ICarAppService
    {
        public CarAppService()
        {

        }
        public IDictionary<string, object> CAR_App(int id, string checkerId)
        {
            return procedureHelper.GetData<dynamic>("CAR_App", new
            {
                Id = id,
                CheckerId = checkerId
            }).FirstOrDefault();
        }

        public CarUpdateInfoDto CAR_ById(int id)
        {
            return procedureHelper.GetData<CarUpdateInfoDto>("CAR_ById", new
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

        public IDictionary<string, object> CAR_Ins(CarUpdateInfoDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Ins", input).FirstOrDefault();
        }

        public List<CarUpdateInfoDto> CAR_Search(CarUpdateInfoDto input)
        {
            return procedureHelper.GetData<CarUpdateInfoDto>("CAR_Search", input);
        }

        public IDictionary<string, object> CAR_Upd(CarUpdateInfoDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Upd", input).FirstOrDefault();
        }


    }
}
