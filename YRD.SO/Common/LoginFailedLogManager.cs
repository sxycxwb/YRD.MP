using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;

namespace YRD.SO.Common
{
    public class LoginFailedLogManager
    {
        Manager manager;
        public LoginFailedLogManager(Manager manager)
        {
            this.manager = manager;
        }

        //private ConcurrentQueue<LoginFailedLog> collection = new ConcurrentQueue<LoginFailedLog>();

        //public void Add(LoginFailedLog item)
        //{
        //    collection.Enqueue(item);
        //}

        //public LoginFailedLog GetModel()
        //{
        //    LoginFailedLog item = null;
        //    bool b = collection.TryDequeue(out item);
        //    return item;
        //}

    }
}