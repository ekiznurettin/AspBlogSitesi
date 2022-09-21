using AspBlogSitesi.Core.Utilities.ComplexTypes;
using System;

namespace AspBlogSitesi.Core.Utilities.Results.Abstract
{
    public  interface IResult
    {
        public ResultStatus ResultStatus { get;  }
        public string Message { get;  }
        public Exception  Exception{ get;  }
    }
}
