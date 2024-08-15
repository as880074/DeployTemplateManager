using DeployTemplateManager.Domain.Entities;
using DeployTemplateManager.Domain.ValueObjects;
using DeployTemplateManager.Enums;
using DeployTemplateManager.Helpers;
using System.Text;

namespace DeployTemplateManager.Domain.Aggregates
{
    public class DeploymentPlan
    {
        public DeploymentPlan(DeploymentPlanName name, List<Site> sites, CommitId commitId)
        {
            Name = name;
            Sites = sites;
            CommitId = commitId;
        }

        /// <summary>
        /// 方案名稱
        /// </summary>
        public DeploymentPlanName Name { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Site> Sites { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public CommitId CommitId { get; private set; }


        /// <summary>
        /// 新增站點
        /// </summary>
        /// <param name="site"></param>
        public void AddSite(Site site)
        {
            Sites.Add(site);
        }


        public void AddUpdateSteps(StringBuilder updateSteps)
        {
            updateSteps.AppendLine($"#Deploy {Name} -> stage/s1 -> 帶參數建置 -> 勾選以下選項");

            for (int i = 0; i < Sites.Count; i++)
            {
                updateSteps.AppendLine($"{i + 1}. {Sites[i].JenkinsName}");
            }
            var commit = CommitId.DeployId;
            updateSteps.AppendLine($"# 輸入Commit ID: {commit}");
            updateSteps.AppendLine("選擇MachineGroup -> All");
            updateSteps.AppendLine("按下建置");
        }

        public void AddUpdateSite(StringBuilder updateSite)
        {
            foreach (var site in Sites)
            {
                updateSite.AppendLine($"#[Deploy {Name.GetDescription()}][{site.JenkinsName}]站點");
            }
        }

        public void AddDeployVersion(StringBuilder deployVersion)
        {
            deployVersion.AppendLine($"Deploy {Name.GetDescription()} CommitId：");
            deployVersion.AppendLine(CommitId.DeployId);
        }
        public void AddRollbackSteps(StringBuilder rollbackSteps)
        {
            rollbackSteps.AppendLine($"Deploy {Name.GetDescription()} CommitId：");
            rollbackSteps.AppendLine(CommitId.RollbackId);
        }

    }
}
