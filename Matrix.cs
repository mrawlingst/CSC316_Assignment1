namespace CSC316_Assignment1
{
    public class Matrix
    {
        private int rows, cols;
        private float[][] data;

        public Matrix()
        {
            rows = cols = 4;
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
            return new Matrix();
        }

        public static Matrix operator-(Matrix A, Matrix B)
        {
            return new Matrix();
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
    }
}
