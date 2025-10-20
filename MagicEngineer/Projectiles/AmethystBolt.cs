using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace MagicEngineer.Projectiles
{
    public class AmethystBolt : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.knockBack = 1.25f;
            Projectile.damage = 10;
            Projectile.timeLeft = 600; // 10 seconds
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<Classes.Engineer>();
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 1;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.Center, Color.Purple.ToVector3() * 2.5f);
        }
    }
}