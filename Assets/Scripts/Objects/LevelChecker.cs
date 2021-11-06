using System;
using AbstractObjects;
using UnityEngine;

namespace Objects
{
    [RequireComponent(typeof(LevelGenerateMission))]
    public class LevelChecker : MonoBehaviour
    {
        
        private int _currentLevel;
        private LevelGenerateMission _mission;
        
        private void Awake()
        {
            _mission = GetComponent<LevelGenerateMission>();
        }

        public bool ChekLevel(BaseSpawnItem item)
        {
            if (item.Text != _mission.Mission) return false;
            return true;
        }
    }
}