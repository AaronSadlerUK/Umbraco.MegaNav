[![Build Status](https://dev.azure.com/TerrabitHost/MegaNavV8/_apis/build/status/MegaNavV8-ASP.NET-CI?branchName=master)](https://dev.azure.com/TerrabitHost/MegaNavV8/_build/latest?definitionId=12&branchName=master)

# Umbraco MeganavV8

## Getting started

This package is supported on Umbraco 8.4+.

### Installation

MeganavV8 is available from [Our Umbraco](https://our.umbraco.com/packages/website-utilities/umbracomeganavv8/), [NuGet](https://www.nuget.org/packages/AaronSadler.MegaNavV8.Web/), or as a manual download directly from GitHub.

#### NuGet package repository
To [install UI from NuGet](https://www.nuget.org/packages/AaronSadler.MegaNavV8.Web/), run the following command in your instance of Visual Studio.

    PM> Install-Package AaronSadler.MegaNavV8.Web
	
To [install Core from NuGet](https://www.nuget.org/packages/AaronSadler.MegaNavV8.Core/), run the following command in your instance of Visual Studio.

    PM> Install-Package AaronSadler.MegaNavV8.Core

## Usage

After installing the package, you will have a new property editor called MegaNavV8 in the Umbraco backoffice.

Here you can configure the "Max depth" of the navigation - the maximum number of levels deep at which an editor can place nav items. You also have the option to prevent nav items where the _umbracoNaviHide_ property has been set from rendering on the front-end - these items will still appear in the backoffice but not on your website, you can still edit or change them as you wish. By default both of these settings are left unset.

Now in V8 you can set the querystring / anchor in a seperate input box the same way as the MultiUrlPicker.

Now your Data Type is ready, we need to add it to a Document Type. This is done in the usual way - you will find Meganav appears in the "pickers" section when selecting a property to add.

![Meganav Property Editor](docs/img/property-editor.jpg?raw=true)

Wow! That was easy! You now have a shiny new navigation picker setup for your content editors to enjoy.

In the backoffice, the design of Meganav closely follows the other pickers in Umbraco to ensure your editor's experience is as familiar as possible.

![Meganav](docs/img/nav-items.jpg?raw=true)

Click and drag an item to change it's position within the navigation; drop it wherever you choose. Unpublished items will appear faded out and will not show on the front-end of the website. If you have the "Remove NaviHide Items" setting enabled, any items where the _umbracoNaviHide_ property has been set on the selected content node will appear with a red outline in the backoffice and will also not show on the front-end.

![Meganav Edit Item](docs/img/edit-nav-item.jpg?raw=true)

When editing a navigation item you have the flexibility to modify how the link behaves on the front-end. Entering text into the "Link Title" field will display in place of the select content's name. Changing the "Target" property alters how the link opens when clicked; either in the current window, a new tab, or a new browser window.

### Integration

Meganav was designed to be as clean and simple for developers as it is for content editors.

Check out the [integration guide](docs/integration-guide.md) to learn how to embed the package in your site.

### Contribution guidelines

To raise a new bug, create an issue on the GitHub repository. To fix a bug or add new features, fork the repository and send a pull request with your changes. Feel free to add ideas to the repository's issues list if you would to discuss anything related to the package.

### Who do I talk to?
This project is maintained by [Aaron Sadler](https://aaronsadler.uk) and contributors. If you have any questions about the project please contact me through [Twitter](https://twitter.com/AaronSadlerUK), or by raising an issue on GitHub.

### A special #h5yr to the orignal author

* [Callum Whyte](https://github.com/callumbwhyte)

## License

Copyright &copy; 2020 [Callum Whyte](https://github.com/callumbwhyte) & [Aaron Sadler](https://aaronsadler.uk), and other contributors

Licensed under the MIT License.
