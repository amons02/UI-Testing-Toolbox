# Lombiq UI Testing Toolbox



## About

Web UI testing toolbox mostly for Orchard Core applications. Everything you need to do UI testing for an Orchard app is here.

Highlights:

- Execute fully self-contained, repeatable, parallelizable automated UI tests on Orchard Core apps.
- Do cross-browser testing with all current browsers, both in normal and headless modes.
- Check the HTML structure and behavior of the app, check for errors in the Orchard logs and browser logs. Start troubleshooting from the detailed full application dumps and test logs if a test fails.
- Start tests with a setup using recipes, start with an existing Orchard app or take snapshots in between tests and resume from there. Use SQLite or SQL Server databases.
- Use local file storage or Azure Blob Storage for Media.
- Test e-mail sending with a local SMTP server too. Everything just works.
- Check for web content accessibility so people with disabilities can user your app properly too. You can also create accessibility reports for all pages.
- Check for the validity of the HTML markup either explicitly or automatically on all page changes.
- Reliability is built in, so you won't get false negatives.
- Use shortcuts for common Orchard Core operations like logging in or enabling features instead of going through the UI so you only test what you want, and it's also faster.
- Support for [TeamCity test metadata reporting](https://www.jetbrains.com/help/teamcity/reporting-test-metadata.html) so you can see the important details and metrics of a test at a glance in TeamCity.


## Table of contents

- [Tools we use](Lombiq.Tests.UI/Docs/Tools.md)
- [Making an Orchard Core app testable](Lombiq.Tests.UI/Docs/TestableOrchardCoreApps.md)
- [Creating tests](Lombiq.Tests.UI/Docs/CreatingTests.md)
- [Configuration](Lombiq.Tests.UI/Docs/Configuration.md)
- [Troubleshooting](Lombiq.Tests.UI/Docs/Troubleshooting.md)
- [Limits](Lombiq.Tests.UI/Docs/Limits.md)
