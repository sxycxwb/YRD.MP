using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Concurrent;

namespace YRD.SO.Common
{
    public class LoginLogManager
    {
        Manager manager;
        public LoginLogManager(Manager manager)
        {
            this.manager = manager;
        }

        //private ConcurrentQueue<LoginLog> collection = new ConcurrentQueue<LoginLog>();

        //public void Add(LoginLog item)
        //{
        //    collection.Enqueue(item);
        //}

        //public LoginLog GetModel()
        //{
        //    LoginLog item = null;
        //    bool b = collection.TryDequeue(out item);
        //    return item;
        //}

    }
}