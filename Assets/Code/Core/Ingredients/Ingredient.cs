using DefaultNamespace;
using UnityEngine;

namespace Code.Core.Ingredients
{
    public sealed class Ingredient : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public EIngredientType Type { get; private set; }
    
        private bool _isDragging;
        private IngredientSOType _ingSO;

        public void Init(IngredientSOType ingredientSoType)
        {
            _ingSO = ingredientSoType;
            Type = ingredientSoType.Type;
            _spriteRenderer.sprite = ingredientSoType.Icon;
        }
        private void OnMouseDown()
        {
            _isDragging = true;
        }

        private void OnMouseDrag()
        {
            if (!_isDragging)
                return;
            
            var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            position.z = 0;
            transform.position = position;
        }

        private void OnMouseUp()
        {
            _isDragging = false;
        }
    }
}