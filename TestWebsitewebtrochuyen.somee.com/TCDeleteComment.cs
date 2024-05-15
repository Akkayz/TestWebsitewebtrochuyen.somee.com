using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class TCDeleteComment
{
    private IWebDriver driver;
    public IDictionary<string, object> vars { get; private set; }
    private IJavaScriptExecutor js;

    [SetUp]
    public void SetUp()
    {
        driver = new ChromeDriver();
        js = (IJavaScriptExecutor)driver;
        vars = new Dictionary<string, object>();
        driver.Manage().Window.Maximize();
    }

    [TearDown]
    protected void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void tCDeleteComment01()
    {
        driver.Navigate().GoToUrl("http://webtrochuyen.somee.com/BaiViet/Index");
        driver.FindElement(By.LinkText("Login")).Click();
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("Admin");
        driver.FindElement(By.Id("Password")).SendKeys("123123");
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        driver.FindElement(By.LinkText("Quản lý bính luận")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(4) a:nth-child(3)")).Click();
        driver.FindElement(By.Id("confirmUserName")).SendKeys("Đạt Lê");
        {
            string value = driver.FindElement(By.Id("confirmUserName")).GetAttribute("value");
            Assert.That(value, Is.EqualTo("Đạt Lê"));
        }
        driver.Close();
    }

    [Test]
    public void tCDeleteComment02()
    {
        driver.Navigate().GoToUrl("http://webtrochuyen.somee.com/BaiViet/Index");
        driver.FindElement(By.LinkText("Login")).Click();
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("Admin");
        driver.FindElement(By.Id("Password")).SendKeys("123123");
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        driver.FindElement(By.LinkText("Quản lý bính luận")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(4) a:nth-child(3)")).Click();
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".validation-summary-errors li")).Text, Is.EqualTo("Tên người dùng xác nhận không được để trống."));
        driver.Close();
    }

    [Test]
    public void tCDeleteComment03()
    {
        driver.Navigate().GoToUrl("http://webtrochuyen.somee.com/BaiViet/Index");
        driver.FindElement(By.LinkText("Login")).Click();
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("Admin");
        driver.FindElement(By.Id("Password")).SendKeys("123123");
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        driver.FindElement(By.LinkText("Quản lý bính luận")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(4) a:nth-child(3)")).Click();
        driver.FindElement(By.Id("confirmUserName")).SendKeys("%%");
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".validation-summary-errors li")).Text, Is.EqualTo("Tên người dùng không được chứa ký tự đặc biệt hoặc số."));
        driver.Close();
    }

    [Test]
    public void tCDeleteComment04()
    {
        driver.Navigate().GoToUrl("http://webtrochuyen.somee.com/BaiViet/Index");
        driver.FindElement(By.LinkText("Login")).Click();
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("Admin");
        driver.FindElement(By.Id("Password")).SendKeys("123123");
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        driver.FindElement(By.LinkText("Quản lý bính luận")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(4) a:nth-child(3)")).Click();
        driver.FindElement(By.Id("confirmUserName")).SendKeys("Đạt Lế");
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".validation-summary-errors li")).Text, Is.EqualTo("Tên người dùng xác nhận không đúng."));
        driver.Close();
    }
}