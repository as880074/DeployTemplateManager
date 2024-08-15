using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployTemplateManager.Domain.ValueObjects
{
    /// <param name="DeployId"> 發布版本的 CommitId </param>
    /// <param name="RollbackId"> 退回版本的 CommitId </param>
    public record CommitId(string DeployId, string RollbackId)
    {
        /// <summary>
        /// 發布版本的 CommitId
        /// </summary>
        public string DeployId { get; private set; } = DeployId;

        /// <summary>
        /// 退回版本的 CommitId
        /// </summary>
        public string RollbackId { get; private set; } = RollbackId;
    }
}
