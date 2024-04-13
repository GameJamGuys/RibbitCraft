using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;

public static class PlayerInfo
{
    
    
    public class FrogInfo
    {
        public IntInfo IsOpened;
        public FrogInfo(string name)
        {
            IsOpened = new IntInfo(name + "FrogIsOpened", 0);
        }
    }
    public class RecipeInfo
    {
        public IntInfo IsOpened;
        public RecipeInfo(string name)
        {
            IsOpened = new IntInfo(name + "RecipeIsOpened", 0);
        }
    }
    
    public static Dictionary<string, FrogInfo> Frogs = new Dictionary<string, FrogInfo>();
    public static Dictionary<string, RecipeInfo> Recipes = new Dictionary<string, RecipeInfo>();
    public static IntInfo SoundOn = new IntInfo("SoundOn", 1);
    public static IntInfo ShowTScreen= new IntInfo("ShowTScreen", 0);
}
