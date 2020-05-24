using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using GSoft.AbpZeroTemplate.Helpers;
using GSoft.AbpZeroTemplate.Sessions;
using Group1.AbpZeroTemplate.Application.Share.Cars.Dto;
using Microsoft.AspNetCore.Builder;
using Abp.Application.Services;
using Abp.Runtime.Session;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace Group1.AbpZeroTemplate.Web.Core.Cars
{
    public interface ICarAppService : IApplicationService
    {
        IDictionary<string, object> CAR_Upd(CarTypesProposalDto input);
        IDictionary<string, object> CAR_App(int id, string checkerId);
        CarTypesProposalDto CAR_ById(int id);
        IDictionary<string, object> Car_Proposal(CarTypesProposalDto input);
        IDictionary<string, object> CAR_Ins(CarTypesProposalDto input);
        IDictionary<string, object> CAR_Del(int id);
        List<CarTypesProposalDto> CAR_Search(CarTypesProposalDto input);
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

        public CarTypesProposalDto CAR_ById(int id)
        {
            return procedureHelper.GetData<CarTypesProposalDto>("CAR_ById", new
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

        public IDictionary<string, object> CAR_Ins(CarTypesProposalDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Ins", input).FirstOrDefault();
        }
        public IDictionary<string, object> Car_Proposal(CarTypesProposalDto input)
        {
            return procedureHelper.GetData<dynamic>("Car_Proposal", input).FirstOrDefault();
        }

        public List<CarTypesProposalDto> CAR_Search(CarTypesProposalDto input)
        {
            return procedureHelper.GetData<CarTypesProposalDto>("CAR_Search", input);
        }

        public IDictionary<string, object> CAR_Upd(CarTypesProposalDto input)
        {
            return procedureHelper.GetData<dynamic>("CAR_Upd", input).FirstOrDefault();
        }


    }
}
