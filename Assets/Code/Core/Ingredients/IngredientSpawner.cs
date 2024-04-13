using Code.Core.Pentagram;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Core.Ingredients
{
    public sealed class IngredientSpawner : MonoBehaviour
    {
        [SerializeField] private bool _isCrystall;
        [SerializeField] private IngredientSOType _type;
        private void OnMouseDown()
        {
            if (!_isCrystall && PentagramData.IsFull)
                return;

            if (_isCrystall && !PentagramData.IsFull)
                return;
            
            IngredientSpawnPointer.Instance.StartDrag(_type);
        }
    }
}