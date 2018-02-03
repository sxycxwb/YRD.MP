using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
namespace YRD.SO.Common
{
    public class Manager
    {
        #region 单例
        private static Manager current;
        static object lockObj = new object();
        public static Manager Current
        {
            get
            {
                if (current == null)
                {
                    lock (lockObj)
                    {
                        if (current == null)
                        {
                            current = new Manager();
                        }
                    }
                }
                return current;
            }
        }
        #endregion

        private ConstantManager constantManager;

        public ConstantManager ConstantManager
        {
            get
            {
                if (constantManager == null)
                {
                    constantManager = new ConstantManager(current);
                }
                return constantManager;
            }

        }
        private ConfigManager configManager;

        public ConfigManager ConfigManager
        {
            get
            {
                if (configManager == null)
                {
                    configManager = new ConfigManager(current);
                }
                return configManager;
            }
        }

        private UserLoginManager userloginManager;

        public UserLoginManager UserLoginManager
        {
            get
            {
                if (userloginManager == null)
                {
                    userloginManager = new UserLoginManager(current);
                }
                return userloginManager;
            }
        }

        private BackGroundWorkManager backgroundwkrkManager;

        public BackGroundWorkManager BackGroundWorkManager
        {
            get
            {
                if (backgroundwkrkManager == null)
                {
                    backgroundwkrkManager = new BackGroundWorkManager();
                }
                return backgroundwkrkManager;
            }
        }
        private LoginLogManager loginlogManager;

        public LoginLogManager LoginLogManager
        {
            get
            {
                if (loginlogManager == null)
                {
                    loginlogManager = new LoginLogManager(current);
                }
                return loginlogManager;
            }

        }

        private LoginFailedLogManager loginfailedlogManager;

        public LoginFailedLogManager LoginFailedLogManager
        {
            get
            {
                if (loginfailedlogManager == null)
                {
                    loginfailedlogManager = new LoginFailedLogManager(current);
                }
                return loginfailedlogManager;
            }

        }



    }
}