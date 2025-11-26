using System.Diagnostics;

namespace MCA_ServerConsole.HelperClasses
{
    internal class JavaHelper
    {
        public static bool IsJavaInstalled()
        {
            try
            {
                // Start a process to check if "java -version" works
                Process process = new()
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "java",
                        Arguments = "-version",
                        RedirectStandardError = true,
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                _ = process.Start();

                // Capture the output (Java writes its version info to stderr)
                string output = process.StandardError.ReadToEnd();
                process.WaitForExit();

                // Check if the output contains "Java" or "OpenJDK"
                return output.Contains("Java") || output.Contains("OpenJDK");
            }
            catch
            {
                // Process fails (Java is not installed or not in PATH)
                return false;
            }
        }

        public static bool JarFileExists(string directoryPath)
        {
            try
            {
                if(!Directory.Exists(directoryPath))
                {
                    _ = MessageBox.Show($"The directory '{directoryPath}' does not exist.",
                        "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                // Search for .jar files in the directory
                string[] jarFiles = Directory.GetFiles(directoryPath, "*.jar", SearchOption.TopDirectoryOnly);

                // Return true if at least one .jar file exists
                return jarFiles.Length > 0;
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"An error occurred while checking for .jar files: {ex.Message}",
                    "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static string[] GetJarFiles(string directoryPath)
        {
            try
            {
                if(!Directory.Exists(directoryPath))
                {
                    _ = MessageBox.Show($"The directory '{directoryPath}' does not exist.",
                        "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return [];
                }

                // Search for .jar files in the directory
                string[] jarFilesWithPath = Directory.GetFiles(directoryPath, "*.jar", SearchOption.TopDirectoryOnly);

                List<string> jarFiles = [];
                foreach(string jarFileName in jarFilesWithPath)
                {
                    jarFiles.Add(jarFileName.Split('\\')[^1]);
                }

                return [.. jarFiles];
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"An error occurred while checking for .jar files: {ex.Message}",
                    "MCA Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return [];
            }
        }

        public static string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;

            while(len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len /= 1024;
            }

            return $"{len:0.##} {sizes[order]}";
        }
    }
}