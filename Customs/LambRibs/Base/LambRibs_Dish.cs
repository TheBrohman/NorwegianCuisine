using KitchenData;
using KitchenLib.Customs;
using KitchenLib.References;
using KitchenLib.Utils;
using SwimingSushi.Customs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace NorwegianCuisine.Customs
{
    public class LambRibs_Dish : CustomDish
    {
        public override string UniqueNameID => "LambRibs_Dish";
        public override int BaseGameDataObjectID => DishReferences.BurgerBase;
        public override GameObject DisplayPrefab => ((Item)GDOUtils.GetCustomGameDataObject<Cooked_Lamb_Ribs_Plated>().GameDataObject).Prefab;

        //CustomUnlock
        public override Unlock.RewardLevel ExpReward => Unlock.RewardLevel.Medium;
        public override bool IsUnlockable => true;
        public override UnlockGroup UnlockGroup => UnlockGroup.Dish;
        public override CardType CardType => CardType.Default;
        public override int MinimumFranchiseTier => 0;
        public override bool IsSpecificFranchiseTier => false;
        public override DishCustomerChange CustomerMultiplier => DishCustomerChange.SmallIncrease;
        public override float SelectionBias => 0;
        public override List<Unlock> HardcodedRequirements => new List<Unlock> { };
        public override List<Unlock> HardcodedBlockers => new List<Unlock> { };
        public override bool IsAvailableAsLobbyOption => true;

        //CustomDish
        public override string AchievementName => "";
        public override DishType Type => DishType.Base;
        public override HashSet<Item> MinimumIngredients => new HashSet<Item>()
        {
            (Item)GDOUtils.GetCustomGameDataObject<Lamb_Ribs>().GameDataObject,
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot),
            (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
        };


        public override HashSet<Process> RequiredProcesses => new HashSet<Process>
        {
            (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook)
        };

        public override List<Dish.MenuItem> ResultingMenuItems => new List<Dish.MenuItem>
        {
            new Dish.MenuItem
            {
                Item = (Item)GDOUtils.GetCustomGameDataObject<Cooked_Lamb_Ribs_Plated>().GameDataObject,
                Phase = MenuPhase.Main,
                Weight = 1,
                DynamicMenuType = DynamicMenuType.Static,
                DynamicMenuIngredient = null
            }
        };
        public override HashSet<Dish.IngredientUnlock> IngredientsUnlocks => new HashSet<Dish.IngredientUnlock>
        {
            new Dish.IngredientUnlock
            {
                MenuItem = (ItemGroup)GDOUtils.GetCustomGameDataObject<Cooked_Lamb_Ribs_Plated>().GameDataObject,
                Ingredient = (Item)GDOUtils.GetCustomGameDataObject<Lamb_Ribs>().GameDataObject
            }
        };
        public override Dictionary<Locale, string> Recipe => new Dictionary<Locale, string>
        {
            { Locale.English, "Add Lamb Ribs to pot, fill with water and boil. Serve on plate." }
        };

        public override void OnRegister(GameDataObject gameDataObject)
        {
            Dish dish = (Dish)gameDataObject;
            LocalisationObject<UnlockInfo> info = new LocalisationObject<UnlockInfo>();
            FieldInfo dictionary = ReflectionUtils.GetField<LocalisationObject<UnlockInfo>>("Dictionary");
            Dictionary<Locale, UnlockInfo> dict = new Dictionary<Locale, UnlockInfo>();
            dict.Add(Locale.English, new UnlockInfo
            {
                Name = "Lamb Ribs",
                Description = "Adds Lamb Ribs as a Main"
            });
            dictionary.SetValue(info, dict);
            dish.Info = info;
        }
    }
}
