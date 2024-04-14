using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Code.Core.Bestiary;

namespace Code.UI.Book
{
    public class RecipeUI : MonoBehaviour
    {
        [SerializeField]
        Recipe recipe;

        [SerializeField]
        List<Image> images;

        public void SetUp(Recipe rec)
        {
            recipe = rec;
            CheckRecipeToShow();
        }

        private void OnEnable()
        {
            if (recipe)
                CheckRecipeToShow();
        }

        void CheckRecipeToShow()
        {
            if (BestiaryBook.CheckRecipe(recipe))
            {
                foreach (Image item in images)
                {
                    item.sprite = recipe.ingredients[images.IndexOf(item)].Icon;
                }
            }
        }

    }

}
