using Terraria.ModLoader;
using Terraria;

namespace MagicEngineer.Classes
{
    public class MagicEngineer : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            return base.GetModifierInheritance(damageClass);
        }
    }
}
