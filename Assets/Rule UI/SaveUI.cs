using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUI : MonoBehaviour {

    GameManager instance;
    public GameObject[] UIObjects;

    public bool RerollSaves { get; set; }
    public int RerollSavesOf { get; set; }
    public bool RerollFailedSaves { get; set; }
    public bool Invuln { get; set; }
    public int InvulnRoll { get; set; }
    public bool RerollInvulns { get; set; }
    public int RerollInvulnsOf { get; set; }
    public bool RerollFailedInvulns { get; set; }
    public bool ShootingSave { get; set; }
    public int ShootingSaveAt { get; set; }
    public bool MeleeSave { get; set; }
    public int MeleeSaveAt { get; set; }
    public bool ShootingInvuln { get; set; }
    public int ShootingInvulnAt { get; set; }
    public bool MeleeInvuln { get; set; }
    public int MeleeInvulnAt { get; set; }
    public bool CoverSave { get; set; }
    public int CoverSaveBonus { get; set; }
    public bool ReduceDamage { get; set; }
    public int ReduceDamageBy { get; set; }
    public bool ReduceDamageTaken { get; set; }
    public int ReduceDamageTakenTo { get; set; }
    public bool ReduceDamageTakenTo1 { get; set; }
    public bool FeelNoPain { get; set; }
    public int FeelNoPainOf { get; set; }
    public bool Regenerate { get; set; }
    public int RegenerateAmount { get; set; }
    public int RegenerateRoll { get; set; }
    public int RegenerateDuring { get; set; }
    public bool Explodes { get; set; }
    public int ExplodesRoll { get; set; }
    public int ExplodesRange { get; set; }
    public int ExplodesDamage { get; set; }
    public bool MoraleBonus { get; set; }
    public int MoraleBonusOf { get; set; }
    public bool RerollMorales { get; set; }
    public int RerollMoralesOf { get; set; }
    public bool RerollAnyMorale { get; set; }
    public bool PassMorale { get; set; }
    public bool Terror { get; set; }
    public int TerrorRange { get; set; }
    public int TerrorPenalty { get; set; }
    public bool TerrorAlternate { get; set; }

	// Use this for initialization
	//void Start () {

 //       instance = GameManager.instance;
        
 //       if (instance.SaveRulesSet) {

 //           UIObjects[0].GetComponent<Toggle>().isOn = instance.RerollSaves;
 //           UIObjects[1].GetComponent<Dropdown>().value = instance.RerollSavesOf;
 //           UIObjects[2].GetComponent<Toggle>().isOn = instance.RerollFailedSaves;
 //           UIObjects[3].GetComponent<Toggle>().isOn = instance.Invuln;
 //           UIObjects[4].GetComponent<Dropdown>().value = instance.InvulnRoll;
 //           UIObjects[5].GetComponent<Toggle>().isOn = instance.RerollInvulns;
 //           UIObjects[6].GetComponent<Dropdown>().value = instance.RerollInvulnsOf;
 //           UIObjects[7].GetComponent<Toggle>().isOn = instance.RerollFailedInvulns;
 //           UIObjects[8].GetComponent<Toggle>().isOn = instance.ShootingSave;
 //           UIObjects[9].GetComponent<Dropdown>().value = instance.ShootingSaveAt;
 //           UIObjects[10].GetComponent<Toggle>().isOn = instance.MeleeSave;
 //           UIObjects[11].GetComponent<Dropdown>().value = instance.MeleeSaveAt;
 //           UIObjects[12].GetComponent<Toggle>().isOn = instance.ShootingInvuln;
 //           UIObjects[13].GetComponent<Dropdown>().value = instance.ShootingInvulnAt;
 //           UIObjects[14].GetComponent<Toggle>().isOn = instance.MeleeInvuln;
 //           UIObjects[15].GetComponent<Dropdown>().value = instance.MeleeInvulnAt;
 //           UIObjects[16].GetComponent<Toggle>().isOn = instance.CoverSave;
 //           UIObjects[17].GetComponent<Dropdown>().value = instance.CoverSaveBonus;
 //           UIObjects[18].GetComponent<Toggle>().isOn = instance.ReduceDamage;
 //           UIObjects[19].GetComponent<Dropdown>().value = instance.ReduceDamageBy;
 //           UIObjects[20].GetComponent<Toggle>().isOn = instance.ReduceDamageTaken;
 //           UIObjects[21].GetComponent<Dropdown>().value = instance.ReduceDamageTakenTo;
 //           UIObjects[22].GetComponent<Toggle>().isOn = instance.ReduceDamageTakenTo1;
 //           UIObjects[23].GetComponent<Toggle>().isOn = instance.FeelNoPain;
 //           UIObjects[24].GetComponent<Dropdown>().value = instance.FeelNoPainOf;
 //           UIObjects[25].GetComponent<Toggle>().isOn = instance.Regenerate;
 //           UIObjects[26].GetComponent<Dropdown>().value = instance.RegenerateAmount;
 //           UIObjects[27].GetComponent<Dropdown>().value = instance.RegenerateRoll;

 //           if (instance.RegenerateEachTurn) {
 //               UIObjects[28].GetComponent<Dropdown>().value = 1;
 //           } else if (instance.RegenerateYourTurn) {
 //               UIObjects[28].GetComponent<Dropdown>().value = 2;
 //           } else if (instance.RegenerateEachMove) {
 //               UIObjects[28].GetComponent<Dropdown>().value = 3;
 //           } else if (instance.RegenerateYourMove) {
 //               UIObjects[28].GetComponent<Dropdown>().value = 4;
 //           } else if (instance.RegenerateEachMoveEnd) {
 //               UIObjects[28].GetComponent<Dropdown>().value = 5;
 //           } else if (instance.RegenerateYourMoveEnd) {
 //               UIObjects[28].GetComponent<Dropdown>().value = 6;
 //           } else {
 //               UIObjects[28].GetComponent<Dropdown>().value = 0;
 //           }

 //           UIObjects[29].GetComponent<Toggle>().isOn = instance.Explodes;
 //           UIObjects[30].GetComponent<Dropdown>().value = instance.ExplodesRoll;
 //           UIObjects[31].GetComponent<Dropdown>().value = instance.ExplodesRange;
 //           UIObjects[32].GetComponent<Dropdown>().value = instance.ExplodesDamage;
 //           UIObjects[33].GetComponent<Toggle>().isOn = instance.MoraleBonus;
 //           UIObjects[34].GetComponent<Dropdown>().value = instance.MoraleBonusOf;
 //           UIObjects[35].GetComponent<Toggle>().isOn = instance.RerollMorales;
 //           UIObjects[36].GetComponent<Dropdown>().value = instance.RerollMoralesOf;
 //           UIObjects[37].GetComponent<Toggle>().isOn = instance.RerollAnyMorale;
 //           UIObjects[38].GetComponent<Toggle>().isOn = instance.PassMorale;
 //           UIObjects[39].GetComponent<Toggle>().isOn = instance.Terror;
 //           UIObjects[40].GetComponent<Dropdown>().value = instance.TerrorRange;
 //           UIObjects[41].GetComponent<Dropdown>().value = instance.TerrorPenalty;
 //           UIObjects[42].GetComponent<Toggle>().isOn = instance.TerrorAlternate;
 //       }
	//}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

 //   public void SetSaveRules () {

 //       instance.RerollSaves = RerollSaves;
 //       instance.RerollSavesOf = RerollSavesOf;
 //       instance.RerollFailedSaves = RerollFailedSaves;
 //       instance.Invuln = Invuln;
 //       instance.InvulnRoll = InvulnRoll;
 //       instance.RerollInvulns = RerollInvulns;
 //       instance.RerollInvulnsOf = RerollInvulnsOf;
 //       instance.RerollFailedInvulns = RerollFailedInvulns;
 //       instance.ShootingSave = ShootingSave;
 //       instance.ShootingSaveAt = ShootingSaveAt;
 //       instance.MeleeSave = MeleeSave;
 //       instance.MeleeSaveAt = MeleeSaveAt;
 //       instance.ShootingInvuln = ShootingInvuln;
 //       instance.ShootingInvulnAt = ShootingInvulnAt;
 //       instance.MeleeInvuln = MeleeInvuln;
 //       instance.MeleeInvulnAt = MeleeInvulnAt;
 //       instance.CoverSave = CoverSave;
 //       instance.CoverSaveBonus = CoverSaveBonus;
 //       instance.ReduceDamage = ReduceDamage;
 //       instance.ReduceDamageBy = ReduceDamageBy;
 //       instance.ReduceDamageTaken = ReduceDamageTaken;
 //       instance.ReduceDamageTakenTo = ReduceDamageTakenTo;
 //       instance.ReduceDamageTakenTo1 = ReduceDamageTakenTo1;
 //       instance.FeelNoPain = FeelNoPain;
 //       instance.FeelNoPainOf = FeelNoPainOf;
 //       instance.Regenerate = Regenerate;
 //       instance.RegenerateAmount = RegenerateAmount;
 //       instance.RegenerateRoll = RegenerateRoll;

 //       switch (RegenerateDuring) {
 //           case 1:
 //               instance.RegenerateEachTurn = true;
 //               instance.RegenerateYourTurn = false;
 //               instance.RegenerateEachMove = false;
 //               instance.RegenerateYourMove = false;
 //               instance.RegenerateEachMoveEnd = false;
 //               instance.RegenerateYourMoveEnd = false;
 //               break;
 //           case 2:
 //               instance.RegenerateEachTurn = false;
 //               instance.RegenerateYourTurn = true;
 //               instance.RegenerateEachMove = false;
 //               instance.RegenerateYourMove = false;
 //               instance.RegenerateEachMoveEnd = false;
 //               instance.RegenerateYourMoveEnd = false;
 //               break;
 //           case 3:
 //               instance.RegenerateEachTurn = false;
 //               instance.RegenerateYourTurn = false;
 //               instance.RegenerateEachMove = true;
 //               instance.RegenerateYourMove = false;
 //               instance.RegenerateEachMoveEnd = false;
 //               instance.RegenerateYourMoveEnd = false;
 //               break;
 //           case 4:
 //               instance.RegenerateEachTurn = false;
 //               instance.RegenerateYourTurn = false;
 //               instance.RegenerateEachMove = false;
 //               instance.RegenerateYourMove = true;
 //               instance.RegenerateEachMoveEnd = false;
 //               instance.RegenerateYourMoveEnd = false;
 //               break;
 //           case 5:
 //               instance.RegenerateEachTurn = false;
 //               instance.RegenerateYourTurn = false;
 //               instance.RegenerateEachMove = false;
 //               instance.RegenerateYourMove = false;
 //               instance.RegenerateEachMoveEnd = true;
 //               instance.RegenerateYourMoveEnd = false;
 //               break;
 //           case 6:
 //               instance.RegenerateEachTurn = false;
 //               instance.RegenerateYourTurn = false;
 //               instance.RegenerateEachMove = false;
 //               instance.RegenerateYourMove = false;
 //               instance.RegenerateEachMoveEnd = false;
 //               instance.RegenerateYourMoveEnd = true;
 //               break;
 //           default:
 //               instance.RegenerateEachTurn = false;
 //               instance.RegenerateYourTurn = false;
 //               instance.RegenerateEachMove = false;
 //               instance.RegenerateYourMove = false;
 //               instance.RegenerateEachMoveEnd = false;
 //               instance.RegenerateYourMoveEnd = false;
 //               break;
 //       }

 //       instance.Explodes = Explodes;
 //       instance.ExplodesRoll = ExplodesRoll;
 //       instance.ExplodesRange = ExplodesRange;
 //       instance.ExplodesDamage = ExplodesDamage;
 //       instance.MoraleBonus = MoraleBonus;
 //       instance.MoraleBonusOf = MoraleBonusOf;
 //       instance.RerollMorales = RerollMorales;
 //       instance.RerollMoralesOf = RerollMoralesOf;
 //       instance.RerollAnyMorale = RerollAnyMorale;
 //       instance.PassMorale = PassMorale;
 //       instance.Terror = Terror;
 //       instance.TerrorRange = TerrorRange;
 //       instance.TerrorPenalty = TerrorPenalty;
 //       instance.TerrorAlternate = TerrorAlternate;
 //   }
}
