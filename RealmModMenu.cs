﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.Audio;
using Terraria.ModLoader;

namespace RealmOne
{
	public class RealmModMenu : ModMenu
	{
		private const string menuAssetPath = "RealmOne/Assets/Textures/Menu"; // Creates a constant variable representing the texture path, so we don't have to write it out multiple times

		public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>("RealmOne/Assets/Textures/Menu/MenuLogo", (AssetRequestMode)2);

		public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/WormSun");

		public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/WormMoon");

		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/TheUnknown1");

		public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<SurfaceBack>();

		public override string DisplayName => "The Last Paradox Aligns";

		public override void OnSelected()
		{
			SoundEngine.PlaySound(rorAudio.ModMenuClick);

		}

		public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
		{
			logoScale = 1.5f;
			return true;

		}
	}
}