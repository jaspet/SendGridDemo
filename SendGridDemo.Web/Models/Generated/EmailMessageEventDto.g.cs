using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;

namespace SendGridDemo.Web.Models
{
    public partial class EmailMessageEventDtoGen : GeneratedDto<SendGridDemo.Data.Models.EmailMessageEvent>
    {
        public EmailMessageEventDtoGen() { }

        public int? EmailMessageEventId { get; set; }
        public int? fkEmailMessageId { get; set; }
        public SendGridDemo.Web.Models.EmailMessageDtoGen EmailMessage { get; set; }
        public double? TimeStamp { get; set; }
        public System.DateTime? EventTime { get; set; }
        public string Event { get; set; }
        public string SendGridEventId { get; set; }
        public string Response { get; set; }
        public string Url { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(SendGridDemo.Data.Models.EmailMessageEvent obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.EmailMessageEventId = obj.EmailMessageEventId;
            this.fkEmailMessageId = obj.fkEmailMessageId;
            this.TimeStamp = obj.TimeStamp;
            this.EventTime = obj.EventTime;
            this.Event = obj.Event;
            this.SendGridEventId = obj.SendGridEventId;
            this.Response = obj.Response;
            this.Url = obj.Url;
            if (tree == null || tree[nameof(this.EmailMessage)] != null)
                this.EmailMessage = obj.EmailMessage.MapToDto<SendGridDemo.Data.Models.EmailMessage, EmailMessageDtoGen>(context, tree?[nameof(this.EmailMessage)]);

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(SendGridDemo.Data.Models.EmailMessageEvent entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            entity.EmailMessageEventId = (EmailMessageEventId ?? entity.EmailMessageEventId);
            entity.fkEmailMessageId = (fkEmailMessageId ?? entity.fkEmailMessageId);
            entity.TimeStamp = (TimeStamp ?? entity.TimeStamp);
            entity.Event = Event;
            entity.SendGridEventId = SendGridEventId;
            entity.Response = Response;
            entity.Url = Url;
        }
    }
}
