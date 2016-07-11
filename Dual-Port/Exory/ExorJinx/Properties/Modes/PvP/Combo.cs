using System;
using System.Linq;
using ExorAIO.Utilities;
using LeagueSharp;
using LeagueSharp.SDK;
using LeagueSharp.SDK.Core.Utils;

namespace ExorAIO.Champions.Jinx
{
    /// <summary>
    ///     The logics class.
    /// </summary>
    internal partial class Logics
    {
        /// <summary>
        ///     Called when the game updates itself.
        /// </summary>
        /// <param name="args">The <see cref="EventArgs" /> instance containing the event data.</param>
        public static void Combo(EventArgs args)
        {
            /// <summary>
            ///     The R Combo Logic.
            /// </summary>
            if (Vars.R.IsReady() &&
                Vars.getSliderItem(Vars.RMenu, "aoe") != 6)
            {
                foreach (var target in GameObjects.EnemyHeroes.Where(
                    t =>
                        t.LSIsValidTarget(Vars.W.Range) &&
                        t.CountEnemyHeroesInRange(225f) >=
                            Vars.getSliderItem(Vars.RMenu, "aoe")))
                {
                    Vars.R.Cast(target.ServerPosition);
                }
            }

            if (Bools.HasSheenBuff() ||
                !Targets.Target.LSIsValidTarget() ||
                Invulnerable.Check(Targets.Target))
            {
                return;
            }

            /// <summary>
            ///     The E Combo Logic.
            /// </summary>
            if (Vars.E.IsReady() &&
                Targets.Target.LSIsValidTarget(Vars.E.Range) &&
                Targets.Target.CountEnemyHeroesInRange(Vars.E.Width) >= 2 &&
                Vars.getCheckBoxItem(Vars.EMenu, "combo"))
            {
                Vars.E.Cast(GameObjects.Player.ServerPosition.LSExtend(
                    Targets.Target.ServerPosition, GameObjects.Player.Distance(Targets.Target) + Targets.Target.BoundingRadius));
            }

            if (GameObjects.EnemyHeroes.Any(t => t.LSIsValidTarget(Vars.PowPow.Range)))
            {
                return;
            }

            /// <summary>
            ///     The W Combo Logic.
            /// </summary>
            if (Vars.W.IsReady() &&
                !GameObjects.Player.IsUnderEnemyTurret() &&
                Targets.Target.LSIsValidTarget(Vars.W.Range) &&
                Vars.getCheckBoxItem(Vars.WMenu, "combo"))
            {
                if (!Vars.W.GetPrediction(Targets.Target).CollisionObjects.Any())
                {
                    Vars.W.Cast(Vars.W.GetPrediction(Targets.Target).UnitPosition);
                }
            }
        }
    }
}