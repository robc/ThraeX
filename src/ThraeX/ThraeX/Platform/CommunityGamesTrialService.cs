using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;

namespace ThraeX.Platform
{
    public class CommunityGamesTrialService : ITrialService
    {
        SignedInGamerCollection signedInGamers;

        public bool IsTrialMode
        {
            get { return Guide.IsTrialMode; }
        }

        public void ShowMarketplace(PlayerIndex player)
        {
            Guide.ShowMarketplace(player);
        }

        public bool CanPurchaseFullVersion(PlayerIndex player)
        {
            signedInGamers = Gamer.SignedInGamers;
            bool canPurchase = false;
            
            foreach (SignedInGamer gamer in signedInGamers)
            {
                if (gamer.PlayerIndex == player && gamer.Privileges.AllowPurchaseContent)
                {
                    canPurchase = true;
                    break;
                }
            }

            return canPurchase;
        }
    }
}