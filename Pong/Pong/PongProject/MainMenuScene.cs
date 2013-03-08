using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Animation;
using WaveEngine.Framework.Graphics;

namespace PongProject
{
    class MainMenuScene : Scene
    {
        Entity menuBar;
        protected override void CreateScene()
        {
            RenderManager.BackgroundColor = Color.CornflowerBlue;
            CreateUI();
        }
        private void CreateUI()
        {
            menuBar = new Entity("Menu Bar")
                .AddComponent(new ImageControl("Content/menubar.wpk"))
                .AddComponent(new ImageControlRenderer(DefaultLayers.Alpha))
                .AddComponent(new Transform2D
                {
                    X = 0,
                    Y = 600
                })
                .AddComponent(new AnimationUI());

            EntityManager.Add(menuBar);
        }
    }
}
