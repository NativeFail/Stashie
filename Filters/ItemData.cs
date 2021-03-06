﻿#region Header

//-----------------------------------------------------------------
//   Class:          ItemData
//   Description:    Input item data for filter
//   Author:         Stridemann        Date: 08.26.2017
//-----------------------------------------------------------------

#endregion

using PoeHUD.Models;
using PoeHUD.Models.Enums;
using PoeHUD.Poe.Components;
using PoeHUD.Poe.Elements;
using SharpDX;

namespace Stashie.Filters
{
    public class ItemData
    {
        private readonly NormalInventoryItem _inventoryItem;

        public string Path;
        public string ClassName;
        public string BaseName;
        public ItemRarity Rarity;
        public int ItemQuality;
        public bool BIdentified;
        public int ItemLevel;

        public ItemData(NormalInventoryItem inventoryItem, BaseItemType baseItemType)
        {
            _inventoryItem = inventoryItem;
            var item = inventoryItem.Item;
            Path = item.Path;

            var mods = item.GetComponent<Mods>();
            Rarity = mods.ItemRarity;
            BIdentified = mods.Identified;
            ItemLevel = mods.ItemLevel;

            var quality = item.GetComponent<Quality>();
            ItemQuality = quality.ItemQuality;
            ClassName = baseItemType.ClassName;
            BaseName = baseItemType.BaseName;
        }

        public Vector2 GetClickPos()
        {
            return _inventoryItem.GetClientRect().Center;
        }
    }
}