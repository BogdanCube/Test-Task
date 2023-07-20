using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Serialization;

namespace Core.Spell
{
    [CreateAssetMenu(fileName = "Spell", menuName = "My Assets")]
    public class Spell : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public float ExplosionRadius;
        public float Speed;
        public Color Color;
        public Gradient Gradient;

        [Space] public bool IsBaseSpell = true;
        [ShowIf("IsBaseSpell")] public GameObject PrefabParticle;
        [HideIf("IsBaseSpell")] [FormerlySerializedAs("_firstParent")]  public Spell FirstParent;
        [HideIf("IsBaseSpell")] [FormerlySerializedAs("_secondParent")]  public Spell SecondParent;
    }
}