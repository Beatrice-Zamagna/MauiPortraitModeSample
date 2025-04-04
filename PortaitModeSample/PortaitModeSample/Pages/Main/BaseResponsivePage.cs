
using Android.Content.PM;

namespace PortaitModeSample.Pages.Main;

public abstract class BaseResponsivePage : ContentPage
{
	protected  BaseResponsivePage() { }

    /// <summary>
    /// Every page must have a portrait and landscape resource.
    /// </summary>
    protected abstract string PortraitResource { get; }
    protected abstract string LandscapeResource { get; }

    /// <summary>
    /// Method to attach and detach personalized events.
    /// </summary>
    protected abstract void AttachEvents();
    protected abstract void DetachEvents();

    /// <summary>
    /// On appearing, the layout is set based on the orientation.
    /// The personalized events are attached.
    /// </summary>
    protected override void OnAppearing()
    {
        base.OnAppearing();
        SetOrientationLayout();
        AttachEvents(); 
    }

    /// <summary>
    /// On disappearing, the personalized events are detached.
    /// </summary>
    protected override void OnDisappearing()
    {
        DetachEvents();
        base.OnDisappearing();
    }

    /// <summary>
    /// Set the layout based on the orientation.
    /// </summary>
    private void SetOrientationLayout()
    {
        Content = new Grid();

        bool isPortrait = Preferences.Get("AppOrientation", "Portrait") == ScreenOrientation.Portrait.ToString();
        string resourceKey = isPortrait ? PortraitResource : LandscapeResource;

        if (Application.Current!.Resources.TryGetValue(resourceKey, out var dataObj) && dataObj is DataTemplate dataTemplate)
        {
            var content = dataTemplate.CreateContent();
            Content = content as Grid;
        }
    }
}