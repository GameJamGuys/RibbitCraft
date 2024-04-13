using UnityEngine;

namespace Code.Core.Frogs
{
    public sealed class FrogsCollectionSO : ScriptableObject
    {
        [field: SerializeField] public FrogSOData[] Frogs { get; private set; }
    }
}