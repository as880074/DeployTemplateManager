using DeployTemplateManager.Domain.Entities;
using DeployTemplateManager.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployTemplateManager.Interfaces.Repositories
{
    public interface ISiteRepository
    {
        public Dictionary<string, string> GetSitesFromMapping();
        public List<Site> GetAllSites();

    }
}
