using GnsMuhasebe.Application.Common.Resources;

namespace GnsMuhasebe.Application.Common
{
    public class BaseResponse
    {
        public int Status { get; set; }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }

        public void SetStatus(int _statusCode)
        {
            if ( _statusCode == 200 ) this.IsSuccess = true;
            else this.IsSuccess = false;
            this.Status = _statusCode;
            this.Message = Messages.ResourceManager.GetString($"Error_{_statusCode.ToString()}") ?? "Undefined Error";
        }
    }
}
