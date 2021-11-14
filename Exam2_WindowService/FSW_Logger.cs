using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceProcess;

namespace Exam2_WindowService
{
    public class FSW_Logger
    {

        public static void Log(string message)
        {
            
            try {
                string _message = String.Format("{0} {1}", message, Environment.NewLine);
                File.AppendAllText(AppDomain.CurrentDomain.BaseDirectory + "FSW.txt", _message);

                
            } 
            catch (Exception ex)
            {

            }
        }
    }
}
