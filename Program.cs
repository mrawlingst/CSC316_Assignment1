using System;
using System.IO;
using System.Xml.Serialization;

namespace CSC316_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Matrix A = new Matrix();
            //Matrix B = new Matrix();
            //Console.WriteLine(A.ToString());
            //Console.WriteLine(B.ToString());

            //Matrix C = A + B;
            //Console.WriteLine(C.ToString());

            //XmlSerializer matrixSerializer = new XmlSerializer(typeof(Matrix));
            //TextWriter matrixWriter = new StreamWriter("matrix.xml");
            //matrixSerializer.Serialize(matrixWriter, C);
            //matrixWriter.Close();

            Console.Write("Enter xml file: ");
            var matrixPath = Console.ReadLine();

            Matrix inputMatrix;
            XmlSerializer matrixSerializer = new XmlSerializer(typeof(Matrix));
            try
            {
                TextReader matrixReader = new StreamReader(matrixPath);
                inputMatrix = (Matrix)matrixSerializer.Deserialize(matrixReader);
                matrixReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not read " + matrixPath);
                Console.WriteLine(e);
                return;
            }

            Console.WriteLine("Enter expression: ");
            var expressionInput = Console.ReadLine();
        }
    }
}
