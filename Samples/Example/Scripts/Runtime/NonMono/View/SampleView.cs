/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/26 22:18:06
* Version: v1.0
* Description：The demo of TinyMVVM view usage
* ==========================================
*/

using AA.Framework.TinyMVVM.View;
using UnityEngine;

namespace AA.Framework.TinyMVVM.Demo.NonMono
{
    /// <summary>
    /// The demo of TinyMVVM view usage
    /// </summary>
    public class SampleView : View<SampleViewModel, SampleModel>
    {
        #region Bind

        #region Model

        /// <summary>
        /// Bind the new model.
        /// </summary>
        /// <param name="model">the new model</param>
        protected override void OnNewModelBind(SampleModel model)
        {
            base.OnNewModelBind(model);
            BindToModel(model);
        }

        /// <summary>
        /// Finish binding the new model.
        /// </summary>
        protected override void OnBindModelComplete()
        {
            base.OnBindModelComplete();
            Debug.Log('[' + GetType().Name + "]init 'Name' from model:" + BindingData.m_Name.Value);
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "4>";
#endif
        }

        /// <summary>
        /// Unbind the old model.
        /// </summary>
        /// <param name="model">the old model</param>
        protected override void OnOldModelUnbind(SampleModel model)
        {
            base.OnOldModelUnbind(model);
            UnbindToModel(model);
        }

        #endregion

        #region View Model

        /// <summary>
        /// Bind the new view model.
        /// </summary>
        /// <param name="viewModel">the new model</param>
        protected override void OnNewViewModelBind(SampleViewModel viewModel)
        {
            base.OnNewViewModelBind(viewModel);
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "14>";
#endif
        }

        /// <summary>
        /// Finish binding the new view model.
        /// </summary>
        protected override void OnBindViewModelComplete()
        {
            base.OnBindViewModelComplete();
            Debug.Log("[" + GetType().Name + "]OnBindViewModelComplete");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "1>";
#endif
        }

        /// <summary>
        /// Unbind the old view model.
        /// </summary>
        /// <param name="viewModel">the old view model</param>
        protected override void OnOldViewModelUnbind(SampleViewModel viewModel)
        {
            base.OnOldViewModelUnbind(viewModel);
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "15>";
#endif
        }

        #endregion

        #region Common

        /// <summary>
        /// Bind view elements to a model.
        /// </summary>
        /// <param name="model">a model</param>
        private void BindToModel(SampleModel model)
        {
            model.m_Name.OnValueChanged += NameValueChanged;
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "12>";
#endif
        }
        
        /// <summary>
        /// Unbind view elements to a model.
        /// </summary>
        /// <param name="model">a model</param>
        private void UnbindToModel(SampleModel model)
        {
            model.m_Name.OnValueChanged -= NameValueChanged;
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "13>";
#endif
        }

        #endregion

        #endregion

        #region Data Change

        /// <summary>
        /// Response the variation of the name value in the model.
        /// </summary>
        /// <param name="oldValue">the old value</param>
        /// <param name="newValue">the new value</param>
        private void NameValueChanged(string oldValue, string newValue)
        {
            Debug.Log('[' + GetType().Name + "]'Name':old:" + oldValue + ",new:" + newValue);
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "2>";
#endif
        }

        #endregion

        #region Operator

        /// <summary>
        /// Change the value of name.
        /// </summary>
        /// <param name="text">the new value</param>
        public void ChangeName(string text)
        {
            BindingVM.ChangeName(text);
        }

        /// <summary>
        /// Get the value of the name in the model.
        /// </summary>
        /// <returns>the value of the name</returns>
        public string GetName()
        {
            return BindingData.m_Name.Value;
        }

        /// <summary>
        /// Switch the elements of the mvvm.
        /// </summary>
        public void SwitchMVVM()
        {
            var newViewModel = MVVMSample.Ins.SwitchMVVM();
            if (newViewModel == null)
            {
                return;
            }

            //
            Debug.Log('[' + GetType().Name + "]Has switched to the view model named '" + newViewModel + "'.");
        }

        /// <summary>
        /// Get the view model which binding to the view.
        /// </summary>
        /// <returns>the view model</returns>
        public SampleViewModel GetViewModel()
        {
            return BindingVM;
        }

        #endregion
    }
}