using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenNorwegianCuisine;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class Cooked_Lamb_Ribs : CustomItem
    {
        public override string UniqueNameID => "Cooked_Lamb_Ribs";
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Cooked_Lamb_Ribs");
        public override ItemStorage ItemStorageFlags => ItemStorage.StackableFood;

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Prefab.ApplyMaterialToChildren("cooked", "Porkchop", "Cooked Drumstick Bone");
        }
    }
}
