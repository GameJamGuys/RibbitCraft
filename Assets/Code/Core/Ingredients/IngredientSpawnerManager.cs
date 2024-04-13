using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

namespace Code.Core.Ingredients
{
    public sealed class IngredientSpawnerManager : MonoBehaviour
    {
        [SerializeField] private List<IngredientSpawner> _spawners = new();
        
        public static IngredientSpawnerManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void Unlock(IngredientSOType ingredientType)
        {
            foreach (var spawner in _spawners)
            {
                if (spawner.Type == ingredientType)
                    spawner.Unlock();
            }
        }
    }
}