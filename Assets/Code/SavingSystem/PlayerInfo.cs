using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInfo
{
    
    
    public class FrogInfo
    {
        public IntInfo IsOpened;
        public List<IntInfo> recipes = new List<IntInfo>();
        public FrogInfo(string name)
        {
            IsOpened = new IntInfo(name + "IsOpened", 0);
            foreach (var recipe in recipes)
            {
                
            }
        }
    }
    
    public static Dictionary<string, FrogInfo> Frogs = new Dictionary<string, FrogInfo>();
    public static IntInfo SoundOn = new IntInfo("SoundOn", 1);
    public static IntInfo ShowTScreen= new IntInfo("ShowTScreen", 0);
}
