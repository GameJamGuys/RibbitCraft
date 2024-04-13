using Code.Core.Frogs;
using Code.Core.Ingredients;
using UnityEngine;

namespace Code.Core.Pentagram
{
    public sealed class Pentagram : MonoBehaviour
    {
        [SerializeField] private Frog _frogPrefab;
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
            //FrogSOData frogData = ReciepeService.GetFrog(PentagramData.IngredientsList);
            //var frogGO = Instantiate(_frogPrefab, transform.position, Quaternion.identity);
            //frogGO.Init(frogData);
        }
    }
}