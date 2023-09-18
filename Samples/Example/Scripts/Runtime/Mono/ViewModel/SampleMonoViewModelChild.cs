/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/29 11:41:32
* Version: v1.0
* Description：Another demo of TinyMVVM view model usage on the MonoBehaviour class. It is the child of the SampleMonoViewModel class.
* ==========================================
*/


namespace AA.TinyMVVM.Demo.Mono
{
    /// <summary>
    /// Another demo of TinyMVVM view model usage on the MonoBehaviour class. It is the child of the SampleMonoViewModel class.
    /// </summary>
    public class SampleMonoViewModelChild : SampleMonoViewModel
    {
        #region Operate

        /// <summary>
        /// Change the value of name.
        /// </summary>
        /// <param name="newValue">the new value</param>
        public override void ChangeName(string newValue)
        {
            ModelIns.m_Name.Value = "[" + GetType().Name + "]Name=" + newValue;
        }

        #endregion
    }
}