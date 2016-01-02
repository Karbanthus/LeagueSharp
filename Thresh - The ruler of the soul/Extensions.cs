using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;

namespace ThreshTherulerofthesoul
{
    public static class Extensions
    {
        #region Obj_AI_Hero

        public static float HpPercents(this Obj_AI_Hero hero)
        {
            return hero.Health / hero.MaxHealth * 100;
        }

        public static float ManaPercents(this Obj_AI_Hero hero)
        {
            return hero.Mana / hero.MaxMana * 100;
        }

        #endregion

        #region Menu

        public static bool IsBool(this Menu Menu, string item)
        {
            return Menu.Item(item, true).GetValue<bool>();
        }

        public static bool IsActive(this Menu Menu, string item)
        {
            return Menu.Item(item, true).GetValue<KeyBind>().Active;
        }
        
        public static int GetValue(this Menu Menu, string item)
        {
            return Menu.Item(item, true).GetValue<Slider>().Value;
        }

        #endregion

    }
}
