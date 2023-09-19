/**
* ==========================================
* Copyright © AA. All rights reserved.
* Author：AA
* CreatTime：2023/07/12 11:14:40
* Version: v1.2
* Description：The sample test the basic features of the Object Pool.
* ==========================================
*/

using AA.TinyMVVM.ObjectPool;
using System.Collections;
using UnityEngine;

namespace AA.TinyMVVM.Demo.ObjectPool
{
    /// <summary>
    /// The sample test the basic features of the Object Pool.
    /// </summary>
    public class ObjectPoolSample : MonoBehaviour
    {
        [Tooltip("The root of the prefab where to spawn.")]
        [SerializeField]
        private RectTransform m_SpawnRoot;
        
        [Tooltip("The sample of the prefab about the pool object.")]
        [SerializeField]
        private PoolObjMonoSample1 m_PoolObjectSample;

        /// <summary>
        /// A sample about the usage of mono object with the Object Pool.
        /// </summary>
        private IEnumerator SampleMonoObject()
        {
            // Obj1
            // Spawn obj1
            var obj1 = ObjectPoolManager.Ins.GetObj<PoolObjMonoSample1>(() => Instantiate(m_PoolObjectSample, m_SpawnRoot));
            yield return new WaitForSeconds(2);
            obj1.ChangeName("Will recycle and hide.");
            Debug.Log($"[ChangedName]:{obj1.Name}");
            yield return new WaitForSeconds(2);
            // Recycle obj1
            ObjectPoolManager.Ins.RecycleObj(ref obj1);
            yield return new WaitForSeconds(2);

            // Reuse obj1
            // Get obj1
            var obj1Ryc = ObjectPoolManager.Ins.GetObj<PoolObjMonoSample1>();
            obj1Ryc.ChangeName("Recycled and show.");
            yield return new WaitForSeconds(2);
            obj1Ryc.ChangeName("Will recycle and hide.");
            yield return new WaitForSeconds(2);
            // Recycle obj1
            ObjectPoolManager.Ins.RecycleObj(ref obj1Ryc);
            yield return new WaitForSeconds(2);

            // Clear obj pool
            Debug.Log("Will release.");
            // Clear all
            ObjectPoolManager.Ins.Release();
        }
        
        /// <summary>
        /// A sample about the usage of non-mono object with the Object Pool.
        /// </summary>
        private void SampleNonMonoObject()
        {
            // Obj1
            // Spawn obj1
            var obj1 = ObjectPoolManager.Ins.GetObj<PoolObjSample1>();
            obj1.ChangeName("obj1");
            // Recycle obj1
            ObjectPoolManager.Ins.RecycleObj(ref obj1);

            // Reuse obj1
            // Get obj1
            var obj1Ryc = ObjectPoolManager.Ins.GetObj<PoolObjSample1>();
            obj1Ryc.ChangeName("obj1Ryc");
            // Recycle obj1
            ObjectPoolManager.Ins.RecycleObj(ref obj1Ryc);

            // Obj2
            // Spawn obj2
            var obj2 = ObjectPoolManager.Ins.GetObj<PoolObjSample2>(null, "obj2");
            // Recycle obj
            ObjectPoolManager.Ins.RecycleObj(ref obj2);

            // Clear obj pool
            // Clear by a specific type
            ObjectPoolManager.Ins.Release<PoolObjSample2>();
            // Clear all
            ObjectPoolManager.Ins.Release();
        }
        
        #region U3D

        private void OnEnable()
        {
            SampleNonMonoObject();
            StartCoroutine(SampleMonoObject());
        }

        #endregion
    }
}
