using System.Collections.Generic;
using Code.Core.Frogs;
using UnityEngine;

namespace Code.Core.Bestiary
{
    public class BestiarySaving : MonoBehaviour
    {
        
        [SerializeField] private List<FrogSOData> frogs = new List<FrogSOData>();
        [SerializeField] private List<Recipe> recipes = new List<Recipe>();
        private void Awake()
        {
            for (int i = 0; i < frogs.Count; i++)
            {
                if (!PlayerInfo.Frogs.ContainsKey(frogs[i].Name))
                {
                    PlayerInfo.Frogs.Add(frogs[i].Name,new PlayerInfo.FrogInfo(frogs[i].Name));
                    string frogName = frogs[i].Name;
                    PlayerInfo.Frogs[frogs[i].Name].IsOpened.Value = 1;
                }
            }
            for (int i = 0; i < recipes.Count; i++)
            {
                if (!PlayerInfo.Recipes.ContainsKey(recipes[i].SavingName))
                {
                    PlayerInfo.Recipes.Add(recipes[i].SavingName,new PlayerInfo.RecipeInfo(recipes[i].SavingName));
                    PlayerInfo.Recipes[recipes[i].SavingName].IsOpened.Value = 1;
                    
                }
            }
        }
    }
}