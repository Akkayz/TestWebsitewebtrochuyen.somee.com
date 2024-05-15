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
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
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
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
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
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);

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
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Email không được để trống hoặc không hợp lệ."));
        driver.Close();
    }

    [Test]
    public void tCEditUser06()
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
        driver.FindElement(By.CssSelector("tr:nth-child(3) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).Clear();
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Tên tài khoản không được để trống."));
        driver.Close();
    }

    [Test]
    public void tCEditUser07()
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
        driver.FindElement(By.CssSelector("tr:nth-child(3) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("huhu*&%$");
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Tên tài khoản chỉ có thể chứa các ký tự chữ và số."));
        driver.Close();
    }

    [Test]
    public void tCEditUser08()
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
        driver.FindElement(By.CssSelector("tr:nth-child(3) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).Clear();
        driver.FindElement(By.Id("UserName")).SendKeys("huhu");
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Tên tài khoản đã tồn tại."));
        driver.Close();
    }

    [Test]
    public void tCEditUser09()
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
        driver.FindElement(By.CssSelector("tr:nth-child(3) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("UserName")).Click();
        driver.FindElement(By.Id("UserName")).Clear();
        driver.FindElement(By.Id("UserName")).SendKeys("hu hu");
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Tên tài khoản không được chứa khoảng trắng."));
        driver.Close();
    }

    [Test]
    public void tCEditUser10()
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
        driver.FindElement(By.CssSelector("tr:nth-child(3) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("TenNguoiDung")).Click();
        driver.FindElement(By.Id("TenNguoiDung")).Clear();
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Tên người dùng không được để trống."));
        driver.Close();
    }

    [Test]
    public void tCEditUser11()
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
        driver.FindElement(By.CssSelector("tr:nth-child(3) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("TenNguoiDung")).Click();
        driver.FindElement(By.Id("TenNguoiDung")).Clear();
        driver.FindElement(By.Id("TenNguoiDung")).SendKeys("Nguyễn Hưng *(&(*&");
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Tên người dùng không được chứa ký tự đặc biệt hoặc số."));
        driver.Close();
    }

    [Test]
    public void tCEditUser12()
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
        driver.FindElement(By.CssSelector("tr:nth-child(3) #dropdownMenuButton")).Click();
        driver.FindElement(By.LinkText("Edit")).Click();
        driver.FindElement(By.Id("TrangThai")).Clear();
        driver.FindElement(By.Id("TrangThai")).SendKeys("99");
        IWebElement element = driver.FindElement(By.CssSelector(".btn"));
        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
        executor.ExecuteScript("arguments[0].click();", element);
        Assert.That(driver.FindElement(By.CssSelector(".field-validation-error")).Text, Is.EqualTo("Trạng thái không hợp lệ, hãy nhập 0 là khoá hoặc 1 là mở khoá."));
        driver.Close();
    }
}