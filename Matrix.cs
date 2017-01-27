using System;
using System.Xml.Serialization;

namespace CSC316_Assignment1
{
    public class Matrix
    {
        private int rows, cols;
        private float[][] data;

        [XmlArray(ElementName = "data")]
        [XmlArrayItem(ElementName = "row", NestingLevel = 0)]
        [XmlArrayItem(ElementName = "col", NestingLevel = 1)]
        public float[][] Data
        {
            get { return data; }
            set
            {
                data = value;
                rows = data.Length;
                cols = data[0].Length;
            }
        }

        public Matrix()
            : this(4, 4)
        {
        }

        public Matrix(int r, int c)
        {
            if (r <= 0 || c <= 0)
            {
                throw new ArgumentException("Matrix dimensions cannot be zero or less.");
            }

            rows = r;
            cols = c;
            data = new float[rows][];
            for (int i = 0; i < rows; i++)
            {
                data[i] = new float[cols];
            }
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == j)
                        data[i][j] = 1.0f;
                    else
                        data[i][j] = 0.0f;
                }
            }
        }

        public static Matrix operator+(Matrix A, Matrix B)
        {
            if (A.rows != B.rows || A.cols != B.cols)
            {
                throw new ArgumentException("Matrix dimensions do not match");
            }

            Matrix C = new Matrix();

            for (int i = 0; i < A.rows; i++)
            {
                for (int j = 0; j < A.cols; j++)
                {
                    if (i == j)
                    {
                        C.data[i][j] = A.data[i][j] + B.data[i][j];
                    }
                }
            }

            return C;
        }

        public static Matrix operator*(Matrix A, Matrix B)
        {
            if (A.cols != B.rows)
            {
                throw new ArgumentException("Invalid matrix dimensions: Matrix A's # of cols must match Matrix B's # of rows");
            }

            Matrix C = new Matrix(A.rows, B.cols);

            for (int i = 0; i < A.rows; i++)
            {
                for (int j = 0; j < B.cols; j++)
                {
                    float val = 0;
                    for (int k = 0; k < A.cols; k++)
                    {
                        val += A.Data[i][k] * B.data[k][j];
                    }

                    C.Data[i][j] = val;
                }
            }

            return C;
        }

        public override string ToString()
        {
            string output = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    output += data[i][j] + "\t";
                }

                output += "\n";
            }

            return output;
        }

        public static Matrix Translate(float x, float y, float z)
        {
            Matrix translateMatrix = new Matrix();
            translateMatrix.Data[0][3] = x;
            translateMatrix.Data[1][3] = y;
            translateMatrix.Data[2][3] = z;
            return translateMatrix;
        }

        public static Matrix Scale(float s)
        {
            Matrix scaleMatrix = new Matrix();

            scaleMatrix.Data[0][0] = s;
            scaleMatrix.Data[1][1] = s;
            scaleMatrix.Data[2][2] = s;

            return scaleMatrix;
        }

        public static Matrix RotateX(double radian)
        {
            Matrix rotateMatrix = new Matrix();

            rotateMatrix.Data[1][1] = (float)Math.Cos(radian);
            rotateMatrix.Data[1][2] = -(float)Math.Sin(radian);
            rotateMatrix.Data[2][1] = (float)Math.Sin(radian);
            rotateMatrix.Data[2][2] = (float)Math.Cos(radian);

            return rotateMatrix;
        }

        public static Matrix RotateY(double radian)
        {
            Matrix rotateMatrix = new Matrix();

            rotateMatrix.Data[0][0] = (float)Math.Cos(radian);
            rotateMatrix.Data[0][2] = (float)Math.Sin(radian);
            rotateMatrix.Data[2][0] = -(float)Math.Sin(radian);
            rotateMatrix.Data[2][2] = (float)Math.Cos(radian);

            return rotateMatrix;
        }

        public static Matrix RotateZ(double radian)
        {
            throw new NotImplementedException();
        }
    }
}
