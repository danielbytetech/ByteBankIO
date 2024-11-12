using System;
using System.IO;
using System.Text;

namespace ByteBankIO
{
    partial class Program
    {
        static void CriarArquivo()
        {
            // Crio o caminho do arquivo 
            var caminhoNovoArquivo = "contasExportadas.csv";

            // chamo o using para tratamento e modificar o arquivo
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            {
                var contaComoString = "456, 7895, 4785.40, Gustavo Santos";

                // utilizo o enconding como um dicionario para traduzir meus caracteres para a maquina 
                var encoding = Encoding.UTF8;

                // o var de string criado é implementado a GetBytes do encoding que é atribuido na var bytes para coletar a quantidade de bytes da string 
                var bytes = encoding.GetBytes(contaComoString);

                // Por fim chama o metodo Write para escrever a string argumentando os bytes, o index inicial e a quantidade de bytes que serão escritos
                fluxoDeArquivo.Write(bytes, 0, bytes.Length);

            }
        }

        static void CriarArquivoComWriter()
        {
            var caminhoNovoArquivo = "contasExportadas.csv";

            // Utilizando o StreamWriter Facilita mais ainda o processo de escrita do Arquivo 
            using(var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)) // tem o CreateNew mas só é utilizado caso n exista o arquivo
            using(var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.Write("456,65465,456.0,Pedro");
            }
        }        

        static void TestaEscrita()
        {
            var caminhoNovoArquivo = "teste_copia.txt";
             
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                for (int i = 0; i < 100000; i++)
                {
                    escritor.WriteLine($"Linha {i}");
                    escritor.Flush(); // Despeja o buffer para o Stream ou seja o arquivo é atualizado em tempo real

                    Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                    Console.ReadLine();
                }
                                
            }
        }
    }
}