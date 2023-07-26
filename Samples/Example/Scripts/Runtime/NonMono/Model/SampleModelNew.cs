/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/26 17:00:06
* Version: v1.1.0
* Description：The demo of TinyMVVM model usage.
* ==========================================
*/

using AA.Framework.TinyMVVM.Base;
using AA.Framework.TinyMVVM.Model;
using UnityEngine;

namespace AA.Framework.TinyMVVM.Demo.NonMono
{
    /// <summary>
    /// The demo of TinyMVVM model usage.
    /// </summary>
    public class SampleModelNew : Model.Model
    {
        /// <summary>
        /// Name
        /// </summary>
        public readonly BindableProperty<string> m_NewName = new BindableProperty<string>();
        
        /// <summary>
        /// Call on the mvvm elements combined completely.
        /// </summary>
        protected override void OnCombineComplete()
        {
            Debug.Log('[' + GetType().Name + "]Combine completed.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "40>";
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
            LogMarker.Mark += "57>";
#endif
        }
        
        /// <summary>
        /// Call on the mvvm elements broken up all completely.
        /// </summary>
        protected override void OnBreakUpAllComplete()
        {
            Debug.Log('[' + GetType().Name + "]Break up all completed.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "50>";
#endif
        }
    }
}
