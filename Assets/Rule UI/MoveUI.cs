using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveUI : MonoBehaviour {

    GameManager instance;

    public GameObject[] UIObjects;

    public bool Fly { get; set; }
    public bool MinimumMove { get; set; }
    public bool Reserves { get; set; }
    public bool ReserveMarker { get; set; }
    public bool DeepStrike { get; set; }
    public int DeepStrikeDistance { get; set; }
    public bool DeepStrikeDamage { get; set; }
    public int DeepStrikeDamageDistance { get; set; }
    public int DeepStrikeDamageOf1 { get; set; }
    public int DeepStrikeDamageOn1 { get; set; }
    public int DeepStrikeDamageOf2 { get; set; }
    public int DeepStrikeDamageOn2 { get; set; }
    public int DeepStrikeDamageOf3 { get; set; }
    public int DeepStrikeDamageOn3 { get; set; }
    public bool DeepStrikeDamageNoCharge { get; set; }
    public bool Transport { get; set; }
    public bool AdvanceAndCharge { get; set; }
    public bool CanMoveInShooting { get; set; }
    public bool CanAdvanceInShooting { get; set; }
    public bool MultipleDiceOnAdvance { get; set; }
    public int NumberOfAdvanceDice { get; set; }
    public bool HasSpecialFallbackRules { get; set; }
    public int FallbackRulesCondition { get; set; }
    public bool Redeploys { get; set; }
    public bool DoublesAdvanceRoll { get; set; }
    public bool Titanic { get; set; }
    public bool BonusToAdvanceRoll { get; set; }
    public int AdvanceBonus { get; set; }
    public bool FlyOver { get; set; }
    public int FlyOverDamage { get; set; }
    public int FlyOverRoll { get; set; }
    public bool FlyOverSpawn { get; set; }
    public int FlyOverModel { get; set; }
    public bool Overdrive { get; set; }
    public int OverdriveDamage { get; set; }
    public int OverdriveRoll { get; set; }
    public bool OverdriveEach { get; set; }
    public bool OverdriveAdvance { get; set; }
    public bool OverdriveShoot { get; set; }
    public bool OverdriveCharge { get; set; }

    // Use this for initialization
 //   void Start () {
 //       instance = GameManager.instance;
 //       if (instance.MovementRulesSet) {
 //           Debug.Log("Move UI being reset.");
 //           if (instance.Fly) {
 //               UIObjects[0].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.MinimumMove) {
 //               UIObjects[1].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.Reserves) {
 //               UIObjects[2].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.ReserveMarker) {
 //               UIObjects[3].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.DeepStrike) {
 //               UIObjects[4].GetComponent<Toggle>().isOn = true;
 //           }

 //           switch (instance.DeepStrikeDistance) {
 //               case 1:
 //                   UIObjects[5].GetComponent<Dropdown>().value = 1;
 //                   break;
 //               case 6:
 //                   UIObjects[5].GetComponent<Dropdown>().value = 2;
 //                   break;
 //               case 9:
 //                   UIObjects[5].GetComponent<Dropdown>().value = 3;
 //                   break;
 //               case 12:
 //                   UIObjects[5].GetComponent<Dropdown>().value = 4;
 //                   break;
 //               default:
 //                   UIObjects[5].GetComponent<Dropdown>().value = 0;
 //                   break;
 //           }

 //           UIObjects[31].GetComponent<Toggle>().isOn = instance.DeepStrikeDamage;
 //           UIObjects[32].GetComponent<Dropdown>().value = instance.DeepStrikeDamageDistance;

 //           if (instance.DeepStrikeDamageOf1 < 30) {
 //               UIObjects[33].GetComponent<Dropdown>().value = instance.DeepStrikeDamageOf1;
 //           } else if (instance.DeepStrikeDamageOf1 == 30) {
 //               UIObjects[33].GetComponent<Dropdown>().value = 4;
 //           }

 //           UIObjects[34].GetComponent<Dropdown>().value = instance.DeepStrikeDamageOn1;

 //           if (instance.DeepStrikeDamageOf2 < 30) {
 //               UIObjects[35].GetComponent<Dropdown>().value = instance.DeepStrikeDamageOf2;
 //           } else if (instance.DeepStrikeDamageOf2 == 30) {
 //               UIObjects[35].GetComponent<Dropdown>().value = 4;
 //           } 

 //           UIObjects[36].GetComponent<Dropdown>().value = instance.DeepStrikeDamageOn2;

 //           if (instance.DeepStrikeDamageOf3 < 30) {
 //               UIObjects[37].GetComponent<Dropdown>().value = instance.DeepStrikeDamageOf3;
 //           } else if (instance.DeepStrikeDamageOf3 == 30) {
 //               UIObjects[37].GetComponent<Dropdown>().value = 4;
 //           }

 //           UIObjects[38].GetComponent<Dropdown>().value = instance.DeepStrikeDamageOn3;
 //           UIObjects[39].GetComponent<Toggle>().isOn = instance.DeepStrikeDamageNoCharge;


 //           if (instance.Transport) {
 //               UIObjects[6].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.AdvanceAndCharge) {
 //               UIObjects[7].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.CanMoveInShooting) {
 //               UIObjects[8].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.CanAdvanceInShooting) {
 //               UIObjects[9].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.MultipleDiceOnAdvance) {
 //               UIObjects[10].GetComponent<Toggle>().isOn = true;
 //           }

 //           switch (instance.NumberOfAdvanceDice) {
 //               case 3:
 //                   UIObjects[11].GetComponent<Dropdown>().value = 1;
 //                   break;
 //               default:
 //                   UIObjects[11].GetComponent<Dropdown>().value = 0;
 //                   break;
 //           }

 //           if (instance.HasSpecialFallbackRules) {
 //               UIObjects[12].GetComponent<Toggle>().isOn = true;
 //           }

 //           if (instance.FallbackAndShoot && instance.FallbackAndCharge) {
 //               UIObjects[13].GetComponent<Dropdown>().value = 3;
 //           } else if (instance.FallbackAndCharge) {
 //               UIObjects[13].GetComponent<Dropdown>().value = 2;
 //           } else if (instance.FallbackAndShoot) {
 //               UIObjects[13].GetComponent<Dropdown>().value = 1;
 //           }

 //           if (instance.Redeploys) {
 //               UIObjects[14].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.DoublesAdvanceRoll) {
 //               UIObjects[15].GetComponent<Toggle>().isOn = true;
 //           }
 //           if (instance.Titanic) {
 //               UIObjects[16].GetComponent<Toggle>().isOn = true;
 //           }
 //           UIObjects[17].GetComponent<Toggle>().isOn = instance.BonusToAdvanceRoll;
 //           UIObjects[18].GetComponent<Dropdown>().value = instance.AdvanceBonus;
 //           UIObjects[19].GetComponent<Toggle>().isOn = instance.FlyOver;
            
 //           switch (instance.FlyOverDamage) {
 //               case 1:
 //                   UIObjects[20].GetComponent<Dropdown>().value = 1;
 //                   break;
 //               case 30:
 //                   UIObjects[20].GetComponent<Dropdown>().value = 2;
 //                   break;
 //               default:
 //                   UIObjects[20].GetComponent<Dropdown>().value = 0;
 //                   break;
 //           }

 //           UIObjects[21].GetComponent<Dropdown>().value = instance.FlyOverRoll;
 //           UIObjects[22].GetComponent<Toggle>().isOn = instance.FlyOverSpawn;
 //           UIObjects[23].GetComponent<Dropdown>().value = instance.FlyOverModel;
 //           UIObjects[24].GetComponent<Toggle>().isOn = instance.Overdrive;

 //           switch (instance.OverdriveDamage) {
 //               case 1:
 //                   UIObjects[25].GetComponent<Dropdown>().value = 1;
 //                   break;
 //               case 30:
 //                   UIObjects[25].GetComponent<Dropdown>().value = 2;
 //                   break;
 //               default:
 //                   UIObjects[25].GetComponent<Dropdown>().value = 0;
 //                   break;
 //           }

 //           UIObjects[26].GetComponent<Dropdown>().value = instance.OverdriveRoll;
 //           UIObjects[27].GetComponent<Toggle>().isOn = instance.OverdriveEach;
 //           UIObjects[28].GetComponent<Toggle>().isOn = instance.OverdriveAdvance;
 //           UIObjects[29].GetComponent<Toggle>().isOn = instance.OverdriveShoot;
 //           UIObjects[30].GetComponent<Toggle>().isOn = instance.OverdriveCharge;
 //       }
 //   }
	
	//// Update is called once per frame
	//void Update () {
		
	//}

 //   public void ResetProfiles () {

 //       SceneManager.LoadScene("Profile UI");
 //   }

 //   public void SetMoveRules () {

 //       bool readyToProceed = true;

 //       instance.Fly = Fly;
 //       instance.MinimumMove = MinimumMove;
 //       instance.Reserves = Reserves;
 //       instance.ReserveMarker = ReserveMarker;
 //       instance.DeepStrike = DeepStrike;
        
 //       switch (DeepStrikeDistance) {
 //           case 1:
 //               instance.DeepStrikeDistance = 1;
 //               break;
 //           case 2:
 //               instance.DeepStrikeDistance = 6;
 //               break;
 //           case 3:
 //               instance.DeepStrikeDistance = 9;
 //               break;
 //           case 4:
 //               instance.DeepStrikeDistance = 12;
 //               break;
 //           default:
 //               instance.DeepStrikeDistance = 0;
 //               break;
 //       }
        
 //       if (instance.DeepStrike && instance.DeepStrikeDistance == 0) {
 //           print("Please select a distance for the Deep Strike option.");
 //           readyToProceed = false;
 //       }

 //       instance.DeepStrikeDamage = DeepStrikeDamage;
 //       instance.DeepStrikeDamageDistance = DeepStrikeDamageDistance;

 //       if (DeepStrikeDamageOf1 < 4) {
 //           instance.DeepStrikeDamageOf1 = DeepStrikeDamageOf1;
 //       } else {
 //           instance.DeepStrikeDamageOf1 = 30;
 //       }

 //       instance.DeepStrikeDamageOn1 = DeepStrikeDamageOn1;

 //       if (DeepStrikeDamageOf2 < 4) {
 //           instance.DeepStrikeDamageOf2 = DeepStrikeDamageOf2;
 //       } else {
 //           instance.DeepStrikeDamageOf2 = 30;
 //       }

 //       instance.DeepStrikeDamageOn2 = DeepStrikeDamageOn2;

 //       if (DeepStrikeDamageOf3 < 4) {
 //           instance.DeepStrikeDamageOf3 = DeepStrikeDamageOf3;
 //       } else {
 //           instance.DeepStrikeDamageOf3 = 30;
 //       }

 //       instance.DeepStrikeDamageOn3 = DeepStrikeDamageOn3;
 //       instance.DeepStrikeDamageNoCharge = DeepStrikeDamageNoCharge;

 //       instance.Transport = Transport;
 //       instance.AdvanceAndCharge = AdvanceAndCharge;
 //       instance.CanMoveInShooting = CanMoveInShooting;
 //       instance.CanAdvanceInShooting = CanAdvanceInShooting;
 //       instance.MultipleDiceOnAdvance = MultipleDiceOnAdvance;

 //       switch (NumberOfAdvanceDice) {
 //           case 1:
 //               instance.NumberOfAdvanceDice = 3;
 //               break;
 //           default:
 //               instance.NumberOfAdvanceDice = 0;
 //               break;
 //       }

 //       if (instance.MultipleDiceOnAdvance && instance.NumberOfAdvanceDice == 0) {
 //           print("Please select the number of dice the unit rolls when advancing.");
 //           readyToProceed = false;
 //       }

 //       instance.HasSpecialFallbackRules = HasSpecialFallbackRules;

 //       switch (FallbackRulesCondition) {
 //           case 1:
 //               instance.FallbackAndShoot = true;
 //               instance.FallbackAndCharge = false;
 //               break;
 //           case 2:
 //               instance.FallbackAndShoot = false;
 //               instance.FallbackAndCharge = true;
 //               break;
 //           case 3:
 //               instance.FallbackAndShoot = true;
 //               instance.FallbackAndCharge = true;
 //               break;
 //           default:
 //               instance.FallbackAndShoot = false;
 //               instance.FallbackAndCharge = false;
 //               break;
 //       }

 //       if (instance.HasSpecialFallbackRules && ! instance.FallbackAndShoot && ! instance.FallbackAndCharge) {
 //           print("Please select the intended fallback rules for the unit.");
 //           readyToProceed = false;
 //       }

 //       instance.Redeploys = Redeploys;
 //       instance.DoublesAdvanceRoll = DoublesAdvanceRoll;
 //       instance.BonusToAdvanceRoll = BonusToAdvanceRoll;
 //       instance.AdvanceBonus = AdvanceBonus;

 //       if (instance.BonusToAdvanceRoll && instance.AdvanceBonus == 0) {
 //           print("Please select the bonus the unit receives on Advance rolls.");
 //           readyToProceed = false;
 //       }
 //       instance.FlyOver = FlyOver;

 //       switch (FlyOverDamage) {
 //           case 1:
 //               instance.FlyOverDamage = 1;
 //               break;
 //           case 2:
 //               instance.FlyOverDamage = 30;
 //               break;
 //       }

 //       instance.FlyOverRoll = FlyOverRoll;

 //       if (instance.FlyOver && (instance.FlyOverDamage == 0 || instance.FlyOverRoll == 0)) {
 //           print("Fly Over rules require that you set both the damage and the number on the dice the damage occurs on.");
 //           readyToProceed = false;
 //       }

 //       instance.FlyOverSpawn = FlyOverSpawn;
 //       instance.FlyOverModel = FlyOverModel;

 //       if (instance.FlyOverSpawn && instance.FlyOverModel == 0) {
 //           print("Please select the model spawned by the unit if it misses its Fly Over attack.");
 //           readyToProceed = false;
 //       }

 //       instance.Overdrive = Overdrive;

 //       switch (OverdriveDamage) {
 //           case 1:
 //               instance.OverdriveDamage = 1;
 //               break;
 //           case 2:
 //               instance.OverdriveDamage = 30;
 //               break;
 //       }

 //       instance.OverdriveRoll = OverdriveRoll;

 //       if (instance.Overdrive && (instance.OverdriveRoll == 0 || instance.OverdriveDamage == 0)) {
 //           print("Overdrive rules require a damage caused by overdrive on a specific roll.");
 //           readyToProceed = false;
 //       }

 //       instance.OverdriveEach = OverdriveEach;
 //       instance.OverdriveAdvance = OverdriveAdvance;
 //       instance.OverdriveShoot = OverdriveShoot;
 //       instance.OverdriveCharge = OverdriveCharge;

 //       if (readyToProceed) {
 //           SceneManager.LoadScene("Shoot UI");
 //       }
 //   }

    public void Exit() {
        instance.OnDisable();
        Application.Quit();
    }
}
