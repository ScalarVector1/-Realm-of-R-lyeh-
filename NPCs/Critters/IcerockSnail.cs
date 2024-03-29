﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
namespace RealmOne.NPCs.Critters
{
	public class IcerockSnail : ModNPC
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icerock Snail");
			Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.MagmaSnail];

			var value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{ // Influences how the NPC looks in the Bestiary
				Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
		}

		public override void SetDefaults()
		{
			NPC.width = 23;
			NPC.height = 40;
			NPC.defense = 5;
			NPC.lifeMax = 5;
			NPC.value = 76f;
			NPC.aiStyle = NPCAIStyleID.Snail;
			NPC.HitSound = SoundID.Item50;

			NPC.DeathSound = SoundID.NPCDeath1;
			AIType = NPCID.MagmaSnail;
			AnimationType = NPCID.MagmaSnail;

		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.SpawnTileY < Main.worldSurface && Main.dayTime && spawnInfo.Player.ZoneSnow && !Main.dayTime && !spawnInfo.PlayerSafe ? 1f : 0f;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				   BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,
								BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,

				new FlavorTextBestiaryInfoElement("Hardened and frigid, these snails have much tougher shells than most snails. When broken, they turn into ice slugs"),

			});
		}
		public override void HitEffect(NPC.HitInfo hit)
		{

			for (int i = 0; i < 10; i++)
			{

				Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);

				var d = Dust.NewDustPerfect(NPC.position, DustID.Ice, speed * 5, Scale: 2f);
				;
				d.noGravity = true;
			}
		}
		public override void AI()
		{
			Lighting.AddLight(NPC.position, r: 0f, g: 0.1f, b: 0.6f);
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo hurtInfo)
		{
			// Here we can make things happen if this NPC hits a player via its hitbox (not projectiles it shoots, this is handled in the projectile code usually)
			// Common use is applying buffs/debuffs:

			int buffType = BuffID.Frozen;
			// Alternatively, you can use a vanilla buff: int buffType = BuffID.Slow;

			int timeToAdd = 2 * 60; //This makes it 5 seconds, one second is 60 ticks
			target.AddBuff(buffType, timeToAdd);
		}
	}
}
