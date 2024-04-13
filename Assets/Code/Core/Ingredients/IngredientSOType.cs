using Code.Core.Ingredients;
using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(menuName = "IngredientType")]
    public sealed class IngredientSOType : ScriptableObject
    {
        [field: SerializeField] public EIngredientType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
    }
}