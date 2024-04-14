using Code.UI;
using UnityEngine;

namespace Code.Core.Likes
{
    public static class LikesSystem
    {
        private static int _likes;
        public static int Likes
        {
            get => _likes;
            set
            {
                _likes = value;
                LikesUI.Instance.UpdateLikes(_likes);
                SaveToPrefs();
            } 
        }

        public static void Init()
        {
            LoadFromPrefs();
        }

        public static void SaveToPrefs()
        {
            PlayerPrefs.SetInt("Likes", _likes);
            PlayerPrefs.Save();
        }

        public static void LoadFromPrefs()
        {
            _likes = PlayerPrefs.GetInt("Likes", 0);
            LikesUI.Instance.UpdateLikes(_likes);
        }
    }
}