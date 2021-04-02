using System;
using Sigo.Standard.Api.Domain.Contracts;
using Sigo.Standard.Api.Domain.Seedwork;

namespace Sigo.Standard.Api.Domain
{
    public class Standard : Entity
    {
        public string Description { get; private set; }
        public string Url { get; private set; }
        public string Status { get; private set; }
        public string Type { get; private set; }
        public string Owner { get; private set; }
        public string Code { get; private set; }

        public Standard()
        {
        }
        
        Standard(ICreateStandardRequest request)
        {
            Description = request.Description;
            Url = request.Url;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            ExternalId = Seedwork.Code.Create("stand_");
            Status = "active";
            Type = request.Type;
            Owner = request.Owner;
            Code = request.Code;
        }

        public static Standard Create(ICreateStandardRequest request)
        {
            return new Standard(request);
        }

        public void Update(IUpdateStandard request)
        {
            Description = request.Description;
            Code = request.Code;
            Owner = request.Owner;
            Type = request.Type;
            Url = request.Url ?? Url;
            UpdatedAt = DateTime.Now;
        }
    }
}