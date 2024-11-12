using System;
using System.IO;
using System.Text;

namespace ByteBankIO
{
    partial class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Digite seu nome: ");
            //var nome = Console.ReadLine();

            var linhas = File.ReadAllLines("contas.txt");
            Console.WriteLine(linhas.Length);

            //foreach(var linha in linhas)
            //{
            //    Console.WriteLine(linha);
            //}

            var bytesArquivo = File.ReadAllBytes("contas.txt");
            Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes");

            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText");

            Console.WriteLine("Aplicação Finalizada ...");

            Console.ReadLine();

            #region Exercico 1
            //var arquivoOriginal = new FileStream("teste.txt", FileMode.Open);
            //var arquivoNovo = new FileStream("teste_copia.txt", FileMode.Create);
            //var buffer = new byte[1024];

            //using (arquivoOriginal)
            //using (arquivoNovo)
            //{
            //    // Funciona como um copia e cola 
            //    var bytesLidos = -1;
            //    while (bytesLidos != 0)
            //    {
            //        bytesLidos = arquivoOriginal.Read(buffer, 0, 1024);
            //        arquivoNovo.Write(buffer, 0, bytesLidos);
            //    }

            //    // aqui ele escreve normalmente 
            //    var rodape = Encoding.UTF8.GetBytes("Este documento é uma cópia do original");
            //    arquivoNovo.Write(rodape, 0, rodape.Length);
            //}
            #endregion
        }

    }
}
