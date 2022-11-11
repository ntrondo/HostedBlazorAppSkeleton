
### The following steps were taken to make Playwright tests work:
- Create the project as a nUnit test project in Visual Studio.
- Add nuget package Microsoft.Playwright.NUnit to the project.
- Install a browser using comand line. [Docs](https://playwright.dev/docs/cli#install-system-dependencies).
    - Open command prompt.
    - It does not matter which directory you are in.
    - Type "npx playwright install chromium".
    - Ignore warning.
