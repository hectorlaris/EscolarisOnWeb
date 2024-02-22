namespace Escolaris.Common.EntityModels.Tests
{
	public interface IAppConfig
	{
		string GetSetting(string configurationKey, string defaultValue);
	}
}