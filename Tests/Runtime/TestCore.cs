/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/26 10:57:57
* Version: v1.0
* Description：Test
* ==========================================
*/

using AA.Framework.TinyMVVM.Demo;
using AA.Framework.TinyMVVM.Demo.NonMono;
using NUnit.Framework;

public class TestCore
{
    /// <summary>
    /// 测试三模块协作开始与解除
    /// </summary>
    [Test]
    public void TestCombineAndBreak()
    {
        // 定义View
        var sampleView = new SampleView();
        var sampleViewForNewVM = new SampleViewForNewVM();
        var sampleViewForNewModel = new SampleViewForNewModel();
        
        // 1.初始化，协作连接。
        LogMarker.Mark = string.Empty;
        var isReady = MVVMSample.Ins.Initialize(sampleView, sampleViewForNewVM, sampleViewForNewModel);
        Assert.IsTrue(isReady);
        // 检查执行点
        Assert.AreEqual("16>17>14>1>12>4>", LogMarker.Mark);
        
        // 2.改变Model值
        LogMarker.Mark = string.Empty;
        sampleView.ChangeName("New Name in Tests.");
        // 检查执行点
        Assert.AreEqual("2>3>", LogMarker.Mark);
        // 检查新的Model值
        Assert.AreEqual("[SampleViewModel]Name=New Name in Tests.", sampleView.GetName());
        
        // 3.断开协作
        LogMarker.Mark = string.Empty;
        var viewModel = sampleView.GetViewModel();
        MVVMSample.Ins.UnInitialize(); 
        // 检查执行点
        Assert.AreEqual("13>15>18>", LogMarker.Mark);
        // 检查释放后的值
        Assert.IsNull(sampleView.GetViewModel());
        Assert.IsNull(viewModel.GetModel());
    }
    
    /// <summary>
    /// 测试MVVM模块切换
    /// </summary>
    [Test]
    public void TestMVVMGroupSwitch()
    {
        // 0.1.定义View
        var sampleView = new SampleView();
        var sampleViewForNewVM = new SampleViewForNewVM();
        var sampleViewForNewModel = new SampleViewForNewModel();
        // 0.2.初始化，协作连接。
        var isReady = MVVMSample.Ins.Initialize(sampleView, sampleViewForNewVM, sampleViewForNewModel);
        Assert.IsTrue(isReady);

        // 1.切换MVVM组1
        LogMarker.Mark = string.Empty;
        sampleView.SwitchMVVM();
        // 检查执行点
        Assert.AreEqual("18>15>16>17>14>1>", LogMarker.Mark);
        // 改变Model值
        LogMarker.Mark = string.Empty;
        sampleView.ChangeName("New Name in Tests1.");
        // 检查执行点
        Assert.AreEqual("2>25>", LogMarker.Mark);
        // 检查新的Model值
        Assert.AreEqual("[SampleViewModelChild]Name=New Name in Tests1.", sampleView.GetName());
        
        // 2.切换MVVM组2
        LogMarker.Mark = string.Empty;
        sampleViewForNewVM.SwitchMVVM();
        // 检查执行点
        Assert.AreEqual("18>15>13>27>28>23>5>33>8>", LogMarker.Mark);
        // 改变Model值
        LogMarker.Mark = string.Empty;
        sampleViewForNewVM.ChangeName("New Name in Tests2.");
        // 检查执行点
        Assert.AreEqual("6>26>", LogMarker.Mark);
        // 检查新的Model值
        Assert.AreEqual("[SampleViewModelNew]Name=New Name in Tests2.", sampleViewForNewVM.GetName());
        
        // 3.切换MVVM组3
        LogMarker.Mark = string.Empty;
        sampleViewForNewModel.SwitchMVVM();
        // 检查执行点
        Assert.AreEqual("29>34>24>30>31>19>9>21>11>", LogMarker.Mark);
        // 改变Model值
        LogMarker.Mark = string.Empty;
        sampleViewForNewModel.ChangeName("New Name in Tests3.");
        // 检查执行点
        Assert.AreEqual("10>7>", LogMarker.Mark);
        // 检查新的Model值
        Assert.AreEqual("[SampleViewModelForNewModel]NewName=New Name in Tests3.", sampleViewForNewModel.GetName());
        
        // 4.切换MVVM组0
        LogMarker.Mark = string.Empty;
        sampleView.SwitchMVVM();
        // 检查执行点
        Assert.AreEqual("32>22>20>16>17>14>1>12>4>", LogMarker.Mark);
        // 改变Model值
        LogMarker.Mark = string.Empty;
        sampleView.ChangeName("New Name in Tests0.");
        // 检查执行点
        Assert.AreEqual("2>3>", LogMarker.Mark);
        // 检查新的Model值
        Assert.AreEqual("[SampleViewModel]Name=New Name in Tests0.", sampleView.GetName());
    }

    
}
