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
            _canvasGroup.DOFade(1f, 0.4f);
        }

        public async UniTask Hide()
        {
            _canvasGroup.DOFade(0f, 0.4f);
            await UniTask.Delay(TimeSpan.FromSeconds(0.4f));
            gameObject.SetActive(false);
        }
    }
}