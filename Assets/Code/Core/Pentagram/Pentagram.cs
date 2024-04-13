using Code.Core.Ingredients;
using UnityEngine;

namespace Code.Core.Pentagram
{
    public sealed class Pentagram : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Ingredient ingredient))
                return;
            
            PentagramData.AddIngredient(ingredient);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (!other.TryGetComponent(out Ingredient ingredient))
                return;
            
            PentagramData.RemoveIngredient(ingredient);
        }
    }
}