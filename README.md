# WinUI Demo Application - settings module

## Description
This project is a demonstration of a WinUI application that showcases the implementation of various navigation components, including settings module, frames, breadcrumbs navigation, translation strings resource, and usage of `ApplicationData.Current.LocalSettings`.

### Features
- **NavigationView**: Provides a modern navigation experience with a sidebar menu.
- **Frame Navigation**: Enables content navigation within the application.
- **Breadcrumbs Navigation**: Demonstrates hierarchical navigation for better user experience.
- **Localization**: Implements translation strings using resource files for multilingual support.
- **Settings Management**: Utilizes `ApplicationData.Current.LocalSettings` to store and retrieve user settings.
- **Data Protection API (DPAPI)**: Ensures secure storage of sensitive data using Windows Data Protection API.
- **MVVM Community Toolkit**: Implements the MVVM pattern using the MVVM Community Toolkit for clean and maintainable code.

### Usage
- Navigate through the app using the sidebar menu.
- Check out the settings page to see how user preferences are stored locally.
- Explore the breadcrumbs navigation to understand hierarchical navigation.
- Switch languages to see the localization in action.
- Review the secure storage of sensitive data using the Data Protection API (DPAPI).
- Observe the implementation of the MVVM pattern using the MVVM Community Toolkit for clean and maintainable code.

### SLNX Support
[More info about SLNX support](https://devblogs.microsoft.com/dotnet/introducing-slnx-support-dotnet-cli/)

This project uses SLNX for solution management. If you do not have SLNX activated, you can still open and work with the project by following these steps:
1. Install the .NET SDK 8.0 or later.
2. Use the .NET CLI to open the solution: `dotnet sln add <path-to-solution-file>`