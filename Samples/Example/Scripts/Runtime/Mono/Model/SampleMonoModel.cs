/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/24 21:18:06
* Version: v1.0
* Description：The demo of TinyMVVM model usage on the MonoBehaviour class.
* ==========================================
*/

using AA.Framework.TinyMVVM.Base;
using AA.Framework.TinyMVVM.Model;

namespace AA.Framework.TinyMVVM.Demo.Mono
{
    /// <summary>
    /// The demo of TinyMVVM model usage on the MonoBehaviour class.
    /// </summary>
    public class SampleMonoModel : MonoModel
    {
#if ENABLE_DEMO
        /// <summary>
        /// Name
        /// </summary>
        public readonly BindableProperty<string> m_Name = new BindableProperty<string>();
#endif
    }
}
