using System;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    [CreateAssetMenu(fileName = "AssetGame", menuName = "Game/CreateAssetGame", order = 0)]
    public class AssetGame : ScriptableObject
    {
        [SerializeField] private List<AssetLevel> levels;
        public List<AssetLevel> Levels => levels;

        private void OnValidate()
        {
            if (levels.Count == 0) Debug.LogError("Levels equals zero!");
        }
    }
}