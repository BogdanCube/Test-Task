namespace Core.Spell
{
    public static class SpellExtension
    {
        public static bool Equal(this Spell firstSpell, Spell secondSpell)
        {
            return firstSpell.Name.Equals(secondSpell.Name);
        }
    }
}