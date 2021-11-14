using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace Exam2_WindowService
{
    public class FileWatcher
    {
        private FileSystemWatcher _fw;

        public FileWatcher()
        {
            _fw = new FileSystemWatcher(PathLoc());

            _fw.Created += new FileSystemEventHandler(_fw_Created);
            _fw.Deleted += new FileSystemEventHandler(_fw_Deleted);
            _fw.Changed += new FileSystemEventHandler(_fw_Changed);
            _fw.Renamed += new RenamedEventHandler(_fw_Renamed);


            _fw.EnableRaisingEvents = true;
        }

        private void _fw_Renamed(object sender, RenamedEventArgs e)
        {
            FSW_Logger.Log(String.Format("File Rename: Path:{0}, Name:{1}", e.FullPath, e.Name));



            //string source = "FSW_Logger";
            //string log = "Application";
            //if (!EventLog.SourceExists(source))
            //{
            //    EventLog.CreateEventSource(source, log);
            //}
            //EventLog.WriteEntry(source, log_message, EventLogEntryType.Information);

            string log_message = String.Format("File Rename: Path:{0}, Name:{1}", e.FullPath, e.Name);
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(log_message, EventLogEntryType.Information);
            }
        }

        private string PathLoc()
        {
            String pth = String.Empty;

            try
            {
                pth = System.Configuration.ConfigurationManager.AppSettings["location"];
            }
            catch (Exception ex)
            {
                
            }

            return pth;
            
        }

        void _fw_Changed(object sender, FileSystemEventArgs e)
        {
            FSW_Logger.Log(String.Format("File Change: Path:{0}, Name:{1}",e.FullPath,e.Name));

            string log_message = String.Format("File Change: Path:{0}, Name:{1}", e.FullPath, e.Name);
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(log_message, EventLogEntryType.Information);
            }

        }

        void _fw_Deleted(object sender, FileSystemEventArgs e)
        {
            FSW_Logger.Log(String.Format("File Deleted: Path:{0}, Name:{1}",e.FullPath,e.Name));

            string log_message = String.Format("File Deleted: Path:{0}, Name:{1}", e.FullPath, e.Name);
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(log_message, EventLogEntryType.Information);
            }
        }

        void _fw_Created(object sender, FileSystemEventArgs e)
        {
            FSW_Logger.Log(String.Format("File Created: Path:{0}, Name:{1}", e.FullPath,e.Name));

            string log_message = String.Format("File Created: Path:{0}, Name:{1}", e.FullPath, e.Name);
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";
                eventLog.WriteEntry(log_message, EventLogEntryType.Information);
            }
        }
    }
}
