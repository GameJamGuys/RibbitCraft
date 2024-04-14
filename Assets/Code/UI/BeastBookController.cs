using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Code.UI.Book
{
    public class BeastBookController : MonoBehaviour
    {
        [SerializeField]
        GameObject book;

        [SerializeField]
        Button open, close;

        private void OnEnable()
        {
            open.onClick.AddListener(() => ShowBook(true));
            close.onClick.AddListener(() => ShowBook(false));
        }

        private void OnDisable()
        {
            open.onClick.RemoveListener(() => ShowBook(true));
            close.onClick.RemoveListener(() => ShowBook(false));
        }

        private void Start()
        {
            ShowBook(false);
        }

        public void ShowBook(bool isShow)
        {
            book.SetActive(isShow);
        }
    }

}
