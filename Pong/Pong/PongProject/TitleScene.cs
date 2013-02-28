#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;
#endregion

namespace PongProject
{
    class TitleScene : Scene
    {
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.CornflowerBlue;
            CreateUI();
        }

        private void CreateUI()
        {
            TextBlock titleText = new TextBlock()
            {
                Text = "Pongify",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(15, 0, 0, 60)
            };
            Button startButton = new Button()
            {
                Text = "Start",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 90, 0, 0)
            };
            startButton.Click += (s, o) =>
            {
                WaveServices.ScreenLayers.AddScene<MainScene>().Apply();
            };
            EntityManager.Add(titleText);
            EntityManager.Add(startButton);
        }
    }
}
