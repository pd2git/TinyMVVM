/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/07/12 11:32:40
* Version: v1.2
* Description：The pool object test the basic features of the Object Pool for mono objects.
* ==========================================
*/

using AA.TinyMVVM.ObjectPool;
using UnityEngine;
using UnityEngine.UI;

namespace AA.TinyMVVM.Demo.ObjectPool
{
    /// <summary>
    /// The pool object test the basic features of the Object Pool for mono objects.
    /// </summary>
    public class PoolObjMonoSample1 : MonoBehaviour, IPoolObject
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
            GetComponentInChildren<Text>().text = newName;
        }

        #region Object Pool

        /// <summary>
        /// Invoke on span the obj from the object pool.
        /// </summary>
        /// <param name="paramsList">the list of the params</param>
        public void OnSpawn(params object[] paramsList)
        {
            Debug.Log('[' + GetType().Name + "]OnSpawn.");
            gameObject.SetActive(true);
        }

        /// <summary>
        /// Invoke on recycle the obj to the object pool.
        /// </summary>
        public void OnRecycle()
        {
            gameObject.SetActive(false);
            // Should reset the value in the class.
            Name = string.Empty;
            Debug.Log('[' + GetType().Name + "]OnRecycle.");
        }

        /// <summary>
        /// Invoke on release the obj from the object pool.
        /// </summary>
        public void OnRelease()
        {
            // Should clear the value in the class.
            Name = null;
            Debug.Log('[' + GetType().Name + "]OnRelease.");
            Destroy(gameObject);
        }
        

        #endregion
    }
}
