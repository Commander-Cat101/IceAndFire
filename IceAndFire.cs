using MelonLoader;
using BTD_Mod_Helper;
using IceAndFire;
using Il2CppAssets.Scripts.Simulation.Towers;
using BTD_Mod_Helper.Api.Enums;
using BTD_Mod_Helper.Api.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using IceAndFire.tower;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Unity.UI_New.InGame;
using UnityEngine;
using BTD_Mod_Helper.Api.Components;

[assembly: MelonInfo(typeof(IceAndFire.IceAndFire), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace IceAndFire;

public class IceAndFire : BloonsTD6Mod
{
    public GameObject upgrade;
    public GameObject upgrade1;
    public GameObject upgrade2;
    public override void OnApplicationStart()
    {
        ModHelper.Msg<IceAndFire>("IceAndFire loaded!");
    }
    public override void OnMatchStart()
    {
        base.OnMatchEnd();
        upgrade = GameObject.Find("UpgradeObject_1");
        upgrade1 = GameObject.Find("UpgradeObject_2");
        upgrade2 = GameObject.Find("UpgradeObject_3");
    }
    public override void OnTowerSelected(Tower tower)
    {
        if (!upgrade.GetComponent<MatchLocalPosition>())
        {
            upgrade.AddComponent<MatchLocalPosition>();
            upgrade.GetComponent<MatchLocalPosition>().transformToCopy = upgrade1.transform;
        }
        if (!upgrade2.GetComponent<MatchLocalPosition>())
        {
            upgrade2.AddComponent<MatchLocalPosition>();
            upgrade2.GetComponent<MatchLocalPosition>().transformToCopy = upgrade1.transform;
        }

        if (tower.towerModel.baseId.Contains("Elemental"))
        {
            upgrade.GetComponent<MatchLocalPosition>().offset = new Vector3(0, 275, 0);
            upgrade2.GetComponent<MatchLocalPosition>().offset = new Vector3(0, -275, 0);

            upgrade1.active = false;

            upgrade2.transform.localPosition = new(0, -230, 0);
            upgrade2.transform.GetChild(1).localScale = new(1.2f, 1.2f, 1.2f);
            upgrade2.transform.GetChild(0).localScale = new(0.9f, .9f, .9f);
            upgrade2.transform.GetChild(0).transform.GetChild(0).transform.localScale = new(1.2f, 1.2f, 1.1f);
            upgrade2.transform.GetChild(0).transform.GetChild(4).transform.localPosition = new(-55, 25, 0);
            upgrade2.transform.GetChild(0).transform.GetChild(0).transform.localPosition = new(-16, 9, 0);

            upgrade2.transform.GetChild(0).transform.GetChild(1).localPosition = new(-22.9819f, 12, 0);
            upgrade2.transform.GetChild(0).transform.GetChild(2).localPosition = new(-25, -136, 0);
            upgrade2.transform.GetChild(0).transform.GetChild(3).localPosition = new(-30, 136, 0);

            upgrade.transform.localPosition = new(0, 230, 0);
            upgrade.transform.GetChild(1).localScale = new(1.2f, 1.2f, 1.2f);
            upgrade.transform.GetChild(0).localScale = new(0.9f, .9f, .9f);
            upgrade.transform.GetChild(0).transform.GetChild(0).transform.localScale = new(1.2f, 1.2f, 1.1f);
            upgrade.transform.GetChild(0).transform.GetChild(4).transform.localPosition = new(-55, 25, 0);
            upgrade.transform.GetChild(0).transform.GetChild(0).transform.localPosition = new(-16, 9, 0);


            upgrade.transform.GetChild(0).transform.GetChild(1).localPosition = new(-22.9819f, 12, 0);
            upgrade.transform.GetChild(0).transform.GetChild(2).localPosition = new(-25, -136, 0);
            upgrade.transform.GetChild(0).transform.GetChild(3).localPosition = new(-30, 136, 0);

        }
        else
        {
            upgrade.GetComponent<MatchLocalPosition>().offset = new Vector3(0, 350, 0);
            upgrade2.GetComponent<MatchLocalPosition>().offset = new Vector3(0, -350, 0);

            upgrade1.active = true;
            upgrade2.transform.localPosition = new(0.0002f, -372, 0);
            upgrade2.transform.GetChild(1).localScale = new(1, 1, 1);
            upgrade2.transform.GetChild(0).localScale = new(1, 1, 1);
            upgrade2.transform.GetChild(0).transform.GetChild(0).transform.localScale = new(1, 1, 1);
            upgrade2.transform.GetChild(0).transform.GetChild(4).transform.localPosition = new(-25, 25, 0);
            upgrade2.transform.GetChild(0).transform.GetChild(0).transform.localPosition = new(-30, 9, 0);
            upgrade2.transform.GetChild(0).transform.GetChild(1).localPosition = new(0, 12, 0);
            upgrade2.transform.GetChild(0).transform.GetChild(2).localPosition = new(0, -136, 0);
            upgrade2.transform.GetChild(0).transform.GetChild(3).localPosition = new(0, 136, 0);

            upgrade.transform.localPosition = new(0, 348, 0);
            upgrade.transform.GetChild(1).localScale = new(1, 1, 1);
            upgrade.transform.GetChild(0).localScale = new(1, 1, 1);
            upgrade.transform.GetChild(0).transform.GetChild(0).transform.localScale = new(1, 1, 1);
            upgrade.transform.GetChild(0).transform.GetChild(4).transform.localPosition = new(-25, 25, 0);
            upgrade.transform.GetChild(0).transform.GetChild(0).transform.localPosition = new(-30, 9, 0);

            upgrade.transform.GetChild(0).transform.GetChild(1).localPosition = new(0, 12, 0);
            upgrade.transform.GetChild(0).transform.GetChild(2).localPosition = new(0, -136, 0);
            upgrade.transform.GetChild(0).transform.GetChild(3).localPosition = new(0, 136, 0);
        }

    }
}