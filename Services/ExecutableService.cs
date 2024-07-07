namespace TFGDevopsApp1.Services
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    public class ExecutableService
    {
        public async Task<(int,string)> ExecuteAsync(string executable, string arguments = "")
        {
            try
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = executable,
                    Arguments = $"\"{arguments}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using var process = new Process { StartInfo = processStartInfo };
                process.Start();

                string output = await process.StandardOutput.ReadToEndAsync();
                string error = await process.StandardError.ReadToEndAsync();

                process.WaitForExit();

                return (process.ExitCode, string.IsNullOrEmpty(error) ? output : error);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error executing {executable} {arguments}", ex);
            }
        }
    }

}
