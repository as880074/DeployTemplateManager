using DeployTemplateManager.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployTemplateManager.Interfaces.Serivces
{
    public interface IDeploymentService
    {
        public string CreateDeploymentPlan(DeploymentPlan plan);
    }
}
