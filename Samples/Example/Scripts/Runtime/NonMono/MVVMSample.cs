/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/26 15:46:07
* Version: v1.1.0
* Description：The demo of TinyMVVM usage
* ==========================================
*/

using System.Collections.Generic;
using AA.Framework.TinyMVVM.Core;
using AA.Framework.TinyMVVM.Model;
using AA.Framework.TinyMVVM.View;
using AA.Framework.TinyMVVM.ViewMode;
using UnityEngine;

namespace AA.Framework.TinyMVVM.Demo.NonMono
{
    /// <summary>
    /// The demo of TinyMVVM usage
    /// </summary>
    public class MVVMSample
    {
        #region Operate

        /// <summary>
        /// Switch the elements of the mvvm.
        /// </summary>
        /// <returns>the view model of this mvvm.</returns>
        public IViewModel<IModel> SwitchMVVM()
        {
            if (m_MVVMHandler == null)
            {
                Debug.LogWarning("Please initialize the handler of MVVM at first.");
                return null;
            }

            // Switch next
            m_CurDataIndex = (m_CurDataIndex + 1) % m_MvvmDataList.Count;
            var data = m_MvvmDataList[m_CurDataIndex];
            m_MVVMHandler.RequestModification(data.Model);
            m_MVVMHandler.RequestModification(data.ViewModel);
            m_MVVMHandler.RequestModification(data.View);
            // Apply
            if (!m_MVVMHandler.ApplyModification())
            {
                Debug.LogWarning("Can not apply the modifications with some error.");
                return null;
            }
            // 
            return m_MVVMHandler.CurViewModel;
        }

        #endregion

        #region Initialize and UnInitialize

        /// <summary>
        /// The instance of self
        /// </summary>
        private static MVVMSample m_Ins;
        
        /// <summary>
        /// The instance of self
        /// </summary>
        public static MVVMSample Ins
        {
            get
            {
                if (m_Ins == null)
                {
                    m_Ins = new MVVMSample();
                }
                return m_Ins;
            }
        }
        
        /// <summary>
        /// the handler of MVVM.
        /// </summary>
        private MVVMCore m_MVVMHandler;

        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="view">the view</param>
        /// <param name="viewForNewVm">the view for a new view model</param>
        /// <param name="viewForNewModel">the view for a new model </param>
        /// <returns>Whether initialize successfully or not.</returns>
        public bool Initialize(IView<SampleViewModel, SampleModel> view, IView<SampleViewModelNew, SampleModel> viewForNewVm, 
            IView<SampleViewModelForNewModel, SampleModelNew> viewForNewModel)
        {
            m_MVVMHandler = new MVVMCore();
            // Initialize
            // Model
            var model = new SampleModel();
            var modelNew = new SampleModelNew();
            // View Model
            var viewModel = new SampleViewModel();
            var viewModelChild = new SampleViewModelChild();
            var viewModelNew = new SampleViewModelNew();
            var viewModelForNewModel = new SampleViewModelForNewModel();
            // Build the switcher list.
            // Case 1:All match
            m_MvvmDataList.Add(new MVVMData(model, viewModel, view));
            // Case 2:Change the view model (child of viewModel) without the prior view modified.
            m_MvvmDataList.Add(new MVVMData(model, viewModelChild, view));
            // Case 3:Change the view model (a new viewModel) and has to pass a new view to fit.
            m_MvvmDataList.Add(new MVVMData(model, viewModelNew, viewForNewVm));
            // Case 4:Change the model (include the new and the child), so the view model and view both have to modify.
            m_MvvmDataList.Add(new MVVMData(modelNew, viewModelForNewModel, viewForNewModel));
            
            // Combine the view with the model and the view model.
            return m_MVVMHandler.Combine(model, viewModel, view);
        }

        /// <summary>
        /// Release
        /// </summary>
        public void UnInitialize()
        {
            m_MVVMHandler.BreakUpAll();
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
        private int m_CurDataIndex;

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
    }
}