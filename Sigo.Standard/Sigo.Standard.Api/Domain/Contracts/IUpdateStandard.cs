namespace Sigo.Standard.Api.Domain.Contracts
{
    public interface IUpdateStandard
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public string Code { get; set; }
    }
}