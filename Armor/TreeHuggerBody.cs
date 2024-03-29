﻿using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Armor
{
	[AutoloadEquip(EquipType.Body)]

	public class TreeHuggerBody : ModItem
	{
		public override void SetStaticDefaults()
		{
			base.SetStaticDefaults();
			DisplayName.SetDefault("Tree Hugger Chestplate");
			Tooltip.SetDefault("5% increased knockback on all weapons"
				+ "\n'Chestplate of the tree tops!'");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;

			// If your head equipment should draw hair while drawn, use one of the following:
			// ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false; // Don't draw the head at all. Used by Space Creature Mask
			// ArmorIDs.Head.Sets.DrawHatHair[Item.headSlot] = true; // Draw hair as if a hat was covering the top. Used by Wizards Hat
			// ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true; // Draw all hair as normal. Used by Mime Mask, Sunglasses
			// ArmorIDs.Head.Sets.DrawBackHair[Item.headSlot] = true;
			// ArmorIDs.Head.Sets.DrawsBackHairWithoutHeadgear[Item.headSlot] = true; 
		}
		public override void SetDefaults()
		{
			Item.width = 18; // Width of the item
			Item.height = 18; // Height of the item
			Item.value = Item.sellPrice(gold: 1); // How many coins the item is worth
			Item.rare = ItemRarityID.Green; // The rarity of the item
			Item.defense = 3; // The amount of defense the item will give when equipped
		}

		public override void UpdateEquip(Player player)
		{
			player.GetKnockback(DamageClass.Generic) += 0.05f;

		}

		// IsArmorSet determines what armor pieces are needed for the setbonus to take effect

		// UpdateArmorSet allows you to give set bonuses to the armor.

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Wood, 30)
			.AddIngredient(ItemID.Acorn, 6)
			.AddIngredient(Mod, "CrushedAcorns", 30)
			.AddTile(TileID.WorkBenches)
			.Register();

		}
	}
}
