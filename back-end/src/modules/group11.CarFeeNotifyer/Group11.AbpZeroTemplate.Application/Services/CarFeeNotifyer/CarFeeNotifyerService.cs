using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Helpers;
using GSoft.AbpZeroTemplate.Sessions;
using Group11.AbpZeroTemplate.Application.Share.Cars.Dto;
using Microsoft.AspNetCore.Builder;
using Abp.Application.Services;
using Abp.Runtime.Session;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace Group11.AbpZeroTemplate.Web.Core.Cars
{
    public interface ICarAppService : IApplicationService
    {
        IDictionary<string, object> CAR_Upd(CarFeeNotifyerDto input);
        IDictionary<string, object> CAR_App(int id, string checkerId);
        CarFeeNotifyerDto CAR_ById(int id);
        IDictionary<string, object> CAR_Ins(CarFeeNotifyerDto input);
        IDictionary<string, object> CAR_Del(int id);
        List<CarFeeNotifyerDto> CAR_Search(CarFeeNotifyerDto input);
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

        public CarFeeNotifyerDto CAR_ById(int id)
        {
            return procedureHelper.GetData<CarFeeNotifyerDto>("CAR_ById", new
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

        public IDictionary<string, object> CAR_Ins(CarFeeNotifyerDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Ins", input).FirstOrDefault();
        }

        public List<CarFeeNotifyerDto> CAR_Search(CarFeeNotifyerDto input)
        {
            return procedureHelper.GetData<CarFeeNotifyerDto>("CAR_Search", input);
        }

        public IDictionary<string, object> CAR_Upd(CarFeeNotifyerDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Upd", input).FirstOrDefault();
        }


    }
}
