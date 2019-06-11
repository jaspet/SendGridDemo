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
    public partial class SmsMessageDtoGen : GeneratedDto<SendGridDemo.Data.Models.SmsMessage>
    {
        public SmsMessageDtoGen() { }

        public string Subject { get; set; }
        public int? pkMessageId { get; set; }
        public string MessageId { get; set; }
        public string To { get; set; }
        public string MessageText { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(SendGridDemo.Data.Models.SmsMessage obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            // Fill the properties of the object.

            this.Subject = obj.Subject;
            this.pkMessageId = obj.pkMessageId;
            this.MessageId = obj.MessageId;
            this.To = obj.To;
            this.MessageText = obj.MessageText;
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(SendGridDemo.Data.Models.SmsMessage entity, IMappingContext context)
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
