using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenNorwegianCuisine;
using System.Collections.Generic;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class Cooked_Lamb_Ribs_Plated : CustomItemGroup
    {
        public override string UniqueNameID => "Cooked_Lamb_Ribs_Plated";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cooked_Lamb_Ribs_Plated");
        public override bool AutoCollapsing => false;
        public override Item DirtiesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.PlateDirty);
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate);
        public override bool CanContainSide => false;
        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>()
        {
            new ItemGroup.ItemSet()
            {
                Max = 2,
                Min = 2,
                Items = new List<Item>()
                {
                    (Item)GDOUtils.GetCustomGameDataObject<Cooked_Lamb_Ribs>().GameDataObject,
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Plate)
                },
                OrderingOnly = false,
                IsMandatory = true,
                RequiresUnlock = false
            }
        };
        public override ItemValue ItemValue => ItemValue.Large;
        public override string ColourBlindTag => "LR";
    }
}
