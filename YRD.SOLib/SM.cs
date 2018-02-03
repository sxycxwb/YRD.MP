using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace YRD.SOLib
{
    public class SM
    {
        #region 单例
        private static SM current;
        static object lockObj = new object();
        public static SM Current
        {
            get
            {
                if (current == null)
                {
                    lock (lockObj)
                    {
                        if (current == null)
                        {
                            current = new SM();
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

        private IPManager ipManager;

        public IPManager IPManager
        {
            get
            {
                if (ipManager == null)
                {
                    ipManager = new IPManager(current);
                }
                return ipManager;
            }

        }

        private HashManager hashManager;

        public HashManager HashManager
        {
            get
            {
                if (hashManager == null)
                {
                    hashManager = new HashManager(current);
                }
                return hashManager;
            }
        }

        private CryptoManager cryptoManager;

        public CryptoManager CryptoManager
        {
            get
            {
                if (cryptoManager == null)
                {
                    cryptoManager = new CryptoManager(current);
                }
                return cryptoManager;
            }

        }


    }
}