﻿using System.ComponentModel;

namespace E_Commerce.Business.Types
{
    public class ServiceMessage
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class ServiceMessageCount
    {
        public bool IsSucceed { get; set; }

        [DefaultValue(0)]
        public int Count { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class ServiceMessage<T>
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; } = string.Empty;
        public int Count { get; set; }
        public T? Data { get; set; }
    }
}
