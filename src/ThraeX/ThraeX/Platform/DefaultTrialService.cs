using System;
using Microsoft.Xna.Framework;

namespace ThraeX.Platform
{
    public class DefaultTrialService : ITrialService
    {
        #region ITrialService Members
        public bool IsTrialMode
        {
            get { return false; }
        }

        public void ShowMarketplace(PlayerIndex player)
        {
            ;
        }

        public bool CanPurchaseFullVersion(PlayerIndex player)
        {
            return true;
        }

        public bool CanUseOnlineSessions(PlayerIndex player)
        {
            return true;
        }

        public bool CanUseCommunication(PlayerIndex player)
        {
            return true;
        }

        public bool CanViewProfiles(PlayerIndex player)
        {
            return true;
        }

        public bool CanPurchaseContent(PlayerIndex player)
        {
            return true;
        }

        public bool CanTradeContent(PlayerIndex player)
        {
            return true;
        }

        public bool CanUseUserContent(PlayerIndex player)
        {
            return true;
        }
        #endregion
    }
}
