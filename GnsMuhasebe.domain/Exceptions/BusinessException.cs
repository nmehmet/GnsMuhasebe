using GnsMuhasebe.domain.Enums;

namespace GnsMuhasebe.domain.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessErrorCode ErrorCode { get; }

        public BusinessException(BusinessErrorCode errorCode) : base(errorCode.ToString())
        {
            ErrorCode = errorCode;
        }
    }
}
