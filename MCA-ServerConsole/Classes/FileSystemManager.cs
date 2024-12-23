namespace MCA_ServerConsole.Classes
{
    public class FileSystemManager
    {
        private readonly FileSystemWatcher _fileSystemWatcher;

        public FileSystemManager(Action onChange)
        {
            _fileSystemWatcher = new FileSystemWatcher
            {
                IncludeSubdirectories = true,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite
            };

            _fileSystemWatcher.Created += (s, e) => onChange();
            _fileSystemWatcher.Deleted += (s, e) => onChange();
            _fileSystemWatcher.Renamed += (s, e) => onChange();
        }

        public void SetupWatcher(string path)
        {
            if(Directory.Exists(path))
            {
                _fileSystemWatcher.Path = path;
                _fileSystemWatcher.EnableRaisingEvents = true;
            }
        }

        public void LoadFolderStructure(string rootPath, TreeView treeView)
        {
            try
            {
                // Clear existing nodes
                treeView.Nodes.Clear();

                // Create root node
                TreeNode rootNode = new(Path.GetFileName(rootPath))
                {
                    Tag = rootPath,
                    ImageKey = "rootFolder",
                    SelectedImageKey = "rootFolder"
                };

                _ = treeView.Nodes.Add(rootNode);

                // Load subdirectories and files
                LoadSubDirectories(rootPath, rootNode);

                // Expand the first two levels
                rootNode.Expand();
                foreach(TreeNode childNode in rootNode.Nodes)
                {
                    childNode.Expand();
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading folder structure: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubDirectories(string path, TreeNode parentNode)
        {
            try
            {
                // Add subdirectories
                foreach(string directory in Directory.GetDirectories(path))
                {
                    TreeNode directoryNode = new(Path.GetFileName(directory))
                    {
                        Tag = directory,
                        ImageKey = "folder",
                        SelectedImageKey = "folder"
                    };
                    _ = parentNode.Nodes.Add(directoryNode);

                    // Recursively add subdirectories and files
                    LoadSubDirectories(directory, directoryNode);
                }

                // Add files
                foreach(string file in Directory.GetFiles(path))
                {
                    string imageKey = file.EndsWith(".jar", StringComparison.OrdinalIgnoreCase) ? "javaFile" : "file";

                    TreeNode fileNode = new(Path.GetFileName(file))
                    {
                        Tag = file,
                        ImageKey = imageKey,
                        SelectedImageKey = imageKey
                    };
                    _ = parentNode.Nodes.Add(fileNode);
                }
            }
            catch(UnauthorizedAccessException)
            {
                _ = parentNode.Nodes.Add(new TreeNode("Access Denied")
                {
                    ImageKey = "error",
                    SelectedImageKey = "error"
                });
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error loading subdirectories or files: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateFolderStructure(string rootPath, TreeView treeView)
        {
            try
            {
                // Find Root-Node or create if not existing
                TreeNode rootNode = treeView.Nodes.Cast<TreeNode>()
                    .FirstOrDefault(node => node.Tag?.ToString() == rootPath);

                if(rootNode == null)
                {
                    rootNode = new TreeNode(Path.GetFileName(rootPath))
                    {
                        Tag = rootPath,
                        ImageKey = "rootFolder",
                        SelectedImageKey = "rootFolder"
                    };
                    _ = treeView.Nodes.Add(rootNode);
                }

                // Update nodes recursively
                UpdateSubDirectories(rootPath, rootNode);

                // Expand the first two levels
                rootNode.Expand();
                foreach(TreeNode childNode in rootNode.Nodes)
                {
                    childNode.Expand();
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error updating folder structure: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSubDirectories(string path, TreeNode parentNode)
        {
            try
            {
                string[] currentDirectories = Directory.GetDirectories(path);
                string[] currentFiles = Directory.GetFiles(path);

                // Remove nodes that no longer exist
                List<TreeNode> nodesToRemove = parentNode.Nodes.Cast<TreeNode>()
                    .Where(node => node.Tag is string tagPath &&
                                   !currentDirectories.Contains(tagPath) &&
                                   !currentFiles.Contains(tagPath))
                    .ToList();

                foreach(TreeNode nodeToRemove in nodesToRemove)
                {
                    parentNode.Nodes.Remove(nodeToRemove);
                }

                // Add or update subdirectories
                foreach(string directory in currentDirectories)
                {
                    TreeNode existingNode = parentNode.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(node => node.Tag?.ToString() == directory);

                    if(existingNode == null)
                    {
                        TreeNode newNode = new(Path.GetFileName(directory))
                        {
                            Tag = directory,
                            ImageKey = "folder",
                            SelectedImageKey = "folder"
                        };
                        _ = parentNode.Nodes.Add(newNode);
                        UpdateSubDirectories(directory, newNode);
                    }
                    else
                    {
                        UpdateSubDirectories(directory, existingNode);
                    }
                }

                // Add or update files
                foreach(string file in currentFiles)
                {
                    string imageKey = file.EndsWith(".jar", StringComparison.OrdinalIgnoreCase) ? "javaFile" : "file";

                    TreeNode existingNode = parentNode.Nodes.Cast<TreeNode>()
                        .FirstOrDefault(node => node.Tag?.ToString() == file);

                    if(existingNode == null)
                    {
                        TreeNode newNode = new(Path.GetFileName(file))
                        {
                            Tag = file,
                            ImageKey = imageKey,
                            SelectedImageKey = imageKey
                        };
                        _ = parentNode.Nodes.Add(newNode);
                    }
                }
            }
            catch(UnauthorizedAccessException)
            {
                TreeNode accessDeniedNode = parentNode.Nodes.Cast<TreeNode>()
                    .FirstOrDefault(node => node.Text == "Access Denied");

                if(accessDeniedNode == null)
                {
                    _ = parentNode.Nodes.Add(new TreeNode("Access Denied")
                    {
                        ImageKey = "error",
                        SelectedImageKey = "error"
                    });
                }
            }
            catch(Exception ex)
            {
                _ = MessageBox.Show($"Error updating subdirectories or files: {ex.Message}", "Minecraft Advanced Server Console", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}