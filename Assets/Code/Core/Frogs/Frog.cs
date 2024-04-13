using UnityEngine;

namespace Code.Core.Frogs
{
    public sealed class Frog : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Init(FrogSOData soData)
        {
            _spriteRenderer.sprite = soData.Sprite;
        }
    }
}