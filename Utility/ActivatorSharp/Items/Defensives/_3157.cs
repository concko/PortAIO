﻿using System;
using Activators.Base;
using LeagueSharp.Common;
using EloBuddy.SDK.Menu.Values;

namespace Activators.Items.Defensives
{
    class _3157 : CoreItem
    {
        internal override int Id => 3157;
        internal override int Priority => 7;
        internal override string Name => "Zhonyas";
        internal override string DisplayName => "Zhonya's Hourglass";
        internal override int Duration => 2500;
        internal override float Range => 750f;
        internal override MenuType[] Category => new[] { MenuType.SelfLowHP, MenuType.SelfMuchHP, MenuType.Zhonyas };
        internal override MapType[] Maps => new[] { MapType.SummonersRift, MapType.HowlingAbyss };
        internal override int DefaultHP => 35;  
        internal override int DefaultMP => 0;

        public override void OnTick(EventArgs args)
        {
            if (!Menu["use" + Name].Cast<CheckBox>().CurrentValue || !IsReady())
                return;

            foreach (var hero in Activator.Allies())
            {
                if (hero.Player.NetworkId == Player.NetworkId)
                {
                    if (Activator.dmenu[Parent.UniqueMenuId + "useon" + hero.Player.NetworkId] == null)
                    {
                        continue;
                    }
                    if (!Activator.dmenu[Parent.UniqueMenuId + "useon" + hero.Player.NetworkId].Cast<CheckBox>().CurrentValue)
                        continue;

                    if (hero.IncomeDamage / hero.Player.MaxHealth * 100 >=
                        Menu["selfmuchhp" + Name + "pct"].Cast<Slider>().CurrentValue)
                        UseItem();

                    if (Menu["use" + Name + "norm"].Cast<CheckBox>().CurrentValue &&
                        hero.IncomeDamage > 0 && hero.HitTypes.Contains(HitType.Danger))
                        UseItem();

                    if (Menu["use" + Name + "ulti"].Cast<CheckBox>().CurrentValue &&
                        hero.IncomeDamage > 0 && hero.HitTypes.Contains(HitType.Ultimate))
                        UseItem();

                    if (hero.Player.Health/hero.Player.Health*100 <=
                        Menu["selflowhp" + Name + "pct"].Cast<Slider>().CurrentValue)
                        if (hero.IncomeDamage > 0 || hero.MinionDamage > hero.Player.Health)
                            UseItem();
                }
            }
        }
    }
}
