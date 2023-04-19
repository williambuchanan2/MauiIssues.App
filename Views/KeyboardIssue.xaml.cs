using MauiIssues.ViewModels;

namespace MauiIssues.Views;

public partial class KeyboardIssue : ContentPage
{
    public ContentPageUtil<KeyboardIssueVm> PageUtil { get; set; }

    public KeyboardIssue(KeyboardIssueVm vm)
    {
        InitializeComponent();

        PageUtil = new ContentPageUtil<KeyboardIssueVm>(this, vm);
        BindingContext = PageUtil.PageBindingContext;
    }
}