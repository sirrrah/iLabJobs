﻿using System;
using iLabJobs.utilities;
using OpenQA.Selenium;

namespace iLabJobs.pages
{
    public class Careers : BaseClass
    {
        private static IWebElement element;

        public Careers(IWebDriver driver) : base(driver) { }

        public static IWebElement Link_SouthAfrica()
        {
            try
            {
                element = driver.FindElement(By.XPath("//*[@href='/careers/south-africa/']"));
                Log.Info("'South Africa' link is found on the Careers Page");
            }
            catch (Exception ex)
            {
                Log.Error("'South Africa' link is not found on the Careers Page");
                throw (ex);
            }
            return element;
        }

    }
}