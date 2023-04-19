using MauiIssues.ViewModels;
using MauiIssues;

namespace MauiIssues.Views;

public partial class MainPage : ContentPage
{

    public ContentPageUtil<MainPageVm> PageUtil { get; set; }

    public MainPage(MainPageVm vm)
    {
        InitializeComponent();

        PageUtil = new ContentPageUtil<MainPageVm>(this, vm);
        BindingContext = PageUtil.PageBindingContext;
    }

}

