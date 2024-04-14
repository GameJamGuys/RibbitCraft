using System;
using Code.Core.Frogs;
using Code.Core.Ingredients;
using Unity.Mathematics;
using UnityEngine;
using Code.Core.Bestiary;

namespace Code.Core.Pentagram
{
    public sealed class Pentagram : MonoBehaviour
    {
        [SerializeField] private Frog _frogPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] RecipesManager recipesManager;
        [SerializeField] private FrogSOData _emptyFrog;
        [SerializeField] private Candle[] _candles;

        public event Action OnFiveItems;
        public event Action OnSummon;

        private void OnEnable()
        {
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
                _candles[4].Fire();

                foreach (var candle in _candles)
                {
                    candle.FireSummon();
                }
                OnFiveItems?.Invoke();

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

            if (Input.GetMouseButton(0))
            {
                Debug.Log("!!!!");
                IngredientSpawnPointer.Instance.PentagramExited();
            }
        }

        public void Summon()
        {
            if (!PentagramData.IsFull)
                return;

            bool findRecipe = false;

            foreach (var recipe in recipesManager.Recipes)
            {
                Recipe frogRecipe = recipe.CheckIngredients(PentagramData.IngredientsList);
                if (frogRecipe != null)
                {
                    Debug.Log("Create FROG " + frogRecipe.frogData.Name);
                    var frog = Instantiate(_frogPrefab, _spawnPoint.position, Quaternion.identity);
                    frog.Init(frogRecipe.frogData).Forget();
                    PentagramData.Summon();
                    BestiaryBook.CollectRecipe(frogRecipe);

                    findRecipe = true;
                }
            }
            
            if (!findRecipe)
            {
                Debug.Log("Create FROG ???" );
                var frog = Instantiate(_frogPrefab, _spawnPoint.position, Quaternion.identity);
                frog.Init(_emptyFrog).Forget();
                PentagramData.Summon();
            }

            foreach (var candle in _candles)
            {
                candle.Fuse();
            }

            OnSummon?.Invoke();
        }
    }
}