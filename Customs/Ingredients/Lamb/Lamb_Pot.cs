using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenNorwegianCuisine;
using System.Collections.Generic;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class Lamb_Pot : CustomItemGroup
    {
        public override string UniqueNameID => "Lamb_Pot";
        public override bool AutoCollapsing => false;
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Lamb_Pot");
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot);
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 2,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                RequiresWrapper = false,
                Result = (Item)GDOUtils.GetCustomGameDataObject<Cooked_Lamb_Pot>().GameDataObject
            }
        };
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 1,
                Min = 1,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot)
                },
                IsMandatory = true
            },
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<Lamb_Ribs>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Water)
                },
                IsMandatory = true
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            ItemGroup item = (ItemGroup)gameDataObject;
            ItemGroupView view = item.Prefab.GetComponent<ItemGroupView>();
            GameObjectUtils.GetChildObject(item.Prefab, "Raw_Lamb_Ribs").ApplyMaterialToChildren("lamb", "Pork", "Raw Drumstick Bone");
            Prefab.ApplyMaterialToChildren("Handles", "Metal Dark");
            Prefab.ApplyMaterialToChildren("Pot", "Metal- Shiny");
            Prefab.ApplyMaterialToChildren("Water", "Water");

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<Lamb_Ribs>().GameDataObject,
                    GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Raw_Lamb_Ribs"),
                    DrawAll = true
                },

                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
                    GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Water"),
                    DrawAll = true
                }
            };
        }
    }
}
