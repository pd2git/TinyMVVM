/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/26 21:48:32
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
    public class SampleViewModelForNewModel : ViewModel<SampleModelNew>
    {
        
        #region Model

        /// <summary>
        /// Bind the new model.
        /// </summary>
        /// <param name="model">the new model</param>
        protected override void OnNewModelBind(SampleModelNew model)
        {
            base.OnNewModelBind(model);
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "30>";
#endif
        }

        /// <summary>
        /// Finish binding the new model.
        /// </summary>
        public override void OnBindModelComplete()
        {
            base.OnBindModelComplete();
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "31>";
#endif
        }

        /// <summary>
        /// Unbind the old model.
        /// </summary>
        /// <param name="model">the old model</param>
        protected override void OnOldModelUnbind(SampleModelNew model)
        {
            base.OnOldModelUnbind(model);
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "32>";
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
            ModelIns.m_NewName.Value = "[" + GetType().Name + "]NewName=" + newValue;
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "7>";
#endif
        }

        #endregion
    }
}