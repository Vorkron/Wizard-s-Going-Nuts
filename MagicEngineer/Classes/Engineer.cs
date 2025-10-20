using Terraria.ModLoader;
using Terraria;

namespace MagicEngineer.Classes
{
    public class Engineer : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            return base.GetModifierInheritance(damageClass);
        }
    }
}