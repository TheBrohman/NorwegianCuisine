using KitchenLib;
using KitchenLib.Logging;
using KitchenLib.Logging.Exceptions;
using KitchenMods;
using NorwegianCuisine.Customs;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace KitchenNorwegianCuisine
{
    public class Mod : BaseMod, IModSystem
    {
        public const string MOD_GUID = "com.thebrohman.norwegiancuisine";
        public const string MOD_NAME = "NorwegianCuisine";
        public const string MOD_VERSION = "0.2.0";
        public const string MOD_AUTHOR = "TheBrohman";
        public const string MOD_GAMEVERSION = ">=1.1.4";

        public static AssetBundle Bundle;
        public static KitchenLogger Logger;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            Logger.LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            Bundle = Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_GUID);
            AddGameDataObject<Lamb_Ribs_Provider>();
            AddGameDataObject<Lamb_Ribs>();
            AddGameDataObject<Lamb_Pot>();
            AddGameDataObject<Cooked_Lamb_Pot>();
            AddGameDataObject<Cooked_Lamb_Ribs>();
            AddGameDataObject<Cooked_Lamb_Ribs_Plated>();
            AddGameDataObject<LambRibs_Dish>();
            Logger = InitLogger();
        }
    }
}
