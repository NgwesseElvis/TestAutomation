using BaseProject.Factory;
using OpenQA.Selenium;
using System;

namespace BaseProject.BaseClass
{
    public abstract partial class BaseClass: DriverFactory
    {
        private readonly string _pageName;
        private readonly By _by;

        public BaseClass(string pageName, By by)
        {
            _pageName = pageName;
            _by = by;
            this.OnPage();
        }

        private bool OnPage()
        {
            WaitUntillPageFullyLoaded();
            var boolResults = WaitTillElementIsDisplayed(_by);
            if (!boolResults)
            {
                // Report with page name
                Console.WriteLine($"Unable to to navigate to: {_pageName}");
                return false;
            }
            return true;
        }

        public static IWebDriver Driver
        {
            get { return (IWebDriver)DriverStored; }
        }

        public static T GetPage<T>()
        {

            return (T)Activator.CreateInstance(typeof(T), Array.Empty<object>());
        }
    }
}
