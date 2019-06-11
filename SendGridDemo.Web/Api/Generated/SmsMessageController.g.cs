
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SendGridDemo.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SendGridDemo.Web.Api
{
    [Route("api/SmsMessage")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class SmsMessageController
        : BaseApiController<SendGridDemo.Data.Models.SmsMessage, SmsMessageDtoGen, SendGridDemo.Data.AppDbContext>
    {
        public SmsMessageController(SendGridDemo.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<SendGridDemo.Data.Models.SmsMessage>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<SmsMessageDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<SmsMessageDtoGen>> List(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<SmsMessageDtoGen>> Save(
            SmsMessageDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource,
            IBehaviors<SendGridDemo.Data.Models.SmsMessage> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<SmsMessageDtoGen>> Delete(
            int id,
            IBehaviors<SendGridDemo.Data.Models.SmsMessage> behaviors,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        /// <summary>
        /// Downloads CSV of SmsMessageDtoGen
        /// </summary>
        [HttpGet("csvDownload")]
        [Authorize]
        public virtual Task<FileResult> CsvDownload(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource)
            => CsvDownloadImplementation(parameters, dataSource);

        /// <summary>
        /// Returns CSV text of SmsMessageDtoGen
        /// </summary>
        [HttpGet("csvText")]
        [Authorize]
        public virtual Task<string> CsvText(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource)
            => CsvTextImplementation(parameters, dataSource);

        /// <summary>
        /// Saves CSV data as an uploaded file
        /// </summary>
        [HttpPost("csvUpload")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvUpload(
            IFormFile file,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource,
            IBehaviors<SendGridDemo.Data.Models.SmsMessage> behaviors,
            bool hasHeader = true)
            => CsvUploadImplementation(file, dataSource, behaviors, hasHeader);

        /// <summary>
        /// Saves CSV data as a posted string
        /// </summary>
        [HttpPost("csvSave")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvSave(
            string csv,
            IDataSource<SendGridDemo.Data.Models.SmsMessage> dataSource,
            IBehaviors<SendGridDemo.Data.Models.SmsMessage> behaviors,
            bool hasHeader = true)
            => CsvSaveImplementation(csv, dataSource, behaviors, hasHeader);

        // Methods from data class exposed through API Controller.

        /// <summary>
        /// Method: SendSms
        /// </summary>
        [HttpPost("SendSms")]
        [Authorize]
        public virtual ItemResult<string> SendSms(string to, string message)
        {
            var methodResult = SendGridDemo.Data.Models.SmsMessage.SendSms(to, message, Db);
            var result = new ItemResult<string>();
            result.Object = methodResult;
            return result;
        }
    }
}
