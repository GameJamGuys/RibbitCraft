using Code.Core.Ingredients;
using UnityEngine;

namespace Code.Core.Pentagram
{
    public sealed class Pentagram : MonoBehaviour
    {
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
    }
}