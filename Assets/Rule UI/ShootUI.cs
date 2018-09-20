using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShootUI : MonoBehaviour {

    GameManager instance;

    public GameObject[] UIObjects;

    public bool BonusToHit { get; set; }
    public int HitBonus { get; set; }
    public bool RerollHitRolls { get; set; }
    public int RerollHitRollsOf { get; set; }
    public bool RerollMisses { get; set; }
    public bool BonusToWound { get; set; }
    public int WoundBonus { get; set; }
    public bool RerollWoundRolls { get; set; }
    public int RerollWoundRollsOf { get; set; }
    public bool RerollFailedWounds { get; set; }
    public bool OpponentsShootAt { get; set; }
    public int MinusToHit { get; set; }
    public bool OpponentsWoundAt { get; set; }
    public int MinusToWound { get; set; }
    public bool Braced { get; set; }
    public int BracedBonus { get; set; }
    public bool ShootsTwice { get; set; }
    public bool ShootsTwiceNoMove { get; set; }
    public bool Fortified { get; set; }
    public bool BracedReroll { get; set; }
    public int BracedRerollOn { get; set; }
    public bool BracedRerollMisses { get; set; }
    public bool NoPenaltiesToHit { get; set; }
    public bool NoPenaltiesToWound { get; set; }
    public bool DenyCover { get; set; }
    public int DenyCoverWithin { get; set; }
    public bool Biovore { get; set; }
    public int Sporemine { get; set; }

    // Use this for initialization
    void Start () {
        instance = GameManager.instance;

        if (instance.ShootingRulesSet) {
            UIObjects[0].GetComponent<Toggle>().isOn = instance.BonusToHit;
            UIObjects[1].GetComponent<Dropdown>().value = instance.HitBonus;
            UIObjects[2].GetComponent<Toggle>().isOn = instance.RerollHitRolls;
            UIObjects[3].GetComponent<Dropdown>().value = instance.RerollHitRollsOf;
            UIObjects[4].GetComponent<Toggle>().isOn = instance.RerollMisses;
            UIObjects[5].GetComponent<Toggle>().isOn = instance.BonusToWound;
            UIObjects[6].GetComponent<Dropdown>().value = instance.WoundBonus;
            UIObjects[7].GetComponent<Toggle>().isOn = instance.RerollWoundRolls;
            UIObjects[8].GetComponent<Dropdown>().value = instance.RerollWoundRollsOf;
            UIObjects[9].GetComponent<Toggle>().isOn = instance.RerollFailedWounds;
            UIObjects[10].GetComponent<Toggle>().isOn = instance.OpponentsShootAt;
            UIObjects[11].GetComponent<Dropdown>().value = instance.MinusToHit;
            UIObjects[12].GetComponent<Toggle>().isOn = instance.OpponentsWoundAt;
            UIObjects[13].GetComponent<Dropdown>().value = instance.MinusToWound;
            UIObjects[14].GetComponent<Toggle>().isOn = instance.Braced;
            UIObjects[15].GetComponent<Dropdown>().value = instance.BracedBonus;
            UIObjects[16].GetComponent<Toggle>().isOn = instance.ShootsTwice;
            UIObjects[17].GetComponent<Toggle>().isOn = instance.Fortified;
            UIObjects[18].GetComponent<Toggle>().isOn = instance.BracedReroll;
            UIObjects[19].GetComponent<Dropdown>().value = instance.BracedRerollOn;
            UIObjects[20].GetComponent<Toggle>().isOn = instance.BracedRerollMisses;
            UIObjects[21].GetComponent<Toggle>().isOn = instance.NoPenaltiesToHit;
            UIObjects[22].GetComponent<Toggle>().isOn = instance.NoPenaltiesToWound;
            UIObjects[23].GetComponent<Toggle>().isOn = instance.DenyCover;
            if (instance.DenyAllCover) {
                UIObjects[24].GetComponent<Dropdown>().value = 2;
            } else if (instance.DenyCoverWithin == 3) {
                UIObjects[24].GetComponent<Dropdown>().value = 1;
            }
            UIObjects[25].GetComponent<Toggle>().isOn = instance.Biovore;
            UIObjects[26].GetComponent<Dropdown>().value = instance.Sporemine;
            UIObjects[27].GetComponent<Toggle>().isOn = instance.ShootsTwiceNoMove;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetShootingRules () {
        bool readyToProceed = true;

        instance.BonusToHit = BonusToHit;
        instance.HitBonus = HitBonus;

        if (instance.BonusToHit && instance.HitBonus == 0) {
            print("Please select the unit's bonus to hit.");
            readyToProceed = false;
        }

        instance.RerollHitRolls = RerollHitRolls;
        instance.RerollHitRollsOf = RerollHitRollsOf;

        if (instance.RerollHitRolls && instance.RerollHitRollsOf == 0) {
            print("Please select the roll the unit gets to re-roll.");
            readyToProceed = false;
        }

        instance.RerollMisses = RerollMisses;
        instance.BonusToWound = BonusToWound;
        instance.WoundBonus = WoundBonus;

        if (instance.BonusToWound && instance.WoundBonus == 0) {
            print("Please select the unit's bonus to wound.");
            readyToProceed = false;
        }

        instance.RerollWoundRolls = RerollWoundRolls;
        instance.RerollWoundRollsOf = RerollWoundRollsOf;

        if (instance.RerollWoundRolls && instance.RerollWoundRollsOf == 0) {
            print("Please select the wound roll the unit gets to re-roll.");
            readyToProceed = false;
        }

        instance.RerollFailedWounds = RerollFailedWounds;
        instance.OpponentsShootAt = OpponentsShootAt;
        instance.MinusToHit = MinusToHit;

        if (instance.OpponentsShootAt && instance.MinusToHit == 0) {
            print("Please select the pentaly to hit opponents receive when shooting at the unit.");
            readyToProceed = false;
        }

        instance.OpponentsWoundAt = OpponentsWoundAt;
        instance.MinusToWound = MinusToWound;

        if (instance.OpponentsWoundAt && instance.MinusToWound == 0) {
            print("Please select the pentaly to wound rolls opponents receive when shooting at the unit.");
            readyToProceed = false;
        }

        instance.Braced = Braced;
        instance.BracedBonus = BracedBonus;

        if (instance.Braced && instance.BracedBonus == 0) {
            print("Please select the bonus the unit receives if the unit does not move.");
            readyToProceed = false;
        }

        instance.ShootsTwice = ShootsTwice;
        instance.ShootsTwiceNoMove = ShootsTwiceNoMove;
        instance.Fortified = Fortified;
        instance.BracedReroll = BracedReroll;
        instance.BracedRerollOn = BracedRerollOn;

        if (instance.BracedReroll && instance.BracedRerollOn == 0) {
            print("Please select the dice the unit can re-roll if the unit does not move.");
            readyToProceed = false;
        }

        instance.BracedRerollMisses = BracedRerollMisses;
        instance.NoPenaltiesToHit = NoPenaltiesToHit;
        instance.NoPenaltiesToWound = NoPenaltiesToWound;
        instance.DenyCover = DenyCover;
        switch (DenyCoverWithin) {
            case 1:
                instance.DenyCoverWithin = 3;
                instance.DenyAllCover = false;
                break;
            case 2:
                instance.DenyCoverWithin = 0;
                instance.DenyAllCover = true;
                break;
            default:
                instance.DenyCoverWithin = 0;
                instance.DenyAllCover = false;
                break;
        }

        if (instance.DenyCover && instance.DenyCoverWithin == 0 && instance.DenyAllCover) {
            print("Please select the distance the unit denies cover over.");
            readyToProceed = false;
        }

        instance.Biovore = Biovore;
        instance.Sporemine = Sporemine;

        if (instance.Biovore && instance.Sporemine == 0) {
            print("Please select the unit spawned on a miss.");
            readyToProceed = false;
        }

        if (readyToProceed) {
            SceneManager.LoadScene("Charge UI");
        }
    }

    public void ResetProfiles() {

        SceneManager.LoadScene("Profile UI");
    }

    public void Back () {

        SceneManager.LoadScene("Move UI");
    }

    public void Exit () {
        instance.OnDisable();
        Application.Quit();
    }
}
