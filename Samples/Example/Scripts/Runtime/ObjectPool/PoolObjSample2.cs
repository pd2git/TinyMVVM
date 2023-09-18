/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/07/11 17:07:40
* Version: v1.2
* Description：The pool object test the initialization features after spawn from the Object Pool.
* ==========================================
*/

using AA.TinyMVVM.ObjectPool;
using UnityEngine;

namespace AA.TinyMVVM.Demo.ObjectPool
{
    /// <summary>
    /// The pool object test the initialization features after spawn from the Object Pool.
    /// </summary>
    public class PoolObjSample2 : IPoolObject
    {
        /// <summary>
        /// The name for a test value.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Initialize.
        /// </summary>
        public PoolObjSample2()
        {
            
        }

        /// <summary>
        /// Initialize with some params. But can not initialize from here after spawning from the object pool. Please see the sample in the method 'OnSpawn' below.
        /// </summary>
        public PoolObjSample2(string newName)
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
            if (paramsList.Length > 0)
            {
                // Initialize here
                Name = paramsList[0] as string;
            }
            Debug.Log($"[{GetType().Name}][Name:{Name}]OnSpawn.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "46>";
#endif
        }

        public void OnRecycle()
        {
            // Should reset the value in the class.
            Name = string.Empty;
            Debug.Log($"[{GetType().Name}][Name:{Name}]OnRecycle.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "47>";
#endif
        }

        public void OnRelease()
        {
            // Should clear the value in the class.
            Name = null;
            Debug.Log($"[{GetType().Name}][Name:{Name}]OnRelease.");
#if UNITY_INCLUDE_TESTS
            // Mark log
            LogMarker.Mark += "48>";
#endif
        }
        

        #endregion
    }
}
