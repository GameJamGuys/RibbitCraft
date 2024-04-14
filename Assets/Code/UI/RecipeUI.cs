using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Code;

namespace Code.UI.Book
{
    public class RecipeUI : MonoBehaviour
    {
        [SerializeField]
        Recipe recipe;

        [SerializeField]
        List<Image> images;

        void SetUp(Recipe rec)
        {
            recipe = rec;
        }

        private void Start()
        {
            if (recipe)
            {
                foreach(Image item in images)
                {
                    item.sprite = recipe.ingredients[images.IndexOf(item)].Icon;
                }
            }
        }

    }

}
