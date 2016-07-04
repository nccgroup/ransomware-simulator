/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Donato Ferrante, donato dot ferrante at nccgroup dot trust

https://www.github.com/nccgroup/ransomware-simulator

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RansomwareSimulator
{
    /// <summary>
    /// Helper class to deal with the FileSystem
    /// </summary>
    class FileSystem
    {
        // Path to all the possible target files found on the system
        public List<string> TargetFilePaths;
        // Sequence of file extensions to scan for
        public string TargetFileExtensions;
        // Number of target files found on the system
        public int TargetFileFound;
        // Cross-reference for the output
        RichTextBox RichTextBox;
        // Cross-reference for the output
        Label LabelFileVictim;
        // Cross-reference for the output
        Label LabelDataVictim;
        // Cross-reference for the output
        Label LabelStatus;
        // Cross-reference for the output
        Label LabelFileVictimNet;
        // Cross-reference for the output
        Label LabelDataVictimNet;
        // Cross-reference for the output
        Label LabelFileVictimRem;
        // Cross-reference for the output
        Label LabelDataVictimRem;
        // Cross-reference for the output
        Label LabelCurrentFile;
        // Ref to current user
        CurrentUserSecurity CurrentUser;
        // Cross-reference for reporting
        Button buttonReport;
        // List of the local drives to scan
        List<DriveInfo> LocalDrives = new List<DriveInfo>();
        // List of the network drives to scan
        List<DriveInfo> NetworkDrives = new List<DriveInfo>();
        // List of the Removable drives to scan
        List<DriveInfo> RemovableDrives = new List<DriveInfo>();

        /// <summary>
        /// Main constructor
        /// </summary>
        public FileSystem(
            string targetFileExtensions,
            RichTextBox richTextBox,
            Label fileVictim,
            Label dataVictim,
            Label status,
            Label fileVictimNet,
            Label dataVictimNet,
            Label fileVictimRem,
            Label dataVictimRem, 
            Label currentFile,
            Button buttonReport)
        {
            this.TargetFileExtensions = targetFileExtensions;
            this.TargetFilePaths = null;
            this.TargetFileFound = 0;
            this.RichTextBox = richTextBox;
            this.LabelFileVictim = fileVictim;
            this.LabelDataVictim = dataVictim;
            this.LabelStatus = status;
            this.LabelFileVictimNet = fileVictimNet;
            this.LabelDataVictimNet = dataVictimNet;
            this.LabelFileVictimRem = fileVictimRem;
            this.LabelDataVictimRem = dataVictimRem;
            this.LabelCurrentFile = currentFile;
            this.buttonReport = buttonReport;

            this.CurrentUser = new CurrentUserSecurity();

            GetAllDrives();
        }

        /// <summary>
        /// Directory to skip while scanning
        /// </summary>
        /// <param name="path">Path to check</param>
        /// <returns></returns>
        private bool DirectoryToSkip(string path)
        {
            return path.StartsWith("C:\\$", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Recursive scan of a directory tree, skip unaccessible files
        /// Base method from: http://stackoverflow.com/a/12332773
        /// </summary>
        /// <param name="rootDirectory">The root directory to scan from</param>
        /// <returns>A sequence of paths accessible to the CurrentUser</returns>
        private IEnumerable<string> Traverse(string rootDirectory)
        {
            IEnumerable<string> files = Enumerable.Empty<string>();
            IEnumerable<string> directories = Enumerable.Empty<string>();
            try
            {
                this.LabelStatus.Invoke((MethodInvoker)delegate
                {
                    this.LabelStatus.Text = "Searching.";
                });

                // Test for UnauthorizedAccessException.
                var permission = new FileIOPermission(FileIOPermissionAccess.PathDiscovery, rootDirectory);
                permission.Demand();

                files = Directory.GetFiles(rootDirectory, this.TargetFileExtensions);
                directories = Directory.GetDirectories(rootDirectory);
            }
            catch
            {
                // Ignore folder
                rootDirectory = null;
            }

            foreach (var file in files)
            {
                this.LabelStatus.Invoke((MethodInvoker)delegate
                {
                    this.LabelStatus.Text = "Searching..";
                });

                this.LabelCurrentFile.Invoke((MethodInvoker)delegate
                {
                    this.LabelCurrentFile.Text = file;
                });

                FileAttributes fa = File.GetAttributes(file);
                if (!fa.HasFlag(FileAttributes.Directory) && HasPermissionOnFile(file) && !DirectoryToSkip(file))
                {
                    yield return file;
                }
            }
            
            // Recursive call for SelectMany.
            var subdirectoryItems = directories.SelectMany(Traverse);
            foreach (var result in subdirectoryItems)
            {
                this.LabelStatus.Invoke((MethodInvoker)delegate
                {
                    this.LabelStatus.Text = "Searching...";
                });

                this.LabelCurrentFile.Invoke((MethodInvoker)delegate
                {
                    this.LabelCurrentFile.Text = result;
                });

                FileAttributes fa = File.GetAttributes(result);
                if (!fa.HasFlag(FileAttributes.Directory) && HasPermissionOnFile(result) && !DirectoryToSkip(result))
                {
                    yield return result;
                }
            }
        }

        /// <summary>
        /// Scan the system and only list target files
        /// </summary>
        public void ScanToInspect()
        {
            // Disable report generation
            this.buttonReport.Invoke((MethodInvoker)delegate
            {
                this.buttonReport.Enabled = false;
            });

            // Delegate scan
            DelegateScan(Inspect);
        }

        /// <summary>
        /// Get all drives (local, network and removable)
        /// </summary>
        private void GetAllDrives()
        {
            foreach(DriveInfo drive in DriveInfo.GetDrives().ToList<DriveInfo>())
            {
                switch (drive.DriveType)
                {
                    // Network drive
                    case DriveType.Network:
                        NetworkDrives.Add(drive);
                        break;

                    // Removable drive
                    case DriveType.Removable:
                        RemovableDrives.Add(drive);
                        break;

                    // Others
                    default:
                        LocalDrives.Add(drive);
                        break;
                }
            }
        }

        /// <summary>
        /// Inspect explorer method
        /// </summary>
        /// <param name="drives">A list of drives to scan</param>
        private void Inspect(List<DriveInfo> drives)
        {
            long data = 0;
            long counter = 0;

            foreach (DriveInfo drive in drives)
            {
                string currentRoot = drive.RootDirectory.FullName;

                foreach (string _filepath in Traverse(currentRoot))
                {
                    // Skip files related to this program
                    if (_filepath.StartsWith(Path.GetFullPath(Environment.CurrentDirectory)))
                    {
                        continue;
                    }

                    this.LabelCurrentFile.Invoke((MethodInvoker)delegate
                    {
                        this.LabelCurrentFile.Text = _filepath;
                    });

                    if (HasPermissionOnFile(_filepath))
                    {
                        data += new FileInfo(_filepath).Length;
                        counter++;

                        Label refLabelData;
                        Label refLabelFile;

                        switch (drive.DriveType)
                        {
                            case DriveType.Network:
                                refLabelData = this.LabelDataVictimNet;
                                refLabelFile = this.LabelFileVictimNet;
                                break;

                            case DriveType.Removable:
                                refLabelData = this.LabelDataVictimRem;
                                refLabelFile = this.LabelFileVictimRem;
                                break;

                            default:
                                refLabelData = this.LabelDataVictim;
                                refLabelFile = this.LabelFileVictim;
                                break;
                        }

                        refLabelData.Invoke((MethodInvoker)delegate
                        {
                            refLabelData.Text = BytesToString(data);
                        });

                        refLabelFile.Invoke((MethodInvoker)delegate
                        {
                            refLabelFile.Text = counter.ToString();
                        });

                        this.RichTextBox.Invoke((MethodInvoker)delegate
                        {
                            this.RichTextBox.Text += "  [-] " + _filepath + " .. [" + BytesToString(new FileInfo(_filepath).Length) + "]\r\n";
                            this.RichTextBox.SelectionStart = this.RichTextBox.Text.Length;
                            this.RichTextBox.ScrollToCaret();
                        });
                    }
                }
            }

            // Enable report generation
            this.buttonReport.Invoke((MethodInvoker)delegate
            {
                this.buttonReport.Enabled = true;
            });
        }

        /// <summary>
        /// Check for permission on the current path
        /// </summary>
        /// <param name="path">A path</param>
        /// <returns>True if user has permissions</returns>
        public bool HasPermissionOnFile(string path)
        {
            // this could be configured to have different results
            if (this.CurrentUser.HasAccess(new DirectoryInfo(Path.GetDirectoryName(path)), FileSystemRights.Write))
            {
                return this.CurrentUser.HasAccess(new FileInfo(path), FileSystemRights.Modify);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Delegate to handle directory exploration
        /// </summary>
        /// <param name="drives">A list of drives to explore</param>
        private delegate void ExploreDrives(List<DriveInfo> drives);

        /// <summary>
        /// Scan the system and get all the files accessible to CurrentUser
        /// </summary>
        private void DelegateScan(ExploreDrives explorer)
        {
            this.LabelDataVictim.Invoke((MethodInvoker)delegate
            {
                this.LabelDataVictim.Text = "n/a";
            });

            this.LabelFileVictim.Invoke((MethodInvoker)delegate
            {
                this.LabelFileVictim.Text = "n/a";
            });

            this.LabelDataVictim.Invoke((MethodInvoker)delegate
            {
                this.LabelDataVictimNet.Text = "n/a";
            });

            this.LabelFileVictim.Invoke((MethodInvoker)delegate
            {
                this.LabelFileVictimNet.Text = "n/a";
            });

            this.LabelDataVictim.Invoke((MethodInvoker)delegate
            {
                this.LabelDataVictimRem.Text = "n/a";
            });

            this.LabelFileVictim.Invoke((MethodInvoker)delegate
            {
                this.LabelFileVictimRem.Text = "n/a";
            });

            this.RichTextBox.Invoke((MethodInvoker)delegate
            {
                this.RichTextBox.Text = "\r\n [ Local Drives ]\r\n";
            });

            explorer(LocalDrives);

            this.RichTextBox.Invoke((MethodInvoker)delegate
            {
                this.RichTextBox.Text += "\r\n [ Network Drives ]\r\n";
            });

            explorer(NetworkDrives);

            this.RichTextBox.Invoke((MethodInvoker)delegate
            {
                this.RichTextBox.Text += "\r\n [ Removable Drives ]\r\n";
            });

            explorer(RemovableDrives);

            this.LabelStatus.Invoke((MethodInvoker)delegate
            {
                this.LabelStatus.Text = "Done.";
            });

            this.RichTextBox.Invoke((MethodInvoker)delegate
            {
                this.RichTextBox.Text += "\r\n[ Done ]\r\n";
            });

            this.LabelStatus.Invoke((MethodInvoker)delegate
            {
                this.LabelCurrentFile.Text = ".";
            });
        }

        /// <summary>
        /// Transform byte to KB, MB etc..
        /// Base method from: http://stackoverflow.com/a/4975942
        /// </summary>
        /// <param name="byteCount">A size in byte</param>
        /// <returns>A string representing a file size</returns>
        private static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB" };
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }
    }

}
