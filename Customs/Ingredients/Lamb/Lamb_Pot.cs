using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using System.Collections.Generic;

namespace NorwegianCuisine.Customs
{
    public class Lamb_Pot : CustomItemGroup
    {
        public override string UniqueNameID => "Lamb_Pot";
        public override bool AutoCollapsing => false;
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot);
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 2,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                RequiresWrapper = false,
                Result = (Item)GDOUtils.GetCustomGameDataObject<Cooked_Lamb_Ribs>().GameDataObject
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
                }
            }
        };
        public override void OnRegister(GameDataObject gameDataObject)
        {
            ItemGroup item = (ItemGroup)gameDataObject;
            ItemGroupView view = item.Prefab.GetComponent<ItemGroupView>();

            view.ComponentGroups = new List<ItemGroupView.ComponentGroup>
            {
                new ItemGroupView.ComponentGroup
                {
                    Item = (Item)GDOUtils.GetCustomGameDataObject<Lamb_Ribs>().GameDataObject,
                    GameObject = GameObjectUtils.GetChildObject(item.Prefab, "Lamb_Ribs"),
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
