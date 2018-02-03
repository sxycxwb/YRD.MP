using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace YRD.SO.Common
{
    /// <summary>
    /// BackGroundWorkManager 的摘要说明
    /// </summary>
    public class BackGroundWorkManager
    {


        //轮循系统，每15秒钟，开始一次处理
        private int timeout = 1000 * 1;//
        public BackGroundWorkManager()
        {
            backgroud.WorkerReportsProgress = true;
            backgroud.WorkerSupportsCancellation = true;

            backgroud.DoWork += backgroud_DoWork;
            backgroud.ProgressChanged += backgroud_ProgressChanged;
            backgroud.RunWorkerCompleted += backgroud_RunWorkerCompleted;
        }
        /// <summary>
        /// 后台线程是否开始执行
        /// </summary>
        private bool isStart = false;

        public void StartBackgroundWorker()
        {
            if (!backgroud.IsBusy)
            {
                isStart = true;
                backgroud.RunWorkerAsync();
            }
        }


        private void backgroud_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void backgroud_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroud_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            while (isStart)
            {
                try
                {

                    //处理未领奖状态
                    ProcessUserLoginLog();

                    System.Threading.Thread.Sleep(timeout);
                }
                catch (Exception Exc)
                {
                }
            }
        }

        private BackgroundWorker backgroud = new BackgroundWorker();


        /// <summary>
        /// 处理用户未领取奖品状态和网商未发货状态
        /// </summary>
        private void ProcessUserLoginLog()
        {
            #region 奖品状态有0变成10
            try
            {
                #region LoginLog
                {
                    //List<LoginLog> listLoginLog = new List<LoginLog>();

                    //var model = Manager.Current.LoginLogManager.GetModel();
                    //while (model != null && listLoginLog.Count <= 1000)
                    //{
                    //    listLoginLog.Add(model);
                    //    model = Manager.Current.LoginLogManager.GetModel();
                    //}

                    //try
                    //{
                    //    if (listLoginLog.Any())
                    //    {
                    //        using (var db = new jhtEntities())
                    //        {
                    //            db.LoginLog.AddRange(listLoginLog);
                    //            db.SaveChanges();
                    //        }
                    //    }

                    //}
                    //catch (Exception Exc)
                    //{

                    //}
                }
                #endregion

                #region LoginFailedLog
                {
                    //List<LoginFailedLog> listLoginFailedLog = new List<LoginFailedLog>();

                    //var model = Manager.Current.LoginFailedLogManager.GetModel();
                    //while (model != null && listLoginFailedLog.Count <= 1000)
                    //{
                    //    listLoginFailedLog.Add(model);
                    //    model = Manager.Current.LoginFailedLogManager.GetModel();
                    //}

                    //try
                    //{
                    //    if (listLoginFailedLog.Any())
                    //    {
                    //        using (var db = new jhtEntities())
                    //        {
                    //            db.LoginFailedLog.AddRange(listLoginFailedLog);
                    //            db.SaveChanges();
                    //        }
                    //    }

                    //}
                    //catch (Exception Exc)
                    //{

                    //}
                }
                #endregion
            }
            catch (Exception Exc)
            {
            }
            #endregion

        }

    }
}
