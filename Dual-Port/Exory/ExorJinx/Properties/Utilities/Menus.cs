using EloBuddy.SDK.Menu.Values;
using ExorAIO.Utilities;

namespace ExorAIO.Champions.Jinx
{
    /// <summary>
    ///     The menu class.
    /// </summary>
    internal class Menus
    {
        /// <summary>
        ///     Sets the menu.
        /// </summary>
        public static void Initialize()
        {
            /// <summary>
            ///     Sets the menu for the Q.
            /// </summary>
            Vars.QMenu = Vars.Menu.AddSubMenu("Use Q to:");
            {
                Vars.QMenu.Add("combo", new CheckBox("Combo", true));
                Vars.QMenu.Add("clear", new Slider("Clear / if Mana >= x%", 50, 0, 101));
                Vars.QMenu.Add("harass", new Slider("Harass / if Mana >= x%", 50, 0, 101));
                Vars.QMenu.Add("lasthit", new Slider("LastHit / if Mana >= x%", 50, 0, 101));
            }

            /// <summary>
            ///     Sets the menu for the W.
            /// </summary>
            Vars.WMenu = Vars.Menu.AddSubMenu("Use W to:");
            {
                Vars.WMenu.Add("combo", new CheckBox("Combo", true));
                Vars.WMenu.Add("killsteal", new CheckBox("KillSteal", true));
                Vars.WMenu.Add("logical", new CheckBox("Logical", true));
                Vars.WMenu.Add("harass", new Slider("Harass / if Mana >= x%", 50, 0, 101));
            }

            /// <summary>
            ///     Sets the menu for the E.
            /// </summary>
            Vars.EMenu = Vars.Menu.AddSubMenu("Use E to:");
            {
                Vars.EMenu.Add("combo", new CheckBox("Combo", true));
                Vars.EMenu.Add("gapcloser", new CheckBox("Anti-Gapcloser", true));
                Vars.EMenu.Add("logical", new CheckBox("Logical", true));
            }

            /// <summary>
            ///     Sets the menu for the R.
            /// </summary>
            Vars.RMenu = Vars.Menu.AddSubMenu("Use R to:");
            {
                Vars.RMenu.Add("aoe", new Slider("AoE / If can hit >= x enemies", 3, 2, 6));
                Vars.RMenu.Add("killsteal", new CheckBox("KillSteal", true));
            }

            /// <summary>
            ///     Sets the miscellaneous menu.
            /// </summary>
            Vars.MiscMenu = Vars.Menu.AddSubMenu("Miscellaneous");
            {
                Vars.MiscMenu.Add("blockq", new CheckBox("Block Manual Q Casting in LC", true));
            }

            /// <summary>
            ///     Sets the drawings menu.
            /// </summary>
            Vars.DrawingsMenu = Vars.Menu.AddSubMenu("Drawings");
            {
                Vars.DrawingsMenu.Add("q", new CheckBox("Q Range"));
                Vars.DrawingsMenu.Add("w", new CheckBox("W Range"));
                Vars.DrawingsMenu.Add("e", new CheckBox("E Range"));
            }
        }
    }
}