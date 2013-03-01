using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaveEngine.Common.Math;

namespace PongProject
{
    class Helper
    {
        public static Vector2 randomUnitVector()
        {
            float x = ((float)new Random().Next(0, 100)) / 100f;
            float y = (float)Math.Sqrt((1 - (x*x)));
            x = (new Random().Next(0, 100) > 50) ? -x : x;
            y = (new Random().Next(0, 100) > 50) ? -y : y;
            return new Vector2(x, y);
        }
        public static Vector2 randomUnitVector(VectorFavor favor)
        {
            float x = 0;
            float y = 0;
            Random r = new Random();
            switch (favor)
            {
                case VectorFavor.Horizontal:
                    x = (float)(r.Next(71, 100)) / 100f;
                    y = (float)Math.Sqrt((1 - (x * x)));
                    x = (r.Next(0, 100) > 50) ? -x : x;
                    y = (r.Next(0, 100) > 50) ? -y : y;
                    return new Vector2(x, y);

                case VectorFavor.Vertical:
                    y = (float)(r.Next(71, 100)) / 100f;
                    x = (float)Math.Sqrt((1 - (y * y)));
                    x = (r.Next(0, 100) > 50) ? -x : x;
                    y = (r.Next(0, 100) > 50) ? -y : y;
                    return new Vector2(x, y);

                default:
                    return randomUnitVector();
            }
        }
        /// <summary>
        /// Describes a "favoring" of a particular direction type.
        /// 
        /// <para>Used for generating random vectors.</para>
        /// <para>ex. "Horizontal" makes perfectly vertical vectors impossible.</para>
        /// <para></para>
        /// <para>The current implementation is restrictive, in the sense that it does not cause a linear decrease in
        /// the probability density of the unfavored types. It simply restricts the possibilities at pi/2 rad
        /// intervals.</para>
        /// <para>ex. If Horizontal were picked, the only possible resulting "random" vectors would come from the ranges
        /// 0 -> pi/4, 3pi/4 -> 5pi/4, and then 7pi/4 -> 2pi.</para>
        /// </summary>
        public enum VectorFavor
        {
            Horizontal, Vertical
        }
    }
    
}
