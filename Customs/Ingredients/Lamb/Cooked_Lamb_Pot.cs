using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenNorwegianCuisine;
using System.Collections.Generic;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class Cooked_Lamb_Pot : CustomItem
    {
        public override string UniqueNameID => "Cooked_Lamb_Pot";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cooked_Lamb_Pot");
        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<Cooked_Lamb_Ribs>().GameDataObject;
        public override int SplitCount => 6;
        public override List<Item> SplitDepletedItems => new List<Item>
        {
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot)
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChildren("lamb", "Porkchop", "Cooked Drumstick Bone");
            Prefab.ApplyMaterialToChildren("Handles", "Metal Dark");
            Prefab.ApplyMaterialToChildren("Pot", "Metal- Shiny");
            Prefab.ApplyMaterialToChildren("Water", "Water");
        }
    }
}
