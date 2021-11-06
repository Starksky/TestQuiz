using System;
using System.Collections.Generic;
using System.Linq;
using AbstractObjects;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Objects
{
    [RequireComponent(typeof(GridLayoutGroup), typeof(Transform))]
    public sealed class Spawner : BaseSpawner
    {
        [SerializeField] private BaseSpawnItem prefabItem;
        [SerializeField] private LevelEvents levelEvents;

        private Transform _transform;
        private GridLayoutGroup _gridLayoutGroup;

        private void OnValidate()
        {
            if(!prefabItem) Debug.LogError("Prefab not set!");
            if(!levelEvents) Debug.LogError("LevelEvents not set!");
        }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _gridLayoutGroup = GetComponent<GridLayoutGroup>();
            
            ClearChildren();
        }

        private void ClearChildren()
        {
            for(int i = _transform.childCount - 1; i >= 0; i--)
                Destroy(_transform.GetChild(i).gameObject);
        }
        
        public override bool TrySpawn(AssetLevel asset, bool first = false)
        {
            if (!asset) return false;
            
            ClearChildren();
            
            _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _gridLayoutGroup.constraintCount = asset.CountColumn;
            
            int size = asset.CountColumn * asset.CountRow;
            
            List<string> data = asset.DataForItems.ToList();
            List<string> addedData = new List<string>();
            
            for (int i = 0; i < size; i++)
            {
                var item = Instantiate(prefabItem, _transform);
                
                if (first)
                {
                    item.Hidden(0f, 0f);
                    item.Show();
                    item.Bounce(item.transform);
                }
                
                item.SpriteAsset = asset.SpriteAsset;
                
                int iRnd = Random.Range(0, asset.RandomBackgroundColors.Count);
                item.BackgroundColor = asset.RandomBackgroundColors[iRnd];

                item.BorderColor = asset.BorderColor;
                
                iRnd = Random.Range(0, data.Count);
                item.Text = data[iRnd];
                addedData.Add(data[iRnd]);
                data.RemoveAt(iRnd);
                
                item.OnClick.AddListener(() => levelEvents.OnClickSpawnItem?.Invoke(item));
            }
            
            levelEvents.OnSpawner?.Invoke(addedData);
            
            return true;
        }
    }
}
