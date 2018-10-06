using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChargeUI : MonoBehaviour {

    GameManager instance;

    public GameObject[] UIObjects;

    public bool RerollCharges { get; set; }
    public bool ReserveReroll { get; set; }
    public bool BonusOnChargeRolls { get; set; }
    public int ChargeBonus { get; set; }
    public bool Ram { get; set; }
    public int RamRoll { get; set; }
    public int RamDamage { get; set; }
    public bool RamInfantry { get; set; }
    public int RamInfantryDamage { get; set; }
    public bool RamVehicle { get; set; }
    public int RamVehicleDamage { get; set; }
    public bool RamEach { get; set; }
    public bool BonusToHitOnCharge { get; set; }
    public int ChargeHitBonus { get; set; }
    public bool BonusToAttackOnCharge { get; set; }
    public int ChargeAttackBonus { get; set; }
    public bool Detonates { get; set; }
    public int DetonateDistance { get; set; }
    public int DetonateDamage { get; set; }
    public int DetonateSelection { get; set; }
    public int DetonateRoll { get; set; }
    public bool DetonateBonusDamageOnRoll { get; set; }
    public int DetonateBonusDamageRoll { get; set; }
    public int DetonateBonusDamage { get; set; }
    public bool DiesOnDetonate { get; set; }
    public bool Scream { get; set; }
    public int ScreamDistance { get; set; }
    public bool Agile { get; set; }
    public int AgileDice { get; set; }
    public bool AgileDropTheLowest { get; set; }
    public int AgileDropThisManyDice { get; set; }

	// Use this for initialization
	//void Start () {
 //       instance = GameManager.instance;

 //       if (instance.ChargeRulesSet) {

 //           UIObjects[0].GetComponent<Toggle>().isOn = instance.RerollCharges;
 //           UIObjects[1].GetComponent<Toggle>().isOn = instance.ReserveReroll;
 //           UIObjects[2].GetComponent<Toggle>().isOn = instance.BonusOnChargeRolls;
 //           UIObjects[3].GetComponent<Dropdown>().value = instance.ChargeBonus;
 //           UIObjects[4].GetComponent<Toggle>().isOn = instance.Ram;
 //           UIObjects[5].GetComponent<Dropdown>().value = instance.RamRoll;
 //           UIObjects[6].GetComponent<Dropdown>().value = instance.RamDamage;
 //           UIObjects[7].GetComponent<Toggle>().isOn = instance.RamInfantry;
 //           UIObjects[8].GetComponent<Dropdown>().value = instance.RamInfantryDamage;
 //           UIObjects[9].GetComponent<Toggle>().isOn = instance.RamVehicle;
 //           UIObjects[10].GetComponent<Dropdown>().value = instance.RamVehicleDamage;
 //           UIObjects[11].GetComponent<Toggle>().isOn = instance.BonusToHitOnCharge;
 //           UIObjects[12].GetComponent<Dropdown>().value = instance.ChargeHitBonus;
 //           UIObjects[13].GetComponent<Toggle>().isOn = instance.BonusToAttackOnCharge;
 //           UIObjects[14].GetComponent<Dropdown>().value = instance.ChargeAttackBonus;
 //           UIObjects[15].GetComponent<Toggle>().isOn = instance.Detonates;
 //           UIObjects[16].GetComponent<Dropdown>().value = instance.DetonateDistance;
 //           UIObjects[17].GetComponent<Dropdown>().value = instance.DetonateDamage;
 //           if (instance.DetonateHitsOneUnit) {
 //               UIObjects[18].GetComponent<Dropdown>().value = 1;
 //           } else if (instance.DetonateHitsAllUnits) {
 //               UIObjects[18].GetComponent<Dropdown>().value = 2;
 //           }
 //           UIObjects[19].GetComponent<Dropdown>().value = instance.DetonateRoll;
 //           UIObjects[20].GetComponent<Toggle>().isOn = instance.DetonateBonusDamageOnRoll;
 //           UIObjects[21].GetComponent<Dropdown>().value = instance.DetonateBonusDamage;
 //           UIObjects[22].GetComponent<Dropdown>().value = instance.DetonateBonusDamageRoll;
 //           UIObjects[23].GetComponent<Toggle>().isOn = instance.DiesOnDetonate;
 //           UIObjects[24].GetComponent<Toggle>().isOn = instance.Scream;
 //           UIObjects[25].GetComponent<Dropdown>().value = instance.ScreamDistance;
 //           UIObjects[26].GetComponent<Toggle>().isOn = instance.Agile;
 //           UIObjects[27].GetComponent<Dropdown>().value = instance.AgileDice;
 //           UIObjects[28].GetComponent<Toggle>().isOn = instance.AgileDropTheLowest;
 //           UIObjects[29].GetComponent<Dropdown>().value = instance.AgileDropThisManyDice;
 //           UIObjects[30].GetComponent<Toggle>().isOn = instance.RamEach;
 //       }
 //   }
	
	//// Update is called once per frame
	//void Update () {
		
	//}

 //   public void SetChargeRules () {
 //       bool readyToProceed = true;

 //       instance.RerollCharges = RerollCharges;
 //       instance.ReserveReroll = ReserveReroll;
 //       instance.BonusOnChargeRolls = BonusOnChargeRolls;
 //       instance.ChargeBonus = ChargeBonus;

 //       if (instance.BonusOnChargeRolls && instance.ChargeBonus == 0) {
 //           print("Please select a bonus on charge rolls.");
 //           readyToProceed = false;
 //       }

 //       instance.Ram = Ram;
 //       instance.RamRoll = RamRoll;

 //       switch (RamDamage) {
 //           case 1:
 //               instance.RamDamage = 1;
 //               break;
 //           case 2:
 //               instance.RamDamage = 30;
 //               break;
 //           default:
 //               instance.RamDamage = 0;
 //               break;
 //       }

 //       if (instance.Ram && (instance.RamRoll == 0 || instance.RamDamage == 0)) {
 //           print("Ram rules require both a roll and damage to be selected.");
 //           readyToProceed = false;
 //       }

 //       instance.RamInfantry = RamInfantry;

 //       switch (RamInfantryDamage) {
 //           case 1:
 //               instance.RamInfantryDamage = 1;
 //               break;
 //           case 2:
 //               instance.RamInfantryDamage = 30;
 //               break;
 //           default:
 //               instance.RamInfantryDamage = 0;
 //               break;
 //       }

 //       if (instance.RamInfantry && instance.RamInfantryDamage == 0) {
 //           print("Select the damage the unit does against infantry.");
 //           readyToProceed = false;
 //       }

 //       instance.RamVehicle = RamVehicle;
 //       instance.RamVehicleDamage = RamVehicleDamage;

 //       switch (RamVehicleDamage) {
 //           case 1:
 //               instance.RamVehicleDamage = 1;
 //               break;
 //           case 2:
 //               instance.RamVehicleDamage = 30;
 //               break;
 //           default:
 //               instance.RamVehicleDamage = 0;
 //               break;
 //       }

 //       if (instance.RamVehicle && instance.RamVehicleDamage == 0) {
 //           print("Select the damage the unit does against vehicles.");
 //           readyToProceed = false;
 //       }

 //       instance.RamEach = RamEach;
 //       instance.BonusToHitOnCharge = BonusToHitOnCharge;
 //       instance.ChargeHitBonus = ChargeHitBonus;

 //       if (instance.BonusToHitOnCharge && instance.ChargeHitBonus == 0) {
 //           print("Select the hit bonus.");
 //           readyToProceed = false;
 //       }

 //       instance.BonusToAttackOnCharge = BonusToHitOnCharge;
 //       instance.ChargeAttackBonus = ChargeAttackBonus;

 //       if (instance.BonusToHitOnCharge && instance.ChargeAttackBonus == 0) {
 //           print("Slect the attack bonus.");
 //           readyToProceed = false;
 //       }

 //       instance.Detonates = Detonates;
 //       instance.DetonateDistance = DetonateDistance;

 //       switch (DetonateDamage) {
 //           case 1:
 //               instance.DetonateDamage = 1;
 //               break;
 //           case 2:
 //               instance.DetonateDamage = 30;
 //               break;
 //           default:
 //               instance.DetonateDamage = 0;
 //               break;
 //       }

 //       switch (DetonateSelection) {
 //           case 1:
 //               instance.DetonateHitsOneUnit = true;
 //               instance.DetonateHitsAllUnits = false;
 //               break;
 //           case 2:
 //               instance.DetonateHitsOneUnit = false;
 //               instance.DetonateHitsAllUnits = true;
 //               break;
 //           default:
 //               instance.DetonateHitsOneUnit = false;
 //               instance.DetonateHitsAllUnits = false;
 //               break;
 //       }

 //       instance.DetonateRoll = DetonateRoll;

 //       if (instance.Detonates && (instance.DetonateDistance == 0 || instance.DetonateRoll == 0 || ( ! instance.DetonateHitsOneUnit && ! instance.DetonateHitsAllUnits))) {
 //           print("Detonate rules require a range, roll, damage, and number of units affected.");
 //           readyToProceed = false;
 //       }

 //       instance.DetonateBonusDamageOnRoll = DetonateBonusDamageOnRoll;
 //       instance.DetonateBonusDamageRoll = DetonateBonusDamageRoll;

 //       switch (DetonateBonusDamage) {
 //           case 1:
 //               instance.DetonateBonusDamage = 1;
 //               break;
 //           case 2:
 //               instance.DetonateBonusDamage = 30;
 //               break;
 //           default:
 //               instance.DetonateBonusDamage = 0;
 //               break;
 //       }

 //       if (instance.DetonateBonusDamageOnRoll && (instance.DetonateBonusDamageRoll == 0 || instance.DetonateBonusDamage == 0)) {
 //           print("Please select the bonus damage and roll for bonus damage.");
 //           readyToProceed = false;
 //       }

 //       instance.DiesOnDetonate = DiesOnDetonate;
 //       instance.Scream = Scream;
 //       instance.ScreamDistance = ScreamDistance;

 //       if (instance.Scream && instance.ScreamDistance == 0) {
 //           print("Please select the range for the scream rule.");
 //           readyToProceed = false;
 //       }

 //       instance.Agile = Agile;
 //       instance.AgileDice = AgileDice;

 //       if (instance.Agile && instance.AgileDice == 0) {
 //           print("Please select the number of dice the unit rolls for charges.");
 //           readyToProceed = false;
 //       }

 //       instance.AgileDropTheLowest = AgileDropTheLowest;
 //       instance.AgileDropThisManyDice = AgileDropThisManyDice;

 //       if (instance.AgileDropTheLowest && instance.AgileDropThisManyDice == 0) {
 //           print("Please select the number of dice the unit drops from their charges.");
 //           readyToProceed = false;
 //       }

 //       if (readyToProceed) {
 //           SceneManager.LoadScene("Fight UI");
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
