using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cls.web.plataforma.Configs
{
    public class Configurations
    {
        public string Version { get; set; } = string.Empty;

    }

    public class OptionsConfig : IOptionsConfig
    {
        private readonly Configurations _options;

        public OptionsConfig(IOptions<Configurations> options)
        {
            _options = options.Value;
        }

        public string GetAppVersion()
        {
            return _options.Version;
        }
    }

    public interface IOptionsConfig
    {
        public string GetAppVersion();
    }
}
