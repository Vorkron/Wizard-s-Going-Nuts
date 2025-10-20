using Terraria.ModLoader;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.GameInput;
using Terraria.UI.Chat;
using MagicEngineer.Classes;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace MagicEngineer.UI
{
    public class SpellUI : UIState
    {
        private UIPanel panel;
        private List<UIItemSlot> itemSlots = new List<UIItemSlot>();
        private List<Item> spellItems = new List<Item>();

        private int maxslots = 10;
        private float slotSize = 64f;
        private float padding = 10f;
        private float panelX = 350f;
        private float panelY = 300f;

        public override void OnInitialize()
        {
            panel = new UIPanel();
            panel.SetPadding(10);
            panel.Width.Set(450, 0f);
            panel.Height.Set(100, 0f);
            panel.Left.Set(panelX, 0f);
            panel.Top.Set(panelY, 0f);
            panel.BackgroundColor = new Color(22, 21, 38);

            for (int i = 0; i < maxslots; i++)
            {
                Item item = new Item();
                item.TurnToAir();
                spellItems.Add(item);

                UIItemSlot itemSlot = new UIItemSlot(spellItems.ToArray(), i, ItemSlot.Context.InventoryItem);
                itemSlot.Left.Set(padding, 0f);
                itemSlot.Top.Set(padding + i * (slotSize + padding), 0f);
                itemSlot.Width.Set(slotSize, 0f);
                itemSlot.Height.Set(slotSize, 0f);
                panel.Append(itemSlot);
                itemSlots.Add(itemSlot);
            }

            Append(panel);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            List<Item> engineerItems = new List<Item>();
            foreach (Item item in Main.LocalPlayer.inventory)
            {
                if (!item.IsAir && item.DamageType == ModContent.GetInstance<Engineer>())
                {
                    engineerItems.Add(item);
                }
            }

            for (int i = 0; i < maxslots; i++)
            {
                if (i < engineerItems.Count)
                {
                    spellItems[i] = engineerItems[i];
                }
                else
                {
                    spellItems[i] = new Item();
                    spellItems[i].TurnToAir();
                }
            }

            for (int i = 0; i < maxslots; i++)
            {
                ItemSlot.Draw(spellItems[i], ItemSlot.Context.InventoryItem, panel.GetDimensions().Position() + new Vector2(padding, padding + i * (slotSize + padding)));
            }

            float neededHeight = padding + maxslots * (slotSize + padding);
            if (neededHeight > panel.Height.Pixels)
            {
                panel.Height.Set(neededHeight, 0f);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}