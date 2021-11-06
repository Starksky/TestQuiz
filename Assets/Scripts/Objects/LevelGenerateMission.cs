using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Objects
{
    [RequireComponent(typeof(LevelEvents))]
    public class LevelGenerateMission : MonoBehaviour
    {
        public string Mission { get; private set; }
        private List<string> oldMissions;
        
        private LevelEvents _levelEvents;
        
        private void Awake()
        {
            oldMissions = new List<string>();
            _levelEvents = GetComponent<LevelEvents>();
            
            _levelEvents.OnStartGame.AddListener(ClearOldMission);
            _levelEvents.OnSpawner.AddListener(GenerateMission);
        }

        private void ClearOldMission()
        {
            oldMissions.Clear();
        }
        
        private void GenerateMission(List<string> data)
        {
            List<string> cdata = data.ToList();
            
            for (int i = 0; i < data.Count; i++)
            {
                int iRnd = Random.Range(0, cdata.Count);
                if(oldMissions.Contains(cdata[iRnd])) cdata.RemoveAt(iRnd);
                else
                {
                    Mission = cdata[iRnd];
                    oldMissions.Add(Mission);
                }
            }
            
            _levelEvents.OnGenerateMission?.Invoke(Mission);
        }
    }
}