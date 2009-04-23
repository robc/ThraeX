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

        public bool CanUseOnlineSessions(PlayerIndex player)
        {
            return false;
        }

        public bool CanPurchaseContent(PlayerIndex player)
        {
            return false;
        }

        public bool CanTradeContent(PlayerIndex player)
        {
            return false;
        }
        #endregion
    }
}
