using System.Collections.Generic;
using Code.Core.Frogs;

namespace Code.Core.Bestiary
{
    public static class BestiaryBook
    {
        private static List<FrogSOData> _collectedFrogs = new();
        private static List<Recipe> _collectedRecipes = new();
        
        public static void CollectFrog(FrogSOData data)
        {
            _collectedFrogs.Add(data);
        }
    }
}