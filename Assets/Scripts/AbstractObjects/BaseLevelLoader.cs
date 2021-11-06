using UnityEngine;

namespace AbstractObjects
{
    public abstract class BaseLevelLoader : MonoBehaviour
    {
        public abstract void NextLevel();
        public abstract void Restart();
    }
}