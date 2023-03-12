using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Creative;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace RealmOne.Projectiles.Throwing
{
    public class TundraThrowingKnifeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Knife");

        }

        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 12;

            Projectile.aiStyle = 2;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.5f;
            Projectile.tileCollide = true;
            Projectile.penetrate = -2;
            Projectile.timeLeft = 320;
            Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
            AIType = ProjectileID.ThrowingKnife;
        }
        public override void Kill(int timeleft)

        {
            for (var i = 0; i < 6; i++)
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ice, 0f, 0f, 0, default, 1f);
            Collision.AnyCollision(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item50, Projectile.position);


        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)

        {
            target.AddBuff(BuffID.Frostburn, 180);
        }


    }
}