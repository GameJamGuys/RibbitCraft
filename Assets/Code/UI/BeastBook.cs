using System;
using System.Collections.Generic;
using _Code.Core;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Book
{
    public class BeastBook : MonoBehaviour
    {
        [SerializeField]
        List<BeastBookPage> pages;
        [Space]
        [SerializeField] Button next, prev;

        int curPage = 0;

        private void OnEnable()
        {
            next.onClick.AddListener(NextPage);
            prev.onClick.AddListener(PrevPage);
        }

        private void OnDisable()
        {
            next.onClick.RemoveListener(NextPage);
            prev.onClick.RemoveListener(PrevPage);
        }

        private void Start()
        {
            pages[0].Show();
            next.interactable = true;
            prev.interactable = false;
        }

        void NextPage()
        {
            SoundManager.Instance.Play(SoundType.FlipBook);
            int page = Mathf.Clamp(curPage + 1, 0, pages.Count - 1);
            OpenPage(page);
            CheckPage(page);
        }

        void PrevPage()
        {
            SoundManager.Instance.Play(SoundType.FlipBook);
            int page = Mathf.Clamp(curPage - 1, 0, pages.Count - 1);
            OpenPage(page);
            CheckPage(page);
        }

        void CheckPage(int page)
        {
            next.interactable = true;
            prev.interactable = true;

            if (page == 0)
                prev.interactable = false;
            if (page == pages.Count - 1)
                next.interactable = false;
        }

        private async UniTaskVoid OpenPage(int page)
        {
            next.enabled = false;
            prev.enabled = false;
            await pages[curPage].Hide();
            curPage = page;
            pages[curPage].Show();
            next.enabled = true;
            prev.enabled = true;
        }
    }

}
