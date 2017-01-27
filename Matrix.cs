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
                    //if (i == j)
                    //    data[i][j] = 1.0f;
                    //else
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
                    for (int k = 0; k < A.cols; k++)
                    {
                        C.Data[i][j] += A.Data[i][k] * B.data[k][j];
                    }
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

        public Matrix Translate(float x, float y, float z)
        {
            Matrix translateMatrix = new Matrix(rows, cols);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0)
                    {
                        translateMatrix.Data[i][j] = x;
                    }

                    if (i == 1)
                    {
                        translateMatrix.Data[i][j] = y;
                    }

                    if (i == 2)
                    {
                        translateMatrix.Data[i][j] = z;
                    }
                }
            }

            return this + translateMatrix;
        }

        public Matrix Scale(float s)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    data[i][j] *= s;
                }
            }

            return this;
        }

        public Matrix Rotate(float x, float y, float z)
        {
            throw new NotImplementedException();
        }
    }
}
