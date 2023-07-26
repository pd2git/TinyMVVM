/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/07/11 16:50:40
* Version: v1.1.0
* Description：The pool object test the basic features of the Object Pool.
* ==========================================
*/

using AA.Framework.TinyMVVM.ObjectPool;
using UnityEngine;

namespace AA.Framework.TinyMVVM.Demo.ObjectPool
{
    /// <summary>
    /// The pool object test the basic features of the Object Pool.
    /// </summary>
    public class PoolObjSample1 : IPoolObject
    {
        /// <summary>
        /// The name for a test value.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Change the name value.
        /// </summary>
        /// <param name="newName">new name value</param>
        public void ChangeName(string newName)
        {
            Name = newName;
        }

        #region Object Pool

        /// <summary>
        /// Invoke on span the obj from the object pool.
        /// </summary>
        /// <param name="paramsList">the list of the params</param>
        public void OnSpawn(params object[] paramsList)
        {
            Debug.Log('[' + GetType().Name + "]OnSpawn.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "43>";
#endif
        }

        /// <summary>
        /// Invoke on recycle the obj to the object pool.
        /// </summary>
        public void OnRecycle()
        {
            // Should reset the value in the class.
            Name = string.Empty;
            Debug.Log('[' + GetType().Name + "]OnRecycle.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "44>";
#endif
        }

        /// <summary>
        /// Invoke on release the obj from the object pool.
        /// </summary>
        public void OnRelease()
        {
            // Should clear the value in the class.
            Name = null;
            Debug.Log('[' + GetType().Name + "]OnRelease.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "45>";
#endif
        }
        

        #endregion
    }
}
