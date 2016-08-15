using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PointOfSaleService
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer = null;
        int Interval = 1;

        public Service1()
        {
            InitializeComponent();

        }

        protected override void OnStart(string[] args)
        {

            int.TryParse(ConfigurationManager.AppSettings["Interval"], out Interval);
            timer = new Timer();
            this.timer.Interval = 60 * 1000 * Interval;
            this.timer.Elapsed += timer_Elapsed;
            this.timer.Enabled = true;

        }
        public void OnDebug()
        {
            OnStart(null);
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            PerformTask();
            timer.Enabled = true;
        }
        private void PerformTask()
        {
            SyncController syncController = new SyncController();
            syncController.SyncData();
        }
        protected override void OnStop()
        {
        }
    }

}
