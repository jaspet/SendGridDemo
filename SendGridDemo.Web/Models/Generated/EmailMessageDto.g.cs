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
    public partial class EmailMessageDtoGen : GeneratedDto<SendGridDemo.Data.Models.EmailMessage>
    {
        public EmailMessageDtoGen() { }

        public string Subject { get; set; }
        public System.Collections.Generic.ICollection<SendGridDemo.Web.Models.EmailMessageEventDtoGen> EmailEvents { get; set; }
        public string LastStatus { get; set; }
        public int? pkMessageId { get; set; }
        public string MessageId { get; set; }
        public string To { get; set; }
        public string MessageText { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(SendGridDemo.Data.Models.EmailMessage obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.Subject = obj.Subject;
            this.LastStatus = obj.LastStatus;
            this.pkMessageId = obj.pkMessageId;
            this.MessageId = obj.MessageId;
            this.To = obj.To;
            this.MessageText = obj.MessageText;
            var propValEmailEvents = obj.EmailEvents;
            if (propValEmailEvents != null && (tree == null || tree[nameof(this.EmailEvents)] != null))
            {
                this.EmailEvents = propValEmailEvents
                    .AsQueryable().OrderBy("EmailMessageEventId ASC").AsEnumerable<SendGridDemo.Data.Models.EmailMessageEvent>()
                    .Select(f => f.MapToDto<SendGridDemo.Data.Models.EmailMessageEvent, EmailMessageEventDtoGen>(context, tree?[nameof(this.EmailEvents)])).ToList();
            }
            else if (propValEmailEvents == null && tree?[nameof(this.EmailEvents)] != null)
            {
                this.EmailEvents = new EmailMessageEventDtoGen[0];
            }

        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(SendGridDemo.Data.Models.EmailMessage entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            entity.Subject = Subject;
            entity.pkMessageId = (pkMessageId ?? entity.pkMessageId);
            entity.MessageId = MessageId;
            entity.To = To;
            entity.MessageText = MessageText;
        }
    }
}
