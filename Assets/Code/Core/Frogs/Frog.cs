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
        private bool _canCollect;
        
        private FrogSOData _data;
        public async UniTaskVoid Init(FrogSOData soData)
        {
            _spriteRenderer.sprite = soData.Sprite;
            var baseScale = transform.localScale.x;
            transform.DOScale(new Vector3(baseScale * 1.5f, baseScale * 1.5f, baseScale * 1.5f), 0.7f).SetEase(Ease.InCubic);
            await UniTask.Delay(TimeSpan.FromSeconds(0.7f));
            transform.DOScale(new Vector3(baseScale, baseScale, baseScale), 0.7f).SetEase(Ease.OutCubic);
            await UniTask.Delay(TimeSpan.FromSeconds(0.7f));
            _canCollect = true;
            _data = soData;
        }

        private void OnMouseDown()
        {
            if (!_canCollect)
                return;
            
            DestroyFrog().Forget();
        }

        private async UniTaskVoid DestroyFrog()
        {
            BestiaryBook.CollectFrog(_data);
            transform.DOScale(Vector3.zero, 1f).SetEase(Ease.OutExpo);
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            Destroy(gameObject);
        }
    }
}