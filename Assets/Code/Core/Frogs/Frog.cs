using System;
using Code.Core.Bestiary;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.Core.Frogs
{
    public sealed class Frog : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public async UniTaskVoid Init(FrogSOData soData)
        {
            _spriteRenderer.sprite = soData.Sprite;
            transform.DOScale(Vector3.zero, 1.5f).SetEase(Ease.InBack);
            await UniTask.Delay(TimeSpan.FromSeconds(1.5f));
            BestiaryBook.CollectFrog(soData);
            Destroy(gameObject);
        }
    }
}