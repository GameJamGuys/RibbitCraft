using System;
using System.Collections.Generic;
using _Code.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Code.Core.Bestiary;

namespace Code.UI.Book
{
    public class BeastBookController : MonoBehaviour
    {
        [SerializeField]
        GameObject book;
        [SerializeField]
        Animator bookAnim;

        [SerializeField]
        Button open, close;

        public bool BookIsOpen => book.activeSelf;

        private void OnEnable()
        {
            open.onClick.AddListener(() => ShowBook(true));
            close.onClick.AddListener(() => ShowBook(false));
            BestiaryBook.OnFrogCollect += ShakeBook;

        }

        private void OnDisable()
        {
            open.onClick.RemoveListener(() => ShowBook(true));
            close.onClick.RemoveListener(() => ShowBook(false));
            BestiaryBook.OnFrogCollect -= ShakeBook;
        }

        void ShakeBook() => bookAnim.SetTrigger("Shake");

        private void Start()
        {
            book.gameObject.SetActive(false);
        }

        public void ShowBook(bool isShow)
        {
            if (isShow)
                SoundManager.Instance.Play(SoundType.OpenBook);
            else
                SoundManager.Instance.Play(SoundType.CloseBook);
            book.SetActive(isShow);
        }
    }

}
