using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rotation
{
    public class EulerAngles
    {
        public float getAlpha() { return alpha; }
        public float getBeta() { return beta; }
        public float getGamma() { return gamma; }

        private float alpha, beta, gamma;

        EulerAngles(float alphaVal, float betaVal, float gammaVal)
        {
            alpha = alphaVal; beta = betaVal; gamma = gammaVal;
        }
    }
}
