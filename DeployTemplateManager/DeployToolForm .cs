using DeployTemplateManager.Domain.Aggregates;
using DeployTemplateManager.Domain.Entities;
using DeployTemplateManager.Domain.ValueObjects;
using DeployTemplateManager.Enums;
using DeployTemplateManager.Interfaces.Repositories;
using System.Text;

namespace DeployTemplateManager
{
    public partial class DeployToolForm : Form
    {
        private readonly ISiteRepository siteRepository;
        private readonly ICommitIdRepository commitIdRepository;
        private Dictionary<string, DeploymentPlan> deploymentPlans = new Dictionary<string, DeploymentPlan>();
        private Dictionary<string, string> jenkinsNameSiteMapping;
        private Dictionary<DeploymentPlanName, HashSet<string>> siteGroups;

        public DeployToolForm(ISiteRepository siteRepository, ICommitIdRepository commitIdRepository)
        {
            this.siteRepository = siteRepository;
            this.commitIdRepository = commitIdRepository;
            InitializeComponent();
            InitializeSiteGroups();
        }
        private void InitializeSiteGroups()
        {
            jenkinsNameSiteMapping = siteRepository.GetSitesFromMapping();
            siteGroups = new Dictionary<DeploymentPlanName, HashSet<string>>
{
    { DeploymentPlanName.CreditFrontendBackend, new HashSet<string>
        {
            "Mg.Credit.Api.Admin",
            "Mg.Credit.Api.Navigation",
            "Mg.Credit.Api.Player",
            "Mg.Credit.Web.Admin",
            "Mg.Credit.Web.Navigation",
            "Mg.Credit.Web.Player",
            "Mg.Credit.Worker.Maintain"
        }
    },
    { DeploymentPlanName.SlotGameBackend, new HashSet<string>
        {
            "Mg.Lobby.Player.Api",
            "Mg.Lobby.Backoffice.Api",
            "Mg.Game.PocketGames.Backoffice.Api",
            "Mg.Game.PragmaticPlay.Backoffice.Api",
            "Mg.Supplier.PragmaticPlay.Api",
            "Mg.Supplier.PocketGames.Api",
            "Mg.Supplier.PocketGames.Api.Amb",
            "Mg.Supplier.PragmaticPlay.Worker",
            "Mg.Supplier.SlotGame.Worker.Report"
        }
    },
    { DeploymentPlanName.SlotGameFrontEnd, new HashSet<string>
        {
            "Mg.Lobby.Player.Web",//前台玩家大廳
            "Mg.Game.PocketGames.Backoffice.Web",//後台管理站點-PG
            "Mg.Game.PragmaticPlay.Backoffice.Web",//後台管理站點-PP
            "Mg.Lobby.Backoffice.Web",//後台管理大廳         
        }
    }
};
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // 获取当前程序集
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            // 将版本号添加到窗体的标题栏
            this.Text = $"發版工具 - Version {version}";

            var date = DateTime.Now.ToString("yyyy.MM.dd");

            txtPublishEnvironment.Text = $"[stage/s1][IDC][预生产] {date}";

            InitializePublishSites();

            var commit  = commitIdRepository.GetAllLatestCommitHash();
            foreach (var kvp in commit)
            {
                if (kvp.Key == DeploymentPlanName.CreditFrontendBackend)
                {
                    textBoxCreditFrontendBackendCommitId.Text = kvp.Value;
                }
                else if (kvp.Key == DeploymentPlanName.SlotGameBackend)
                {
                    textBoxSlotGameBackendCommitId.Text = kvp.Value;
                }
                else if (kvp.Key == DeploymentPlanName.SlotGameFrontEnd)
                {
                    textBoxSlotGameFrontendCommitId.Text = kvp.Value;
                }
            }
        }

