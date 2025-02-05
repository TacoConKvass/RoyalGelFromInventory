using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace RoyalGelFromInventory;

public class RoyalGelTweak : GlobalItem {
	public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.RoyalGel;

	public override void UpdateInventory(Item item, Player player) {
		if (!item.favorited) return;

		player.ApplyEquipFunctional(item, true);
	}

	public override void ModifyTooltips(Item item, List<TooltipLine> tooltips) {
		int index = tooltips.FindIndex(line => line.Name == "Tooltip0");
		if (index < 0) return;

		tooltips[index].Text += "\n" + Language.GetTextValue("Mods.RoyalGelFromInventory.CanWorkInInventory");
	}
}