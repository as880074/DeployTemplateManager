using DeployTemplateManager.Domain.Entities;
using DeployTemplateManager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeployTemplateManager.Repositories
{
    /// <summary>
    /// 管理站點數據和映射的倉庫。
    /// </summary>
    public class SiteRepository : ISiteRepository
    {
        private readonly Dictionary<string, string> _jenkinsNameSiteMapping = new Dictionary<string, string>
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
            {"Mg.Supplier.SlotGame.Worker.Report", "Mg_Supplier_SlotGame_Worker_Report"},
            {"Mg.Lobby.Player.Web", "Mg_Lobby_Player_Web"},
            {"Mg.Game.PocketGames.Backoffice.Web", "Mg_Game_PocketGames_Backoffice_Web"},
            {"Mg.Game.PragmaticPlay.Backoffice.Web", "Mg_Game_PragmaticPlay_Backoffice_Web"},
            {"Mg.Lobby.Backoffice.Web", "Mg_Lobby_Backoffice_Web"}
        };

        /// <summary>
        /// 獲取Jenkins站點名稱與其對應標識符的映射。
        /// </summary>
        public Dictionary<string, string> GetSitesFromMapping() => _jenkinsNameSiteMapping;

        /// <summary>
        /// 獲取所有站點作為Site對象的列表。
        /// </summary>
        public List<Site> GetAllSites()
        {
            // 將字典轉換為Site實體列表
            return _jenkinsNameSiteMapping.Select(kvp => new Site(kvp.Key, kvp.Value)).ToList();
        }
    }
}