        private void InitializePublishSites()
        {
            // 清空CheckedListBox以確保開始時是空的
            chkListBoxPublishSites.Items.Clear();

            var sites = siteRepository.GetAllSites();
            chkListBoxPublishSites.Items.AddRange(sites.Select(x => x.Name).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> jenkinsNameSiteMapping = siteRepository.GetSitesFromMapping();

            // 使用字典來存儲不同系統的 CommitId 和 Rollback CommitId
            var commitIdDictionary = new Dictionary<DeploymentPlanName, Tuple<string, string>>
{
    {
        DeploymentPlanName.CreditFrontendBackend,
        new Tuple<string, string>(
            textBoxCreditFrontendBackendCommitId.Text,        // Deploy CommitId
            textBoxCreditFrontendBackendRollbackCommitId.Text // Rollback CommitId
        )
    },
    {
        DeploymentPlanName.SlotGameFrontEnd,
        new Tuple<string, string>(
            textBoxSlotGameFrontendCommitId.Text,             // Deploy CommitId
            textBoxSlotGameFrontendRollbackCommitId.Text      // Rollback CommitId
        )
    },
    {
        DeploymentPlanName.SlotGameBackend,
        new Tuple<string, string>(
            textBoxSlotGameBackendCommitId.Text,              // Deploy CommitId
            textBoxSlotGameBackendRollbackCommitId.Text       // Rollback CommitId
        )
    }
};

            var deploymentPlans = new List<DeploymentPlan>();

            // 將站點添加到相應的更新組
            foreach (var site in chkListBoxPublishSites.CheckedItems)
            {
                var siteString = site.ToString();

                foreach (var siteGroup in siteGroups)
                {
                    if (siteGroup.Value.Contains(siteString))
                    {
                        var deploymentPlan = deploymentPlans.FirstOrDefault(x => x.Name == siteGroup.Key);
                        if (deploymentPlan is null)
                        {
                            deploymentPlan = new DeploymentPlan(siteGroup.Key, new List<Site>() { new Site(siteString, jenkinsNameSiteMapping[siteString]) },
                                new CommitId(commitIdDictionary[siteGroup.Key].Item1, commitIdDictionary[siteGroup.Key].Item2));
                            deploymentPlans.Add(deploymentPlan);
                        }
                        else 
                        {
                            deploymentPlan.AddSite(new Site(siteString, jenkinsNameSiteMapping[siteString]));
                        }

                    }
                }
            }

            // 建立更新步驟
            var updateSteps = new StringBuilder();
            updateSteps.AppendLine("登入 http://192.168.51.203:8080/ 飛速Jenkins主機");

            foreach (var deploymentPlan in deploymentPlans)
            {
                deploymentPlan.AddUpdateSteps(updateSteps);
            }

            // 建立異動站點的描述
            var updateSite = new StringBuilder();
            foreach (var deploymentPlan in deploymentPlans)
            {
                deploymentPlan.AddUpdateSite(updateSite);
            }

            // 建立發布版本
            var deployVersion = new StringBuilder();
            foreach (var deploymentPlan in deploymentPlans)
            {
                deploymentPlan.AddDeployVersion(deployVersion);
            }


            // 建立發布版本
            var rollbackSteps = new StringBuilder();
            rollbackSteps.AppendLine("重新按照發布流程以以下Commit ID重新發布");
            foreach (var deploymentPlan in deploymentPlans)
            {
                deploymentPlan.AddRollbackSteps(rollbackSteps);
            }


            // 最終輸出
            var finalUpdateSteps = new StringBuilder();
            finalUpdateSteps.AppendLine("【發布環境】");
            finalUpdateSteps.AppendLine(txtPublishEnvironment.Text);
            finalUpdateSteps.AppendLine("【發布時間】");
            finalUpdateSteps.AppendLine("可立即執行");
            finalUpdateSteps.AppendLine("【異動項目】");
            finalUpdateSteps.AppendLine(txtChangeItem.Text);
            finalUpdateSteps.AppendLine("【發布版本】");
            finalUpdateSteps.Append(deployVersion);
            finalUpdateSteps.AppendLine("【異動站點】");
            finalUpdateSteps.Append(updateSite.ToString());
            finalUpdateSteps.AppendLine("【更新步驟】");
            finalUpdateSteps.Append(updateSteps.ToString());
            finalUpdateSteps.AppendLine("【回滾步驟】");
            finalUpdateSteps.Append(rollbackSteps.ToString());

            // 定義輸出的檔案路徑
            string outputPath = "update_steps.txt";

            // 將字串寫入檔案
            File.WriteAllText(outputPath, finalUpdateSteps.ToString());

            MessageBox.Show("操作已成功完成！", "成功");

        }

    }
}
