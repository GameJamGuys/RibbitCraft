using System.Collections.Generic;
using Code.Core.Frogs;
using Code.Core.Ingredients;
using DefaultNamespace;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "New Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        public int price = 1;
        public string SavingName;
        public FrogSOData frogData;
        public List<IngredientSOType> ingredients;

        public Recipe CheckIngredients(IReadOnlyList<Ingredient> pIngredients)
        {
            List<IngredientSOType> rIngredients = new List<IngredientSOType>();
            foreach (var ingredient in ingredients)
            {
                rIngredients.Add(ingredient);
            }
            for (int j = 0; j < pIngredients.Count; j++)
            {
                for (int i = 0; i < rIngredients.Count; i++)
                {
                    
                    if (pIngredients[j].Type == rIngredients[i])
                    {
                        rIngredients.Remove(rIngredients[i]);
                        break;
                    }
                }
            }
            if (rIngredients.Count > 0)
            {
                return null;
            }
            return this;
        }
    }
}