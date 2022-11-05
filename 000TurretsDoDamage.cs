//=============================================================================
// Author: Jackty89
//=============================================================================


public class TurretsDoDamage : cmk.NMS.Script.ModClass
{
	protected override void Execute()
	{
		EditsToProjectilTable();
		EditTurretEntity();
		EditAiSpaceShipGlobals();
	}

	protected void EditsToProjectilTable()
	{
		var mbin = ExtractMbin<GcProjectileDataTable>("METADATA/PROJECTILES/PROJECTILETABLE.MBIN");
		
		var freightGun = mbin.Table.Find(PROJECTILE => PROJECTILE.Id == "FREIGHTGUN");
		freightGun.Scale = 4;
		freightGun.Radius = 85;
		freightGun.DefaultSpeed = 1750;
		freightGun.Life = 10;
		freightGun.DefaultDamage = 1000;
		freightGun.CriticalHitModifier = 2.5f;
		freightGun.UseCustomBulletData = true; 
		
		freightGun.CustomBulletData.BulletLength = 25;
		freightGun.CustomBulletData.BulletGlowWidthTime = 0.15f;
		freightGun.CustomBulletData.BulletGlowWidthMax = 25;
		freightGun.CustomBulletData.BulletGlowWidthMin = 35;
		freightGun.CustomBulletData.BulletMaxScaleDistance = 8000;
		
		freightGun.Colour.R = 0.973f;
		freightGun.Colour.G = 0.172f;
		freightGun.Colour.B = 0.358f;

		freightGun.OverrideLightColour = true;

		freightGun.LightColour.R = 0.8f;
		freightGun.LightColour.G = 0.2f;


		var freighterProjectile = CloneMbin(mbin.Table.Find(PROJECTILE => PROJECTILE.Id == "SHIPPLASMAGUN"));
		freighterProjectile.Id = "FREIGHTPLASMAGUN";
		freighterProjectile.FireAudioEvent.AkEvent = GcAudioWwiseEvents.AkEventEnum.WPN_PL_NEUTRON_CANNON_FIRE;
		freighterProjectile.OverheatAudioEvent.AkEvent = GcAudioWwiseEvents.AkEventEnum.INVALID_EVENT;
		freighterProjectile.Scale = 33;
		freighterProjectile.Radius = 65;
		freighterProjectile.DefaultSpeed = 1850;
		freighterProjectile.Life = 14;
		freighterProjectile.DefaultDamage = 200;
		freighterProjectile.PlayerDamage = "FREIGHTERGUN";

		freighterProjectile.CustomBulletData.BulletLength = 20;
		freighterProjectile.CustomBulletData.BulletGlowWidthTime = 0.35f;
		freighterProjectile.CustomBulletData.BulletGlowWidthMax = 8;
		freighterProjectile.CustomBulletData.BulletGlowWidthMin = 32;
		freighterProjectile.CustomBulletData.BulletScaler = 4;

		freighterProjectile.UseCustomBulletData = true;
		freighterProjectile.Colour.R = 0.15f;
		freighterProjectile.Colour.G = 0.962f;
		freighterProjectile.Colour.B = 0.335f;

		freighterProjectile.Class = GcProjectileData.ClassEnum.Ship;

		mbin.Table.Add(freighterProjectile);

		var aiFreighterGun = mbin.Lasers.Find(PROJECTILE => PROJECTILE.Id == "AI_FREIGHTER");
		aiFreighterGun.Width = 1300;
		aiFreighterGun.HitWidth = 85;
		aiFreighterGun.PulseFrequency = 32;
		aiFreighterGun.PulseAmplitude = 0.8f;
		aiFreighterGun.DefaultDamage = 150;
		aiFreighterGun.HitRate = 0.06f;
		aiFreighterGun.HasLight = true;
		aiFreighterGun.LightIntensity = 2;

		aiFreighterGun.LightColour.R = 0.597f;
		aiFreighterGun.LightColour.G = 0.325f;
		aiFreighterGun.LightColour.B = 0.951f;

		aiFreighterGun.Colour.R = 0.597f;
		aiFreighterGun.Colour.G = 0.325f;

		var basturretL = mbin.Lasers.Find(PROJECTILE => PROJECTILE.Id == "BASE_TURRET_L");
		basturretL.LightColour.R = 0.051f;
		basturretL.LightColour.B = 1;
	}

	protected void EditTurretEntity()
	{
		var mbin = ExtractMbin<TkAttachmentData>("MODELS/COMMON/SPACECRAFT/INDUSTRIAL/TURRET/TURRETA/ENTITIES/TURRET.ENTITY.MBIN");

		var turrentComponentData = mbin.Components.FindFirst<GcTurretComponentData>();
		turrentComponentData.ProjectileId = "FREIGHTPLASMAGUN";
		turrentComponentData.TurretRange = 17000;
		turrentComponentData.TurretLaserShootTime = 2;
		turrentComponentData.TurretLaserLength = 200;
		turrentComponentData.TurretLaserMoveSpeed = 20;
		turrentComponentData.TurretLaserActiveTime = 5;
		turrentComponentData.TurretLaserAbortDistance = 18000;
		turrentComponentData.TurretShootPauseTime = 1.5f;
		turrentComponentData.TurretBurstCount = 27;
		turrentComponentData.TurretBurstTime = 0.05f;
		turrentComponentData.TurretMissileLaunchSpeed = 300;
		turrentComponentData.TurretProjectileRange = 17000;
		turrentComponentData.TurretMissileRange = 8000;
		turrentComponentData.TurretDispersionAngle = 0;

		var shootableComponentData = mbin.Components.FindFirst<GcShootableComponentData>();
		shootableComponentData.Health = 6000;
	}

	protected void EditAiSpaceShipGlobals()
	{
		var mbin = ExtractMbin<GcAISpaceshipGlobals>("GCAISPACESHIPGLOBALS.GLOBAL.MBIN");
		mbin.FreighterAttackDisengageDistance = 8000;
	}
}

//=============================================================================
