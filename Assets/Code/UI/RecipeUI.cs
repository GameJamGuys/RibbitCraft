using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Core;
using UnityEngine;
using UnityEngine.UI;
using Code.Core.Bestiary;
using Code.Core.Likes;
using Code.Core.Pentagram;
using TMPro;

namespace Code.UI.Book
{
    public class RecipeUI : MonoBehaviour
    {
        [SerializeField] private Button buyBtn;
        [SerializeField] private TextMeshProUGUI price;
        [SerializeField]
        Recipe recipe;

        [SerializeField]
        List<Image> images;


        private void OnEnable()
        {

            buyBtn.onClick.AddListener(Buy);
            if (recipe)
                CheckRecipeToShow();
        }

        private void OnDisable()
        {
            
            buyBtn.onClick.RemoveAllListeners();
        }
        
        public void SetUp(Recipe rec)
        {
            recipe = rec;
            CheckRecipeToShow();
        }

        public void Buy()
        {
            if (LikesSystem.Likes >= recipe.price)
            {
                SoundManager.Instance.Play(SoundType.Like);
                LikesSystem.Likes -= recipe.price;
                BestiaryBook.CollectRecipe(recipe);
                CheckRecipeToShow();
            }
        }
        void CheckRecipeToShow()
        {
            if (BestiaryBook.CheckRecipe(recipe))
            {
                buyBtn.gameObject.SetActive(false);
                foreach (Image item in images)
                {
                    item.sprite = recipe.ingredients[images.IndexOf(item)].Icon;
                }
            }
            else
            {
                price.text = recipe.price.ToString();
                buyBtn.gameObject.SetActive(true);
            }
        }

        // private void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.A))
        //         LikesSystem.Likes++;
        // }
    }

}
