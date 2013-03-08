#region Using Statements
using System;
using WaveEngine.Common;
using WaveEngine.Common.Graphics;
using WaveEngine.Common.Input;
using WaveEngine.Common.Math;
using WaveEngine.Components.Cameras;
using WaveEngine.Components.Graphics2D;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;
using WaveEngine.Framework.UI;
#endregion

namespace PongProject
{
    public class MainScene : Scene
    {

        private const int LEFT_PADDLE_STARTING_X = 30;
        private const int RIGHT_PADDLE_STARTING_X = 770;
        private const int PADDLE_STARTING_Y = 300;
        private const int BALL_STARTING_X = 385;
        private const int BALL_STARTING_Y = 285;

        private const string PADDLE_FILENAME = "Content/paddle.wpk";
        private const string BALL_FILENAME = "Content/ball.wpk";
        private const string WALL_FILENAME = "Content/wall.wpk";
        
        private int score = 0;

        protected override void CreateScene()
        {
            //Set up game engine stuff.
            RenderManager.BackgroundColor = Color.CornflowerBlue;
            PhysicsManager.Gravity2D = new Vector2(0, 0);

            //Initialize UI entities.
            TextBlock scoreText = new TextBlock()
            {
                Text = "Score: " + score,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 30, 0, 0)
            };

            //Initialize in-game entities.
            Entity ball = this.CreateCircularSprite("Ball", BALL_STARTING_X, BALL_STARTING_Y, BALL_FILENAME, false)
                .AddComponent(new BallBehavior(scoreText));
            
            Entity leftPaddle = this.CreateSquareSprite("Left Paddle", LEFT_PADDLE_STARTING_X, PADDLE_STARTING_Y, PADDLE_FILENAME, true).AddComponent(new LeftPaddleBehavior());
            Entity rightPaddle = this.CreateSquareSprite("Right Paddle", RIGHT_PADDLE_STARTING_X, PADDLE_STARTING_Y, PADDLE_FILENAME, true).AddComponent(new ComputerPaddleBehavior(ball.FindComponentOfType<RigidBody2D>()));//RightPaddleBehavior());//

            Entity topWall = this.CreateSquareSprite("Top Wall", 400, 0, WALL_FILENAME, true);
            Entity bottomWall = this.CreateSquareSprite("Bottom Wall", 400, 600, WALL_FILENAME, true);

            //Add UI entities to the entity manager.
            EntityManager.Add(scoreText);

            //Add in-game entities to the entity manager.
            EntityManager.Add(leftPaddle);
            EntityManager.Add(rightPaddle);
            EntityManager.Add(topWall);
            EntityManager.Add(bottomWall);
            EntityManager.Add(ball);

        } 

        
        /// <summary>
        /// Creates a Sprite
        /// </summary>
        /// <param name="name">Sprite Name.</param>
        /// <param name="x">X position.</param>
        /// <param name="y">Y posisition.</param>
        /// <param name="fileName">Sprite filename.</param>
        /// <param name="isKinematic">Physic IsKinetic Sprite Parameter.</param>
        /// <param name="mass">Physic Mass Sprite Parameter.</param>
        /// <returns></returns>
        private Entity CreateSquareSprite(string name, int x, int y, string fileName, bool isKinematic, float mass = 1f)
        {
            Entity sprite = new Entity(name)
                .AddComponent(new Transform2D() { X = x, Y = y })
                .AddComponent(new RectangleCollider())
                .AddComponent(new Sprite(fileName))
                .AddComponent(new RigidBody2D() { IsKinematic = isKinematic, Mass = mass })
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha));
            return sprite;
        }

        /// <summary>
        /// Creates a Sprite
        /// </summary>
        /// <param name="name">Sprite Name.</param>
        /// <param name="x">X position.</param>
        /// <param name="y">Y posisition.</param>
        /// <param name="fileName">Sprite filename.</param>
        /// <param name="isKinematic">Physic IsKinetic Sprite Parameter.</param>
        /// <param name="mass">Physic Mass Sprite Parameter.</param>
        /// <returns></returns>
        private Entity CreateCircularSprite(string name, int x, int y, string fileName, bool isKinematic, float mass = 0f)
        {
            Entity sprite = new Entity(name)
                .AddComponent(new Transform2D() { X = x, Y = y })
                .AddComponent(new CircleCollider())
                .AddComponent(new Sprite(fileName))
                .AddComponent(new RigidBody2D() { IsKinematic = isKinematic, Mass = mass, Friction = 0f, Damping = 0f, Restitution = 1.05f })
                .AddComponent(new SpriteRenderer(DefaultLayers.Alpha));
            return sprite;
        }
    }
    
}
