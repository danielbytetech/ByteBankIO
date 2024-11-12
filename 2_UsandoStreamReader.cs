using System;
using System.IO;

namespace ByteBankIO
{
    partial class Program
    {
        static void LidandoComStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                // Le a apenas uma unica linha
                //var linha = leitor.ReadLine();

                // Le o arquivo todo de uma só vez (não é uma boa pratica)
                //var texto = leitor.ReadToEnd();

                // Le em byte a primeira linha
                //var numero = leitor.Read();

                // Le o arquivo em todo carregando parte por parte ou carregando em fluxo (uma boa pratica)
                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    var msg = $"{contaCorrente.Titular.Nome} : Conta número {contaCorrente.Numero}, ag {contaCorrente.Agencia}, Saldo {contaCorrente.Saldo}";
                    Console.WriteLine(msg);
                }

            }
            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            // 375,4644,2483.13,Jonatan Silva
            var campos = linha.Split(','); // Quebra minha string em fragmentos (substrings) fazendo um campos a cada ',' encontrada

            var agencia = campos[0];
            var numero = campos[1];
            var saldo = campos[2].Replace('.', ','); // Faz uma troca de caracteres 
            var nomeTitular = campos[3];

            var agenciaComInt = int.Parse(agencia);
            var numeroComInt = int.Parse(numero);
            var saldoComDouble = double.Parse(saldo);

            var titular = new Cliente();
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
            resultado.Depositar(saldoComDouble);
            resultado.Titular = titular;

            return resultado;
        }
    }
}
