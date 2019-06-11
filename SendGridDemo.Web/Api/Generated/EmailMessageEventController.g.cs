
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
    [Route("api/EmailMessageEvent")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class EmailMessageEventController
        : BaseApiController<SendGridDemo.Data.Models.EmailMessageEvent, EmailMessageEventDtoGen, SendGridDemo.Data.AppDbContext>
    {
        public EmailMessageEventController(SendGridDemo.Data.AppDbContext db) : base(db)
        {
            GeneratedForClassViewModel = ReflectionRepository.Global.GetClassViewModel<SendGridDemo.Data.Models.EmailMessageEvent>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EmailMessageEventDtoGen>> Get(
            int id,
            DataSourceParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<EmailMessageEventDtoGen>> List(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<EmailMessageEventDtoGen>> Save(
            EmailMessageEventDtoGen dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource,
            IBehaviors<SendGridDemo.Data.Models.EmailMessageEvent> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<EmailMessageEventDtoGen>> Delete(
            int id,
            IBehaviors<SendGridDemo.Data.Models.EmailMessageEvent> behaviors,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);

        /// <summary>
        /// Downloads CSV of EmailMessageEventDtoGen
        /// </summary>
        [HttpGet("csvDownload")]
        [Authorize]
        public virtual Task<FileResult> CsvDownload(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource)
            => CsvDownloadImplementation(parameters, dataSource);

        /// <summary>
        /// Returns CSV text of EmailMessageEventDtoGen
        /// </summary>
        [HttpGet("csvText")]
        [Authorize]
        public virtual Task<string> CsvText(
            ListParameters parameters,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource)
            => CsvTextImplementation(parameters, dataSource);

        /// <summary>
        /// Saves CSV data as an uploaded file
        /// </summary>
        [HttpPost("csvUpload")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvUpload(
            IFormFile file,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource,
            IBehaviors<SendGridDemo.Data.Models.EmailMessageEvent> behaviors,
            bool hasHeader = true)
            => CsvUploadImplementation(file, dataSource, behaviors, hasHeader);

        /// <summary>
        /// Saves CSV data as a posted string
        /// </summary>
        [HttpPost("csvSave")]
        [Authorize]
        public virtual Task<IEnumerable<ItemResult>> CsvSave(
            string csv,
            IDataSource<SendGridDemo.Data.Models.EmailMessageEvent> dataSource,
            IBehaviors<SendGridDemo.Data.Models.EmailMessageEvent> behaviors,
            bool hasHeader = true)
            => CsvSaveImplementation(csv, dataSource, behaviors, hasHeader);

        // Methods from data class exposed through API Controller.
    }
}
