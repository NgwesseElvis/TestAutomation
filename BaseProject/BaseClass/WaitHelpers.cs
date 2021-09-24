using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BaseProject.BaseClass
{
    public abstract partial class BaseClass
    {
        public static bool WaitTillElementSelected(By by, int timeout = 10)
        {
            var boolResults = false;

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            try
            {
                boolResults = wait.Until(x => x.FindElement(by).Selected);
            }
            catch (Exception e)
            {
                // Report
                Console.Write(e.Message);
            }

            return boolResults;
        }

        public static bool WaitTillElementEnabled(By by, int timeout = 10)
        {
            var boolResults = false;

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            try
            {
                boolResults = wait.Until(x => x.FindElement(by).Enabled);
            }
            catch (Exception e)
            {
                // Report
                Console.Write(e.Message);
            }

            return boolResults;
        }

        public static bool WaitTillElementContainsString(By by, string text, int timeout = 10)
        {
            var boolResults = false;

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            try
            {
                boolResults = wait.Until(x => x.FindElement(by).Text == text);
            }
            catch (Exception e)
            {
                // Report
                Console.Write(e.Message);
            }

            return boolResults;
        }

        public static bool WaitTillElementIsDisplayed(By by, int timeout = 10)
        {
            var boolResults = false;

            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            try
            {
                boolResults = wait.Until(x => x.FindElement(by).Displayed);
            }
            catch (Exception e)
            {
                // Report
                Console.Write(e.Message);
            }

            return boolResults;
        }

        public static bool WaitUntillPageFullyLoaded(int timeout = 10)
        {
            var boolResults = false;
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            try
            {
                wait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
            }
            catch (Exception e)
            {
                // Report
                Console.Write(e.Message);
            }

            return boolResults;
        }

        public static void ExecuteJavaScript(string executionText, object obj)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript(executionText, obj);
        }
    }
}
