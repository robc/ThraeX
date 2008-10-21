using System;
using Microsoft.Xna.Framework;

namespace ThraeX.Platform
{
    class DefaultTrialService : ITrialService
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
        #endregion
    }
}
