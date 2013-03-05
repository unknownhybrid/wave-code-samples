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
            block = new Entity("Block")
                .AddComponent(new Transform2D())
                .AddComponent(new ImageControl("Content/menubar.wpk")
                {
                    HorizontalAlignment = HorizontalAlignment.Left
                })
                .AddComponent(new ImageControlRenderer(DefaultLayers.Alpha))
                .AddComponent(new AnimationUI());
            EntityManager.Add(titleText);
            EntityManager.Add(startButton);
            EntityManager.Add(block);
        }
        private void toMainMenu(){
            SingleAnimation anim = new SingleAnimation(600f, 0f, 4f, EasingFunctions.Cubic);
            anim.Completed += new EventHandler(OnAnimationCompleted);

            block.FindComponent<AnimationUI>()
                .BeginAnimation(Transform2D.YProperty, anim);
        }
        private void OnAnimationCompleted(object sender, EventArgs e)
        {
            WaveServices.ScreenLayers.AddScene<MainScene>().Apply();
        }
    }
}
