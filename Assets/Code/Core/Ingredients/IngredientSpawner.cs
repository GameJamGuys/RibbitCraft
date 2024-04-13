using Code.Core.Pentagram;
using DefaultNamespace;
using UnityEngine;

namespace Code.Core.Ingredients
{
    public sealed class IngredientSpawner : MonoBehaviour
    {
        [SerializeField] private IngredientSOType _type;
        [SerializeField] private bool _isLocked;

        public IngredientSOType Type => _type;
        private void OnMouseDown()
        {
            if (_isLocked)
                return;
            
            if (PentagramData.IsFull)
                return;
            
            IngredientSpawnPointer.Instance.StartDrag(_type);
        }

        public void Unlock()
        {
            _isLocked = false;
        }
    }
}