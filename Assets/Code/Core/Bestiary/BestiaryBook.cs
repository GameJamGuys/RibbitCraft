using System.Collections.Generic;
using Code.Core.Frogs;
using Code.Core.Ingredients;
using UnityEngine;

namespace Code.Core.Bestiary
{
    public static class BestiaryBook
    {
        private static List<FrogSOData> _collectedFrogs = new();
        private static List<Recipe> _collectedRecipes = new();

        private static BestiaryUnlock _unlocks;

        public static void CollectFrog(FrogSOData data)
        {
            _collectedFrogs.Add(data);
            CheckUnlocks(data);
        }

        private static void CheckUnlocks(FrogSOData frog)
        {
            foreach (var unlock in _unlocks.Unlocks)
            {
                if (unlock.FrogsCount <= _collectedFrogs.Count)
                    IngredientSpawnerManager.Instance.Unlock(unlock.Ingredient);
            }
        }

        public static void Init()
        {
            _unlocks = Resources.Load<BestiaryUnlock>("Unlocks");
        }
    }
}