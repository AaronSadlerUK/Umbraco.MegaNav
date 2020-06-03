# Change Log
All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](http://keepachangelog.com/) and this project adheres to [Semantic Versioning](http://semver.org/).

## [8.0.5] - 2020-06-03
### Changed
* Split into projects / packages, MegaNavV8.Core and MegaNavV8.Web, this now has 2 separate NuGet packages

## [8.0.1] - 2020-06-03
### Changed
* Changed dependencies from UmbracoCms to UmbracoCms.Web and UmbracoCms.Core

## [8.0.0] - 2020-05-31
### Added
* Umbraco V8 support - Added in V2.0.0 by Callum Whyte
* Added support for querystrings / anchors

### Changed
* Renamed to MegaNavV8 to be separate from the original MegaNav plugin

### Fixed
* Changed to use UDI instead of ID to work with Umbraco Cloud Deploy

## [1.1.2] - 2018-20-08
### Fixed
* Nav item settings dialog not functioning in Umbraco v7.12

## [1.1.1] - 2018-17-01
### Fixed
* Exception thrown when trying to render an empty Meganav

## [1.1.0] - 2017-23-07
### Added
* Support for UmbracoNaviHide on content items
* Handling legacy icons returned by Umbraco APIs
* Required field validation to nav item settings
* This CHANGELOG file
* AppVeyor configuration to allow for automated builds and tests
* Project version number to package.json for automated builds

### Changed
* Re-targeting package to Umbraco 7.4+
* Replaced Umbraco Link Picker with custom Umbraco UI overlay to allow for further customisation
* Updated documentation to reflect UmbracoNaviHide support

### Fixed
* Node names not updating after save
* Legacy node icons rendering incorrectly
* Changes persisting after editing a nav item then cancelling the changes
* Duplicate files in NuGet package

## [1.0.1] - 2017-10-03
### Added
* Nuspec file to allow for publishing to NuGet.org
* Assembly descriptions on the project DLLs

### Fixed
* Fix issues with NuGet packaging

## [1.0.0] - 2017-01-03
### Added
* Initial release of Meganav for Umbraco 7.5
* Build scripts
* README file with information about the project and screenshots
* MIT license in the form of a LICENSE.md file

[Unreleased]: https://github.com/thecogworks/meganav/compare/v1.1.2...HEAD
[1.1.2]: https://github.com/thecogworks/meganav/compare/v1.1.1...v1.1.2
[1.1.1]: https://github.com/thecogworks/meganav/compare/v1.1.0...v1.1.1
[1.1.0]: https://github.com/thecogworks/meganav/compare/v1.0.1...v1.1.0
[1.0.1]: https://github.com/thecogworks/meganav/compare/v1.0.0...v1.0.1
