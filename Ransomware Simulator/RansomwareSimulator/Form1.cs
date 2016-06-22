/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Donato Ferrante, donato dot ferrante at nccgroup dot trust

https://www.github.com/nccgroup/ransomware-simulator

Released under AGPL see LICENSE for more information
*/

using Novacode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RansomwareSimulator
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class Form1 : Form
    {
        // Keep track of the current version
        private static string VERSION = "1.0 (public)";
        private static string NCC_RS_REPORT_RTF = Path.Combine(Environment.CurrentDirectory, "NCC_RS_report.rtf");
        private static string NCC_RS_REPORT_TEMPLATE = Path.Combine(Environment.CurrentDirectory, "ncc_report_template.docx");

        /// <summary>
        /// Main Form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.labelVersion.Text = "ver. " + VERSION;
        }
 
        // Handle Inspect
        private void buttonInspect_Click(object sender, EventArgs e)
        {
            FileSystem fs = new FileSystem(
                this.textBoxTargets.Text,
                this.richTextBoxOutput,
                this.LabelFileVictim,
                this.LabelDataVictim,
                this.labelStatus,
                this.LabelFileVictimNet,
                this.LabelDataVictimNet,
                this.LabelFileVictimRem,
                this.LabelDataVictimRem,
                this.labelCurrentFile,
                this.buttonReport);

            // Clean up from previous scans (handle old .rtf)
            string reportPath = NCC_RS_REPORT_RTF;
            if (File.Exists(reportPath))
            {
                File.Delete(reportPath);
            }

            // Perform the scan
            Thread inspectThread = new Thread(fs.ScanToInspect);
            inspectThread.Start();
        }

        /// <summary>
        /// Generate reports
        /// </summary>
        private void GenerateReport()
        {
            // Generate .rtf report (mostly used as input for the next .docx generation)
            string rtfReport = GenerateReportRTF();
            if(rtfReport == null)
            {
                MessageBox.Show(
                    this,
                    "Please remove the old report before generating the new one.",
                    "Ransomware Simulator",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            // Try to generate the report in .docx format
            // if Word can't be found, open the .rtf report instead
            try
            {
                GenerateReportDocx();
            }catch(Exception)
            {
                // Use the default reader to open the .rtf file
                Process.Start(rtfReport);
            }
        }

        /// <summary>
        /// Utility method for template editing
        /// </summary>
        /// <param name="table">A table</param>
        static void SetTableProperty(Table table)
        {
            table.Alignment = Alignment.center;
            table.AutoFit = AutoFit.ColumnWidth;
        }

        /// <summary>
        /// Utility method for template editing
        /// </summary>
        /// <param name="document">A document</param>
        /// <param name="placeholder">A placeholder</param>
        /// <param name="table">A table</param>
        static void InsertTable(DocX document, string placeholder, Table table)
        {
            foreach (var paragraph in document.Paragraphs)
            {
                paragraph.FindAll(placeholder).ForEach(index => paragraph.InsertTableAfterSelf((table)));
            }
        }
        
        /// <summary>
        /// Generate a report: docx format
        /// It uses as input the template in the same folder as the binary: "ncc_report_template.docx"
        /// And the intermediate report in .rtf format: "NCC_RS_report.rtf"
        /// </summary>
        void GenerateReportDocx()
        {
            string NCCtemplateFile = NCC_RS_REPORT_TEMPLATE;

            if(!File.Exists(NCCtemplateFile))
            {
                MessageBox.Show(
                    string.Format("Unable to find NCC template file: {0}",
                    NCCtemplateFile));
                
                throw new Exception("missing Word template");
            }

            string NCCscanOutput = NCC_RS_REPORT_RTF;
            if (!File.Exists(NCCscanOutput))
            {
                MessageBox.Show(
                    string.Format("Unable to find NCC Ransomware Simulator scan output: {0}"),
                    NCCscanOutput);
                return;
            }

            using (DocX document = DocX.Load(NCCtemplateFile))
            {

                Table tableTemplate = document.Tables[0];

                bool inSummary = false;
                bool inDetails = false;
                string fileN = null;
                string dataN = null;
                string lastKnownList = null;
                string lastKnownTable = null;

                // A very simple text parser based on the .rtf file
                foreach (string _entry in File.ReadAllLines(NCCscanOutput))
                {

                    string entry = _entry.Trim();

                    switch (entry)
                    {
                        case "[ Summary ]":
                            inSummary = true;
                            inDetails = false;
                            break;

                        case "[ Details ]":
                            inSummary = false;
                            inDetails = true;
                            break;

                        default:
                            break;
                    }

                    if (inSummary)
                    {
                        switch (entry)
                        {
                            case "[ Local ]":
                                lastKnownList = "###LOCAL_";
                                break;

                            case "[ Network ]":
                                lastKnownList = "###NETWORK_";
                                break;

                            case "[ Removable ]":
                                lastKnownList = "###REMOVABLE_";
                                break;
                        }

                        if (entry.Contains("File: "))
                        {
                            fileN = entry.Substring(entry.IndexOf(": ") + 1).Trim();
                            document.ReplaceText(lastKnownList + "FILES###", fileN);
                        }
                        else if (entry.Contains("Data: "))
                        {
                            dataN = entry.Substring(entry.IndexOf(": ") + 1).Trim();
                            document.ReplaceText(lastKnownList + "DATA###", dataN);
                        }
                    }
                    else if (inDetails)
                    {
                        if (lastKnownList != null)
                        {
                            document.ReplaceText(lastKnownList + "FILES###", fileN);
                            document.ReplaceText(lastKnownList + "DATA###", dataN);
                            lastKnownList = null;
                        }

                        switch (entry)
                        {
                            case "[ Local Drives ]":
                                tableTemplate = document.Tables[0];
                                SetTableProperty(tableTemplate);
                                break;

                            case "[ Network Drives ]":
                                if (lastKnownTable != null)
                                {
                                    InsertTable(document, lastKnownTable, tableTemplate);
                                }
                                tableTemplate = document.Tables[1];
                                SetTableProperty(tableTemplate);
                                break;

                            case "[ Removable Drives ]":
                                if (lastKnownTable != null)
                                {
                                    InsertTable(document, lastKnownTable, tableTemplate);
                                }
                                tableTemplate = document.Tables[2];
                                SetTableProperty(tableTemplate);
                                break;

                            case "[ Done ]":
                                if (lastKnownTable != null)
                                {
                                    InsertTable(document, lastKnownTable, tableTemplate);
                                }
                                lastKnownTable = null;
                                break;

                            default:
                                break;
                        }

                        if (entry.Length > 0 && entry.Contains(".. ["))
                        {
                            int start = entry.IndexOf(" [-");

                            entry = entry.Replace("[-] ", "");

                            int split = entry.LastIndexOf(".. [");
                            if (split > 0 && split + 5 < entry.Length)
                            {
                                string path = entry.Substring(0, split);
                                string size = entry.Substring(split + 4).Replace("]", "");

                                Row newRow = tableTemplate.InsertRow();
                                newRow.Cells[0].VerticalAlignment = VerticalAlignment.Center;
                                newRow.Cells[1].VerticalAlignment = VerticalAlignment.Center;
                                newRow.Cells[0].Paragraphs.First().Append(path).FontSize(9);
                                newRow.Cells[1].Paragraphs.First().Append(size).FontSize(9);
                            }
                        }
                    }
                }

                // Add system info
                string computerName = Environment.MachineName;
                string userName = Environment.UserName;
                string ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.First(f => f.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();
                string currentDate = DateTime.Now.ToString("d/M/yyyy");

                // Replace placeholders
                document.ReplaceText("###SYSTEM_NAME###", computerName);
                document.ReplaceText("###SYSTEM_USER###", userName);
                document.ReplaceText("###SYSTEM_IP###", ipAddress);
                document.ReplaceText("###SYSTEM_DATE###", currentDate);
                document.ReplaceText("###SYSTEM_TARGET###", this.textBoxTargets.Text);

                // Save current report
                string documentName = string.Format("NCC_RS_Report_{0}_{1}.docx", computerName, userName);
                document.SaveAs(documentName);

                // Use the default reader to open the .docx file
                Process.Start(documentName);
            }
        }

        /// <summary>
        /// Generate a report: RTF formats
        /// </summary>
        public string GenerateReportRTF()
        {
            // If the file already exists don't need to generate a new .rtf
            string reportPath = NCC_RS_REPORT_RTF;
            if (File.Exists(reportPath))
            {
                return null;
            }

            // Simple formatting for the intermediate output in .rtf
            // Don't edit the format as it may affect the parser generating .docx
            string fileContent = string.Format(
                "[ NCC Ransomware Simulator Report ]\r\n" +
                "\r\n[ Summary ]\r\n" +
                "\r\n [ Local ]\r\n" +
                "  File: {0}\r\n" +
                "  Data: {1}\r\n" +
                "\r\n [ Network ]\r\n" +
                "  File: {2}\r\n" +
                "  Data: {3}\r\n" +
                "\r\n [ Removable ]\r\n" +
                "  File: {4}\r\n" +
                "  Data: {5}\r\n" +
                "\r\n[ Details ]\r\n{6}\r\n",
                this.LabelFileVictim.Text,
                this.LabelDataVictim.Text,
                this.LabelFileVictimNet.Text,
                this.LabelDataVictimNet.Text,
                this.LabelFileVictimRem.Text,
                this.LabelDataVictimRem.Text,
                this.richTextBoxOutput.Text
                );

            File.WriteAllText(reportPath, fileContent);

            return reportPath;
        }

        /// <summary>
        /// Handler for report generation click
        /// </summary>
        private void buttonReport_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }


        /// <summary>
        /// Handler for Acknowledgement click
        /// </summary>
        private void buttonAcknowledgement_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, 
                "- Icons designed by Freepik.\n\n" +
                "- Word documents parsing based on: https://github.com/WordDocX/DocX",
                "Acknowledgements", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handler for NCC label click
        /// </summary>
        private void labelNCC_Click(object sender, EventArgs e)
        {
            Process.Start("https://nccgroup.trust");
        }

        /// <summary>
        /// Handler for NCC logo click
        /// </summary>
        private void panelNCCLogo_MouseClick(object sender, MouseEventArgs e)
        {
            Process.Start("https://nccgroup.trust");
        }

    }
}
