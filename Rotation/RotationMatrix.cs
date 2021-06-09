using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rotation
{
    class RotationMatrix
    {
        private float[] _matrixData = new float[16];

        public RotationMatrix(float[] matrixDataVal)
        {
            for (int i = 0; i < 16; i++) _matrixData[i] = matrixDataVal[i];
        }

        public float getMatrixData(int i) { return _matrixData[i]; }
    }
}
