using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using SharpDX;

namespace ThreshTherulerofthesoul
{
    class Turret
    {
        public static bool IsUnderEnemyTurret(Obj_AI_Hero hero)
        {
            return ObjectManager.Get<Obj_AI_Turret>().Any(turret => turret.Distance(hero.Position) < 950 && turret.IsEnemy);
        }

        public static bool IsUnderAllyTurret(Obj_AI_Hero hero)
        {
            return ObjectManager.Get<Obj_AI_Turret>().Any(turret => turret.Distance(hero.Position) < 950 && turret.IsAlly);
        }
    }
}
