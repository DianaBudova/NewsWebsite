using NewsWebsite.Shared.Utilities.Results.ComplexTypes;

namespace NewsWebsite.Shared.Entity.Abstract
{
    public abstract class DtoGetBase
    {
        public virtual ResultStatus ResultStatus { get; set; }
    }
}