﻿namespace TFGDevopsApp.Core.Models.Result
{
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public T Data { get; set; }

    }
}
