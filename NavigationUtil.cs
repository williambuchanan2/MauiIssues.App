using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiIssues
{

    public static class NavigationUtil
    {
        public static void GoBack(string parameters = "")
        {
            var route = "..";
            try
            {
                if (!string.IsNullOrEmpty(parameters))
                    route += "?" + parameters;
                Shell.Current.GoToAsync(route);
            }
            catch (Exception ex)
            {
                // TODO: Proper error handling
                if (ex == null) { }
                throw;
            }

        }

        /// <summary>
        /// Navigates to a page specified by the page type
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        public static void Navigate<TPage>() where TPage : ContentPage
        {
            Navigate<TPage>("");
        }

        /// <summary>
        /// Navigates to a page specified by the page type
        /// </summary>
        /// <typeparam name="TPage"></typeparam>
        /// <param name="parameters">Query parameters for the page.</param>
        public static void Navigate<TPage>(string parameters) where TPage : ContentPage
        {
            try
            {
                string route = typeof(TPage).Name;
                if (!string.IsNullOrEmpty(parameters))
                    route += "?" + parameters;
                Shell.Current.GoToAsync(route);
            }
            catch (Exception ex)
            {
                // TODO: Proper error handling
                if (ex == null) { }
                throw;
            }
        }

        /// <summary>
        /// Navigates to a shell item specified in the AppShell
        /// </summary>
        /// <param name="shellItemName">The name of the shell item to navigate to</param>
        public static void NavigateShell(string shellItemName)
        {
            ShellItem shellItem = (ShellItem)Shell.Current.FindByName(shellItemName);
            Shell.Current.CurrentItem = shellItem;
        }

    }
}
