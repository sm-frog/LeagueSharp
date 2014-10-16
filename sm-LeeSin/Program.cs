using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace sm_LeeSin
{
    class Program
    {
        private static Orbwalking.Orbwalker Orbwalker;
        private static Obj_AI_Hero Player;
        private static Obj_AI_Hero Target;

        public const string ChampionName = "LeeSin";
        public static Spellbook sBook;
        public static SpellDataInst Qdata;
        public static Menu Config;
        public static Spell Q;
        public static Spell W;
        public static Spell E;
        public static Spell R;

        static void Main(string[] args)
        {
            CustomEvents.Game.OnGameLoad += onLoadGame;
        }
        public static void onLoadGame(EventArgs args)
        {
            Player = ObjectManager.Player;
            init();
        }

        private static void init()
        {
            Game.PrintChat("L e e S i n !");
            setMenu();
            setVars();
        }
        public static void setVars()
        {
            Target = null;
            sBook = Player.Spellbook;
            Qdata = sBook.GetSpell(SpellSlot.Q);
            Q = new Spell(SpellSlot.Q, 1000);
            W = new Spell(SpellSlot.W, 700);
            E = new Spell(SpellSlot.E, 1000);
            R = new Spell(SpellSlot.R, 375);
        }
        public static void setMenu()
        {
            Config = new Menu(ChampionName, ChampionName, true);
            Config.AddSubMenu(new Menu("Orbwalking", "Orbwalking"));

            Config.AddSubMenu(new Menu("WardJump", "WardJump"));
            Config.SubMenu("WardJump").AddItem(new MenuItem("WHJS", "Key").SetValue(new KeyBind(51, KeyBindType.Press)));

            Config.AddSubMenu(new Menu("ShotQ", "ShotQ"));
            Config.SubMenu("ShotQ").AddItem(new MenuItem("ShotQ", "Key").SetValue(new KeyBind(81, KeyBindType.Press)));

            Config.AddSubMenu(new Menu("SmartInsec", "SmartInsec"));
            Config.SubMenu("SmartInsec").AddItem(new MenuItem("SmartInsec", "Key").SetValue(new KeyBind(84, KeyBindType.Press)));

            var targetSelectorMenu = new Menu("Target Selector", "Target Selector");
            SimpleTs.AddToMenu(targetSelectorMenu);
            Config.AddSubMenu(targetSelectorMenu);
            Orbwalker = new Orbwalking.Orbwalker(Config.SubMenu("Orbwalking"));
            Config.AddToMainMenu();
        }
    }
}
