using log4net;
using System;
using System.Diagnostics;

namespace System
{
    public class LogHelper
    {
        /// <summary>
        /// 日志实例
        /// </summary>
        private static ILog log;
        public static ILog Log
        {
            get
            {
                if (log == null)
                {
                    log = LogManager.GetLogger("LogToTXT");
                }
                return log;
            }
        }

        /// <summary>
        /// Error错误日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Error(string message, Exception e = null)
        {
            var IsShowExceptionDetail = WebTools.GetAppConfig("IsShowExceptionDetail") == "1";
            if (IsShowExceptionDetail == false)
            {
                e = null;
            }
            if (Log.IsErrorEnabled)
            {
                StackTrace st = new StackTrace(true);
                StackFrame last = st.GetFrame(1); //上一个方法
                var name = last.GetMethod();  //方法名
                var fileName = name.ReflectedType.FullName;  //文件名
                var rowNum = last.GetFileLineNumber(); //行号
                var colNum = last.GetFileColumnNumber(); //列号
                var err = string.Format("发生错误的文件[{0}],方法[{1}],行列[{2},{3}] ", fileName, name, rowNum, colNum);

                StackFrame last2 = st.GetFrame(2); // 
                if (last2 != null)
                {
                    var name2 = last2.GetMethod();  //方法名
                    var fileName2 = name2.ReflectedType?.FullName;  //文件名
                    var rowNum2 = last2.GetFileLineNumber(); //行号
                    var colNum2 = last2.GetFileColumnNumber(); //列号
                    err += string.Format("来自[{0}],方法[{1}],行列[{2},{3}] ", fileName2, name2, rowNum2, colNum2);
                }

                err += message;
                if (e == null)
                {
                    Log.Error(err);
                }
                else
                {
                    Log.Error(err, e);
                }
            }
        }

        public static void Error(Exception e)
        {
            var msg = WebTools.getFinalException(e);
            Error("异常：" + msg);
        }
        /// <summary>
        /// Info信息日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Info(string message, Exception e = null)
        {
            var IsShowExceptionDetail = WebTools.GetAppConfig("IsShowExceptionDetail") == "1";
            if (IsShowExceptionDetail == false)
            {
                e = null;
            }
            if (Log.IsErrorEnabled)
            {
                if (e == null)
                {
                    Log.Info(message);
                }
                else
                {
                    Log.Info(message, e);
                }
            }
        }

        /// <summary>
        /// Debug调试日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Debug(string message, Exception e = null)
        {
            var IsShowExceptionDetail = WebTools.GetAppConfig("IsShowExceptionDetail") == "1";
            if (IsShowExceptionDetail == false)
            {
                e = null;
            }
            if (Log.IsErrorEnabled)
            {
                if (e == null)
                {
                    Log.Debug(message);
                }
                else
                {
                    Log.Debug(message, e);
                }
            }
        }

        /// <summary>
        /// Fatal日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void SQL(string message, Exception e = null)
        {
            var IsShowExceptionDetail = WebTools.GetAppConfig("IsShowExceptionDetail") == "1";
            if (IsShowExceptionDetail == false)
            {
                e = null;
            }
            if (Log.IsErrorEnabled)
            {
                if (e == null)
                {
                    Log.Fatal(message);
                }
                else
                {
                    Log.Fatal(message, e);
                }
            }
        }

        /// <summary>
        /// Warn警告日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Warn(string message, Exception e = null)
        {
            var IsShowExceptionDetail = WebTools.GetAppConfig("IsShowExceptionDetail") == "1";
            if (IsShowExceptionDetail == false)
            {
                e = null;
            }
            if (Log.IsErrorEnabled)
            {
                if (e == null)
                {
                    Log.Warn(message);
                }
                else
                {
                    Log.Warn(message, e);
                }
            }
        }
    }
}
