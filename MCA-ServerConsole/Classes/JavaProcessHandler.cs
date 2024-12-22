using System.Diagnostics;

namespace MCA_ServerConsole.Classes
{
    public class JavaProcessHandler
    {
        private Process? _javaProcess;
        public bool IsProcessExited => _javaProcess == null || _javaProcess.HasExited;

        public async Task StartJavaProcessAsync(string javaArguments, Action<string> outputHandler, Action<string> errorHandler)
        {
            try
            {
                string javaExecutable = "java";

                ProcessStartInfo processStartInfo = new()
                {
                    FileName = javaExecutable,
                    Arguments = javaArguments,
                    WorkingDirectory = Properties.Settings.Default.ServerDirectory,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true, // Allow sending input to the process
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                _javaProcess = new Process
                {
                    StartInfo = processStartInfo,
                    EnableRaisingEvents = true
                };

                _javaProcess.OutputDataReceived += (sender, e) =>
                {
                    if(!string.IsNullOrEmpty(e.Data))
                    {
                        outputHandler?.Invoke(e.Data);
                    }
                };

                _javaProcess.ErrorDataReceived += (sender, e) =>
                {
                    if(!string.IsNullOrEmpty(e.Data))
                    {
                        errorHandler?.Invoke(e.Data);
                    }
                };

                _ = _javaProcess.Start();

                _javaProcess.BeginOutputReadLine();
                _javaProcess.BeginErrorReadLine();

                await _javaProcess.WaitForExitAsync();
            }
            catch(Exception ex)
            {
                errorHandler?.Invoke($"Error starting Java process: {ex.Message}");
            }
        }

        public void StopJavaProcess()
        {
            if(_javaProcess != null && !_javaProcess.HasExited)
            {
                try
                {
                    // Send the "stop" command to the process (if supported)
                    _javaProcess.StandardInput.WriteLine("stop");
                    _javaProcess.StandardInput.Flush();
                }
                catch(Exception)
                {
                    KillJavaProcess();
                }
            }
        }

        public void KillJavaProcess()
        {
            if(_javaProcess != null && !_javaProcess.HasExited)
            {
                try
                {
                    _javaProcess.Kill(); // Forcefully terminate the process
                    _javaProcess.WaitForExit();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error killing Java process: {ex.Message}");
                }
            }
        }

    }
}