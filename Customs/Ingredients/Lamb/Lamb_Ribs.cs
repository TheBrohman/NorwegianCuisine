using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenNorwegianCuisine;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class Lamb_Ribs : CustomItem
    {
        public override string UniqueNameID => "Lamb_Ribs";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Raw_Lamb_Ribs");
        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<Lamb_Ribs_Provider>().GameDataObject;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChildren("raw", "Pork", "Raw Drumstick Bone");
        }
    }
}
