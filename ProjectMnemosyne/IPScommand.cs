using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMnemosyne
{
    public interface IPScommand
    static void Main()
    {
        try
        {
            // Cria uma instância do processo do PowerShell
            Process process = new Process();

            // Define as propriedades do processo
            process.StartInfo.FileName = "powershell.exe";
            // Especifique o comando que você deseja executar no PowerShell
            process.StartInfo.Arguments = "-Command \"SeuComandoAqui\"";
            // Define que você quer redirecionar a saída padrão
            process.StartInfo.RedirectStandardOutput = true;
            // Define que você quer redirecionar a saída de erro
            process.StartInfo.RedirectStandardError = true;
            // Define que você quer usar a shell do sistema operacional
            process.StartInfo.UseShellExecute = false;
            // Inicia o processo
            process.Start();

            // Lê a saída padrão e a saída de erro e as armazena em variáveis
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            // Aguarda até que o processo termine
            process.WaitForExit();

            // Verifica se houve algum erro
            if (!string.IsNullOrWhiteSpace(error))
            {
                Console.WriteLine("Erro ao executar o comando PowerShell:");
                Console.WriteLine(error);
            }
            else
            {
                Console.WriteLine("Saída do comando PowerShell:");
                Console.WriteLine(output);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ocorreu uma exceção:");
            Console.WriteLine(ex.Message);
        }
    }
}
