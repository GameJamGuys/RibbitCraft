using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Code.UI
{
    public sealed class BeastBookPage : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        public void Show()
        {
            gameObject.SetActive(true);
            _canvasGroup.DOFade(1f, 1f);
        }

        public async UniTaskVoid Hide()
        {
            _canvasGroup.DOFade(0f, 1f);
            await UniTask.Delay(TimeSpan.FromSeconds(1f));
            gameObject.SetActive(false);
        }
    }
}