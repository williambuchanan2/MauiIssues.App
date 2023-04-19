using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiIssues.ViewModels
{
    public abstract partial class BaseViewModel : ObservableValidator
    {
        //private ILogger _logger;

        public static Page MainPage => Application.Current?.MainPage ?? throw new NullReferenceException();

        public BaseViewModel()
        {
            //_logger = logger;
            Create();
        }

        private void Create() { }

        /// <summary>
        /// Override this method to carry out an action when the page appears
        /// </summary>
        [RelayCommand]
        public virtual void PageAppearing()
        {

        }

        public virtual void Appearing(object sender, System.EventArgs e)
        {

        }

        public virtual void NavigatedTo(object sender, Microsoft.Maui.Controls.NavigatedToEventArgs e)
        {

        }

        /// <summary>
        /// Override this method to carry out an action when the page disappears
        /// </summary>
        [RelayCommand]
        public virtual void PageDisappearing()
        {

        }

        /// <summary>
        /// Override this method to carry out an action when the back button is pressed
        /// </summary>
        public virtual bool BackButtonPressed()
        {
            return false;
        }

        /// <summary>
        /// Calls the ValidateAllProperties method and returns the result in a ready to use format.
        /// </summary>
        /// <returns></returns>
        public virtual (bool haveErrors, List<string> errorMessages) Validate()
        {
            ValidateAllProperties();
            bool haveErrors = false;
            List<string> errorMessages = new List<string>();

            if (HasErrors)
            {
                haveErrors = true;
                errorMessages = GetErrors().Select(e => e.ErrorMessage).ToList();// string.Join(Environment.NewLine, GetErrors().Select(e => e.ErrorMessage));
            }

            return (haveErrors, errorMessages);
        }
    }

}
