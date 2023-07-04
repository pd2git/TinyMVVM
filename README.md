# TinyMVVM 
Language：English, [简体中文](/README_CN.md)

This is a brief description of the framework. See the folders **_"[Example](/Samples/Example/)"_** and **_"[Documentation](/Documentation)"_** for details.

## version[1.0.1]

## Function
1. This is a tiny MVVM framework for Unity, suitable for making some plug-ins.
2. Orderly separation of code into **_Model_**, **_ViewModel_** and **_View_** three layers, easy maintenance and management, as well as multi-person collaboration.

## Usage
1. Design and initialize three modules: **_Model (data module)_**, **_View Model (control module)_** and **_View (view module)_**.
2. Instantiate the **_MVVMCore_** object and call the **_Combine()_** method to join the three modules above to form a complete module.
3. According to the needs of the project, create different modules according to the step 1 and step 2. Each module can communicate with the **_View Model (control module)_**, while the other modules are relatively independent.

## Dependence
- If you need to view folder **_"[Documentation](/Documentation)"_**, you need to install **_Unity UI (version 1.0 or later)_**.