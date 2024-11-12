using System;
using System.IO;
using System.Text;

namespace ByteBankIO
{
    // Criar esse arquivo permite que eu organize meu código do program.cs, podemos ter um código mais modular e fácil de entender, além de facilitar a colaboração.
    // Partial permite que uma classe seja definida em varios arquivos, como se fosse uma única classe
    partial class Program
    {
        static void LidandoComFileStreamDiretamente()
        {
            // Importo meu arquivo txt
            var enderecoDoArquivo = "contas.txt";

            // uso uma variavel chamando o objeto FileStream para poder manipular o arquivo
            // o using foi utilizado para tratar excessões que podem ocorrer como um arquivo vier null, permitindo que o close seja chamado mesmo com erros
            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                // Para garantir que o loop do while seja executado pelo menos uma vez 
                var numeroDeBytesLidos = -1;

                var buffer = new byte[1024]; // 1Kb

                // quando não houver mais nada de conteudo, ele iria imprimir zeros ou campos vazios até preencer os 1024 espaços da array byte (1kb)
                while (numeroDeBytesLidos != 0)
                {
                    // public override int Read(byte[] array, int offset, int count);
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);

                    Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                    EscreverBuffer(buffer, numeroDeBytesLidos);
                }

                //Devoluções 
                // O numero total de bytes lidos do buffer. Isso podera ser menor que o numero de bytes solicitados se esse 
                // numero de bytes não estiver disponivel no momento, ou zero, se o final do fluxo for atingido

                // finaliza/libera o arquivo 
                fluxoDoArquivo.Close();

                Console.ReadLine();
            }

        }

        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            var utf8 = new UTF8Encoding();

            // public virtual string GetString(byte[] bytes, int index, int count)
            // Quando o buffer termina de ler todos os elementos, os espaços que sobra são preenchidos com dados ja existentes
            // Para que isso não ocorra utilizamos a estrutura do GetString escrito acima para definir
            var texto = utf8.GetString(buffer, 0, bytesLidos);

            Console.Write(texto);

            //foreach(var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }

        #region Exercicio 1
        //var fs = new FileStream("teste.txt", FileMode.Open);

        //var encoding = Encoding.ASCII;

        //var bytesLidos = fs.Read(buffer, 0, 1024);
        //var conteudoArquivo = encoding.GetString(buffer, 0, bytesLidos);

        //Console.Write(conteudoArquivo);
        #endregion
    }
}
