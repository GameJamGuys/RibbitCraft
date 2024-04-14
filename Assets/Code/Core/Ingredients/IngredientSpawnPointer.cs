using System;
using _Code.Core;
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
            SoundManager.Instance.Play(SoundType.Pickup);
            gameObject.SetActive(true);
            IngredientType = ingredient;
            _spriteRenderer.sprite = ingredient.Icon;
            _isDragging = true;
        }
        

        private void StopDrag()
        {
            SoundManager.Instance.Play(SoundType.Drop);
            _isDragging = false;
            gameObject.SetActive(false);

            Debug.Log("!!");
            if (_isInPentagram)
            {
                Debug.Log("!");
                //var ingredient = Instantiate(_ingredientPrefab, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
                var ingredient = Instantiate(_ingredientPrefab, transform.position + Vector3.down * 0.3f, Quaternion.Euler(0, 0, Random.Range(-30, 30)));
                ingredient.Init(IngredientType);
                PentagramData.AddIngredient(ingredient);
                PentagramExited();
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
            Debug.Log("Ex");
            _isInPentagram = false;
        }

        public void PentagramEntered()
        {
            Debug.Log("En");
            _isInPentagram = true;
        }
    }
}