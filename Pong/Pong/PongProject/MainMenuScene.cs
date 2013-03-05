using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Graphics;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Framework;
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
                .AddComponent(new Sprite("Content/menubar.wpk"))
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha));
        }
    }
}
