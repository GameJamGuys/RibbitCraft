using System;
using System.Collections.Generic;
using Code.Core.Frogs;
using DefaultNamespace;
using UnityEngine;

namespace Code.Core.Bestiary
{
    [CreateAssetMenu(menuName = "Unlocks")]
    public sealed class BestiaryUnlock : ScriptableObject
    {
        [field: SerializeField] public List<BestiaryUnlockElement> Unlocks { get; private set; } = new();
    }

    [Serializable]
    public sealed class BestiaryUnlockElement
    {
        [field: SerializeField] public FrogSOData Frog { get; private set; }
        [field: SerializeField] public IngredientSOType Ingredient { get; private set; }
    }
}