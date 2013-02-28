using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Math;
using WaveEngine.Framework;
using WaveEngine.Framework.Physics2D;

namespace PongProject
{
    class ComputerPaddleBehavior : PaddleBehavior
    {
        Vector2 ballLocation;

        [RequiredComponent]
        RigidBody2D ballbody;

        public ComputerPaddleBehavior(RigidBody2D ballbody)
            : base()
        {
            this.ballbody = ballbody;
        }
        protected override void Update(TimeSpan gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
