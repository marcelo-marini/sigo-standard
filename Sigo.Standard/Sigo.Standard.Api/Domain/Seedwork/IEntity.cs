using System;

namespace Sigo.Standard.Api.Domain.Seedwork
{
    public interface IEntity
    {
        int Id { get; set; }
        string ExternalId { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}