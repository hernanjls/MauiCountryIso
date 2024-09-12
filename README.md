# Country ISO MAUI App

This is a simple example of a mobile application built with .NET MAUI using the MVVM (Model-View-ViewModel) design pattern. The application demonstrates good practices for creating mobile apps with MAUI, focusing on consuming a REST API for countries based on the ISO specification.

## Features

- **MVVM Architecture**: The app uses the **MVVM pattern** to separate the business logic from the UI, providing a clean and maintainable codebase.
- **REST API Integration**: It consumes a REST API that returns country details using ISO standards for country codes.
  
## Libraries and Tools

The app utilizes the following .NET MAUI native libraries:

- [CommunityToolkit.Maui](https://www.nuget.org/packages/CommunityToolkit.Maui/) (Version 5.2.0)
- [CommunityToolkit.Mvvm](https://www.nuget.org/packages/CommunityToolkit.Mvvm/) (Version 8.2.2)

These libraries help in improving productivity by simplifying the implementation of common mobile app features, like UI controls and MVVM support.

## How It Works

The application is focused on demonstrating the following key principles:

1. **MVVM Pattern**: 
   - The UI is entirely separate from the logic of the app, which resides in the ViewModels.
   - ViewModels interact with the REST API to fetch and manage data.

2. **REST API Consumption**:
   - The app retrieves country data based on the ISO standard via a REST API.
   - It uses good practices for asynchronous calls, ensuring a smooth user experience with proper error handling.

## Structure

The application is structured as follows:

- **Views**: Contains the pages that define the UI of the app.
- **ViewModels**: Contains the logic for binding the data to the UI.
- **Models**: Represents the data objects that map to the ISO country data.

## How to Build and Run

1. Clone the repository:
    ```bash
    git clone https://github.com/hernanjls/MauiCountryIso
    ```

2. Restore the necessary NuGet packages:
    ```bash
    dotnet restore
    ```

3. Build and run the project using Visual Studio or from the command line:
    ```bash
    dotnet build
    dotnet run
    ```
