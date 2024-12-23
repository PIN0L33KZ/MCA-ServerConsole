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
                        CheckKeywords(e.Data);
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
            string[] keywords = { "agree to the eula", "starting", "server version", "server on", "done", "game type", "stopping server" };
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
                _ = MessageBox.Show($"Error sending command: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}