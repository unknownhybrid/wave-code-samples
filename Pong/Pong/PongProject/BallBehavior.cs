using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Math;
using WaveEngine.Components.UI;
using WaveEngine.Framework;
using WaveEngine.Framework.Physics2D;

namespace PongProject
{
    class BallBehavior : Behavior
    {
        private const int BALL_STARTING_X = 385;
        private const int BALL_STARTING_Y = 285;
        private int score;
        public TextBlock scoreText;
        [RequiredComponent]
        public RigidBody2D body;


        public BallBehavior(TextBlock scoreText)
            : base("BallBehavior")
        {
            body = null;
            this.scoreText = scoreText;
            score = 0;
        }
        protected override void Initialize()
        {
            base.Initialize();
            this.body.ApplyLinearImpulse((Helper.randomUnitVector(Helper.VectorFavor.Horizontal) / 10));
            this.scoreText.Text = "Score: " + score;
            //body.OnPhysic2DCollision += (s, o) =>
            //    {
            //        this.body.ApplyLinearImpulse(new Vector2(.05f, .05f));
            //    };
        }
        protected override void Update(TimeSpan gameTime)
        {
            if (body.Transform2D.X < 0 || body.Transform2D.X > 800)
            {
                if (this.body.Transform2D.X < 0) this.scoreText.Text = "Score: " + (score = 0);
                else if (this.body.Transform2D.X > 800) this.scoreText.Text = "Score: " + ++score;
                this.body.ResetPosition(new Vector2(BALL_STARTING_X, BALL_STARTING_Y));
                this.body.ApplyLinearImpulse((Helper.randomUnitVector() / 10));
            }
        }
    }
}
