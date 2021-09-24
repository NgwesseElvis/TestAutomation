using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace BaseProject.BaseClass
{
    public abstract partial class BaseClass
    {
        public IWebElement GetElementOrThrow(By by)
        {
            try
            {
                var elementLocated = Driver.FindElement(by);
                return elementLocated;
            }
            catch (Exception)
            {
                var elementLocated = Driver.FindElement(by);
                ScrollToView(elementLocated);
                return elementLocated;
            }
        }

        public IEnumerable<IWebElement> GetElementsOrThrow(By by)
        {
            try
            {
                var elementLocated = Driver.FindElements(by);
                return elementLocated;
            }
            catch (Exception)
            {
                var elementLocated = Driver.FindElements(by);
                ScrollToView(elementLocated[0]);
                return elementLocated;
            }
        }

        public bool IsElementDisplayed(By by)
        {
            try
            {
                var elementLocated = Driver.FindElement(by);
                return elementLocated.Displayed;
            }
            catch (Exception)
            {
                var elementLocated = Driver.FindElement(by);
                ScrollToView(elementLocated);
                return elementLocated.Displayed;
            }
        }

        public bool DoesElementContainText(By by, string text)
        {
            try
            {
                var elementLocated = Driver.FindElement(by);
                var getText = elementLocated.Text;
                return getText == text;
            }
            catch (Exception)
            {
                var elementLocated = Driver.FindElement(by);
                ScrollToView(elementLocated);
                return elementLocated.Text == text;
            }
        }
    }
}
