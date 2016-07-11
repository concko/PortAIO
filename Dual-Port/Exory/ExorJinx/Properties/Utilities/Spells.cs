using EloBuddy;
using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK;
using LeagueSharp.SDK.Enumerations;

namespace ExorAIO.Champions.Jinx
{
    /// <summary>
    ///     The spells class.
    /// </summary>
    internal class Spells
    {
        /// <summary>
        ///     Sets the spells.
        /// </summary>
        public static void Initialize()
        {
            Vars.PowPow = new Spell(SpellSlot.Q, GameObjects.Player.BoundingRadius + 525f);
            Vars.Q = new Spell(SpellSlot.Q, Vars.PowPow.Range + (50f + 25f * GameObjects.Player.Spellbook.GetSpell(SpellSlot.Q).Level));
            Vars.W = new Spell(SpellSlot.W, 1350f); // Test - Original Range: 1450f.
            Vars.E = new Spell(SpellSlot.E, 900f);
            Vars.R = new Spell(SpellSlot.R, 1500f);

            Vars.W.SetSkillshot(0.6f, 80.5f, 3200f, true, SkillshotType.SkillshotLine);
            Vars.E.SetSkillshot(1.5f, 100f, 1000f, false, SkillshotType.SkillshotCircle);
            Vars.R.SetSkillshot(0.6f, 140f, 1700f, false, SkillshotType.SkillshotLine);
        }
    }
}