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
    abstract class PaddleBehavior : Behavior
    {
        protected Input input;
        protected KeyboardState keyboardState;
        protected const float STEP_SIZE = 5;

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

    }
}
