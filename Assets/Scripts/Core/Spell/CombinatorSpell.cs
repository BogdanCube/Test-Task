using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using Equals = Core.Spell.SpellExtension;
namespace Core.Spell
{
    public class CombinatorSpell : MonoBehaviour
    {
        [SerializeField,Expandable] private List<Spell> _spells;
        [ShowNonSerializedField] private Spell _currentSpell;

        public Spell Combination(Spell firstSpell, Spell secondSpell)
        {
            if (firstSpell.Equal(secondSpell) && secondSpell.Equal(firstSpell))
            {
                _currentSpell = firstSpell;
            }
            else
            {
                foreach (var spell in _spells)
                {
                    var firstParent = spell.FirstParent;
                    var secondParent = spell.SecondParent;

                    var equal1 = firstSpell.Equal(firstParent) || firstSpell.Equal(secondParent);
                    var equal2 = secondSpell.Equal(firstParent) || secondSpell.Equal(secondParent);
                    
                    if (equal1 && equal2)
                    {
                        _currentSpell = spell;
                        break;
                    }
                }
            }

            return _currentSpell;
        }
    }
}