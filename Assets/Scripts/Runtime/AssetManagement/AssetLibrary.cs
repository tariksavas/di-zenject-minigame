using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runtime.AssetManagement
{
    public static class AssetLibrary
    {
        private static readonly Dictionary<string, Object> Cache = new Dictionary<string, Object>();

        public static async UniTask<T> LoadAndGetAssetAsync<T>(string key, CancellationToken cancellationToken = default) where T : Object
        {
            if (Cache.TryGetValue(key, out Object asset))
            {
                return asset as T;
            }

            return await LoadAssetAsync<T>(key, cancellationToken);
        }

        private static async UniTask<T> LoadAssetAsync<T>(string key, CancellationToken cancellationToken = default) where T : Object
        { 
            T loadedObject = await Addressables.LoadAssetAsync<T>(key).WithCancellation(cancellationToken);

            Cache.TryAdd(key, loadedObject);

            return loadedObject;
        }

        public static void UnloadAsset(string key)
        {
            Object obj = Cache[key];
            Addressables.Release(obj);

            Cache.Remove(key);
        }

        public static void UnloadAllAssets()
        {
            foreach (string key in Cache.Keys)
            {
                UnloadAsset(key);
            }
            
            Cache.Clear();
        }
    }
}