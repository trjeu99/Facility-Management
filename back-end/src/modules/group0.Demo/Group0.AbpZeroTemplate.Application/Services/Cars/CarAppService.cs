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
using GSoft.AbpZeroTemplate.Sessions.Dto;

namespace Group0.AbpZeroTemplate.Web.Core.Cars
{
    public interface ICarAppService : IApplicationService
    {
        IDictionary<string, object> Xe_Upd(CarDto input);
        IDictionary<string, object> XeProposal_App(int ma, string xe_NguoiTao);
        CarDto Xe_ByMa(int ma);

        IDictionary<string, object> Xe_Ins(CarDto input);

        List<CarDto> Xe_SearchAll(CarDto input);

        public class CarAppService : BaseService, ICarAppService
        {
            public CarAppService()
            {

            }
            public IDictionary<string, object> XeProposal_App(int ma, string xe_NguoiTao)
            {
                return procedureHelper.GetData<dynamic>("XeProposal_App", new
                {
                    Ma = ma,
                    Xe_NguoiTao = xe_NguoiTao
                }).FirstOrDefault();
            }

            public CarDto Xe_ByMa(int ma)
            {
                return procedureHelper.GetData<CarDto>("Xe_ByMa", new
                {
                    Ma = ma
                }).FirstOrDefault();
            }

            //public IDictionary<string, object> CAR_Del(int id)
            //{
            //    return procedureHelper.GetData<dynamic>("CAR_Del", new
            //    {
            //        Id = id
            //    }).FirstOrDefault();
            //}

            public IDictionary<string, object> Xe_Ins(CarDto input)
            {
                return procedureHelper.GetData<dynamic>("Xe_Ins", input).FirstOrDefault();
            }

            public List<CarDto> Xe_SearchAll(CarDto input)
            {
                return procedureHelper.GetData<CarDto>("Xe_SearchAll", input);
            }

            public IDictionary<string, object> Xe_Upd(CarDto input)
            {
                return procedureHelper.GetData<dynamic>("Xe_Upd", input).FirstOrDefault();
            }


        }
    }
}
