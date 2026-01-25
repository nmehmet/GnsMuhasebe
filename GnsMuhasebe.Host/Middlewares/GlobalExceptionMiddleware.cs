using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using GnsMuhasebe.Application.Common.Resources;
using GnsMuhasebe.domain.Enums;
using GnsMuhasebe.domain.Exceptions;
using Microsoft.Extensions.Localization;

namespace GnsMuhasebe.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IStringLocalizer<Messages> _localizer;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, IStringLocalizer<Messages> localizer, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _localizer = localizer;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            int statusCode = (int)HttpStatusCode.InternalServerError;
            int errorCode = (int)BusinessErrorCode.UnknownError;

            string searchKey = $"Error_{errorCode}";
            string message = _localizer[searchKey];

            switch (exception)
            {
                case BusinessException businessEx:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorCode = (int)businessEx.ErrorCode;

                    searchKey = $"Error_{errorCode}";
                    LocalizedString localizedString = _localizer[searchKey];
                    message = localizedString.ResourceNotFound ? searchKey : localizedString.Value;
                    break;
                case ValidationException validateEx:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    errorCode = (int)BusinessErrorCode.ValidationError;

                    message = validateEx.Message;
                    break;
                case KeyNotFoundException keyEx:
                    statusCode = (int)HttpStatusCode.NotFound;
                    message = "Entry not found!!";
                    break;
                default:
                    _logger.LogError(exception, "Unknown Error!!!");
                    break;
            }

            context.Response.StatusCode = statusCode;

            var response = new
            {
                error = true,
                code = errorCode,
                message = message
            };

            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }
    }
}
