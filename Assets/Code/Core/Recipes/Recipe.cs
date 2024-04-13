using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Code
{
    [CreateAssetMenu(fileName = "Recipe", menuName = "New Recipe", order = 0)]
    public class Recipe : ScriptableObject
    {
        [SerializeField] private string titleName;
        [SerializeField] private string description;
        [SerializeField] private List<IngredientSOType> ingredients;

        public bool CheckIngredients(List<IngredientSOType> pIngredients)
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
                    
                    if (pIngredients[j] == rIngredients[i])
                    {
                        rIngredients.Remove(rIngredients[i]);
                        break;
                    }
                }
            }
            if (rIngredients.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}