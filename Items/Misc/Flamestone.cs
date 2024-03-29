using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace RealmOne.Items.Misc
{
	public class Flamestone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flamestone"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("'A hot, bright and earthy material of the underworld'");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;

		}

		public override void SetDefaults()
		{
			Item.material = true;
			Item.width = 20;
			Item.height = 20;
			Item.value = 20000;
			Item.rare = ItemRarityID.Orange;
			Item.maxStack = 999;
			Item.scale = 0.5f;

		}
	}
}