using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace MagicEngineer.Projectiles
{
    public class GreenProj : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.stepSpeed = 1f;
            Projectile.aiStyle = 1;
        }

        public override void AI()
        {
            Lighting.AddLight(Projectile.position, Color.Green.ToVector3() * 2f);
        }
    }
}