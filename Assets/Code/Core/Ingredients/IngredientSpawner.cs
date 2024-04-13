using Code.Core.Pentagram;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Core.Ingredients
{
    public sealed class IngredientSpawner : MonoBehaviour
    {
        // [SerializeField] private Ingredient _ingredientPrefab;
        [SerializeField] private IngredientSOType _type;
        private void OnMouseDown()
        {
            if (PentagramData.IsFull)
                return;
            
            /*var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            var ing = Instantiate(_ingredientPrefab,
                    pos,
                    quaternion.identity);
            
            ing.Init(_type);*/
            IngredientSpawnPointer.Instance.StartDrag(_type);
        }
    }
}