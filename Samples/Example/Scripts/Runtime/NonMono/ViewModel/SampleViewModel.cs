/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/24 21:19:32
* Version: v1.0
* Description：The demo of TinyMVVM view model usage
* ==========================================
*/

using AA.Framework.TinyMVVM.ViewMode;

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
    }
}