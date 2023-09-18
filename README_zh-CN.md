# TinyMVVM 
语言：简体中文, [English](/README.md)

这是有关本框架的一个简单说明。详见 **_"[Example](/Samples/Example/)"_** 和 **_"[Documentation](/Documentation)"_** 文件夹。

## 版本［1.2.0］

## 功能
1. 这是一个基于Unity的微小的MVVM框架，适用于制作一些插件。
2. 将代码有序分离成 **_Model_** 、 **_ViewModel_** 及 **_View_** 三层，便于维护与管理，还有多人协作。
3. 将对象用对象池组织，提升对象生成的效率。

## 使用
1. 设计并初始化 **_Model（数据模块）_**、 **_View Model（控制模块）_**、 **_View（视图模块）_** 三个模块。
2. 实例化 **_MVVMCore对象_** ，调用 **_Combine()_** 方法联结好上述三个模块，以组成一个完成的整体模组。
3. 根据项目需要按步骤1和2创建不同的模组，各模组间通过 **_View Model（控制模块）_** 通讯即可，而其它模块相对独立。

## 依赖
- 如果需要查看 **_"[Documentation](/Documentation)"_** 文件夹 ，则需要安装 **_Unity UI（版本1.0以上）_** 。