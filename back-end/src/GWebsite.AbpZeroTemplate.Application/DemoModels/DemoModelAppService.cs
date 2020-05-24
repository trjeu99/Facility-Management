using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels;
using GWebsite.AbpZeroTemplate.Application.Share.DemoModels.Dto;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace GWebsite.AbpZeroTemplate.Web.Core.DemoModels
{
    public interface IDemoModelAppService
    {
        DemoModelDto CreateOrEditDemoModel(DemoModelInput demoModelInput);
        DemoModelInput GetDemoModelForEdit(int id);
        void DeleteDemoModel(int id);
        DemoModelDto CreateDemo(DemoModelInput demoModelInput);
        void DeleteDemo(int id);
        PagedResultDto<DemoModelDto> GetDemoModels(DemoModelFilter input);

        List<DemoModelDto> DEMO_MODEL_Search(DemoModelDto input);
    }
    public class DemoModelAppService : GWebsiteAppServiceBase, IDemoModelAppService
    {
        private readonly IRepository<DemoModel> demoModelRepository;
        private string connectionString = "Server=IAMMINH; Database=DbPratice; Trusted_Connection=True;";
        private JObject appsettingsjson = JObject.Parse(File.ReadAllText("appsettings.json"));
     

        public DemoModelAppService(IRepository<DemoModel> demoModelRepository)
        {
            this.demoModelRepository = demoModelRepository;
        }


        public DemoModelDto CreateOrEditDemoModel(DemoModelInput demoModelInput)
        {
            DemoModel demoModelEntity = null;
            if (demoModelInput.Id == 0)
            {
                // Insert
                demoModelEntity = ObjectMapper.Map<DemoModel>(demoModelInput);
                demoModelEntity.IsDelete = false;
                demoModelRepository.Insert(demoModelEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            else
            {
                // Update
                demoModelEntity = demoModelRepository.GetAll().Where(x => x.IsDelete == false).SingleOrDefault(x => x.Id == demoModelInput.Id);
                if (demoModelEntity == null)
                {
                    return null;
                }
                ObjectMapper.Map(demoModelInput, demoModelEntity);
                demoModelRepository.Update(demoModelEntity);
                CurrentUnitOfWork.SaveChanges();
            }

            return ObjectMapper.Map<DemoModelDto>(demoModelEntity);
        }

        public void DeleteDemoModel(int id)
        {
            var demoModelEntity = demoModelRepository.Get(id);
            if (demoModelEntity != null)
            {
                demoModelEntity.IsDelete = true;
                demoModelRepository.Update(demoModelEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public DemoModelInput GetDemoModelForEdit(int id)
        {
            var demoModelEntity = demoModelRepository.GetAll().Where(x => x.IsDelete == false).SingleOrDefault(x => x.Id == id);
            if (demoModelEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<DemoModelInput>(demoModelEntity);
        }

        public PagedResultDto<DemoModelDto> GetDemoModels(DemoModelFilter input)
        {
            var query = demoModelRepository.GetAll().Where(x => x.IsDelete == false);

            // filter by value
            if (input.Value != null)
            {
                query = query.Where(x => x.Value == input.Value);
            }

            // filter by Date
            if (input.Date != null)
            {
                query = query.Where(x => x.Date == input.Date);
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<DemoModelDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<DemoModelDto>(item)).ToList());
        }
        ///
        public DemoModelDto CreateDemo(DemoModelInput demoModelInput)
        {
            DemoModelDto demoModelEntity = null;

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                demoModelEntity = con.QueryFirst<DemoModelDto>("CreateDemo @Info,@Value,@Date", new
                {
                    Value = demoModelInput.Value,
                    Info = demoModelInput.Info,
                    Date = demoModelInput.Date
                });
            }
            return demoModelEntity;
        }

        public void DeleteDemo(int id)
        {

            using (IDbConnection con = new SqlConnection(connectionString))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                con.QueryFirst<DemoModelDto>("DELETE FROM [DemoModels] WHERE Id = @Id", new
                {
                    Id = id
                });
            }
        }

        public List<DemoModelDto> DEMO_MODEL_Search(DemoModelDto input)
        {
            return procedureHelper.GetData<DemoModelDto>("DEMO_MODEL_Search", input);
        }
    }
}
