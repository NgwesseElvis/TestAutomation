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
                Info($"Successfully entered text on element {by}");
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
                Info($"Successfully entered text on element {by}");
            }
        }

        public void ClickOnElement(By by)
        {
            var element = Driver.FindElement(by);
            try
            {
                HighlightElement(element);
                element.Click();
                Info($"Successfully clicked element {by}");
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                element.Click();
                Info($"Successfully clicked element {by}");
            }
        }

        public void ClickOnElementJavaScript(By by)
        {
            var element = Driver.FindElement(by);

            try
            {
                HighlightElement(element);
                JavaScriptClick(element);
                Info($"Successfully clicked element {by}");
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                JavaScriptClick(element);
                Info($"Successfully clicked element {by}");
            }
        }

        private void JavaScriptClick(IWebElement element)
        {
            try
            {
                HighlightElement(element);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)Driver;
                executor.ExecuteScript("arguments[0].click();", element);
                Info($"Successfully clicked element");
            }
            catch (Exception e)
            {
                Fail($"{e.Message}");
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
                Fail($"{e.Message}");
            }
        }

        private void HighlightElement(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)Driver;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"", ""background"" : ""yellow"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });

            Info($"Successfully highlighted element");
        }

        public void PressEnter(By by)
        {
            var element = Driver.FindElement(by);
            try
            {
                HighlightElement(element);
                element.SendKeys(Keys.Enter);
                Info($"Successfully hit enter key on element {by}");
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                element.SendKeys(Keys.Enter);
                Info($"Successfully hit enter key on element {by}");
            }
        }
    }
}
