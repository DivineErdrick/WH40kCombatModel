using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FightUI : MonoBehaviour {

    GameManager instance;
    public GameObject[] UIObjects;

    public bool FightBonusToHit { set; get; }
    public int FightHitBonus { set; get; }
    public bool FightRerollHits { set; get; }
    public int FightRerollHitsOn { set; get; }
    public bool FightRerollMisses { set; get; }
    public bool FightBonusToWound { set; get; }
    public int FightWoundBonus { set; get; }
    public bool FightRerollWounds { set; get; }
    public int FightRerollWoundsOn { set; get; }
    public bool FightRerollFailedWounds { set; get; }
    public bool FightOpponentsHitAt { set; get; }
    public int FightHitPenalty { set; get; }
    public bool FightOpponentsWoundAt { set; get; }
    public int FightWoundPenalty { set; get; }
    public bool FightNoHitPenalty { set; get; }
    public bool FightNoWoundPenalty { set; get; }
    public bool Miasma { set; get; }
    public int MiasmaSelection { set; get; }
    public int MiasmaRange { set; get; }
    public int MiasmaDamage { set; get; }
    public int MiasmaRollOn { set; get; }
    public bool AcidBlood { set; get; }
    public int AcidBloodRoll { set; get; }
    public bool AcidBloodOnLast { set; get; }
    public int AcidBloodDamage { set; get; }
    public bool FightsFirst { set; get; }
    public bool OpponentFightsLast { set; get; }
    public bool Implant { set; get; }
    public int ImplantDamage { set; get; }
    public int ImplantRoll { set; get; }
    public bool FightsTwice { set; get; }
    public bool FightExtraDamage { set; get; }
    public int FightExtraDamageOf { set; get; }
    public int FightExtraDamageOn { set; get; }
    public bool MoveAtEndOfFight { set; get; }
    public bool AdvanceAtEndOfFight { set; get; }
    public bool MoveAtEndIfSlays { set; get; }

	//// Use this for initialization
	//void Start () {
 //       instance = GameManager.instance;

 //       if (instance.FightRulesSet) {
 //           UIObjects[0].GetComponent<Toggle>().isOn = instance.FightBonusToHit;
 //           UIObjects[1].GetComponent<Dropdown>().value = instance.FightHitBonus;
 //           UIObjects[2].GetComponent<Toggle>().isOn = instance.FightRerollHits;
 //           UIObjects[3].GetComponent<Dropdown>().value = instance.FightRerollHitsOn;
 //           UIObjects[4].GetComponent<Toggle>().isOn = instance.FightRerollMisses;
 //           UIObjects[5].GetComponent<Toggle>().isOn = instance.FightBonusToWound;
 //           UIObjects[6].GetComponent<Dropdown>().value = instance.FightWoundBonus;
 //           UIObjects[7].GetComponent<Toggle>().isOn = instance.FightRerollWounds;
 //           UIObjects[8].GetComponent<Dropdown>().value = instance.FightRerollWoundsOn;
 //           UIObjects[9].GetComponent<Toggle>().isOn = instance.FightRerollFailedWounds;
 //           UIObjects[10].GetComponent<Toggle>().isOn = instance.FightOpponentsHitAt;
 //           UIObjects[11].GetComponent<Dropdown>().value = instance.FightHitPenalty;
 //           UIObjects[12].GetComponent<Toggle>().isOn = instance.FightOpponentsWoundAt;
 //           UIObjects[13].GetComponent<Dropdown>().value = instance.FightWoundPenalty;
 //           UIObjects[14].GetComponent<Toggle>().isOn = instance.FightNoHitPenalty;
 //           UIObjects[15].GetComponent<Toggle>().isOn = instance.FightNoWoundPenalty;
 //           UIObjects[16].GetComponent<Toggle>().isOn = instance.Miasma;

 //           if (instance.MiasmaForOneUnit) {
 //               UIObjects[17].GetComponent<Dropdown>().value = 1;
 //           } else if (instance.MiasmaForEachUnit) {
 //               UIObjects[17].GetComponent<Dropdown>().value = 2;
 //           }

 //           UIObjects[18].GetComponent<Dropdown>().value = instance.MiasmaRange;

 //           switch (instance.MiasmaDamage) {
 //               case 1:
 //                   UIObjects[19].GetComponent<Dropdown>().value = 1;
 //                   break;
 //               case 30:
 //                   UIObjects[19].GetComponent<Dropdown>().value = 2;
 //                   break;
 //               default:
 //                   UIObjects[19].GetComponent<Dropdown>().value = 0;
 //                   break;
 //           }

 //           UIObjects[20].GetComponent<Dropdown>().value = instance.MiasmaRollOn;
 //           UIObjects[21].GetComponent<Toggle>().isOn = instance.AcidBlood;
 //           UIObjects[22].GetComponent<Dropdown>().value = instance.AcidBloodRoll;
 //           UIObjects[23].GetComponent<Toggle>().isOn = instance.AcidBloodOnLast;

 //           switch (instance.AcidBloodDamage) {
 //               case 1:
 //                   UIObjects[24].GetComponent<Dropdown>().value = 1;
 //                   break;
 //               case 30:
 //                   UIObjects[24].GetComponent<Dropdown>().value = 2;
 //                   break;
 //               default:
 //                   UIObjects[24].GetComponent<Dropdown>().value = 0;
 //                   break;
 //           }

 //           UIObjects[25].GetComponent<Toggle>().isOn = instance.FightsFirst;
 //           UIObjects[26].GetComponent<Toggle>().isOn = instance.OpponentFightsLast;
 //           UIObjects[27].GetComponent<Toggle>().isOn = instance.Implant;

 //           switch (instance.ImplantDamage) {
 //               case 1:
 //                   UIObjects[28].GetComponent<Dropdown>().value = 1;
 //                   break;
 //               case 30:
 //                   UIObjects[28].GetComponent<Dropdown>().value = 2;
 //                   break;
 //               default:
 //                   UIObjects[28].GetComponent<Dropdown>().value = 0;
 //                   break;
 //           }

 //           UIObjects[29].GetComponent<Dropdown>().value = instance.ImplantRoll;
 //           UIObjects[30].GetComponent<Toggle>().isOn = instance.FightsTwice;
 //           UIObjects[31].GetComponent<Toggle>().isOn = instance.FightExtraDamage;

 //           switch (instance.FightExtraDamageOf) {
 //               case 1:
 //                   UIObjects[19].GetComponent<Dropdown>().value = 1;
 //                   break;
 //               case 30:
 //                   UIObjects[19].GetComponent<Dropdown>().value = 2;
 //                   break;
 //               default:
 //                   UIObjects[19].GetComponent<Dropdown>().value = 0;
 //                   break;
 //           }

 //           UIObjects[33].GetComponent<Dropdown>().value = instance.FightExtraDamageOn;
 //           UIObjects[34].GetComponent<Toggle>().isOn = instance.MoveAtEndOfFight;
 //           UIObjects[35].GetComponent<Toggle>().isOn = instance.AdvanceAtEndOfFight;
 //           UIObjects[36].GetComponent<Toggle>().isOn = instance.MoveAtEndIfSlays;
 //       }
 //   }

 //   // Update is called once per frame
 //   void Update () {
		
	//}

 //   public void SetFightRules () {
 //       bool readyToProceed = true;

 //       instance.FightBonusToHit = FightBonusToHit;
 //       instance.FightHitBonus= FightHitBonus;

 //       if (instance.FightBonusToHit && instance.FightHitBonus == 0) {
 //           print("Please select the unit's bonus to hit.");
 //           readyToProceed = false;
 //       }

 //       instance.FightRerollHits = FightRerollHits;
 //       instance.FightRerollHitsOn = FightRerollHitsOn;

 //       if (instance.FightRerollHits && instance.FightRerollHitsOn == 0) {
 //           print("Please select the dice the unit gets to re-roll for hit rolls.");
 //           readyToProceed = false;
 //       }

 //       instance.FightRerollMisses = FightRerollMisses;
 //       instance.FightBonusToWound = FightBonusToWound;
 //       instance.FightWoundBonus = FightWoundBonus;

 //       if (instance.FightBonusToWound && instance.FightWoundBonus == 0) {
 //           print("Please select the unit's bonus to wound.");
 //           readyToProceed = false;
 //       }

 //       instance.FightRerollWounds = FightRerollWounds;
 //       instance.FightRerollWoundsOn = FightRerollWoundsOn;

 //       if (instance.FightRerollWounds && instance.FightRerollWoundsOn == 0) {
 //           print("Please select the dice the unit gets to re-roll for wound rolls.");
 //           readyToProceed = false;
 //       }

 //       instance.FightRerollFailedWounds = FightRerollFailedWounds;
 //       instance.FightOpponentsHitAt = FightOpponentsHitAt;
 //       instance.FightHitPenalty = FightHitPenalty;

 //       if (instance.FightOpponentsHitAt && instance.FightHitPenalty == 0) {
 //           print("Please select the penalty the opponent receives when attacking the unit.");
 //           readyToProceed = false;
 //       }

 //       instance.FightOpponentsWoundAt = FightOpponentsWoundAt;
 //       instance.FightWoundPenalty = FightWoundPenalty;

 //       if (instance.FightOpponentsWoundAt && instance.FightWoundPenalty == 0) {
 //           print("Please select the penalty the opponent receives when wounding the unit.");
 //           readyToProceed = false;
 //       }

 //       instance.FightNoHitPenalty = FightNoHitPenalty;
 //       instance.FightNoWoundPenalty = FightNoWoundPenalty;
 //       instance.Miasma = Miasma;

 //       switch (MiasmaSelection) {
 //           case 1:
 //               instance.MiasmaForOneUnit = true;
 //               instance.MiasmaForEachUnit = false;
 //               break;
 //           case 2:
 //               instance.MiasmaForOneUnit = false;
 //               instance.MiasmaForEachUnit = true;
 //               break;
 //           default:
 //               instance.MiasmaForOneUnit = false;
 //               instance.MiasmaForEachUnit = false;
 //               break;
 //       }

 //       instance.MiasmaRange = MiasmaRange;

 //       switch (MiasmaDamage) {
 //           case 1:
 //               instance.MiasmaDamage = 1;
 //               break;
 //           case 2:
 //               instance.MiasmaDamage = 30;
 //               break;
 //           default:
 //               instance.MiasmaDamage = 0;
 //               break;
 //       }

 //       instance.MiasmaRollOn = MiasmaRollOn;

 //       if (instance.Miasma && (( ! instance.MiasmaForEachUnit && ! instance.MiasmaForOneUnit) || instance.MiasmaRange == 0 || instance.MiasmaDamage == 0)) {
 //           print("Miasma rule require a selection of the units affected, the range of the effect, the roll for the effect, and the damage.");
 //           readyToProceed = false;
 //       }

 //       instance.AcidBlood = AcidBlood;
 //       instance.AcidBloodRoll = AcidBloodRoll;
 //       instance.AcidBloodOnLast = AcidBloodOnLast;

 //       switch (AcidBloodDamage) {
 //           case 1:
 //               instance.AcidBloodDamage = 1;
 //               break;
 //           case 2:
 //               instance.AcidBloodDamage = 30;
 //               break;
 //           default:
 //               instance.AcidBloodDamage = 0;
 //               break;
 //       }

 //       if (instance.AcidBlood && (instance.AcidBloodDamage == 0 || instance.AcidBloodRoll == 0)) {
 //           print("Acid Blood rules require the roll units are affected on and the damage dealt.");
 //           readyToProceed = false;
 //       }

 //       instance.FightsFirst = FightsFirst;
 //       instance.OpponentFightsLast = OpponentFightsLast;
 //       instance.Implant = Implant;

 //       switch (ImplantDamage) {
 //           case 1:
 //               instance.ImplantDamage = 1;
 //               break;
 //           case 2:
 //               instance.ImplantDamage = 30;
 //               break;
 //           default:
 //               instance.ImplantDamage = 0;
 //               break;
 //       }

 //       instance.ImplantRoll = ImplantRoll;

 //       if (instance.Implant && (instance.ImplantDamage == 0 || instance.ImplantRoll == 0)) {
 //           print("Bonus wound rules require a wound amount and rolls bonus wounds are dealt on.");
 //           readyToProceed = false;
 //       }

 //       instance.FightsTwice = FightsTwice;
 //       instance.FightExtraDamage = FightExtraDamage;

 //       switch (FightExtraDamageOf) {
 //           case 1:
 //               instance.FightExtraDamageOf = 1;
 //               break;
 //           case 2:
 //               instance.FightExtraDamageOf = 30;
 //               break;
 //           default:
 //               instance.FightExtraDamageOf = 0;
 //               break;
 //       }

 //       instance.FightExtraDamageOn = FightExtraDamageOn;

 //       if (instance.FightExtraDamage && (instance.FightExtraDamageOf == 0 || instance.FightExtraDamageOn == 0)) {
 //           print("Extra damage rule require a roll that grants extra damage and an amount of extra damage.");
 //           readyToProceed = false;
 //       }

 //       instance.MoveAtEndOfFight = MoveAtEndOfFight;
 //       instance.AdvanceAtEndOfFight = AdvanceAtEndOfFight;
 //       instance.MoveAtEndIfSlays = MoveAtEndIfSlays;

 //       if (readyToProceed) {

 //       }
 //   }

    public void ResetProfiles() {

        SceneManager.LoadScene("Profile UI");
    }

    public void Back() {

        SceneManager.LoadScene("Shoot UI");
    }

    public void Exit() {
        instance.OnDisable();
        Application.Quit();
    }
}
