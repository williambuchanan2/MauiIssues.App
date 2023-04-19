using MauiIssues.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiIssues
{

    public class ContentPageUtil<T> where T : BaseViewModel, new()
    {
        private T _pageBindingContext;
        private ContentPage _page;

        public T PageBindingContext
        {
            get { return _pageBindingContext; }
            set { _pageBindingContext = value; }
        }

        public ContentPageUtil(ContentPage page, T viewModel)
        {
            _page = page;
            _pageBindingContext = viewModel;
            _page.NavigatedTo += _pageBindingContext.NavigatedTo;
            _page.Appearing += _pageBindingContext.Appearing;
        }

        public void OnAppearing()
        {
            AnimateFadeIn();
        }

        public void Dismiss()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                AnimateFadeOutAndPop();
            });
        }

        public void AnimateFadeIn()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                _page.Content.Opacity = 0;
                _page.Content.FadeTo(1.0, 150, Easing.Linear);
            });
        }

        public void AnimateFadeOutAndPop()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                // Animate to fade out
                await _page.Content.FadeTo(0, 150, Easing.Linear);
                await _page.Navigation.PopModalAsync(false);
            });
        }
    }

}
