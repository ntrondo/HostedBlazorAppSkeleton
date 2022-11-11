using Microsoft.Playwright;

namespace BrowserTests
{
    public class Tests
    {
        //private static readonly string DevUrl = "https://localhost:7044";
        private static readonly string TestUrl = "https://whostedblazorappskeleton.azurewebsites.net";
        //private static readonly string ProdUrl = TestUrl;
        private static string Url => TestUrl;
        IPlaywright? PWTool { get; set; }
        IBrowser? Browser { get; set; }
        IPage? Page { get; set; }

        private async Task ResetPage()
        {
            if(Page != null)
            {
                await Page.GotoAsync(Url);
                await Page.WaitForSelectorAsync("div.sidebar");
                Assert.That(await Page.TitleAsync(), Is.EqualTo("Index"));
            }       
        }
        [Test, Order(1)]
        public async Task Setup()
        {
            //This is not unit testing.
            //Unit testing patterns are not observed.
            PWTool = await Playwright.CreateAsync();
            Browser = await PWTool.Chromium.LaunchAsync(new BrowserTypeLaunchOptions() { Headless = false });
            Page = await Browser.NewPageAsync();
            await ResetPage();
        }
        [Test, Order(2)]
        public async Task TestCounter()
        {
            Assert.That(Page, Is.Not.Null);
            await Navigate("Counter", "counter");
            
            var link = Page.GetByRole(AriaRole.Button, new PageGetByRoleOptions() { NameString = "Increment count" });
            var items = Page.GetByText("Current count:");
            for (int count = 0; count < 5; count++)
            {
                await AssertCountTexts(items, count);
                await link.ClickAsync();
                await Page.WaitForSelectorAsync(".has-update-color-green.was-just-updated");
                await Page.WaitForSelectorAsync(".has-update-color-green.has-update-transition");
                await Task.Delay(500);
            }
        }      
        private static  async Task AssertCountTexts(ILocator items, int count)
        {
            var texts = await items.AllInnerTextsAsync();
            foreach (string text in texts)
                Assert.That(text, Does.EndWith(" " + count));
        }
        
        [Test, Order(3)]
        public async Task TestForex()
        {
            if (Page == null)
                await Setup();
            Assert.That(Page, Is.Not.Null);
            await Navigate("Forex", "forex");
            //todo Verify that rates are displayed and updated.
        }

        private async Task Navigate(string linkText, string page)
        {
            Assert.That(Page, Is.Not.Null);
            var link = Page.GetByRole(AriaRole.Link, new PageGetByRoleOptions() { NameString = linkText });
            Assert.That(await link.GetAttributeAsync("href"), Is.EqualTo(page));
            await link.ClickAsync();
            await Page.WaitForURLAsync(Url + "/" + page);
        }

        [Test, Order(5)]
        public async Task TearDown()
        {
            Page = null;
            if(Browser != null)
                await Browser.DisposeAsync();
            Browser = null;
            PWTool?.Dispose();
            PWTool = null;
        }
    }
}