using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenNorwegianCuisine;
using System.Collections.Generic;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class Lamb_Ribs : CustomItem
    {
        public override string UniqueNameID => "Lamb_Ribs";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("lamb_ribs_raw");
        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<Lamb_Ribs_Provider>().GameDataObject;
        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Duration = 3,
                IsBad = false,
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                RequiresWrapper = false,
                Result = (Item)GDOUtils.GetCustomGameDataObject<Cooked_Lamb_Ribs>().GameDataObject
            }
        };
    }
}
