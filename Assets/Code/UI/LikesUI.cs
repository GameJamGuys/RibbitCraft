using System;
using TMPro;
using UnityEngine;

namespace Code.UI
{
    public sealed class LikesUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        
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
            _count.text = count.ToString();
        }
    }
}