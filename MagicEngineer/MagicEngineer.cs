using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria;
using Microsoft.Xna.Framework;
using MagicEngineer.Classes;

namespace MagicEngineer
{
	public class MagicEngineer : Mod
    {
        internal static UserInterface SpellUI;
		internal static UI.SpellUI uiState;
		public override void Load()
		{
			if (Main.dedServ)
				return;

			SpellUI = new UserInterface();
			uiState = new UI.SpellUI();
		}

		public override void Unload()
        {
            SpellUI = null;
			uiState = null;
        }

        internal class Classes
        {
        }
    }

	public class MagicEngineerSystem : ModSystem
	{
		public override void UpdateUI(GameTime gameTime)
		{
			if (Main.dedServ) return;

			if (Main.playerInventory)
			{
				if (MagicEngineer.SpellUI.CurrentState == null)
                {
                    MagicEngineer.SpellUI.SetState(MagicEngineer.uiState);
                }
            }
			else
			{
				if (MagicEngineer.SpellUI.CurrentState != null)
				{
					MagicEngineer.SpellUI.SetState(null);
				}
			}
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"MagicEngineer: Spell UI",
					delegate
					{
						if (MagicEngineer.SpellUI.CurrentState != null)
                        {
                            MagicEngineer.SpellUI.Draw(Main.spriteBatch, Main.GameUpdateCount == 0 ? default : new GameTime());
                        }
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}
