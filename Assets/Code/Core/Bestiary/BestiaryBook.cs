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

        public static bool CheckFrog(FrogSOData frog) => _collectedFrogs.Contains(frog);
        public static bool CheckRecipe(Recipe recipe) => _collectedRecipes.Contains(recipe);

        private static BestiaryUnlock _unlocks;

        public static void CollectFrog(FrogSOData data)
        {
            Debug.Log("Collect frog: " + data.Name);
            _collectedFrogs.Add(data);
            CheckUnlocks(data);
        }

        public static void CollectRecipe(Recipe data)
        {
            Debug.Log("Collect recipe: " + data.SavingName);
            _collectedRecipes.Add(data);
        }

        private static void CheckUnlocks(FrogSOData frog)
        {
            foreach (var unlock in _unlocks.Unlocks)
            {
                if (unlock.FrogsCount <= _collectedFrogs.Count)
                {
                    Debug.Log("Unlock on " + unlock.FrogsCount);
                    IngredientSpawnerManager.Instance.Unlock(unlock.Ingredient);
                }
            }
        }

        public static void Init()
        {
            _unlocks = Resources.Load<BestiaryUnlock>("Unlocks");
            _collectedFrogs.Clear();
            _collectedRecipes.Clear();
        }
    }
}