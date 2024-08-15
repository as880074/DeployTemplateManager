using DeployTemplateManager.Domain.Services;
using DeployTemplateManager.Interfaces.Repositories;
using DeployTemplateManager.Interfaces.Serivces;
using DeployTemplateManager.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DeployTemplateManager
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 建立服務集合
            var services = new ServiceCollection();
            ConfigureServices(services);

            // 建立服務提供者
            using (var serviceProvider = services.BuildServiceProvider())
            {
                // 獲取主表單並運行
                var mainForm = serviceProvider.GetRequiredService<DeployToolForm>();
                Application.Run(mainForm);
            }
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            // 註冊表單
            services.AddTransient<DeployToolForm>();

            // 註冊其他依賴項
            services.AddTransient<ISiteRepository, SiteRepository>();
            services.AddTransient<ICommitIdRepository, CommitIdRepository>();
            services.AddTransient<IDeploymentService, DeploymentService>();

            // 其他服務的註冊
            // services.AddTransient<其他服務>();
        }
    }
}