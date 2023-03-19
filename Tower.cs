using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Il2CppAssets.Scripts.Models.TowerSets;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles.Behaviors;
using Harmony;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;

namespace IceAndFire.tower;
public class ElementalDartMonkey : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;
    public override string BaseTower => TowerType.DartMonkey;
    public override int Cost => 650;
    public override int TopPathUpgrades => 5;
    public override int MiddlePathUpgrades => 0;
    public override int BottomPathUpgrades => 5;
    public override string Description => "The Engineer Monkeys Sentry";
    public override string Icon => VanillaSprites.DartMonkeyIcon;

    public override string Portrait => VanillaSprites.DartMonkeyIcon;

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {

    }
}
public class FrozenTouch : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => TOP;
    public override int Tier => 1;
    public override int Cost => 250;


    public override string Description => "Darts now freeze bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        //FreezeModel freeze = new("Freeze", 0f, 2f, "Freeze_FrozenTouch", 0, "Ice",)
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = (Il2Cpp.BloonProperties)5;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage = 1f;
        var ice = Game.instance.model.GetTower(TowerType.IceMonkey).GetDescendants<FreezeModel>().First().Duplicate();
        towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(ice);
        towerModel.GetAttackModel().weapons[0].projectile.collisionPasses = new[] { -1, 0 };
    }
}
public class QuickFreeze : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => TOP;
    public override int Tier => 2;
    public override int Cost => 400;


    public override string Description => "Faster firing makes freezing multiple bloons a breeze";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        //FreezeModel freeze = new("Freeze", 0f, 2f, "Freeze_FrozenTouch", 0, "Ice",)
        towerModel.GetAttackModel().weapons[0].rate *= .7f;
    }
}
public class FreezeDarts : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => TOP;
    public override int Tier => 3;
    public override int Cost => 1400;


    public override string Description => "Frozen darts travel in slow motion and have much more pierce making it easy to hit groups of bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<TravelStraitModel>().speed *= .2f;
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<TravelStraitModel>().lifespan *= 7f;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 1;
        towerModel.GetAttackModel().weapons[0].projectile.pierce *= 3f;
        towerModel.GetAttackModel().weapons[0].rate *= .5f;
        towerModel.GetAttackModel().range *= 1.3f;
        towerModel.range *= 1.3f;
    }
}
public class BelowZero : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => TOP;
    public override int Tier => 4;
    public override int Cost => 3400;


    public override string Description => "Darts now affect leads and moabs, damage is also increased";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().canFreezeMoabs = true;
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().damageModel.immuneBloonProperties = (Il2Cpp.BloonProperties)4;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = (Il2Cpp.BloonProperties)4;
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().damage += 2;
        towerModel.GetAttackModel().weapons[0].projectile.pierce *= 2f;
    }
}
public class ArcticIce : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => TOP;
    public override int Tier => 5;
    public override int Cost => 18000;


    public override string Description => "Bloons are frozen for much longer and damage to moab bloons is 15x";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<FreezeModel>().lifespan *= 3;
        towerModel.GetAttackModel().weapons[0].projectile.pierce *= 2f;
        towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new DamageModifierForTagModel("5xDamage to moabs", "Moabs", 5, 60, false, true));

        towerModel.displayScale = 1.2f;
    }
}
public class FlamingDarts : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => BOTTOM;
    public override int Tier => 1;
    public override int Cost => 250;


    public override string Description => "Darts set bloons on fire";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var Fire = Game.instance.model.GetTower(TowerType.MortarMonkey, 0, 0, 2).GetAttackModel().weapons[0].projectile.GetBehavior<CreateProjectileOnExhaustFractionModel>().projectile.GetBehavior<AddBehaviorToBloonModel>();
        towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(Fire);
        towerModel.GetAttackModel().weapons[0].projectile.collisionPasses = new[] { -1, 0 };
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = Il2Cpp.BloonProperties.Purple;
    }
}
public class PurplePopping : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => BOTTOM;
    public override int Tier => 2;
    public override int Cost => 500;


    public override string Description => "Fire darts can pop purple bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = 0;
        towerModel.GetAttackModel().weapons[0].projectile.pierce += 1;
    }
}
public class FireyExplosions : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => BOTTOM;
    public override int Tier => 3;
    public override int Cost => 5000;


    public override string Description => "Fire darts can pop purple bloons";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var RingOfFire = Game.instance.model.GetTower(TowerType.TackShooter, 4, 0, 2).GetAttackModel().weapons[0].Duplicate();
        RingOfFire.projectile.pierce += 2;
        RingOfFire.projectile.AddBehavior(new CreateEffectOnContactModel("FireExplosion", RingOfFire.GetBehavior<EjectEffectModel>().effectModel));
        towerModel.GetAttackModel().weapons[0].projectile.AddBehavior(new CreateProjectileOnContactModel("FireExplosions", RingOfFire.projectile, RingOfFire.emission, true, false, true));
        towerModel.GetAttackModel().range += 10;
        towerModel.range += 10;
    }
}
public class FlamingSpeed : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => BOTTOM;
    public override int Tier => 4;
    public override int Cost => 2000;


    public override string Description => "Fire burns alot faster, attack speed is also increased";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate *= 0.4f;
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().interval *= .2f;
    }
}
public class HighlyFlamable : ModUpgrade<ElementalDartMonkey>
{
    public override string Portrait => VanillaSprites.SentryPortrait;
    public override int Path => BOTTOM;
    public override int Tier => 5;
    public override int Cost => 43000;


    public override string Description => "Fire destroys bloons almost instantly";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        towerModel.GetAttackModel().weapons[0].rate *= 0.7f;
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().interval *= .001f;
        towerModel.GetAttackModel().weapons[0].projectile.GetBehavior<AddBehaviorToBloonModel>().GetBehavior<DamageOverTimeModel>().damage *= 10f;
        towerModel.displayScale = 1.2f;
    }
}

