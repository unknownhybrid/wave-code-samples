#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
#endregion

namespace PongProject
{
    public class Game : WaveEngine.Framework.Game
    {
        public override void Initialize(IAdapter adapter)
        {
            base.Initialize(adapter);

            ScreenLayers screenLayers = WaveServices.ScreenLayers;
            screenLayers.AddScene<MainScene>();
            screenLayers.Apply();

        }
    }
}
