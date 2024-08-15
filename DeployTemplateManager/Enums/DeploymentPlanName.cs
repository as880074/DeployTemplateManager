using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployTemplateManager.Enums
{
    /// <summary>
    /// 方案名稱
    /// </summary>
    public enum DeploymentPlanName
    {
        [Description("Credit Frontend, Backend")]
        CreditFrontendBackend,

        [Description("SlotGame FrontEnd")]
        SlotGameFrontEnd,

        [Description("SlotGame Backend")]
        SlotGameBackend,

        [Description("LiveGame Backend")]
        LiveGameBackend,

        [Description("LiveGame FrontEnd")]
        LiveGameFrontEnd,

    }
}
