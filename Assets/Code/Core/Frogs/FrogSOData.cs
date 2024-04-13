using UnityEngine;

namespace Code.Core.Frogs
{
    [CreateAssetMenu(menuName = "Frog data")]
    public sealed class FrogSOData : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Sprite { get; private set; }
    } }