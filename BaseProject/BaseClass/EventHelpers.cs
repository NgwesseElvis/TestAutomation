using OpenQA.Selenium;
using System;

namespace BaseProject.BaseClass
{
    public abstract partial class BaseClass
    {
        public void EnterText(By by, string text)
        {
            var element = Driver.FindElement(by);

            try
            {
                HighlightElement(element);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                element.Clear();
                foreach (var item in text)
                {
                    element.SendKeys(item.ToString());
                }

            }
            finally
            {
                // Report to user unable to click
            }
        }

        public void ClickOnElement(By by)
        {
            var element = Driver.FindElement(by);
            try
            {
                HighlightElement(element);
                element.Click();
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                element.Click();
            }
            finally
            {
                // Report to user unable to click
            }
        }

        public void ClickOnElementJavaScript(By by)
        {
            var element = Driver.FindElement(by);

            try
            {
                HighlightElement(element);
                JavaScriptClick(element);
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                JavaScriptClick(element);
            }
            finally
            {
                // Report to user unable to click
            }
        }

        private void JavaScriptClick(IWebElement element)
        {
            try
            {
                HighlightElement(element);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception e)
            {
                // Report
                Console.Write(e.Message);
            }
        }

        private void ScrollToView(IWebElement element)
        {
            try
            {
                HighlightElement(element);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (Exception e)
            {
                // Report
                Console.Write(e.Message);
            }
        }

        private void HighlightElement(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)Driver;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"", ""background"" : ""yellow"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }
    }
}
