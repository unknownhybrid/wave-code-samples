#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Animation;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;
#endregion

namespace PongProject
{
    class TitleScene : Scene
    {
        TextBlock titleText;
        Button startButton;
        Entity block;

        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.CornflowerBlue;
            CreateUI();
        }
        private void CreateUI()
        {
            titleText = new TextBlock()
            {
                Text = "Pongify",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(15, 0, 0, 60)
            };
            startButton = new Button()
            {
                Text = "Start",
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 90, 0, 0)
            };
            startButton.Click += (s, o) =>
            {
                toMainMenu();
            };
            EntityManager.Add(titleText);
            EntityManager.Add(startButton);
        }
        private void toMainMenu(){
            WaveServices.ScreenLayers.AddScene<MainScene>().Apply();
        }
    }
}
