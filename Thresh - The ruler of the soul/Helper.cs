using System.Collections.Generic;
using System.Linq;
using LeagueSharp;
using LeagueSharp.Common;

namespace ThreshTherulerofthesoul
{
    class Helper
    {
        private static Obj_AI_Hero Player { get { return ObjectManager.Player; } }

        public static Obj_AI_Hero GetMostAD(bool IsAllyTeam, float range)
        {
            Obj_AI_Hero MostAD = null;

            foreach (Obj_AI_Hero hero in ObjectManager.Get<Obj_AI_Hero>()
                .Where(x => (IsAllyTeam ? x.IsAlly : x.IsEnemy && x.IsValidTarget()) && 
                    !x.IsMe && !x.IsDead))
            {
                if (Player.Distance(hero.Position) < range)
                {
                    if (MostAD == null)
                    {
                        MostAD = hero;
                    }
                    else if (MostAD != null && MostAD.TotalAttackDamage < hero.TotalAttackDamage)
                    {
                        MostAD = hero;
                    }
                }
            }

            return MostAD;
        }

        public static IEnumerable<Obj_AI_Hero> GetEnemiesNearTarget(Obj_AI_Hero target)
        {
            return HeroManager.Enemies.Where(x => target.Distance(x.Position) < 1500 && !x.IsDead);
        }

        public static bool EnemyHasShield(Obj_AI_Hero target)
        {
            var status = false;

            if (target.HasBuff("blackshield"))
            {
                status = true;
            }

            if (target.HasBuff("sivire"))
            {
                status = true;
            }

            if (target.HasBuff("nocturneshroudofdarkness"))
            {
                status = true;
            }

            if (target.HasBuff("bansheesveil"))
            {
                status = true;
            }
            return status;
        }

        public static double GetAlliesComboDmg(Obj_AI_Hero target, Obj_AI_Hero ally)
        {
            var SpellSlots = new List<SpellSlot>();
            double dmg = 0;
            #region SpellSots
            SpellSlots.Add(SpellSlot.Q);
            SpellSlots.Add(SpellSlot.W);
            SpellSlots.Add(SpellSlot.E);
            SpellSlots.Add(SpellSlot.R);
            #endregion

            foreach (var slot in SpellSlots)
            {
                var spell = ally.Spellbook.GetSpell(slot);

                dmg += ally.GetSpellDamage(target, slot);
                dmg += ally.GetAutoAttackDamage(target);
            }

            return dmg;
        }

    }
}
