using Code.Core.Pentagram;
using DefaultNamespace;
using UnityEngine;

namespace Code.Core.Ingredients
{
    public sealed class IngredientSpawner : MonoBehaviour
    {
        [SerializeField] private IngredientSOType _type;
        [SerializeField] private GameObject _visual;
        [SerializeField] private SpriteRenderer _item;
        [SerializeField] private bool _isLocked;

        public IngredientSOType Type => _type;

        private void Start()
        {
            _item.sprite = _type.Icon;
            _visual.SetActive(!_isLocked);
        }

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
            _visual.SetActive(true);
        }
    }
}