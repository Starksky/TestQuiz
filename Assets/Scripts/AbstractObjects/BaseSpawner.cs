using Objects;
using UnityEngine;

namespace AbstractObjects
{
    public abstract class BaseSpawner : MonoBehaviour
    {
        public abstract bool TrySpawn(AssetLevel asset, bool first = false);
    }
}