using System;
using Code.Core.Pentagram;
using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Core.Ingredients
{
    public class IngredientSpawnPointer : MonoBehaviour
    {
        private Camera _camera;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Ingredient _ingredientPrefab;
        public IngredientSOType IngredientType { get; private set; }
        private bool _isDragging;
        private bool _isInPentagram;
        
        public static IngredientSpawnPointer Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            _camera = Camera.main;
        }

        public void StartDrag(IngredientSOType ingredient)
        {
            gameObject.SetActive(true);
            IngredientType = ingredient;
            _spriteRenderer.sprite = ingredient.Icon;
            _isDragging = true;
        }
        

        private void StopDrag()
        {
            _isDragging = false;
            gameObject.SetActive(false);

            if (_isInPentagram)
            {
                var ingredient = Instantiate(_ingredientPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                ingredient.Init(IngredientType);
                PentagramData.AddIngredient(ingredient);
            }
        }

        private void Update()
        {
            if (!_isDragging)
                return;
            
            if (Input.GetMouseButtonUp(0))
                StopDrag();
            
            transform.position = _camera.ScreenToWorldPoint(Input.mousePosition + new Vector3(0,0,10));
        }

        public void PentagramExited()
        {
            _isInPentagram = true;
        }

        public void PentagramEntered()
        {
            _isInPentagram = false;
        }
    }
}