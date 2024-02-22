using Microsoft.Extensions.Configuration;

namespace Escolaris.Common.EntityModels.Tests
{
	public class AppConfig : IAppConfig
	{
		private readonly IConfiguration _configuration;

		public AppConfig(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string GetSetting(string configurationKey, string defaultValue)
		{
		
			return _configuration[configurationKey] ?? defaultValue;
		}
	}
}
