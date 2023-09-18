/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/24 21:19:32
* Version: v1.0
* Description：Another demo of TinyMVVM view model usage. It`s a child of SampleViewModel.
* ==========================================
*/

namespace AA.TinyMVVM.Demo.NonMono
{
    /// <summary>
    /// Another demo of TinyMVVM view model usage. It`s a child of SampleViewModel.
    /// </summary>
    public class SampleViewModelChild : SampleViewModel
    {
        /// <summary>
        /// Change the value of name.
        /// </summary>
        /// <param name="newValue">the new value</param>
        public override void ChangeName(string newValue)
        {
            ModelIns.m_Name.Value = "[" + GetType().Name + "]Name=" + newValue;
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "25>";
#endif
        }
        
    }
}