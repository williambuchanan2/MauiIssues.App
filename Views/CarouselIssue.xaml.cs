using MauiIssues.ViewModels;
using System.Collections.ObjectModel;
using System.Reflection;

namespace MauiIssues.Views;

public partial class CarouselIssue : ContentPage
{
    private int _itemcount;
    private string _moodTheme = "standard";

    public string MoodTheme
    {
        get => _moodTheme;
        set
        {
            _moodTheme = value;
            UpdateMoodTheme();
        }
    }


    public ObservableCollection<MoodInformation> MoodList { get; set; }

    public ContentPageUtil<CarouselIssueVm> PageUtil { get; set; }

    public CarouselIssue(CarouselIssueVm vm)
    {
           UpdateMoodTheme();
      InitializeComponent();

        PageUtil = new ContentPageUtil<CarouselIssueVm>(this, vm);
       BindingContext = PageUtil.PageBindingContext;
    }


    private void UpdateMoodTheme()
    {
        if (MoodList == null)
            MoodList = new ObservableCollection<MoodInformation>();
        else
            MoodList.Clear();

        string themeName = MoodTheme;
        Assembly a = typeof(CarouselIssue).GetTypeInfo().Assembly;
        ImageSource isHappy = ImageSource.FromResource($"MauiIssues.Resources.Images.mood.{themeName}.{themeName}_green.png", a);
        ImageSource isOk = ImageSource.FromResource($"MauiIssues.Resources.Images.mood.{themeName}.{themeName}_yellow.png", a);
        ImageSource isSad = ImageSource.FromResource($"MauiIssues.Resources.Images.mood.{themeName}.{themeName}_red.png", a);
        ImageSource isNeedHelp = ImageSource.FromResource($"MauiIssues.Resources.Images.mood.{themeName}.{themeName}_black.png", a);

        MoodList.Add(new MoodInformation { UserImage = isHappy, Mood = MoodIds.Happy, MoodDescription = "Happy" });
        MoodList.Add(new MoodInformation { UserImage = isOk, Mood = MoodIds.Okay, MoodDescription = "Ok" });
        MoodList.Add(new MoodInformation { UserImage = isSad, Mood = MoodIds.Sad, MoodDescription = "Sad" });
        MoodList.Add(new MoodInformation { UserImage = isNeedHelp, Mood = MoodIds.Help, MoodDescription = "Need Help" });
        _itemcount = MoodList.Count;
    }

    //Carousel Back Btn
    public void Prepage(object sender, EventArgs e)
    {
        int pos = Carousel.Position;
        pos--;
        if (pos < 0)
            pos = _itemcount - 1;
        Carousel.Position = pos;
    }

    //Carousel Nxt Btn
    public void Nextpage(object sender, EventArgs e)
    {
        int pos = Carousel.Position;
        pos++;
        if (pos >= _itemcount)
            pos = 0;
        Carousel.Position = pos;
    }

}

public class MoodIds
{
    public const string Okay = "OKAY";
    public const string Sad = "SAD";
    public const string Happy = "HAPPY";
    public const string Help = "HELP";
}
