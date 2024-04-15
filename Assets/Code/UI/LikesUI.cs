using System;
using TMPro;
using UnityEngine;
using DG.Tweening;

namespace Code.UI
{
    public sealed class LikesUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] GameObject heart;
        
        public static LikesUI Instance { get; private set; }

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
        }

        public void UpdateLikes(int count)
        {
            PopHeart();
            _count.text = count.ToString();
        }

        void PopHeart()
        {
            Vector3 baseScale = heart.transform.localScale;
            heart.transform.localScale = Vector3.zero;
            heart.transform.DOScale(baseScale, 0.8f).SetEase(Ease.OutBounce);
        }
    }
}