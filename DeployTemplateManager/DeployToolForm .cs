using System.Text;

namespace DeployTemplateManager
{
    public partial class DeployToolForm : Form
    {
        public DeployToolForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 获取当前程序集
            var version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            // 将版本号添加到窗体的标题栏
            this.Text = $"發版工具 - Version {version}";

            var date = DateTime.Now.ToString("yyyy.MM.dd");

            txtPublishEnvironment.Text = $"[stage/s1][IDC][预生产] {date}";


            // 清空CheckedListBox以確保開始時是空的
            chkListBoxPublishSites.Items.Clear();

            // 定義需要添加到CheckedListBox的站點列表
            string[] publishSites = new string[]
            {
                "Mg.Credit.Api.Admin",
                "Mg.Credit.Api.Navigation",
                "Mg.Credit.Api.Player",
                "Mg.Credit.Web.Admin",
                "Mg.Credit.Web.Navigation",
                "Mg.Credit.Web.Player",
                "Mg.Credit.Worker.Maintain",
                "Mg.Lobby.Player.Api",
                "Mg.Lobby.Backoffice.Api",
                "Mg.Game.PocketGames.Backoffice.Api",
                "Mg.Game.PragmaticPlay.Backoffice.Api",
                "Mg.Supplier.PragmaticPlay.Api",
                "Mg.Supplier.PocketGames.Api",
                "Mg.Supplier.PocketGames.Api.Amb",
                "Mg.Supplier.PragmaticPlay.Worker",
                "Mg.Supplier.SlotGame.Worker.Report"
            };

