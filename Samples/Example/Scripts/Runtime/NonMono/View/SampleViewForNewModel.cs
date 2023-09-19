/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/26 22:40:06
* Version: v1.2
* Description：The demo of TinyMVVM view usage
* ==========================================
*/

using AA.TinyMVVM.View;
using UnityEngine;

namespace AA.TinyMVVM.Demo.NonMono
{
    /// <summary>
    /// The demo of TinyMVVM view usage
    /// </summary>
    public class SampleViewForNewModel : View<SampleViewModelForNewModel, SampleModelNew>
    {
        #region Bind

        #region Model

        /// <summary>
        /// Bind the new model.
        /// </summary>
        /// <param name="model">the new model</param>
        protected override void OnNewModelBind(SampleModelNew model)
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
            Debug.Log('[' + GetType().Name + "]init 'NewName' from model:" + BindingData.m_NewName.Value);
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "11>";
#endif
        }

        /// <summary>
        /// Unbind the old model.
        /// </summary>
        /// <param name="model">the old model</param>
        protected override void OnOldModelUnbind(SampleModelNew model)
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
        protected override void OnNewViewModelBind(SampleViewModelForNewModel viewModel)
        {
            base.OnNewViewModelBind(viewModel);
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "19>";
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
            LogMarker.Mark += "9>";
#endif
        }

        /// <summary>
        /// Unbind the old view model.
        /// </summary>
        /// <param name="viewModel">the old view model</param>
        protected override void OnOldViewModelUnbind(SampleViewModelForNewModel viewModel)
        {
            base.OnOldViewModelUnbind(viewModel);
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "20>";
#endif
        }

        #endregion

        #region Common

        /// <summary>
        /// Bind view elements to a model.
        /// </summary>
        /// <param name="model">a model</param>
        private void BindToModel(SampleModelNew model)
        {
            model.m_NewName.OnValueChanged += NameValueChanged;
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "21>";
#endif
        }

        /// <summary>
        /// Unbind view elements to a model.
        /// </summary>
        /// <param name="model">a model</param>
        private void UnbindToModel(SampleModelNew model)
        {
            model.m_NewName.OnValueChanged -= NameValueChanged;
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "22>";
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
            Debug.Log('[' + GetType().Name + "]'NewName':old:" + oldValue + ",new:" + newValue);
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "10>";
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
            return BindingData.m_NewName.Value;
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

        #endregion

        #region Break

        /// <summary>
        /// Call on the mvvm elements combined completely.
        /// </summary>
        protected override void OnCombineComplete()
        {
            base.OnCombineComplete();
            Debug.Log('[' + GetType().Name + "]Combine completed.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "42>";
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
            LogMarker.Mark += "59>";
#endif
        }

        #endregion
    }
}