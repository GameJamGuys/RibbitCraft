using System;
using System.Collections.Generic;
using Code.Core.Ingredients;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Core.Pentagram
{
    public static class PentagramData
    {
        public static int MaxSize => 5;
        private static List<Ingredient> _ingredients = new();
        public static bool IsFull => _ingredients.Count >= MaxSize;
        public static IReadOnlyList<Ingredient> IngredientsList => _ingredients;

        public static event Action<Ingredient> IngredientAdded;

        static PentagramData()
        {
            _ingredients.Clear();
        }

        public static void AddIngredient(Ingredient ingredient)
        {
            if (_ingredients.Count >= MaxSize)
                return;
            
            _ingredients.Add(ingredient);
            IngredientAdded?.Invoke(ingredient);
            Debug.Log("Add " + ingredient.Type + " (" + _ingredients.Count + " / " + MaxSize + ")");
        }
        
        public static void RemoveIngredient(Ingredient ingredient)
        {
            if (_ingredients.Count <= 0)
                return;
            
            _ingredients.Remove(ingredient);
            Debug.Log("Remove " + ingredient.Type + " (" + _ingredients.Count + " / " + MaxSize + ")");
        }

        public static void Summon()
        {
            foreach (var ingredient in PentagramData.IngredientsList)
            {
                Object.Destroy(ingredient.gameObject);
            }
            _ingredients.Clear();
        }
    }
}