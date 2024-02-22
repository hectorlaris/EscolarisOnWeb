using CoreBusiness;
using Plugins.DataStore.SQL;
using Microsoft.EntityFrameworkCore;

using Xunit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace Escolaris.Common.EntityModels.Tests
{
	public class EscolarisEntityModelsTests
	{

		[Fact]
		public void GetConnectionString_FromDevelopmentJson_ReturnsExpectedValue()
		{
			// Arrange
			var configuration = new ConfigurationBuilder()
									//.SetBasePath(Directory.GetCurrentDirectory())
									.SetBasePath(AppContext.BaseDirectory)
									.AddJsonFile("appSettings.Test.json")
									.Build();

			// Act
			var connectionString = configuration.GetConnectionString("EscolarisMVC");
		
			//Assert
			Assert.Equal("Data Source=(local);Initial Catalog=EscolarisMVC;Integrated Security=True;Trust Server Certificate=True", connectionString);
		}

		[Fact]
		public void CanConnectIsTrue()
		{

			// Arrange
			var options = new DbContextOptionsBuilder<EscolarisContext>()
				.UseSqlServer("Data Source=(local);Initial Catalog=EscolarisMVC;Integrated Security=True;Trust Server Certificate=True")
				.Options;

			using var context = new EscolarisContext(options);

			// Act
			var result = context.Database.CanConnect();

			// Assert
			Assert.True(result);
		}

		[Fact]
		public void ProviderIsSqlServer()
		{

			// Arrange
			var options = new DbContextOptionsBuilder<EscolarisContext>()
				.UseSqlServer("Data Source=(local);Initial Catalog=EscolarisMVC;Integrated Security=True;Trust Server Certificate=True")
				.Options;

			using var context = new EscolarisContext(options);

			//Act
			string? provider = context.Database.ProviderName;

			//Assert
			Assert.Equal("Microsoft.EntityFrameworkCore.SqlServer", provider);
		}

		[Fact]
		public void CategoryId1IsPregrado()
		{
			// Arrange
			var options = new DbContextOptionsBuilder<EscolarisContext>()
				.UseSqlServer("Data Source=(local);Initial Catalog=EscolarisMVC;Integrated Security=True;Trust Server Certificate=True")
				.Options;
			using var context = new EscolarisContext(options);

			//Act
			Category category1 = context.Categories.Single(p => p.CategoryId == 1);

			//Assert
			Assert.Equal("Pregrado", category1.Name);

		}
	}
}