using Lombiq.Tests.UI.Constants;
using Lombiq.Tests.UI.Pages;
using Lombiq.Tests.UI.Services;
using Shouldly;
using System.Net;

namespace Lombiq.Tests.UI.Extensions
{
    /// <summary>
    /// Some useful shortcuts for test execution using the Lombiq.Tests.UI.Shortcuts module. Note that you have to have
    /// it enabled in the app for these to work.
    /// </summary>
    public static class ShortcutsUITestContextExtensions
    {
        public const string FeatureToggleTestBenchUrl = "/Lombiq.Tests.UI.Shortcuts/FeatureToggleTestBench/Index";

        /// <summary>
        /// Authenticates the client with the given user account. Note that this will execute a direct sign in without
        /// anything else happening on the login page. The target app needs to have Lombiq.Tests.UI.Shortcuts enabled.
        /// </summary>
        public static void SignInDirectly(this UITestContext context, string userName = DefaultUser.UserName) =>
            context.GoToRelativeUrl(
                "/Lombiq.Tests.UI.Shortcuts/Account/SignInDirectly?userName=" +
                WebUtility.UrlEncode(userName));

        /// <summary>
        /// Signs the client out. Note that this will execute a direct sign in without anything else happening on the
        /// logoff page. The target app needs to have Lombiq.Tests.UI.Shortcuts enabled.
        /// </summary>
        public static void SignOutDirectly(this UITestContext context) =>
            context.GoToRelativeUrl("/Lombiq.Tests.UI.Shortcuts/Account/SignOutDirectly");

        /// <summary>
        /// Retrieves the currently authenticated user's name, if any. The target app needs to have
        /// Lombiq.Tests.UI.Shortcuts enabled.
        /// </summary>
        /// <returns>The currently authenticated user's name, empty or null string if the user is anonymous.</returns>
        public static string GetCurrentUserName(this UITestContext context) =>
            context.GoToPage<CurrentUserPage>().LoggedInUser.Value;

        /// <summary>
        /// Enables the feature with the given ID directly, without anything else happening on the admin Features page.
        /// </summary>
        public static void EnableFeatureDirectly(this UITestContext context, string featureId) =>
            context.GoToRelativeUrl("/Lombiq.Tests.UI.Shortcuts/ShellFeatures/EnableFeatureDirectly?featureId=" + featureId);

        /// <summary>
        /// Disables the feature with the given ID directly, without anything else happening on the admin Features page.
        /// </summary>
        public static void DisableFeatureDirectly(this UITestContext context, string featureId) =>
            context.GoToRelativeUrl("/Lombiq.Tests.UI.Shortcuts/ShellFeatures/DisableFeatureDirectly?featureId=" + featureId);

        /// <summary>
        /// Turns the <c>Lombiq.Tests.UI.Shortcuts.FeatureToggleTestBench</c> feature on, then off, and checks if the
        /// operations indeed worked. This can be used to test if anything breaks when a feature is enabled or disabled.
        /// </summary>
        public static void ExecuteAndAssertTestFeatureToggle(this UITestContext context)
        {
            context.EnableFeatureDirectly("Lombiq.Tests.UI.Shortcuts.FeatureToggleTestBench");
            context.GoToRelativeUrl(FeatureToggleTestBenchUrl);
            context.Scope.Driver.PageSource.ShouldContain("The Feature Toggle Test Bench worked.");
            context.DisableFeatureDirectly("Lombiq.Tests.UI.Shortcuts.FeatureToggleTestBench");
            context.GoToRelativeUrl(FeatureToggleTestBenchUrl);
            context.Scope.Driver.PageSource.ShouldNotContain("The Feature Toggle Test Bench worked.");
        }

        /// <summary>
        /// Purges the media cache without using any UI operations. Returns status code 500 in case of an error during
        /// cache clear.
        /// </summary>
        /// <param name="toggleTheFeature">In case the <c>Lombiq.Tests.UI.Shortcuts.MediaCachePurge</c> feature haven't
        /// been turned on yet, then set true.</param>
        public static void PurgeMediaCacheDirectly(this UITestContext context, bool toggleTheFeature = true)
        {
            if (toggleTheFeature)
            {
                context.EnableFeatureDirectly("Lombiq.Tests.UI.Shortcuts.MediaCachePurge");
            }

            context.GoToRelativeUrl("/Lombiq.Tests.UI.Shortcuts/MediaCachePurge/PurgeMediaCacheDirectly");

            if (toggleTheFeature)
            {
                context.DisableFeatureDirectly("Lombiq.Tests.UI.Shortcuts.MediaCachePurge");
            }
        }
    }
}
