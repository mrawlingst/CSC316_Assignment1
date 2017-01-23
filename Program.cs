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

            Console.Write("Enter xml file: ");
            var matrixPath = Console.ReadLine();

            Matrix inputMatrix;
            XmlSerializer matrixSerializer = new XmlSerializer(typeof(Matrix));

            //Matrix C = new Matrix();
            //TextWriter matrixWriter = new StreamWriter("matrix.xml");
            //matrixSerializer.Serialize(matrixWriter, C);
            //matrixWriter.Close();

            try
            {
                TextReader matrixReader = new StreamReader(matrixPath);
                inputMatrix = (Matrix)matrixSerializer.Deserialize(matrixReader);
                matrixReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not read " + matrixPath);
                //Console.WriteLine(e);
                return;
            }

            while (true)
            {
                var expressionInput = "";
                Console.Write("Enter expression (q to quit): ");
                expressionInput = Console.ReadLine();

                if (expressionInput == "q" || expressionInput == "quit")
                    break;
            }
        }
    }
}
