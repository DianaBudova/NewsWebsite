using System;
using NewsWebsite.Shared.Utilities.Results.ComplexTypes;

namespace NewsWebsite.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public ResultStatus ResultStatus { get; }
        public string Message { get; }
        public Exception Exception { get; }
    }
}