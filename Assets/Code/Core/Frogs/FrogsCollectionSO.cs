using UnityEngine;

namespace Code.Core.Frogs
{
    [CreateAssetMenu(menuName = "Frogs collection")]
    public sealed class FrogsCollectionSO : ScriptableObject
    {
        [field: SerializeField] public FrogSOData[] Frogs { get; private set; }
    }
}