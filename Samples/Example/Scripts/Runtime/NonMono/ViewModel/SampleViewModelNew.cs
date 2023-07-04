/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/25 10:19:32
* Version: v1.0
* Description：The demo of TinyMVVM view model usage. It`s a new view model.
* ==========================================
*/

using AA.Framework.TinyMVVM.ViewMode;

namespace AA.Framework.TinyMVVM.Demo.NonMono
{
    /// <summary>
    /// The demo of TinyMVVM view model usage. It`s a new view model.
    /// </summary>
    public class SampleViewModelNew : ViewModel<SampleModel>
    {
        
        #region Model

        /// <summary>
        /// Bind the new model.
        /// </summary>
        /// <param name="model">the new model</param>
        protected override void OnNewModelBind(SampleModel model)
        {
            base.OnNewModelBind(model);
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "27>";
#endif
        }

        /// <summary>
        /// Finish binding the new model.
        /// </summary>
        public override void OnBindModelComplete()
        {
            base.OnBindModelComplete();
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "28>";
#endif
        }

        /// <summary>
        /// Unbind the old model.
        /// </summary>
        /// <param name="model">the old model</param>
        protected override void OnOldModelUnbind(SampleModel model)
        {
            base.OnOldModelUnbind(model);
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "29>";
#endif
        }

        #endregion
        
        #region Operate

        /// <summary>
        /// Change the value of name.
        /// </summary>
        /// <param name="newValue">the new value</param>
        public void ChangeName(string newValue)
        {
            ModelIns.m_Name.Value = "[" + GetType().Name + "]Name=" + newValue;
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "26>";
#endif
        }

        #endregion
    }
}