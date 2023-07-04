/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/24 20:33:06
* Version: v1.0
* Description：The demo of TinyMVVM view usage for a new model.
* ==========================================
*/

using System.Text;
using AA.Framework.TinyMVVM.Model;
using AA.Framework.TinyMVVM.View;
using AA.Framework.TinyMVVM.ViewMode;
using UnityEngine;
using UnityEngine.UI;

namespace AA.Framework.TinyMVVM.Demo.Mono
{
    /// <summary>
    /// The demo of TinyMVVM view usage for a new model.
    /// </summary>
    public class SampleMonoViewForNewModel : MonoView<SampleMonoViewModelForNewModel, SampleMonoModelNew>
    {
        #region Bind

        #region Model

        /// <summary>
        /// Bind the new model.
        /// </summary>
        /// <param name="model">the new model</param>
        protected override void OnNewModelBind(SampleMonoModelNew model)
        {
            base.OnNewModelBind(model);
            model.m_NewName.OnValueChanged += NameValueChanged;
        }
        
        /// <summary>
        /// Finish binding the new model.
        /// </summary>
        protected override void OnBindModelComplete()
        {
            m_NameShower.text = BindingData.m_NewName.Value;
        }

        /// <summary>
        /// Unbind the old model.
        /// </summary>
        /// <param name="model">the old model</param>
        protected override void OnOldModelUnbind(SampleMonoModelNew model)
        {
            base.OnOldModelUnbind(model);
            model.m_NewName.OnValueChanged -= NameValueChanged;
        }
        
        #endregion
        
        #region View Model
        
        /// <summary>
        /// Bind the new view model.
        /// </summary>
        /// <param name="viewModel">the new model</param>
        protected override void OnNewViewModelBind(SampleMonoViewModelForNewModel viewModel)
        {
            base.OnNewViewModelBind(viewModel);
            // Build result log
            var result = new StringBuilder();
            result.Append("Model:");
            result.Append(((IViewModel<IModel>)viewModel).Model.GetType().Name);
            result.Append('\n');
            result.Append("View Model:");
            result.Append(viewModel.GetType().Name);
            result.Append('\n');
            result.Append("View:");
            result.Append(GetType().Name);
            m_MVVMShower.text = result.ToString();
            //
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Unbind the old view model.
        /// </summary>
        /// <param name="viewModel">the old view model</param>
        protected override void OnOldViewModelUnbind(SampleMonoViewModelForNewModel viewModel)
        {
            base.OnOldViewModelUnbind(viewModel);
            gameObject.SetActive(false);
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
            m_NameShower.text = newValue;
        }

        #endregion

        #region UI

        [Tooltip("Name show")]
        [SerializeField] private Text m_NameShower;
        
        [Tooltip("Edit name")]
        [SerializeField] private InputField m_NameEditor;
        
        /// <summary>
        /// Change the value of name.
        /// </summary>
        /// <param name="text">the new value</param>
        private void OnSubmit(string text)
        {
            BindingVM.ChangeName(text);
        }
        
        [Tooltip("Change the view model")]
        [SerializeField] private Button m_ViewModelChanger;
        
        [Tooltip("MVVM show")]
        [SerializeField] private Text m_MVVMShower;

        /// <summary>
        /// Switch the elements of the mvvm.
        /// </summary>
        private void OnSwitchMVVM()
        {
            var newViewModel = MVVMMonoSample.Ins.SwitchMVVM();
            if (newViewModel == null)
            {
                return;
            }
            //
            Debug.Log('[' + GetType().Name + "]Has switched to the view model named '" + newViewModel + "'.");
        }

        #endregion

        #region U3D

        protected void OnEnable()
        {
#if UNITY_2021_3_OR_NEWER
            m_NameEditor.onSubmit.AddListener(OnSubmit);
#else
            m_NameEditor.onEndEdit.AddListener(OnSubmit);
#endif
            m_ViewModelChanger.onClick.AddListener(OnSwitchMVVM);
        }

        protected void OnDisable()
        {
#if UNITY_2021_3_OR_NEWER
            m_NameEditor.onSubmit.RemoveListener(OnSubmit);
#else
            m_NameEditor.onEndEdit.RemoveListener(OnSubmit);
#endif
            m_ViewModelChanger.onClick.RemoveListener(OnSwitchMVVM);
        }

        #endregion
    }
}
