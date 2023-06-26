using Photoexpress.Domain.Entities.Base;

namespace Photoexpress.Domain.Entities
{
    public class Parameter : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
