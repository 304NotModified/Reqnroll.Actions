using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Reqnroll.Actions.Selenium.Configuration;
using Reqnroll.Actions.Selenium.Hoster;
using System;

namespace Reqnroll.Actions.Selenium.DriverInitialisers;

public class InternetExplorerDriverInitialiser : DriverInitialiser<InternetExplorerOptions>
{
    private static readonly Lazy<string?> InternetExplorerWebDriverFilePath =
        new Lazy<string?>(() => Environment.GetEnvironmentVariable("IE_WEBDRIVER_FILE_PATH"));

    public InternetExplorerDriverInitialiser(ISeleniumConfiguration seleniumConfiguration,
        ICredentialProvider credentialProvider) : base(seleniumConfiguration, credentialProvider)
    {
    }


    protected override void AddDefaultCapabilities(InternetExplorerOptions options)
    {
        
    }

    protected override IWebDriver CreateWebDriver(InternetExplorerOptions options)
    {
        return string.IsNullOrWhiteSpace(InternetExplorerWebDriverFilePath.Value)
            ? new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(), options,
                TimeSpan.FromSeconds(120))
            : new InternetExplorerDriver(
                InternetExplorerDriverService.CreateDefaultService(InternetExplorerWebDriverFilePath.Value), options,
                TimeSpan.FromSeconds(120));
    }
}