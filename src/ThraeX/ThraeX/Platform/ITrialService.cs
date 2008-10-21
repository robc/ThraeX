using System;
using Microsoft.Xna.Framework;

namespace ThraeX.Platform
{
    public interface ITrialService
    {
        bool IsTrialMode { get; }
        void ShowMarketplace(PlayerIndex player);
    }
}
