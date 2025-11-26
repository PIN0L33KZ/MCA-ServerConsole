using System.Diagnostics;

namespace MCA_ServerConsole.Classes
{
    public class JavaProcessHandler(Action<string, string> keywordHandler)
    {
        private Process? _javaProcess;
        private readonly Action<string, string> _keywordHandler = keywordHandler;

        public bool IsProcessExited => _javaProcess == null || _javaProcess.HasExited;

        public async Task StartJavaProcessAsync(string javaArguments, Action<string> outputHandler, Action<string> errorHandler)
        {
            try
            {
                ProcessStartInfo processStartInfo = new()
                {
                    FileName = "java",
                    Arguments = javaArguments,
                    WorkingDirectory = Properties.Settings.Default.ServerDirectory,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
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
                        CheckKeywords(e.Data.ToLower());
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
                errorHandler($"Error starting Java process: {ex.Message}");
            }
        }

        private void CheckKeywords(string output)
        {
            string[] keywords = { "agree to the eula", "sun.nio.ch.filedispatcherimpl.write0", "starting", "server version", "server on", "done", "game type", "stopping server" };
            foreach(string keyword in keywords)
            {
                if(output.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                {
                    _keywordHandler(keyword, output);
                }
            }
        }

        public void StopJavaProcess()
        {
            try
            {
                _javaProcess?.StandardInput.WriteLine("stop");
                _javaProcess?.StandardInput.Flush();
            }
            catch
            {
                KillJavaProcess();
            }
        }

        public void ReloadJavaProcess()
        {
            try
            {
                _javaProcess?.StandardInput.WriteLine("reload");
            }
            catch
            {
                KillJavaProcess();
            }
        }

        public void SendToJavaProcess(string input)
        {
            try
            {
                _javaProcess?.StandardInput.WriteLine(input.Trim());
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error sending command: {ex.Message}", "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void KillAlreadyRunningJavaProcesses()
        {
            try
            {
                IEnumerable<Process> javaProcesses = Process.GetProcesses()
                    .Where(p => p.ProcessName.Equals("java", StringComparison.OrdinalIgnoreCase) ||
                                p.ProcessName.StartsWith("openjdk", StringComparison.OrdinalIgnoreCase));

                foreach(Process? process in javaProcesses)
                {
                    try
                    {
                        process.Kill();
                        process.WaitForExit();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"Error killing running Java process (PID: {process.Id}): {ex.Message}");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error searching for running Java processes: {ex.Message}");
            }
        }

        public void KillJavaProcess()
        {
            if(_javaProcess != null && !_javaProcess.HasExited)
            {
                _javaProcess.Kill();
                _javaProcess.WaitForExit();
            }
        }

        public void SilenceJavaProcess()
        {
            try
            {
                if(_javaProcess == null || _javaProcess.HasExited)
                {
                    throw new InvalidOperationException("Java process is not running or has already exited.");
                }

                _javaProcess.ErrorDataReceived += (sender, e) => { /* Ignoriere Fehlerausgabe */ };
                _javaProcess.BeginErrorReadLine();

                _javaProcess.OutputDataReceived += (sender, e) => { /* Ignoriere Fehlerausgabe */ };
                _javaProcess.BeginOutputReadLine();
            }
            catch(Exception)
            { }
        }
    }
}