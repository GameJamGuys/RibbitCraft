using System;
using System.Collections.Generic;
using _Code.Core;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Code.Core.Bestiary;
using Code.Core.Likes;

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

        bool isPhoneUp;

        private void OnEnable()
        {
            open.onClick.AddListener(() => ShowBook(true));
            close.onClick.AddListener(() => ShowBook(false));
            BestiaryBook.OnFrogCollect += ShakeBook;
            PhoneController.Instance.PhoneUp += PhoneUp;
            PhoneController.Instance.Shoot += PhoneDown;
        }

        private void OnDisable()
        {
            open.onClick.RemoveAllListeners();
            close.onClick.RemoveAllListeners();
            BestiaryBook.OnFrogCollect -= ShakeBook;
            PhoneController.Instance.PhoneUp -= PhoneUp;
            PhoneController.Instance.Shoot -= PhoneDown;
        }

        void PhoneUp() => isPhoneUp = true;
        void PhoneDown() => isPhoneUp = false;

        void ShakeBook() => bookAnim.SetTrigger("Shake");

        private void Start()
        {
            book.gameObject.SetActive(false);
        }

        public void ShowBook(bool isShow)
        {
            if (isPhoneUp) return;

            if (isShow)
                SoundManager.Instance.Play(SoundType.OpenBook);
            else
                SoundManager.Instance.Play(SoundType.CloseBook);
            book.SetActive(isShow);
        }
    }

}
