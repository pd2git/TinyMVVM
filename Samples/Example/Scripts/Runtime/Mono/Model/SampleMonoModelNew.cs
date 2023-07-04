/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/06/29 11:35:06
* Version: v1.0
* Description：Another demo of TinyMVVM model usage on the MonoBehaviour class.
* ==========================================
*/

using AA.Framework.TinyMVVM.Base;
using AA.Framework.TinyMVVM.Model;

namespace AA.Framework.TinyMVVM.Demo.Mono
{
    /// <summary>
    /// Another demo of TinyMVVM model usage on the MonoBehaviour class.
    /// </summary>
    public class SampleMonoModelNew : MonoModel
    {
        /// <summary>
        /// Name
        /// </summary>
        public readonly BindableProperty<string> m_NewName = new BindableProperty<string>();
    }
}
