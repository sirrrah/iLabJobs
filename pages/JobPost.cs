﻿using System;
using iLabJobs.utilities;
using OpenQA.Selenium;

namespace iLabJobs.pages
{
    public class JobPost : BaseClass
    {
        private static IWebElement element;

        public JobPost(IWebDriver driver) : base(driver) { }

        public static IWebElement Button_ApplyOnline()
        {
            try
            {
                element = driver.FindElement(By.XPath("//*[@class='wpjb-job-buttons']/a"));
                Log.Info("'Apply Online' button is found on the job Page");
            }
            catch (Exception ex)
            {
                Log.Error("'Apply Online' button is not found on the job Page");
                throw (ex);
            }
            return element;
        }

        public static IWebElement Textbox_ApplicantName()
        {
            try
            {
                element = driver.FindElement(By.Id("applicant_name"));
                Log.Info("applicant name input field is found on the job Page");
            }
            catch (Exception ex)
            {
                Log.Error("applicant name input field is not found on the job Page");
                throw (ex);
            }
            return element;
        }

        public static IWebElement Textbox_Email()
        {
            try
            {
                element = driver.FindElement(By.Id("email"));
                Log.Info("email input field is found on the job Page");
            }
            catch (Exception ex)
            {
                Log.Error("email input field is not found on the job Page");
                throw (ex);
            }
            return element;
        }

        public static IWebElement Textbox_Phone()
        {
            try
            {
                element = driver.FindElement(By.Id("phone"));
                Log.Info("phone number input field is found on the job Page");
            }
            catch (Exception ex)
            {
                Log.Error("phone number input field is not found on the job Page");
                throw (ex);
            }
            return element;
        }

        public static IWebElement Buttton_SendApplication()
        {
            try
            {
                element = driver.FindElement(By.Id("wpjb_submit"));
                Log.Info("send button is found on the job Page");
            }
            catch (Exception ex)
            {
                Log.Error("send button is not found on the job Page");
                throw (ex);
            }
            return element;
        }

        public static IWebElement Error_UploadFile()
        {
            try
            {
                element = driver.FindElement(By.XPath("//*[@class='wpjb-errors']/li"));
                Log.Info("Error message item(s) found");
            }
            catch (Exception ex)
            {
                Log.Error("Error message item(s) not found");
                throw (ex);
            }
            return element;
        }
    }
}
