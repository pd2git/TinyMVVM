# About TinyMVVM;

This is a tiny MVVM framework for Unity.
Use the TinyMVVM package to build a plugin or a independent module.

Orderly separation of code into Model, ViewModel and View three layers, easy maintenance and management, as well as multi-person collaboration.

For example, use TinyMVVM to guide a Pick Date module design. Split the Pick Date module to three part: Model, View Model and View.
- Model: **_All the data used in the module are designed here._**
- View Model:**_Main logic used in the module are designed here._**
- View: **_All the logic about the UI or something to show used in the module are designed here._**

The TinyMVVM package includes examples about the features above. 
For more information, see the folder "Samples":

- There is a scene named "Example" in the "Scenes" folder.
- It is a example about the usage in the mono object. The scripts files can locate in the folder **_"Samples\Example\Scripts\Runtime\Mono\"_**.
- The scripts in the folder 'NonMono' are about the usage  in the non-mono object. The runtime usage can locate in the folder **_"Tests\Runtime"_**.

# Installing TinyMVVM

To install this package, follow the any one method below:

- Downloaded the release unity package file to local and import it to the project. See [Importing local asset packages](https://docs.unity3d.com/Manual/AssetPackagesImport.html).
- [Git URL](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@latest/index.html)
- [Local Folder](https://docs.unity3d.com/Manual/upm-ui-local.html)

For more information, see [Package Manager Window](https://docs.unity3d.com/Packages/com.unity.package-manager-ui@latest/index.html)

In addition, you need to install the following resources when use the samples :

 - install [Unity UI](https://docs.unity3d.com/Packages/com.unity.ugui@1.0/manual/index.html) (version 1.0 or later). It is installed by default. You can use the name "com.unity.ugui" to install by the steps "[Install a feature set from the Unity registry](https://docs.unity3d.com/Manual/fs-install.html)".
 
<a name="UsingPackageName"></a>
# Using TinyMVVM

1. Design and initialize three modules: Model (data module), View Model (control module) and View (view module).
2. Instantiate the MVVMCore object and call the Combine() method to join the three modules above to form a complete module.
3. According to the needs of the project, create different modules according to the step 1 and step 2. Each module can communicate with the View Model (control module), while the other modules are relatively independent.
4. See Example.unity for details.

# Technical details
## Requirements

This version of TinyMVVM is compatible with the following versions of the Unity Editor:

* 2019.4 and later (recommended)

## Known limitations

TinyMVVM version 1.0.1 includes the following known limitations:

* A MVVMCore object can only combine a group of the MVVM elements(1 model, 1 view model, 1 view) at a time.
* The compatibility of the MVVM elements have to follow the rules of C# type conversions. **_For example, if you change the model, you have to change the view model and the view. Or if you only change the view model to the child class of the old view model, you do not need to change the view. You can cast it to fit the view. See the details in the Examples scripts._**

## Package contents

The following table indicates the &lt;describe the breakdown you used here&gt;:

|Location|Description|
|---|---|
|`Runtime`|Contains the core codes of the framework.|
|`Documentation`|Contains the documents of API by English and Chinese.|
|`Samples\Example\Scripts\Runtime\Mono\`|Contains a example about the usage in the mono object.|
|`Samples\Example\Scripts\Runtime\NonMono\`|Contains a example about the usage in the non-mono object.|
|`Tests\Runtime`|Contains the tests codes of the framework. <br>It is also another example about the usage in the non-mono object. |

## Document revision history

|Date|Reason|
|---|---|
|2023-07-04|Unedited. Published to package.|
|2023-07-02|Document updated for package version 1.0.1.<br>New modifications: <li>Optimized the code structure of the framework.<li>The compatibility has been upgraded to version 2019.4 of Unity.|
|2023-06-29|Document updated for package version 0.2.1.<br>New features: <li>Built the base of the framework for mono.|
|2023-06-24|Document created. Matches package version 0.1.3|
