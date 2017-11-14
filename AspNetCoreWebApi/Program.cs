using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AspNetCoreWebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			BuildWebHost(args).Run();
		}

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseKestrel(options =>
				{
					options.Listen(IPAddress.Loopback, 5000);
					options.Listen(IPAddress.Loopback, 5001, listenOptions =>
					{
						listenOptions.UseHttps("test.pfx", "test");
					});
				})
				.Build();
	}
}
