using System;
using Code.Core.Bestiary;
using Code.Core.Likes;
using Code.Core.Pentagram;
using UnityEngine;

namespace Code.Core
{
    public sealed class StaticInitializer : MonoBehaviour 
    {
        private void Start()
        {
            BestiaryBook.Init();
            PentagramData.ClearData();
            LikesSystem.Init();
        }
    }
}