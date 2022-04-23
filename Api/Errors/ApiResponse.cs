using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }
        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDefaultMessage(int statusCode)
        {
            var message = String.Empty;

            switch (statusCode)
            {
                case 400:
                    message = "Bad Request";
                    break;
                case 404:
                    message = "Not Found";
                    break;
                case 500:
                    message = "Server Erro";
                    break;
            } 
            return message;
        }
    }
}