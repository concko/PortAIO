﻿using EloBuddy;
using LeagueSharp.SDK;
using LeagueSharp.SDK.Core.Utils;
using SharpDX;
using System;
using System.Linq;
using PrideStalker_Rengar.Main;
using EloBuddy.SDK;

 namespace PrideStalker_Rengar.Handlers
{
    class AfterAA : Core
    {
        
        public static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            var dgfg = target;
            if (dgfg is AIHeroClient)
            {
                var Target = dgfg as AIHeroClient;
      
            if (Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear) || Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
            {

                if (Player.Mana == 5 && MenuConfig.Passive)
                {
                    return;
                }
                if (Mode.getBoxItem(MenuConfig.comboMenu, "ComboMode") != 2)
                {
                    if (Spells.Q.IsReady() && Player.HealthPercent >= 35 && Player.Mana == 5)
                    {
                        Spells.Q.Cast();
                    }
                    var mob = ObjectManager.Get<Obj_AI_Minion>().Where(m => !m.IsDead && !m.IsZombie && m.Team == GameObjectTeam.Neutral && m.LSIsValidTarget(Spells.W.Range)).ToList();
                    foreach(var m in mob)
                    {
                        if (Player.Mana < 5 && m.Health > Player.GetAutoAttackDamage(m))
                        {
                            Spells.Q.Cast();
                        }
                    }
                }
                if(Mode.getBoxItem(MenuConfig.comboMenu, "ComboMode") == 2)
                {
                    if(Player.Mana < 5)
                    {
                        Spells.Q.Cast();
                    }
                }
            }
        }
      }
    }
}
