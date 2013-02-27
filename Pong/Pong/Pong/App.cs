using System;

namespace Pong
{
    public class App : WaveEngine.Adapter.Application
    {
        PongProject.Game game;

        public App()
        {
            this.WindowTitle = "Pong";
            Width = 800;
            Height = 600;
        }

        public override void Initialize()
        {
            this.WindowTitle = "Pong";
            game = new PongProject.Game();
            game.Initialize(this.Adapter);
        }

        public override void Update(TimeSpan elapsedTime)
        {
            if (game != null)
            {
                game.UpdateFrame(elapsedTime);
            }
        }

        public override void Draw(TimeSpan elapsedTime)
        {
            if (game != null)
            {
                game.DrawFrame(elapsedTime);
            }
        }
    }
}

