# 更新日志
这是一个微型MVVM框架，适合做一些插件。
<br>代码有序分离为Model、ViewModel和View三层，易于维护和管理，以及多人协作。

## [1.2.1] - 2023-12-26

### 修复
- 修复核心模块在IL2CPP脚本后端Android平台下编译失败的问题。

## [1.2.0] - 2023-09-18

### 更新
- 将有关此框架生命周期的自述文件添加到描述文档中。

### 已更改
- 更改框架的命名空间。
- 优化部分示例代码日志。

## [1.1.0] - 2023-07-26

### 更新
- 添加了一个接口来响应MVVM元素的组合完成时事件。
- 新增“对象池”模块，提升对象生成性能。
- 添加了一些有关名为“对象池”的模块的示例。
- 添加了一个接口来响应MVVM元素的分离完成时事件。
- 添加了一个名为“Model”的关于Model的模板。
- 添加了一个接口来响应MVVM元素分解的开始时事件。

### 修复
- 修复了MVVMCore多次组合同一元素仍会触发完成事件的bug。

## [1.0.1] - 2023-07-02

### 变更
- 优化了框架的代码结构。
- 对演示脚本进行了约束，以获得更好的体验。
- 兼容性已升级到 Unity 2019.4 版本。

### 修复
- 修复了组合中对象泄漏的bug。

## [0.2.1] - 2023-06-29

### 新增
- 构建了mono框架的基础。

### 修复
- 修复了示例的bug。

## [0.1.3] - 2023-06-24

### 这是 *<TinyMVVM>* 的第一个版本。

- 构建了MVVM框架的三个元素：Model、ViewModel、View。