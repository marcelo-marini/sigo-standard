using System;

namespace Sigo.Standard.Api.Domain.Seedwork
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
        public string ExternalId { get; set; }
        public DateTime CreatedAt { get; set; }
        public  DateTime UpdatedAt { get; set; }
    }
}