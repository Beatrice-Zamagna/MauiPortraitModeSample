
using PortraitModeSampleInheritance.Pages.Landscape;
using PortraitModeSampleInheritance.Pages.Portrait;

namespace PortraitModeSampleInheritance.Pages.MainPages;

public class MainPage : ResponsivePage
{
	public MainPage() { }

    protected override View GetLayout(bool isPortrait)
    {
        return isPortrait
            ? new MainPageLandscape().Content
            : new MainPagePortrait().Content;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//second", true);
    }
}