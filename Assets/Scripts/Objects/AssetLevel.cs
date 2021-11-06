using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Objects
{
    [CreateAssetMenu(fileName = "AssetLevel", menuName = "Game/CreateAssetLevel", order = 0)]
    public class AssetLevel : ScriptableObject
    {
        [SerializeField] private TMP_SpriteAsset spriteAsset;
        [Space]
        [SerializeField] private int countColumn;
        [SerializeField] private int countRow;
        [Space]
        [SerializeField] private List<Color> randomBackgroundColors;
        [SerializeField] private Color borderColor;
        [Space]
        [SerializeField] private List<string> dataForItems;

        public TMP_SpriteAsset SpriteAsset => spriteAsset;
        
        public int CountColumn => countColumn;
        public int CountRow => countRow;
        
        public List<Color> RandomBackgroundColors => randomBackgroundColors;
        public Color BorderColor => borderColor;

        public List<string> DataForItems => dataForItems;

        private void OnValidate()
        {
            if(!spriteAsset) Debug.LogError("TMP_SpriteAsset not set!");
            if(randomBackgroundColors.Count == 0) Debug.LogError("RandomBackgroundColors not set!");
            if(dataForItems.Count == 0) Debug.LogError("DataForItems not set!");
            if (countColumn == 0) countColumn = 1;
            if (countRow == 0) countRow = 1;
            if(dataForItems.Count < countColumn * countRow) Debug.LogError("DataForItems fewer items!");
        }
    }
}