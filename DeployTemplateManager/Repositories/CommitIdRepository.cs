using DeployTemplateManager.Enums;
using DeployTemplateManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployTemplateManager.Repositories
{
    public class CommitIdRepository: ICommitIdRepository
    {
        // Property to store repository URLs
        public Dictionary<DeploymentPlanName, string> RepoUrls { get; private set; }

        public CommitIdRepository()
        {
            // Initialize the RepoUrls property directly
            RepoUrls = new Dictionary<DeploymentPlanName, string>
            {
                { DeploymentPlanName.CreditFrontendBackend, "http://git.fsoffice.com/mg/credit.git" },
                { DeploymentPlanName.SlotGameBackend, "http://git.fsoffice.com/mg/slotgame-backend.git" },
                { DeploymentPlanName.SlotGameFrontEnd, "http://git.fsoffice.com/mg/slotgame-frontend.git" },
                { DeploymentPlanName.LiveGameBackend, "http://git.fsoffice.com/mg/livegame-backend.git" },
                { DeploymentPlanName.LiveGameFrontEnd, "http://git.fsoffice.com/mg/livegame-frontend.git" }
            };
        }


        public Dictionary<DeploymentPlanName, string> GetAllLatestCommitHash()
        {
            var latestCommitHashes = new Dictionary<DeploymentPlanName, string>();
            foreach (var repo in RepoUrls)
            {
                // Get the latest commit hash for each repository
                var commitHash = GetLatestCommitHash(repo.Value, "stage/s1");
                if (commitHash != null)
                {
                    latestCommitHashes[repo.Key] = commitHash;
                }
            }
            return latestCommitHashes;
        }


        public string GetLatestCommitHash(string repoUrl, string branchName)
        {
            // 構建 git ls-remote 命令
            var processStartInfo = new ProcessStartInfo("git")
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = $"ls-remote {repoUrl} {branchName}"
            };

            try
            {
                using (var process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();

                    // 讀取命令執行結果
                    string result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    if (!string.IsNullOrEmpty(result))
                    {
                        // git ls-remote 輸出格式: <commit-hash>\t<ref>
                        var parts = result.Split('\t');
                        if (parts.Length > 0)
                        {
                            return parts[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                
            }

            return null;
        }
    }
}