            // 添加站點到CheckedListBox
            foreach (var site in publishSites)
            {
                chkListBoxPublishSites.Items.Add(site, false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sitesToUpdate = new Dictionary<string, List<string>>();


            // 使用字典來存儲不同系統的 CommitId 和 Rollback CommitId
            var commitIdDictionary = new Dictionary<string, Tuple<string, string>>
{
    {
        "Credit Frontend, Backend",
        new Tuple<string, string>(
            textBoxCreditFrontendBackendCommitId.Text,        // Deploy CommitId
            textBoxCreditFrontendBackendRollbackCommitId.Text // Rollback CommitId
        )
    },
    {
        "SlotGame FrontEnd",
        new Tuple<string, string>(
            textBoxSlotGameFrontendCommitId.Text,             // Deploy CommitId
            textBoxSlotGameFrontendRollbackCommitId.Text      // Rollback CommitId
        )
    },
    {
        "SlotGame Backend",
        new Tuple<string, string>(
            textBoxSlotGameBackendCommitId.Text,              // Deploy CommitId
            textBoxSlotGameBackendRollbackCommitId.Text       // Rollback CommitId
        )
    }
};

            Dictionary<string, string> jenkinsNameSiteMapping = new Dictionary<string, string>()
{
    {"Mg.Credit.Api.Admin", "Mg_Credit_Api_Admin"},
    {"Mg.Credit.Api.Navigation", "Mg_Credit_Api_Navigation"},
    {"Mg.Credit.Api.Player", "Mg_Credit_Api_Player"},
    {"Mg.Credit.Web.Admin", "Mg_Credit_Web_Admin"},
    {"Mg.Credit.Web.Navigation", "Mg_Credit_Web_Navigation"},
    {"Mg.Credit.Web.Player", "Mg_Credit_Web_Player"},
    {"Mg.Credit.Worker.Maintain", "Mg_Credit_Worker_Maintain"},
    {"Mg.Lobby.Player.Api", "Mg_Lobby_Player_Api"},
    {"Mg.Lobby.Backoffice.Api", "Mg_Lobby_Backoffice_Api"},
    {"Mg.Game.PocketGames.Backoffice.Api", "Mg_Game_PocketGames_Backoffice_Api"},
    {"Mg.Game.PragmaticPlay.Backoffice.Api", "Mg_Game_PragmaticPlay_Backoffice_Api"},
    {"Mg.Supplier.PragmaticPlay.Api", "Mg_Supplier_PragmaticPlay_Api"},
    {"Mg.Supplier.PocketGames.Api", "Mg_Supplier_PocketGames_Api"},
    {"Mg.Supplier.PocketGames.Api.Amb", "Mg_Supplier_PocketGames_Api_Amb"},
    {"Mg.Supplier.PragmaticPlay.Worker", "Mg_Supplier_PragmaticPlay_Worker"},
    {"Mg.Supplier.SlotGame.Worker.Report", "Mg_Supplier_SlotGame_Worker_Report"}
};

            var siteGroups = new Dictionary<string, HashSet<string>>
{
    { "Credit Frontend, Backend", new HashSet<string>
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
    { "SlotGame Backend", new HashSet<string>
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
    }
};

            // 將站點添加到相應的更新組
            foreach (var site in chkListBoxPublishSites.CheckedItems)
            {
                var siteString = site.ToString();

                foreach (var siteGroup in siteGroups)
                {
                    if (siteGroup.Value.Contains(siteString))
                    {
                        if (!sitesToUpdate.TryGetValue(siteGroup.Key, out var existingList))
                        {
                            existingList = new List<string>();
                            sitesToUpdate[siteGroup.Key] = existingList;
                        }
                        existingList.Add(siteString);
                    }
                }
            }

            // 建立更新步驟
            var updateSteps = new StringBuilder();
            updateSteps.AppendLine("登入 http://192.168.51.203:8080/ 飛速Jenkins主機");

            foreach (var sites in sitesToUpdate)
            {
                updateSteps.AppendLine($"#Deploy {sites.Key} -> stage/s1 -> 帶參數建置 -> 勾選以下選項");

                for (int i = 0; i < sites.Value.Count; i++)
                {
                    if (jenkinsNameSiteMapping.TryGetValue(sites.Value[i], out var jenkinsName))
                    {
                        updateSteps.AppendLine($"{i + 1}. {jenkinsName}");
                    }
                    else
                    {
                        updateSteps.AppendLine($"{i + 1}. {sites.Value[i]} (未找到對應的Jenkins名稱)");
                    }
                }
                var commit = commitIdDictionary[sites.Key].Item1;
                updateSteps.AppendLine($"# 輸入Commit ID: {commit}");
                updateSteps.AppendLine("選擇MachineGroup -> All");
                updateSteps.AppendLine("按下建置");
            }

            // 建立異動站點的描述
            var updateSite = new StringBuilder();
            foreach (var sites in sitesToUpdate)
            {
                foreach (var site in sites.Value)
                {
                    if (jenkinsNameSiteMapping.TryGetValue(site, out var jenkinsName))
                    {
                        updateSite.AppendLine($"#[Deploy {sites.Key}][{jenkinsName}]站點");
                    }
                    else
                    {
                        updateSite.AppendLine($"#[Deploy {sites.Key}][{site}]站點 (未找到對應的Jenkins名稱)");
                    }
                }
            }

            // 建立發布版本
            var deployVersion = new StringBuilder();
            foreach (var sites in sitesToUpdate)
            {
                deployVersion.AppendLine($"Deploy {sites.Key} CommitId：");
                deployVersion.AppendLine(commitIdDictionary[sites.Key].Item1);
            }

            // 建立發布版本
            var rollbackSteps = new StringBuilder();
            rollbackSteps.AppendLine("重新按照發布流程以以下Commit ID重新發布");
            foreach (var sites in sitesToUpdate)
            {
                rollbackSteps.AppendLine($"Deploy {sites.Key} CommitId：");
                rollbackSteps.AppendLine(commitIdDictionary[sites.Key].Item2);
            }

            // 最終輸出
            var finalUpdateSteps = new StringBuilder();
            finalUpdateSteps.AppendLine("【發布環境】");
            finalUpdateSteps.AppendLine(txtPublishEnvironment.Text);
            finalUpdateSteps.AppendLine("【發布時間】");
            finalUpdateSteps.Append("可立即執行");
            finalUpdateSteps.AppendLine("【異動項目】");
            finalUpdateSteps.Append(txtChangeItem.Text);
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
