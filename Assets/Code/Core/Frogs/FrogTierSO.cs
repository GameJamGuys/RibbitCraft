using UnityEngine;

namespace Code.Core.Frogs
{
    [CreateAssetMenu(menuName = "FrogTier")]
    public sealed class FrogTierSO : ScriptableObject
    {
        [field: SerializeField] public int LikesMin { get; private set; }
        [field: SerializeField] public int LikesMax { get; private set; }
    }
}