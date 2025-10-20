using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace MagicEngineer.Weapons
{
    public class WoodenStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 1;
            Item.value = 2700;
            Item.DamageType = ModContent.GetInstance<Classes.Engineer>();
            Item.damage = 15;
            Item.mana = 5;
            Item.useTime = 25;
            Item.autoReuse = true;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.GreenProj>();
            Item.shootSpeed = 8f;
            Item.rare = ItemRarityID.Blue;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}