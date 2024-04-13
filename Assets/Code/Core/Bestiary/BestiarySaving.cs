using System.Collections.Generic;
using Code.Core.Frogs;
using UnityEngine;

namespace Code.Core.Bestiary
{
    public class BestiarySaving : MonoBehaviour
    {
        
        [SerializeField] private List<FrogSOData> frogs = new List<FrogSOData>();
        private void Awake()
        {
            for (int i = 0; i < frogs.Count; i++)
            {
                if (!PlayerInfo.Frogs.ContainsKey(frogs[i].Name))
                {
                    PlayerInfo.Frogs.Add(frogs[i].Name,new PlayerInfo.FrogInfo(frogs[i].Name));
                }
            }
        }
    }
}