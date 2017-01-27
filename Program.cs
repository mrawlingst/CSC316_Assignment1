using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace CSC316_Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
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
                return;
            }

            while (true)
            {
                var expressionInput = "";
                Console.Write("Enter expression (q to quit): ");
                expressionInput = Console.ReadLine();

                if (Regex.Matches(expressionInput, @"q(uit)?$").Count > 0)
                    break;
            }
        }
    }
}
