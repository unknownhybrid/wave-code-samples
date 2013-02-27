using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Input;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Graphics;
using WaveEngine.Framework.Physics2D;
using WaveEngine.Framework.Services;

namespace PongProject
{
    class PaddleBehavior : Behavior
    {
        private Input input;
        private KeyboardState keyboardState;
        private const float STEP_SIZE = 5;

        [RequiredComponent]
        public RigidBody2D body;

        [RequiredComponent]
        public Transform2D transf;

        public PaddleBehavior()
            : base("PaddleBehavior")
        {
            body = null;
            transf = null;
        }

        protected override void Update(TimeSpan gameTime)
        {
            this.input = WaveServices.Input;

            if (this.input.KeyboardState.IsConnected)
            {
                this.keyboardState = this.input.KeyboardState;

                if (this.keyboardState.Up == ButtonState.Pressed && this.transf.Y > 30 + STEP_SIZE) //the 30 is the height of the top wall
                {
                    this.body.ResetPosition(new Vector2(this.transf.X, this.transf.Y - STEP_SIZE));
                    this.transf.Y = this.transf.Y - STEP_SIZE;

                    // this.RigidBody.LinearVelocity(new Vector2(-STEP, 0));
                }
                else if (this.keyboardState.Down == ButtonState.Pressed && this.transf.Y < 600 - (30 + STEP_SIZE))
                {
                    this.body.ResetPosition(new Vector2(this.transf.X, this.transf.Y + STEP_SIZE));
                    this.transf.Y = this.transf.Y + STEP_SIZE;

                    // this.RigidBody.LinearVelocity(new Vector2(-STEP, 0));
                }
            }
        }
    }
}
