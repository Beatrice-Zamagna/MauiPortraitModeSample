using Android.Content.PM;

namespace PortaitModeSample.Pages.Main;

public class MainPage : BaseResponsivePage
{
    protected override string PortraitResource => "MainPagePortrait";
    protected override string LandscapeResource => "MainPageLandscape";

    public MainPage() { }

    /// <summary>
    /// Attach personalized events.
    /// </summary>
    protected override void AttachEvents()
    {
        var navigationButton = Content.FindByName<Button>("NavigationButton");
        if (navigationButton is not null) navigationButton.Clicked += OnNavigationButtonClicked;
    }

    /// <summary>
    /// Detach personalized events.
    /// </summary>
    protected override void DetachEvents()
    {
        var navigationButton = Content.FindByName<Button>("NavigationButton");
        navigationButton.Clicked -= OnNavigationButtonClicked;
    }

    /// <summary>
    /// Navigate to the second page.
    /// This personalized event is attached to the navigation button on appearing.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnNavigationButtonClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//second", true);
    }
}

