using System;
using _Code.Core;
using Code.Core.Bestiary;
using Code.Core.Pentagram;
using Code.UI.Book;
using DefaultNamespace;
using Unity.VisualScripting;
using UnityEngine;

namespace Code.Core.Ingredients
{
    public sealed class IngredientSpawner : MonoBehaviour
    {
        [SerializeField] private IngredientSOType _type;

        [Space]
        [SerializeField] private GameObject _visual;
        [SerializeField] private SpriteRenderer _item;
        [SerializeField] private bool _isLocked;
        [SerializeField] private BeastBookController beastBookController;

        public IngredientSOType Type => _type;

        private void Start()
        {
            _item.gameObject.SetActive(!_isLocked);
        }

        private void OnMouseEnter()
        {
            
        }

        private void OnMouseDown()
        {
            if (_isLocked || PentagramData.IsFull || beastBookController.BookIsOpen)
            {
                SoundManager.Instance.Play(SoundType.PickupFail);
                return;
            }
            
            IngredientSpawnPointer.Instance.StartDrag(_type);
        }

        public void Unlock()
        {
            _isLocked = false;
            _item.gameObject.SetActive(true);
        }
    }
}