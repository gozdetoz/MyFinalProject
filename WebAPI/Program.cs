using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
               .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureContainer<ContainerBuilder>(builder =>
               {
                   builder.RegisterModule(new AutofacBusinessModule());
               })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
#region A��klama
/*22.sat�r dan baslayan
  .UseServiceProviderFactory(new AutofacServiceProviderFactory())
               .ConfigureContainer<ContainerBuilder>(builder=>
               {
                   builder.RegisterModule(new AutofacBusinessModule());
               })

  
  autofac yap�land�rmas� �c�n ekled�k
 Senin alt yap�n var ama ben�m olusturudugum yap�m� kullan yani Businesde olusturdugumuz autofac kullan
*/
#endregion

