using System;
using System.Collections.Generic;
using Code.Core.Frogs;
using Code.Core.Ingredients;
using UnityEngine;

namespace Code.Core.Bestiary
{
    public static class BestiaryBook
    {
        public static PentagramSave PentagramSave { get; private set; }
        public static bool CheckFrog(FrogSOData frog) => PentagramSave.CollectedFrogs.Contains(frog);
        public static bool CheckRecipe(Recipe recipe) => PentagramSave.CollectedRecipes.Contains(recipe);

        private static BestiaryUnlock _unlocks;

        public static void CollectFrog(FrogSOData data)
        {
            if (!PentagramSave.CollectedFrogs.Contains(data))
                PentagramSave.CollectedFrogs.Add(data);
            CheckUnlocks();
            SaveToPrefs();
        }

        public static void CollectRecipe(Recipe data)
        {
            Debug.Log("Collect recipe: " + data.SavingName);
            if (!PentagramSave.CollectedRecipes.Contains(data))
                PentagramSave.CollectedRecipes.Add(data);
            SaveToPrefs();
        }

        private static void CheckUnlocks()
        {
            foreach (var unlock in _unlocks.Unlocks)
            {
                if (unlock.FrogsCount <= PentagramSave.CollectedFrogs.Count)
                {
                    Debug.Log("Unlock on " + unlock.FrogsCount);
                    IngredientSpawnerManager.Instance.Unlock(unlock.Ingredient);
                }
            }
        }

        public static void Init()
        {
            _unlocks = Resources.Load<BestiaryUnlock>("Unlocks");
            LoadFromPrefs();
        }

        private static void LoadFromPrefs()
        {
            var jsonData = PlayerPrefs.GetString("CollectedData");
            var pentagramSaveData = JsonUtility.FromJson<PentagramSave>(jsonData);
            PentagramSave = new PentagramSave();
            if (pentagramSaveData != null)
                PentagramSave = pentagramSaveData;
            
            CheckUnlocks();
        }

        private static void SaveToPrefs()
        {
            var jsonData = JsonUtility.ToJson(PentagramSave);
            PlayerPrefs.SetString("CollectedData", jsonData);
            PlayerPrefs.Save();
        }
    }

    
    [Serializable]
    public sealed class PentagramSave
    {
        public List<FrogSOData> CollectedFrogs = new();
        public List<Recipe> CollectedRecipes = new();
    }
}