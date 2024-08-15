using DeployTemplateManager.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployTemplateManager.Interfaces.Repositories
{
    public interface ICommitIdRepository
    {
        public Dictionary<DeploymentPlanName, string> GetAllLatestCommitHash();
    }
}
