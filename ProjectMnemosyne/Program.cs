using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMnemosyne
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                // Chama o método da classe separada para executar o comando PowerShell


                // Exibe o resultado
                Console.WriteLine(PSCommand.ResetAdAccount("51727724801", "Dnrcelso@@5966"));

                Console.WriteLine("Pressione qualquer tecla para seguir");
                Console.ReadLine();
            }
        }
    }
}

//70733370101