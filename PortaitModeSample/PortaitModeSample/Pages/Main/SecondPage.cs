using Android.Content.PM;

namespace PortaitModeSample.Pages.Main;

public class SecondPage : BaseResponsivePage
{
    protected override string PortraitResource => "SecondPagePortrait";
    protected override string LandscapeResource => "SecondPageLandscape";
    public SecondPage() { }

    /// <summary>
    /// Attach personalized events.
    /// </summary>
    protected override void AttachEvents()
    {
        var navigationButton = Content.FindByName<Button>("SecondPageNavigationButton");
        if (navigationButton is not null)
            navigationButton.Clicked += OnNavigationButtonClicked;
    }
    /// <summary>
    /// Detach personalized events.
    /// </summary>
    protected override void DetachEvents()
    {
        var navigationButton = Content.FindByName<Button>("SecondPageNavigationButton");
        navigationButton.Clicked -= OnNavigationButtonClicked;
    }
    /// <summary>
    /// Navigate to the main page.
    /// This personalized event is attached to the navigation button on appearing.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnNavigationButtonClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main", true);
    }
}
