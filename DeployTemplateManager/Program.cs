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
            // �إߪA�ȶ��X
            var services = new ServiceCollection();
            ConfigureServices(services);

            // �إߪA�ȴ��Ѫ�
            using (var serviceProvider = services.BuildServiceProvider())
            {
                // ����D���ùB��
                var mainForm = serviceProvider.GetRequiredService<DeployToolForm>();
                Application.Run(mainForm);
            }
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            // ���U���
            services.AddTransient<DeployToolForm>();

            // ���U��L�̿ඵ
            services.AddTransient<ISiteRepository, SiteRepository>();
            services.AddTransient<ICommitIdRepository, CommitIdRepository>();
            services.AddTransient<IDeploymentService, DeploymentService>();

            // ��L�A�Ȫ����U
            // services.AddTransient<��L�A��>();
        }
    }
}