# MauiPortraitModeSample
Handling Views in Landscape &amp; Portrait Mode

We need to manage different XAML views for portrait and landscape mode while maintaining a single, centralized behavior in our .NET MAUI application. We have explored two potential solutions (described below), but we couldn't find any official documentation or guidelines on how to handle this scenario effectively. 

**Solution 1: DataTemplate and ResourceDictionary**
This approach requires creating two ResourceDictionary files for each page that needs alternative views depending on the device’s orientation. Each dictionary contains a DataTemplate defining the respective UI layout.
Since DataTemplate does not support direct code-behind event handling, we must avoid defining events in XAML. Instead, we retrieve UI controls at runtime using x:Name and attach event handlers programmatically in the constructor or the OnAppearing() method.
The views are managed via an aggregator, utilizing MergedDictionaries within a ResourceDictionary to collect the created DataTemplate instances. This aggregator is then included in the MergedDictionary of App.xaml alongside other ResourceDictionary instances.
To enforce consistency, we create a common abstract class, BaseResponsivePage, which overrides OnAppearing() and OnDisappearing(). Derived classes must define two string properties, PortraitResource and LandscapeResource, used to retrieve the correct DataTemplate. Additionally, they must implement AttachEvents and DetachEvents methods to handle UI event bindings dynamically.
**Pros & Cons:**
Pro: Centralized logic with minimal redundancy.
Con: No direct binding between XAML and code-behind since multiple XAML files need to link to a single code-behind, leading to potential reference conflicts.

**Solution 2: Inheritance-Based Approach**
This approach involves creating a MainPage.cs file containing the shared logic and two separate files, MainPageLandscape.xaml and MainPagePortrait.xaml, defining the UI layouts along with their respective code-behind files.
Each code-behind file inherits from MainPage.cs and primarily contains only a constructor. When initializing MainPage.cs, an instance of the appropriate subclass is created based on the device’s orientation, and its content is set as the main page’s Content.
**Pros & Cons:**
Pro: Allows events to be defined in XAML, as the inheritance structure resolves event references properly. Moreover, each orientation could have its own logic, as each XAML also has its unique code-behind. 
Con: Requires more files, although two of them remain mostly empty, serving only as bridges for inheritance. This structure, however, provides flexibility for adding orientation-specific logic when needed.

**Additional Notes**
The provided implementations include not only MainPage but also SecondPage to test behavior during navigation.

Currently, using navigation via Shell (which prevents multiple instances of the same page in the stack) causes an unexpected crash. We reference the open issue[ #22563 on GitHub](https://github.com/dotnet/maui/issues/22563), but for demonstration purposes, we consider this acceptable within our scope.
