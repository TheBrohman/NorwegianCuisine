using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using KitchenNorwegianCuisine;
using System.Collections.Generic;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class Lamb_Ribs_Provider : CustomAppliance
    {
        public override string UniqueNameID => "Lamb_Ribs_Provider";
        public override int BaseGameDataObjectID => ApplianceReferences.SourceApple;
        public override GameObject Prefab => Mod.Bundle.LoadAsset<GameObject>("Lamb_Ribs_Provider");

        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (
                Locale.English,
                new ApplianceInfo
                {
                    Name = "Lamb Ribs",
                    Description = "Provides Lamb Ribs"
                }
            )
        };
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            KitchenPropertiesUtils.GetUnlimitedCItemProvider(GDOUtils.GetCustomGameDataObject<Lamb_Ribs>().GameDataObject.ID)
        };
    }
}
