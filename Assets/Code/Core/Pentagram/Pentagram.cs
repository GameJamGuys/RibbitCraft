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
                    return;
                }
            }
            
            if (frogRecipe == null)
            {
                Debug.Log("Create FROG ???" );var frog = Instantiate(_frogPrefab, transform.position, Quaternion.identity);
                frog.Init(_emptyFrog).Forget();
                PentagramData.Summon();
                return;
            }
        }
    }
}