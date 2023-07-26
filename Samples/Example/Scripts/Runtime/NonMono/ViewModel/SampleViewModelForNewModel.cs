/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/26 21:48:32
* Version: v1.1.0
* Description：The demo of TinyMVVM view model usage. It`s a new view model.
* ==========================================
*/

using AA.Framework.TinyMVVM.ViewMode;
using UnityEngine;

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

        #region Break

        /// <summary>
        /// Call on the mvvm elements start to broke up all.
        /// </summary>
        protected override void OnBreakUpAllStart()
        {
            Debug.Log('[' + GetType().Name + "]Started break up all.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "58>";
#endif
        }
        
        /// <summary>
        /// Call on the mvvm elements combined completely.
        /// </summary>
        protected override void OnCombineComplete()
        {
            base.OnCombineComplete();
            Debug.Log('[' + GetType().Name + "]Combine completed.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "41>";
#endif
        }

        #endregion
    }
}