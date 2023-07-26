# Changelog
This is a tiny MVVM framework, suitable for making some plug-ins.
<br>Orderly separation of code into Model, ViewModel and View three layers, easy maintenance and management, as well as multi-person collaboration.

## [1.1.0] - 2023-07-26

### Added
- Added a interface to response the combined completely of the MVVM elements.
- Added a module named 'Object Pool' to promote the performance of objects generation.
- Added some samples about the module named 'Object Pool'.
- Added a interface to response the break up completely of the MVVM elements.
- Added a template about Model with name 'Model'.
- Added a interface to response the starting of break up of the MVVM elements.

### Fixed
- Fixed the bug which MVVMCore combines the same element multiple times and still triggers completion event.

## [1.0.1] - 2023-07-02

### Changed
- Optimized the code structure of the framework. 
- Made a constraint to the demo scripts for a better experience.
- The compatibility has been upgraded to version 2019.4 of Unity.
### Fixed
- Fixed the bug which objects leak in the combining.

## [0.2.1] - 2023-06-29

### Added
- Built the base of the framework for mono.
### Fixed
- Fixed the bugs of the samples.

## [0.1.3] - 2023-06-24

### This is the first release of *\<TinyMVVM\>*.

- Built the three elements of the MVVM framework: Model, ViewModel, View.