using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class TCEditUserTest
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
    public void tCEditUser01()
    {
        driver.Navigate().GoToUrl("http://webtrochuyen.somee.com/BaiViet/Index");
        driver.FindElement(By.LinkText("Login")).Click();
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("Admin");
        driver.FindElement(By.Id("Password")).Click();
        driver.FindElement(By.Id("Password")).SendKeys("123123");
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        driver.FindElement(By.LinkText("Quản lý người dùng")).Click();
        driver.FindElement(By.Id("dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.CssSelector("body")).Click();
        driver.FindElement(By.Id("Password")).Clear();
        driver.FindElement(By.Id("Password")).SendKeys("hung123123");
        js.ExecuteScript("window.scrollBy(0, 500)");
        Thread.Sleep(5000);
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(4)")).Text, Is.EqualTo("hung123123"));
        driver.Close();
    }
    [Test]
    public void tCEditUser02()
    {
        driver.Navigate().GoToUrl("http://webtrochuyen.somee.com/BaiViet/Index");
        driver.FindElement(By.LinkText("Login")).Click();
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("Admin");
        driver.FindElement(By.Id("Password")).SendKeys("123123");
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        driver.FindElement(By.LinkText("Quản lý người dùng")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(5) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("Email")).Click();
        driver.FindElement(By.Id("Email")).Clear();
        driver.FindElement(By.Id("Email")).SendKeys("nguyenhung@gmail.com");
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.CssSelector(".btn")).Click();
        Assert.That(driver.FindElement(By.CssSelector("tr:nth-child(2) > td:nth-child(3)")).Text, Is.EqualTo("nguyenhung@gmail.com"));
        driver.Close();
    }
    //PasswordInValid

    private void EditUser(string matKhau, string thongBaoLoi)
    {
        driver.Navigate().GoToUrl("http://webtrochuyen.somee.com/BaiViet/Index");
        driver.FindElement(By.LinkText("Login")).Click();
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("Admin");
        driver.FindElement(By.Id("Password")).SendKeys("123123");
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        driver.FindElement(By.LinkText("Quản lý người dùng")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(5) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("Password")).Click();
        driver.FindElement(By.Id("Password")).Clear();
        driver.FindElement(By.Id("Password")).SendKeys(matKhau);
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.CssSelector(".btn")).Click();

        // Kiểm tra thông báo lỗi
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo(thongBaoLoi));
    }

    [Test]
    public void tCEditUser03()
    {
        EditUser("75", "Mật khẩu phải có ít nhất 6 ký tự.");
        driver.Close();
    }

    [Test]
    public void tCEditUser04()
    {
        EditUser("", "Mật khẩu không được để trống.");
        driver.Close();
    }

    [Test]
    public void tCEditUser05()
    {
        driver.Navigate().GoToUrl("http://webtrochuyen.somee.com/BaiViet/Index");
        driver.FindElement(By.LinkText("Login")).Click();
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("Admin");
        driver.FindElement(By.Id("Password")).SendKeys("123123");
        driver.FindElement(By.CssSelector(".btn")).Click();
        driver.FindElement(By.Id("navbarDropdown")).Click();
        driver.FindElement(By.LinkText("Quản lý người dùng")).Click();
        driver.FindElement(By.CssSelector("tr:nth-child(5) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("Email")).Click();
        driver.FindElement(By.Id("Email")).Clear();
        driver.FindElement(By.Id("Email")).SendKeys("nguyenhunggmail.com");
        js.ExecuteScript("window.scrollBy(0, 500)");
        driver.FindElement(By.CssSelector(".btn")).Click();
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Email không đúng định dạng."));
        driver.Close();
    }
}
