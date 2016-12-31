using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibs.Configs
{
    public class MicroServiceConfig: BaseConfig
    {
        public string StudentBaseUrl { get; set; } = "http://localhost:8080/api";
    }
}
