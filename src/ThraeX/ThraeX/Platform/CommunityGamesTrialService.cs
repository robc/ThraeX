using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

namespace ThraeX.Platform
{
    public class CommunityGamesTrialService : ITrialService
    {
        public bool IsTrialMode
        {
            get { return Guide.IsTrialMode; }
        }

        public void ShowMarketplace(PlayerIndex player)
        {
            Guide.ShowMarketplace(player);
        }
    }
}