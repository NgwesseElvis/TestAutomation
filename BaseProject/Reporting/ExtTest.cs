using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BaseProject.Reporting
{
    public class ExtTest
    {
        private static ThreadLocal<ExtentTest> _threadLocal = new();

        public static ExtentTest GetExtentTest()
        {
            return SetExtentTest;
        }

        public static ExtentTest SetExtentTest
        {
            get
            {
                if (_threadLocal == null)
                    return null;
                else
                    return _threadLocal.Value;
            }
            set
            {
                _threadLocal.Value = value;
            }
        }
    }
}
