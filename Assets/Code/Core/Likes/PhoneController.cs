using System;
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

        public event Action Shoot;

        private async UniTaskVoid OnMouseDownAsync()
        {
            await Shot();
            HidePhone();
        }

        public void ShowPhone()
        {
            _animator.SetTrigger("OnShow");
        }
        
        public void HidePhone()
        {
            _animator.SetTrigger("OnHide");
        }

        public async UniTask Shot()
        {
            _target.DOScale(new Vector3(0.9f, 0.9f, 0.9f), 0.2f);
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
            _target.DOScale(new Vector3(1f, 1f, 1f), 0.2f);
            await UniTask.Delay(TimeSpan.FromSeconds(0.2f));
            Shoot?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnMouseDownAsync().Forget();
        }
    }
}