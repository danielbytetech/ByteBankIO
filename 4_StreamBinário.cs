using System;
using System.IO;
using System.Text;

namespace ByteBankIO
{    
    partial class Program
    {
        // Metodo que escreve no arquivo criado o caracteres e ints em binario diminuindo espaço na memoria
        static void EscritaBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Create))
            using (var escritor = new BinaryWriter(fs)) // Funciona para diminuir o espaço utilizado na memoria e assim otimiza
            {
                escritor.Write(456);        //número da Agência
                escritor.Write(546544);    //número da conta
                escritor.Write(4000.50);  //Saldo
                escritor.Write("Gustavo Braga");
            }
        }

        // Le o arquivo e imprimi no console as informações decodificadas, diferente do arquivo que foi registrada em binario essas informações
        static void LeituraBinaria()
        {
            using (var fs = new FileStream("contaCorrente.txt", FileMode.Open))
            using (var leitor = new BinaryReader(fs))
            {
                var agencia = leitor.ReadInt32();
                var numeroConta = leitor.ReadInt32();
                var saldo = leitor.ReadDouble();
                var titular = leitor.ReadString();

                Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");
            }
        }
    }
}
