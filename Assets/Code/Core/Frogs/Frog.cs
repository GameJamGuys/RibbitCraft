using System;
using _Code.Core;
using Code.Core.Bestiary;
using Code.Core.Likes;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Core.Frogs
{
    public sealed class Frog : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private bool _canCollect;
        
        private FrogSOData _data;

        private void OnEnable()
        {
            PhoneController.Instance.Shoot += OnFrogCaptured;
        }
        
        private void OnDisable()
        {
            PhoneController.Instance.Shoot -= OnFrogCaptured;
        }

        public async UniTaskVoid Init(FrogSOData soData, bool success = true)
        {
            SoundManager.Instance.Play(SoundType.Craft);
            _spriteRenderer.sprite = soData.Sprite;
            var baseScale = transform.localScale.x;
            transform.DOScale(new Vector3(baseScale * 1.1f, baseScale * 1.1f, baseScale * 1.1f), 0.7f).SetEase(Ease.OutCubic);
            await UniTask.Delay(TimeSpan.FromSeconds(0.3f));
            transform.DOScale(new Vector3(baseScale, baseScale, baseScale), 0.5f).SetEase(Ease.InCubic);
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
            PhoneController.Instance.ShowPhone();
            
            if (success)
                SoundManager.Instance.Play(SoundType.CraftSuccess);
            else
                SoundManager.Instance.Play(SoundType.CraftFail);
            _canCollect = true;
            _data = soData;
        }

        private void OnFrogCaptured()
        {
            DestroyFrog().Forget();
        }

        private async UniTaskVoid DestroyFrog()
        {
            BestiaryBook.CollectFrog(_data);
            transform.DOScale(Vector3.zero, 1f).SetEase(Ease.OutExpo);
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            LikesSystem.Likes += Random.Range(_data.Tier.LikesMin, _data.Tier.LikesMax + 1);
            Destroy(gameObject);
        }
    }
}