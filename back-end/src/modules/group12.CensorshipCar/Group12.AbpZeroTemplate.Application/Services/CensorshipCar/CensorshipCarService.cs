using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Helpers;
using GSoft.AbpZeroTemplate.Sessions;
using Group12.AbpZeroTemplate.Application.Share.Cars.Dto;
using Microsoft.AspNetCore.Builder;
using Abp.Application.Services;
using Abp.Runtime.Session;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace Group12.AbpZeroTemplate.Web.Core.Cars
{
    public interface ICarAppService : IApplicationService
    {
        IDictionary<string, object> CAR_Upd(CensorshipCarDto input);
        IDictionary<string, object> CAR_App(int id, string checkerId);
        CensorshipCarDto CAR_ById(int id);
        IDictionary<string, object> CAR_Ins(CensorshipCarDto input);
        IDictionary<string, object> CAR_Del(int id);
        List<CensorshipCarDto> CAR_Search(CensorshipCarDto input);
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

        public CensorshipCarDto CAR_ById(int id)
        {
            return procedureHelper.GetData<CensorshipCarDto>("CAR_ById", new
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

        public IDictionary<string, object> CAR_Ins(CensorshipCarDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Ins", input).FirstOrDefault();
        }

        public List<CensorshipCarDto> CAR_Search(CensorshipCarDto input)
        {
            return procedureHelper.GetData<CensorshipCarDto>("CAR_Search", input);
        }

        public IDictionary<string, object> CAR_Upd(CensorshipCarDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Upd", input).FirstOrDefault();
        }


    }
}
