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

                Matrix resultMatrix = new Matrix();
                MatchCollection matches;

                // Translate
                matches = Regex.Matches(expressionInput, @"T\((([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?(\,)?){3}\)");
                foreach (var match in matches)
                {
                    MatchCollection numbers = Regex.Matches(match.ToString(), @"([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?");
                    resultMatrix = resultMatrix * Matrix.Translate(float.Parse(numbers[0].Value), float.Parse(numbers[1].Value), float.Parse(numbers[2].Value));
                }

                // Rotate X
                matches = Regex.Matches(expressionInput, @"RX\((([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?(\,)?){1}\)");
                foreach (var match in matches)
                {
                    MatchCollection numbers = Regex.Matches(match.ToString(), @"([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?");
                    resultMatrix = resultMatrix * Matrix.RotateX(float.Parse(numbers[0].Value));
                }

                // Rotate Y
                matches = Regex.Matches(expressionInput, @"RY\((([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?(\,)?){1}\)");
                foreach (var match in matches)
                {
                    MatchCollection numbers = Regex.Matches(match.ToString(), @"([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?");
                    resultMatrix = resultMatrix * Matrix.RotateX(float.Parse(numbers[0].Value));
                }

                // Rotate Z
                matches = Regex.Matches(expressionInput, @"RZ\((([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?(\,)?){1}\)");
                foreach (var match in matches)
                {
                    MatchCollection numbers = Regex.Matches(match.ToString(), @"([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?");
                    resultMatrix = resultMatrix * Matrix.RotateX(float.Parse(numbers[0].Value));
                }

                // Scale
                matches = Regex.Matches(expressionInput, @"S\((([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?(\,)?){1}\)");
                foreach (var match in matches)
                {
                    MatchCollection numbers = Regex.Matches(match.ToString(), @"([+-])?(0|([1-9][0-9]*))(\.[0-9]+)?");
                    resultMatrix = resultMatrix * Matrix.RotateX(float.Parse(numbers[0].Value));
                }

                if (Regex.Match(expressionInput, @"\*M").Success)
                    resultMatrix = resultMatrix * inputMatrix;

                Console.WriteLine(resultMatrix.ToString());
            }
        }
    }
}
