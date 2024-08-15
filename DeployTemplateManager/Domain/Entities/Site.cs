using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployTemplateManager.Domain.Entities
{
    public class Site
    {
        /// <summary>
        /// 站點名稱
        /// </summary>
        public string Name { get; private set; }
        
        /// <summary>
        /// Jenkins 名稱
        /// </summary>
        public string JenkinsName { get; private set; }

        public Site(string name, string jenkinsName)
        {
            Name = name;
            JenkinsName = jenkinsName;
        }
    }
}
