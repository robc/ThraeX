using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

namespace ThraeX.Platform
{
    public class CommunityGamesTrialService : ITrialService
    {
        #region Strings used for method identification on the GamerPrivileges object
        public static readonly String ALLOW_ONLINE_SESSIONS = "AllowOnlineSessions";
        //public static readonly String ALLOW_COMMUNICATION = "AllowCommunication";
        //public static readonly String ALLOW_PROFILE_VIEWING = "AllowProfileViewing";
        public static readonly String ALLOW_PURCHASE_CONTENT = "AllowPurchaseContent";
        public static readonly String ALLOW_TRADE_CONTENT = "AllowTradeContent";
        //public static readonly String ALLOW_USER_CREATED_CONTENT = "AllowUserCreatedContent";
        #endregion

        SignedInGamerCollection signedInGamers;

        public bool IsTrialMode
        {
            get { return Guide.IsTrialMode; }
        }

        public void ShowMarketplace(PlayerIndex player)
        {
            Guide.ShowMarketplace(player);
        }

        public bool CanUseOnlineSessions(PlayerIndex player)
        {
            return GetBoolGamerPrivilege(player, ALLOW_ONLINE_SESSIONS);
        }

        public bool CanPurchaseContent(PlayerIndex player)
        {
            return GetBoolGamerPrivilege(player, ALLOW_PURCHASE_CONTENT);
        }

        public bool CanTradeContent(PlayerIndex player)
        {
            return GetBoolGamerPrivilege(player, ALLOW_TRADE_CONTENT);
        }

        private bool GetBoolGamerPrivilege(PlayerIndex player, String privilegePropertyName)
        {
            bool result = false;
            signedInGamers = Gamer.SignedInGamers;
            PropertyInfo selectedPrivilege = typeof(GamerPrivileges).GetProperty(privilegePropertyName, typeof(bool));

            foreach (SignedInGamer gamer in signedInGamers)
            {
                if (gamer.PlayerIndex == player)
                {
                    result = (bool)selectedPrivilege.GetValue(gamer.Privileges, null);
                    break;
                }
            }

            return result;
        }
    }
}