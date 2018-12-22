﻿using DotVVM.Testing.Abstractions;
using Riganti.Selenium.Core;
using Xunit;
using Xunit.Abstractions;

namespace DotVVM.Samples.Tests.New.Feature
{
    public class JavascriptEventsTests : AppSeleniumTest
    {
        [Fact]
        public void Feature_JavascriptEvents_JavascriptEvents()
        {
            RunInAllBrowsers(browser => {
                browser.NavigateToUrl(SamplesRouteUrls.FeatureSamples_JavascriptEvents_JavascriptEvents);

                // init alert
                browser.Wait();
                AssertUI.AlertTextEquals(browser, "init");
                browser.ConfirmAlert();

                // postback alerts
                browser.ElementAt("input[type=button]", 0).Click();

                AssertUI.AlertTextEquals(browser, "beforePostback");
                browser.ConfirmAlert();
                browser.Wait();

                AssertUI.AlertTextEquals(browser, "afterPostback");
                browser.ConfirmAlert();

                // error alerts
                browser.ElementAt("input[type=button]", 1).Click();

                AssertUI.AlertTextEquals(browser, "beforePostback");
                browser.ConfirmAlert();
                browser.Wait();

                AssertUI.AlertTextEquals(browser, "custom error handler");
                browser.ConfirmAlert();
            });
        }

        public JavascriptEventsTests(ITestOutputHelper output) : base(output)
        {
        }
    }
}