using DefaultNamespace;
using UnityEngine;

namespace Code.Core.Ingredients
{
    [CreateAssetMenu(menuName = "IngredientsCollection")]
    public sealed class IngredientsCollectionSO : ScriptableObject
    {
        [field: SerializeField] public IngredientSOType[] Ingredients { get; private set; }
    }
}