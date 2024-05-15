using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ValkimiaTennisG1.Excepcion
{
    public class BadRequestException : Exception
    {
        private readonly string _title;
        private readonly string _detail;
        private readonly List<(string, string)> _errors;

        public BadRequestException(string title, string detail)
        {
            _title = title;
            _detail = detail;
        }
        public BadRequestException(string title, string detail, List<(string, string)> errors)
        {
            _title = title;
            _detail = detail;
            _errors = errors;
        }



        public string GetJsonDescription()
        {
            var problemDetails = new ValidationProblemDetails()
            {
                Title = _title,
                Detail = _detail,
                Status = (int)StatusCodes.Status400BadRequest,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
            };

            if (_errors != null)
            {
                var dictionary = _errors.ToDictionary();

                problemDetails.Extensions.Add("Errors", dictionary);

                return JsonConvert.SerializeObject(problemDetails);
            }

            return JsonConvert.SerializeObject(problemDetails);
        }

    }
}
