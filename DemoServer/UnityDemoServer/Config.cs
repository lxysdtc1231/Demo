using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemoServer
{
    static class Config
    {
		static Config()
		{
			IServiceCollection collection = new ServiceCollection();
			collection.AddEntityFrameworkSqlServer().AddDbContextPool<UnityDemoContext>(options =>
			{
				options.UseSqlServer("Data Source=40.73.103.179;Initial Catalog=UnityDemo;User ID=app_UnityDemo;Password=UAW2pxfUKuL9cLIZ");
			});
			services = collection.BuildServiceProvider();
		}
		public static IServiceScope CreateScope()
		{
			return services.CreateScope();
		}
		public static T GetService<T>(this IServiceScope scope)
		{
			return scope.ServiceProvider.GetService<T>();
		}
		static readonly ServiceProvider services;
	}
}
