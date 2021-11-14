using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Exam2_WindowService
{

    [RunInstaller(true)]
    public partial class Service1 : ServiceBase
    {

        public Service1()
        {
            InitializeComponent();
            
        }

        public void onDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            FileWatcher f = new FileWatcher();
        }

        protected override void OnStop()
        {
        }
    }
}
