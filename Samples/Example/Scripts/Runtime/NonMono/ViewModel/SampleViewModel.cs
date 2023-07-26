/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/24 21:19:32
* Version: v1.1.0
* Description：The demo of TinyMVVM view model usage
* ==========================================
*/

using AA.Framework.TinyMVVM.ViewMode;
using UnityEngine;

namespace AA.Framework.TinyMVVM.Demo.NonMono
{
    /// <summary>
    /// The demo of TinyMVVM view model usage
    /// </summary>
    public class SampleViewModel : ViewModel<SampleModel>
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
            LogMarker.Mark += "16>";
#endif
        }

        /// <summary>
        /// Finish binding the new model.
        /// </summary>
        public override void OnBindModelComplete()
        {
            base.OnBindModelComplete();
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "17>";
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
            LogMarker.Mark += "18>";
#endif
        }

        #endregion
        
        #region Operate

        /// <summary>
        /// Change the value of name.
        /// </summary>
        /// <param name="newValue">the new value</param>
        public virtual void ChangeName(string newValue)
        {
            ModelIns.m_Name.Value = "[" + GetType().Name + "]Name=" + newValue;
#if UNITY_INCLUDE_TESTS
            LogMarker.Mark += "3>";
#endif
        }

        /// <summary>
        /// Get the model which binding to the view model.
        /// </summary>
        /// <returns>the model</returns>
        public SampleModel GetModel()
        {
            return ModelIns;
        }

        #endregion

        #region Combine & Break

        /// <summary>
        /// Call on the mvvm elements combined completely.
        /// </summary>
        protected override void OnCombineComplete()
        {
            base.OnCombineComplete();
            Debug.Log('[' + GetType().Name + "]Combine completed.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "36>";
#endif
        }
        
        /// <summary>
        /// Call on the mvvm elements start to broke up all.
        /// </summary>
        protected override void OnBreakUpAllStart()
        {
            Debug.Log('[' + GetType().Name + "]Started break up all.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "54>";
#endif
        }
        
        /// <summary>
        /// Call on the mvvm elements broken up all completely.
        /// </summary>
        protected override void OnBreakUpAllComplete()
        {
            base.OnBreakUpAllComplete();
            Debug.Log('[' + GetType().Name + "]Break up all completed.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "51>";
#endif
        }

        #endregion
    }
}