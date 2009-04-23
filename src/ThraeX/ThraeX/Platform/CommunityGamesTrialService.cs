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

        public bool CanUseOnlineSessions(PlayerIndex player)
        {
            signedInGamers = Gamer.SignedInGamers;
            bool canUseOnlineSessions = false;

            foreach (SignedInGamer gamer in signedInGamers)
            {
                if (gamer.PlayerIndex == player && gamer.Privileges.AllowOnlineSessions)
                {
                    canUseOnlineSessions = true;
                    break;
                }
            }

            return canUseOnlineSessions;
        }

        public bool CanUseCommunication(PlayerIndex player)
        {
            signedInGamers = Gamer.SignedInGamers;
            bool canUseCommunication = false;

            foreach (SignedInGamer gamer in signedInGamers)
            {
                if (gamer.PlayerIndex == player && gamer.Privileges.AllowCommunication)
                {
                    canUseCommunication = true;
                    break;
                }
            }

            return canUseCommunication;
        }

        public bool CanViewProfiles(PlayerIndex player)
        {
            signedInGamers = Gamer.SignedInGamers;
            bool canViewProfiles = false;

            foreach (SignedInGamer gamer in signedInGamers)
            {
                if (gamer.PlayerIndex == player && gamer.Privileges.AllowProfileViewing)
                {
                    canViewProfiles = true;
                    break;
                }
            }

            return canViewProfiles;
        }

        public bool CanPurchaseContent(PlayerIndex player)
        {
            signedInGamers = Gamer.SignedInGamers;
            bool canPurchaseContent = false;

            foreach (SignedInGamer gamer in signedInGamers)
            {
                if (gamer.PlayerIndex == player && gamer.Privileges.AllowPurchaseContent)
                {
                    canPurchaseContent = true;
                    break;
                }
            }

            return canPurchaseContent;
        }

        public bool CanTradeContent(PlayerIndex player)
        {
            signedInGamers = Gamer.SignedInGamers;
            bool canTradeContent = false;

            foreach (SignedInGamer gamer in signedInGamers)
            {
                if (gamer.PlayerIndex == player && gamer.Privileges.AllowTradeContent)
                {
                    canTradeContent = true;
                    break;
                }
            }

            return canTradeContent;
        }

        public bool CanUseUserContent(PlayerIndex player)
        {
            signedInGamers = Gamer.SignedInGamers;
            bool canUseUserContent = false;

            foreach (SignedInGamer gamer in signedInGamers)
            {
                if (gamer.PlayerIndex == player && gamer.Privileges.AllowUserCreatedContent)
                {
                    canUseUserContent = true;
                    break;
                }
            }

            return canUseUserContent;
        }
    }
}