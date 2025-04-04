
using PortraitModeSampleInheritance.Pages.Landscape;
using PortraitModeSampleInheritance.Pages.Portrait;

namespace PortraitModeSampleInheritance.Pages.MainPages;

public class SecondPage : ResponsivePage
{
	public SecondPage() { }

    protected override View GetLayout(bool isPortrait)
    {
        return isPortrait
            ? new SecondPageLandscape().Content
            : new SecondPagePortrait().Content;
    }

    private async void Button_Clicked_SecondPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main", true);
    }
}