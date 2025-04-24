﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ErrorMessage
    {
        public string Message { get; set; } 
        public string Code { get; set; }
        public int StatusCode { get; set; } = StatusCodes.Status400BadRequest;
        public ErrorMessage(string message)
        {
            Message = message;
        }
        public ErrorMessage(string message, int statusCode)
        {
            Message = message;
            StatusCode = statusCode;
        }
        public ErrorMessage(string message, int statusCode, string code)
        {
            Code = code;
            StatusCode = statusCode;
            Message = message;
        }
    }
}
