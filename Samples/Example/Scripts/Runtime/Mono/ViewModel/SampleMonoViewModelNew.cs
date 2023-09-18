/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/29 11:54:32
* Version: v1.0
* Description：Another demo of TinyMVVM view model usage on the MonoBehaviour class.
* ==========================================
*/

using AA.TinyMVVM.ViewMode;

namespace AA.TinyMVVM.Demo.Mono
{
    /// <summary>
    /// Another demo of TinyMVVM view model usage on the MonoBehaviour class.
    /// </summary>
    public class SampleMonoViewModelNew : MonoViewModel<SampleMonoModel>
    {
        #region Model

        /// <summary>
        /// Bind the new model.
        /// </summary>
        /// <param name="model">the new model</param>
        protected override void OnNewModelBind(SampleMonoModel model)
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
        protected override void OnOldModelUnbind(SampleMonoModel model)
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
            ModelIns.m_Name.Value = "[" + GetType().Name + "]Name=" + newValue;
        }

        /// <summary>
        /// Get the model which binding to the view model.
        /// </summary>
        /// <returns>the model</returns>
        public SampleMonoModel GetModel()
        {
            return ModelIns;
        }

        #endregion
    }
}