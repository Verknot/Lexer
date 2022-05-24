using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Lexer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string sample;

            string path = @"D:\C#\lexer\Lexer\Lexer\Code.txt";

            using (FileStream fstream = File.OpenRead(path))
            {
               
                byte[] buffer = new byte[fstream.Length];
               
                await fstream.ReadAsync(buffer, 0, buffer.Length);
               
                string textFromFile = Encoding.Default.GetString(buffer);

                sample = textFromFile;

            }




            var defs = new TokenDefinition[]
            {
           
                new TokenDefinition(@"([""'])(?:\\\1|.)*?\1", "STRING"),
                new TokenDefinition(@"[-+]?\d*\.\d+([eE][-+]?\d+)?", "DOUBLE"),
                new TokenDefinition(@"[-+]?\d+", "INT"),
                new TokenDefinition(@"#t", "TRUE"),
                new TokenDefinition(@"#f", "FALSE"),
                new TokenDefinition(@"int", "INTS"),
                new TokenDefinition(@"double", "DOUBLE"),
                new TokenDefinition(@"[*<>\?\-+/A-Za-z->!]+", "SYMBOL"),
                new TokenDefinition(@"\.", "DOT"),
                new TokenDefinition(@"\(", "LEFT"),
                new TokenDefinition(@"\)", "RIGHT"),
                new TokenDefinition(@"\s", "SPACE"),
                new TokenDefinition(@"=", "OPEquals"),
                new TokenDefinition(@"+", "OPPLUS"),
                new TokenDefinition(@"-", "OPMINUS"),
                new TokenDefinition(@";", "END"),

               

            };



            Console.WriteLine(sample);
            TextReader r = new StringReader(sample);
            Lexer l = new Lexer(r, defs);
            while (l.Next())
                Console.WriteLine("Token: {0} Contents: {1}", l.Token, l.TokenContents);
        }
    }
}
