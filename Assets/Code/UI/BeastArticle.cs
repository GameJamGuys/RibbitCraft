using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Code.Core.Frogs;
using Code.Core.Bestiary;

namespace Code.UI.Book
{
    public class BeastArticle : MonoBehaviour
    {
        [SerializeField]
        FrogSOData frog;
        [SerializeField]
        List<Recipe> recipes;

        [SerializeField]
        TMP_Text frogName, frogDesc;
        [SerializeField]
        List<RecipeUI> recipeUIs;
        [Space]
        [SerializeField]
        Image image;
        [SerializeField]
        GameObject questionMark;

        void Start()
        {
            frogName.text = frog.Name;
            image.sprite = frog.Sprite;

            if (BestiaryBook.CheckFrog(frog))
            {
                questionMark.SetActive(false);
                image.color = Color.white;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
