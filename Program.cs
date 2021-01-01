using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace wordlist_gen {
    class Program {

        /// <summary>
        /// Generate all possible combinations with char array with the specified length
        /// </summary>
        /// <param name="characters">Single char or char array</param>
        /// <param name="length">Output string length</param>
        /// <returns></returns>
        public static IEnumerable<String> GenerateStrings( IEnumerable<char> characters, int length ) {
            if( length > 0 ) {
                foreach( char c in characters ) {
                    foreach( String suffix in GenerateStrings( characters, length - 1 ) ) {
                        yield return c + suffix;
                    }
                }
            } else {
                yield return string.Empty;
            }
        }

        List<string> vrbs = new List<string>();

        static string Path = @"wordlist-" + DateTime.Now.ToString( "ddMMyyyy" ) + ".txt";

        static void Main( string[] args ) {


            string k, un, us;
            int len;

            Console.WriteLine( "-- Bem vindo ao gerador de wordlist --" );
            Console.WriteLine( "por Soly (github.com/CoderDias)" );
            Console.WriteLine( "" );

            Console.WriteLine( "Digite a palavra base:" );
            k = Console.ReadLine();

            Console.WriteLine( "Deseja incluir numeros? (y/n):" );
            un = Console.ReadLine();

            Console.WriteLine( "Deseja incluir simbolos? (y/n):" );
            us = Console.ReadLine();

            Console.WriteLine( "Qual o tamanho da senha desejada? (1-100):" );
            len = Int32.Parse( Console.ReadLine() );

            CalcEstimated( k, un, us, len );

            string r = "n";

            while( r != "y" ) {
                Console.WriteLine( "Deseja iniciar a gerar a wordlist? (y/n):" );
                r = Console.ReadLine();
            }

            Console.WriteLine( "Criação de wordlist iniciada, por favor aguarde..." );

            Generate( k, un, us, len );

            Console.WriteLine( "Pressione [Enter] para sair." );

            while( Console.ReadLine() != "" ) {
                Console.WriteLine( "Pressione [Enter] para sair." );
            }
        }

        public static void Generate(string k, string un, string us, int len) {
            string t = k;

            if( un == "y" || un == "Y" )
                t += "1234567890";

            if( us == "y" || un == "Y" )
                t += "!@#$%¨&*()-_=+~[]{}";

            char[] b = t.ToCharArray();
            int B = len;

            File.WriteAllLines( Path, GenerateStrings( b, B ) );

            Console.WriteLine( "Concluido!" );
        }

        private static void CalcEstimated( string k, string un, string us, int len ) {
            string t = k;

            if( un == "y" || un == "Y" )
                t += "1234567890";

            if( us == "y" || un == "Y" )
                t += "!@#$%¨&*()-_=+~[]{}";

            int t1 = t.Length;
            int t2 = len;


            long tr = (long)Math.Pow( (double)t1, (double)t2 );

            Console.WriteLine("Estimated words: " + tr.ToString());
        }
    }
}
