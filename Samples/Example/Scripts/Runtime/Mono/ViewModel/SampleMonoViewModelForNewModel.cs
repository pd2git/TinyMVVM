/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/29 12:00:32
* Version: v1.0
* Description：The demo of TinyMVVM view model usage for the new model on the MonoBehaviour class.
* ==========================================
*/

using AA.Framework.TinyMVVM.ViewMode;

namespace AA.Framework.TinyMVVM.Demo.Mono
{
    /// <summary>
    /// The demo of TinyMVVM view model usage for the new model on the MonoBehaviour class.
    /// </summary>
    public class SampleMonoViewModelForNewModel : MonoViewModel<SampleMonoModelNew>
    {
        #region Model

        /// <summary>
        /// Bind the new model.
        /// </summary>
        /// <param name="model">the new model</param>
        protected override void OnNewModelBind(SampleMonoModelNew model)
        {
            base.OnNewModelBind(model);
            // Show the model game object
            model.gameObject.SetActive(true);
            // Show self
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Finish binding the new model.
        /// </summary>
        public override void OnBindModelComplete()
        {
            base.OnBindModelComplete();
        }

        /// <summary>
        /// Unbind the old model.
        /// </summary>
        /// <param name="model">the old model</param>
        protected override void OnOldModelUnbind(SampleMonoModelNew model)
        {
            base.OnOldModelUnbind(model);
            // Hide the model game object
            model.gameObject.SetActive(false);
            // Hide self
            gameObject.SetActive(false);
        }

        #endregion
        
        #region Operate

        /// <summary>
        /// Change the value of name.
        /// </summary>
        /// <param name="newValue">the new value</param>
        public void ChangeName(string newValue)
        {
            ModelIns.m_NewName.Value = "[" + GetType().Name + "]Name=" + newValue;
        }

        /// <summary>
        /// Get the model which binding to the view model.
        /// </summary>
        /// <returns>the model</returns>
        public SampleMonoModelNew GetModel()
        {
            return ModelIns;
        }

        #endregion
    }
}