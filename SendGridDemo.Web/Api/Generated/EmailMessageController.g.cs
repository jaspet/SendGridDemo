
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
    [Route("api/EmailMessage")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class EmailMessageController
        : BaseApiController<SendGridDemo.Data.Models.EmailMessage, EmailMessageDtoGen, SendGridDemo.Data.AppDbContext>
    {
        public EmailMessageController(SendGridDemo.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<SendGridDemo.Data.Models.EmailMessage>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EmailMessageDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<EmailMessageDtoGen>> List(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<EmailMessageDtoGen>> Save(
            EmailMessageDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource,
            IBehaviors<SendGridDemo.Data.Models.EmailMessage> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EmailMessageDtoGen>> Delete(
            int id,
            IBehaviors<SendGridDemo.Data.Models.EmailMessage> behaviors,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        /// <summary>
        /// Downloads CSV of EmailMessageDtoGen
        /// </summary>
        [HttpGet("csvDownload")]
        [Authorize]
        public virtual Task<FileResult> CsvDownload(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource)
            => CsvDownloadImplementation(parameters, dataSource);

        /// <summary>
        /// Returns CSV text of EmailMessageDtoGen
        /// </summary>
        [HttpGet("csvText")]
        [Authorize]
        public virtual Task<string> CsvText(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource)
            => CsvTextImplementation(parameters, dataSource);

        /// <summary>
        /// Saves CSV data as an uploaded file
        /// </summary>
        [HttpPost("csvUpload")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvUpload(
            IFormFile file,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource,
            IBehaviors<SendGridDemo.Data.Models.EmailMessage> behaviors,
            bool hasHeader = true)
            => CsvUploadImplementation(file, dataSource, behaviors, hasHeader);

        /// <summary>
        /// Saves CSV data as a posted string
        /// </summary>
        [HttpPost("csvSave")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvSave(
            string csv,
            IDataSource<SendGridDemo.Data.Models.EmailMessage> dataSource,
            IBehaviors<SendGridDemo.Data.Models.EmailMessage> behaviors,
            bool hasHeader = true)
            => CsvSaveImplementation(csv, dataSource, behaviors, hasHeader);

        // Methods from data class exposed through API Controller.

        /// <summary>
        /// Method: SendEmail
        /// </summary>
        [HttpPost("SendEmail")]
        [Authorize]
        public virtual async Task<ItemResult<string>> SendEmail(string to, string subject, string message, [FromServices] SendGridDemo.Data.Services.IEmailSender emailSender)
        {
            var methodResult = await SendGridDemo.Data.Models.EmailMessage.SendEmail(to, subject, message, Db, emailSender);
            var result = new ItemResult<string>();
            result.Object = methodResult;
            return result;
        }
    }
}
