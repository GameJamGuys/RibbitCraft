using System;
using Code.Core.Bestiary;
using Code.Core.Pentagram;
using UnityEngine;

namespace Code.Core
{
    public sealed class StaticInitializer : MonoBehaviour 
    {
        private void Awake()
        {
            BestiaryBook.Init();
            PentagramData.ClearData();
        }
    }
}