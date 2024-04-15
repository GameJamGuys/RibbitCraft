using System;
using _Code.Core;
using _Code.Utils;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Core.Likes
{
    public sealed class PhoneController : SingletonMono<PhoneController>, IPointerClickHandler
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _target;

        public event Action PhoneUp;
        public event Action Shoot;


        private async UniTaskVoid OnMouseDownAsync()
        {
            await Shot();
            HidePhone();
        }

        public void ShowPhone()
        {
            PhoneUp?.Invoke();
            _animator.SetTrigger("OnShow");
        }
        
        public void HidePhone()
        {
            _animator.SetTrigger("OnHide");
        }

        public async UniTask Shot()
        {
            SoundManager.instance.Play(SoundType.Camera);
            _target.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f);
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
            _target.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
            SoundManager.instance.Play(SoundType.Like);
            Shoot?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnMouseDownAsync().Forget();
        }
    }
}