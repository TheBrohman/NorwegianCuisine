using KitchenData;
using KitchenLib.Customs;
using KitchenNorwegianCuisine;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class Cooked_Lamb_Ribs : CustomItem
    {
        public override string UniqueNameID => "Cooked_Lamb_Ribs";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("lamb_ribs_raw");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;
    }
}
