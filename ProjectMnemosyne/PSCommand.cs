using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMnemosyne
{
    public class PSCommand
    {
        //Comando de aquisição de usuario bloqueados.
        public static string GetLockedOut()
        {
            return ExecuteCommand("search-adaccount -lockedout");
        }
        //Comando para desbloqueio de usuario.
        public static string UnlockAdAccount(string usuario)
        {
            return ExecuteCommand($"Unlock-AdAccount -identity {usuario}");
        }
        public static string ResetAdAccount(string usuario, string senha)
        {
            return ExecuteCommand($"Set-ADAccountPassword -Identity {usuario} -NewPassword (ConvertTo-SecureString {senha} -AsPlainText -Force) -Reset -PassThru\r\n");
            
        }
        public static string ExecuteCommand(string command)
        {
            try
            {
                // Cria uma instância do processo do PowerShell
                Process process = new Process();

                // Define as propriedades do processo
                process.StartInfo.FileName = "powershell.exe";
                // Especifique o comando que você deseja executar no PowerShell
                process.StartInfo.Arguments = $"-Command \"{command}\"";
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
                    return "Erro ao executar o comando PowerShell:\n" + error;
                }
                else
                {
                    return "Saída do comando PowerShell:\n" + output;
                }
            }
            catch (Exception ex)
            {
                return "Ocorreu uma exceção:\n" + ex.Message;
            }
        }

    }
}