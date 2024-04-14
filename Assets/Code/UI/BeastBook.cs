using System.Collections.Generic;
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

        void NextPage()
        {
            int page = Mathf.Clamp(curPage + 1, 0, pages.Count - 1);
            OpenPage(page);
            CheckPage(page);
        }

        void PrevPage()
        {
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

        void OpenPage(int page)
        {
            pages[curPage].Hide().Forget();
            curPage = page;
            pages[curPage].Show();
        }
    }

}
