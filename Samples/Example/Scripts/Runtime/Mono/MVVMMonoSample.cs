/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/24 19:55:07
* Version: v1.0
* Description：The demo of TinyMVVM usage
* ==========================================
*/

using System.Collections.Generic;
using AA.Framework.TinyMVVM.Core;
using AA.Framework.TinyMVVM.Model;
using AA.Framework.TinyMVVM.View;
using AA.Framework.TinyMVVM.ViewMode;
using UnityEngine;

namespace AA.Framework.TinyMVVM.Demo.Mono
{
    /// <summary>
    /// The demo of TinyMVVM usage
    /// </summary>
    public class MVVMMonoSample : MonoBehaviour
    {
        [Header("Model")] [Tooltip("The sample model")] [SerializeField]
        private SampleMonoModel m_SampleModel;

        [Tooltip("A new sample model")] [SerializeField]
        private SampleMonoModelNew m_SampleModelNew;

        [Header("View Model")] [Tooltip("The sample view model")] [SerializeField]
        private SampleMonoViewModel m_SampleViewModel;

        [Tooltip("The child of the sample view model")] [SerializeField]
        private SampleMonoViewModelChild m_SampleViewModelChild;

        [Tooltip("The sample view model")] [SerializeField]
        private SampleMonoViewModelNew m_SampleViewModelNew;

        [Tooltip("The sample view model")] [SerializeField]
        private SampleMonoViewModelForNewModel m_SampleViewModelForNewModel;

        [Header("View")] [Tooltip("The sample view")] [SerializeField]
        private SampleMonoView m_SampleMonoView;

        [Tooltip("A sample view for the new view model")] [SerializeField]
        private SampleMonoViewForNewVM m_SampleMonoViewForNewVM;

        [Tooltip("A sample view for the new model")] [SerializeField]
        private SampleMonoViewForNewModel m_SampleMonoViewForNewModel;

        #region Operate

        /// <summary>
        /// Switch the elements of the mvvm.
        /// </summary>
        /// <returns>the view model of this mvvm.</returns>
        public IViewModel<IModel> SwitchMVVM()
        {
            if (m_MVVMHander == null)
            {
                Debug.LogWarning("Please initialize the handler of MVVM at first.");
                return null;
            }

            // Switch next
            m_CurDataIndex = (m_CurDataIndex + 1) % m_MvvmDataList.Count;
            var data = m_MvvmDataList[m_CurDataIndex];
            m_MVVMHander.RequestModification(data.Model);
            m_MVVMHander.RequestModification(data.ViewModel);
            m_MVVMHander.RequestModification(data.View);
            // Apply
            if (!m_MVVMHander.ApplyModification())
            {
                Debug.LogWarning("Can not apply the modifications with some error.");
                return null;
            }
            // 
            return m_MVVMHander.CurViewModel;
        }

        #endregion

        #region Initialize and UnInitialize

        /// <summary>
        /// The instance of self
        /// </summary>
        public static MVVMMonoSample Ins { get; private set; }

        /// <summary>
        /// the handler of MVVM.
        /// </summary>
        private MVVMCore m_MVVMHander;

        /// <summary>
        /// Initialize
        /// </summary>
        /// <returns>Whether initialize successfully or not.</returns>
        private bool Initialize()
        {
            m_MVVMHander = new MVVMCore();
            // Build the switcher list.
            // Case 1:All match
            m_MvvmDataList.Add(new MVVMData(m_SampleModel, m_SampleViewModel, m_SampleMonoView));
            // Case 2:Change the view model (child of viewModel) without the prior view modified.
            m_MvvmDataList.Add(new MVVMData(m_SampleModel, m_SampleViewModelChild, m_SampleMonoView));
            // Case 3:Change the view model (a new viewModel) and has to pass a new view to fit.
            m_MvvmDataList.Add(new MVVMData(m_SampleModel, m_SampleViewModelNew, m_SampleMonoViewForNewVM));
            // Case 4:Change the model (include the new and the child), so the view model and view both have to modify.
            m_MvvmDataList.Add(
                new MVVMData(m_SampleModelNew, m_SampleViewModelForNewModel, m_SampleMonoViewForNewModel));

            // Combine the view with the model and the view model.
            return m_MVVMHander.Combine(m_SampleModel, m_SampleViewModel, m_SampleMonoView);
        }

        /// <summary>
        /// Release
        /// </summary>
        private void UnInitialize()
        {
            m_MVVMHander.BreakUpAll();
            m_MvvmDataList.Clear();
            m_CurDataIndex = 0;
        }

        #endregion

        #region MVVM Switch Data

        /// <summary>
        /// The data list of the mvvm.
        /// </summary>
        private readonly List<MVVMData> m_MvvmDataList = new List<MVVMData>(3);

        /// <summary>
        /// The index of the select mvvm data at this moment. 
        /// </summary>
        private int m_CurDataIndex = 0;

        /// <summary>
        /// The data struct of the mvvm.
        /// </summary>
        private readonly struct MVVMData
        {
            /// <summary>
            /// Initialize
            /// </summary>
            /// <param name="model">the model of mvvm</param>
            /// <param name="viewModel">the view model of mvvm</param>
            /// <param name="view">the view of mvvm</param>
            public MVVMData(IModel model, IViewModel<IModel> viewModel, IView<IViewModel<IModel>, IModel> view)
            {
                Model = model;
                ViewModel = viewModel;
                View = view;
            }

            /// <summary>
            /// the model of mvvm
            /// </summary>
            public IModel Model { get; }

            /// <summary>
            /// the view model of mvvm
            /// </summary>
            public IViewModel<IModel> ViewModel { get; }

            /// <summary>
            /// the view of mvvm
            /// </summary>
            public IView<IViewModel<IModel>, IModel> View { get; }
        }

        #endregion

        #region U3D

        private void Awake()
        {
            Ins = this;
            if (!Initialize())
            {
                Debug.LogError(
                    "Can not initialize the MVVMCore module. Is something pass null? Model? View Model? View?");
            }
        }

        private void OnDestroy()
        {
            UnInitialize();
        }

        #endregion
    }
}