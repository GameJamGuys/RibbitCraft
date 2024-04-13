using System;
using Code.Core.Frogs;
using Code.Core.Ingredients;
using Unity.Mathematics;
using UnityEngine;

namespace Code.Core.Pentagram
{
    public sealed class Pentagram : MonoBehaviour
    {
        [SerializeField] private Frog _frogPrefab;
        [SerializeField] RecipesManager recipesManager;
        [SerializeField] private FrogSOData _emptyFrog;
        [SerializeField] private Candle[] _candles;

        private void OnEnable()
        {
            PentagramData.ClearData();
            PentagramData.IngredientAdded += FireCandle;
        }

        private void OnDisable()
        {
            PentagramData.IngredientAdded -= FireCandle;
        }

        private void FireCandle(Ingredient obj)
        {
            if (_candles[3].IsFired)
            {
                foreach (var candle in _candles)
                {
                    candle.FireSummon();
                }

                return;
            }
                
            for (var i = 0; i < _candles.Length; i++)
            {
                if (_candles[i].IsFired)
                    continue;
                
                _candles[i].Fire();
                return;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IngredientSpawnPointer ingredient))
                return;

            IngredientSpawnPointer.Instance.PentagramEntered();
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IngredientSpawnPointer ingredient))
                return;
            
            IngredientSpawnPointer.Instance.PentagramExited();
        }

        public void Summon()
        {
            if (!PentagramData.IsFull)
                return;
            
            Recipe frogRecipe = null;
            foreach (var recipe in recipesManager.Recipes)
            {
                frogRecipe = recipe.CheckIngredients(PentagramData.IngredientsList);
                if (frogRecipe != null)
                {
                    Debug.Log("Create FROG " + frogRecipe.frogData.Name);
                    var frog = Instantiate(_frogPrefab, transform.position, Quaternion.identity);
                    frog.Init(frogRecipe.frogData).Forget();
                    PentagramData.Summon();
                }
            }
            
            if (frogRecipe == null)
            {
                Debug.Log("Create FROG ???" );var frog = Instantiate(_frogPrefab, transform.position, Quaternion.identity);
                frog.Init(_emptyFrog).Forget();
                PentagramData.Summon();
            }

            foreach (var candle in _candles)
            {
                candle.Fuse();
            }
        }
    }
}