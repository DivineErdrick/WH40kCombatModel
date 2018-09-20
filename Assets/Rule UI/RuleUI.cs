using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RuleUI : MonoBehaviour {

    GameManager instance;

    //UI Objects
    public InputField inputName;
    public Button buttonContinue;
    public Button buttonLoad;
    public Button buttonSave;
    public Toggle useToggleAll;
    public Toggle useToggleNone;
    public Toggle[] useToggles;
    public GameObject panelRuleUse;
    public GameObject panelTriggerTypes;
    public GameObject panelMoveTriggers;
    public GameObject panelPsychicTriggers;
    public GameObject panelShootingTriggers;
    public GameObject panelChargeTriggers;
    public GameObject panelOverwatchTriggers;
    public GameObject panelFightTriggers;
    public GameObject panelMeleeTriggers;
    public GameObject panelMoraleTriggers;
    public GameObject panelNameCheck;

    public GameObject panelRuleTarget;
    public InputField keyword;
    public Dropdown target;
    public Text textRange;
    public InputField inputRange;
    public Text textDamage;
    public Dropdown dropdownDamage;
    public Text textRoll;
    public Dropdown dropdownRoll;
    public GameObject panelRuleType;
    public GameObject panelReserve;
    public InputField inputReserveRange;
    public GameObject panelProfile;
    public GameObject panelRoll;
    public Text textModifier;
    public Dropdown dropdownModifier;
    public GameObject panelIgnore;
    public GameObject panelAdditionalAttacks;
    public GameObject panelMortalWounds;

    //Use flags
    public bool UseDeployment { get; set; }
    public bool UseStartOfGame { get; set; }
    public bool UseYourTurn { get; set; }
    public bool UseOpponentsTurn { get; set; }
    public bool UseStartOfTurn { get; set; }
    public bool UseMove { get; set; }
    public bool UsePsychic { get; set; }
    public bool UseShooting { get; set; }
    public bool UseCharge { get; set; }
    public bool UseFight { get; set; }
    public bool UseMorale { get; set; }
    public bool UseEndOfTurn { get; set; }

    //Use type flags
    public bool TriggerAlways { get; set; }
    public bool TriggerPlayer { get; set; }
    public bool Triggered { get; set; }

    //Move Triggers
    public bool StartOfMove { get; set; }
    public bool Moves { get; set; }
    public bool Advances { get; set; }
    public bool EndOfMove { get; set; }

    //Psychic Triggers
    public bool StartOfPyschic { get; set; }
    public bool PsykerChosen { get; set; }
    public bool PowerChosen { get; set; }
    public bool TargetChosen { get; set; }
    public bool PsychicTest { get; set; }
    public bool TestFailed { get; set; }
    public bool DenyTheWitch { get; set; }
    public bool DenyRolls { get; set; }
    public bool PowerDenied { get; set; }
    public bool DenyFailed { get; set; }
    public bool Manifests { get; set; }
    public bool Perils { get; set; }
    public bool EndOfPsychic { get; set; }

    //Shooting Triggers
    public bool StartOfShooting { get; set; }
    public bool UnitChosenToShoot { get; set; }
    public bool TargetsChosenForShooting { get; set; }
    public bool ShootingRolls { get; set; }
    public bool ShootingMisses { get; set; }
    public bool ShootingHits { get; set; }
    public bool ShootingWoundRolls { get; set; }
    public bool ShootingFailedWounds { get; set; }
    public bool ShootingWounds { get; set; }
    public bool ModelKilledInShooting { get; set; }
    public bool UnitKilledInShooting { get; set; }
    public bool EndOfShooting { get; set; }

    //Charge Triggers
    public bool StartOfCharge { get; set; }
    public bool UnitChosenToCharge { get; set; }
    public bool TargetsChosenForCharging { get; set; }
    public bool ChargeRolls { get; set; }
    public bool FailedCharge { get; set; }
    public bool ChargeMove { get; set; }
    public bool EndOfCharge { get; set; }

    //Overwatch Triggers
    public bool Overwatch { get; set; }
    public bool OverwatchRolls { get; set; }
    public bool OverwatchMisses { get; set; }
    public bool OverwatchHits { get; set; }
    public bool OverwatchWoundRolls { get; set; }
    public bool OverwatchFailedWounds { get; set; }
    public bool OverwatchWounds { get; set; }
    public bool ModelKilledInOverwatch { get; set; }
    public bool UnitKilledInOverwatch { get; set; }

    //Fight Triggers
    public bool StartOfFight { get; set; }
    public bool FirstFights { get; set; }
    public bool ChosenFights { get; set; }
    public bool LastFights { get; set; }
    public bool UnitChosenToFight { get; set; }
    public bool PileIn { get; set; }
    public bool TargetsChosenToFight { get; set; }
    public bool EndOfFight { get; set; }

    //Melee Triggers
    public bool MeleeHitRolls { get; set; }
    public bool MeleeMisses { get; set; }
    public bool MeleeHits { get; set; }
    public bool MeleeWoundRolls { get; set; }
    public bool MeleeFailedWounds { get; set; }
    public bool MeleeWounds { get; set; }
    public bool ModelKilledInMelee { get; set; }
    public bool UnitKilledInMelee { get; set; }
    public bool Consolidates { get; set; }

    //Morale Triggers
    public bool StartOfMorale { get; set; }
    public bool UnitChosenForMorale { get; set; }
    public bool MoraleRolled { get; set; }
    public bool MoralePassed { get; set; }
    public bool MoraleFailed { get; set; }
    public bool ModelFlees { get; set; }
    public bool UnitDestroyedInMorale { get; set; }
    public bool EndOfMorale { get; set; }

    //Target
    public int RuleTarget { get; set; }
    public string InputKeyword { get; set; }
    public int KeywordTarget { get; set; }

    //Properties
    public int Range { get; set; }
    public int Damage { get; set; }
    public int RuleType { get; set; }

    //Reserves
    public bool ReserveOutsideEnemy { get; set; }
    public bool ReserveFromObject { get; set; }
    public bool ReserveRerollCharges { get; set; }
    public bool ReserveDealsMortal { get; set; }
    public int ReserveDamageRange { get; set; }

    //Profile
    public int Profile { get; set; }
    public int Modifier { get; set; }
    public int Change { get; set; }

    //Pass Roll
    public int RollModified { get; set; }
    public int ModifiedBy { get; set; }
    public int RollModifier { get; set; }

    //Ignore Penalties
    public int PenaltyIgnored { get; set; }

    //Additional Attack
    public bool OnlyAdditionalAttack { get; set; }
    public bool CanExplode { get; set; }

    //Mortal Wounds
    public bool SlayTheModel { get; set; }

    Rule rule;
    bool triggersSet = false;
    int ruleToLoad;
    Color defaultColor;

    void Awake () {

        Assert.IsNotNull(inputName, "The Input Name field has not been added to the Rule UI.");
        Assert.IsNotNull(buttonContinue, "The Continue Button has not been added to the Rule UI.");
        Assert.IsNotNull(buttonLoad, "The Load Button has not been added to the Rule UI.");
        Assert.IsNotNull(buttonSave, "The Save Button has not been added to the Rule UI.");
        Assert.IsNotNull(useToggleAll, "The All use toggle has not been added to the Rule UI.");
        Assert.IsNotNull(useToggleNone, "The None use toggle has not been added to the Rule UI.");
        Assert.IsNotNull(panelRuleUse, "The Rule Use panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelTriggerTypes, "The Trigger Types panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelMoveTriggers, "The Move Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelPsychicTriggers, "The Psychic Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelShootingTriggers, "The Shooting Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelChargeTriggers, "The Charge Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelOverwatchTriggers, "The Overwatch Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelFightTriggers, "The Fight Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelMeleeTriggers, "The Melee Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelMoraleTriggers, "The Morale Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelNameCheck, "The Name Check panel has not been added to the Rule UI.");
        Assert.IsTrue((useToggles.Length > 0), "The Use Toggles have not been added to the Rule UI.");
        Assert.IsNotNull(panelRuleTarget, "The Rule Target panel has not been added to the Rule UI.");
        Assert.IsNotNull(keyword, "The Keyword input has not been added to the Rule UI.");
        Assert.IsNotNull(target, "The Target dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(textRange, "The Range default text has not been added to the Rule UI.");
        Assert.IsNotNull(inputRange, "The Range input field has not been added to the Rule UI.");
        Assert.IsNotNull(textDamage, "The Damage text has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownDamage, "The Damage dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(textRoll, "The Roll text has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownRoll, "The Roll dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(inputReserveRange, "The Range input field has not been added to the Rule UI.");
        Assert.IsNotNull(panelRuleType, "The Rule Type panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelReserve, "The Reserve panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelProfile, "The Profile panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelRoll, "The Pass Roll panel has not been added to the Rule UI.");
        Assert.IsNotNull(textModifier, "The Roll text has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownModifier, "The Roll dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(panelIgnore, "The Ignore panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelAdditionalAttacks, "The Aditional Attack panel has not been added to the Rule UI.");

        Assert.IsNotNull(panelRuleUse, "The Rule Use panel has not been added to the Rule UI.");
    }
    // Use this for initialization
    void Start () {

        instance = GameManager.instance;
        defaultColor = textRange.color;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckAllUseToggles (bool turnTogglesOn) {

        if (turnTogglesOn && useToggleAll.isOn && ! useToggleNone.isOn) {

            SwitchUseToggles(turnTogglesOn);

        } else if ( ! turnTogglesOn && ! useToggleAll.isOn && useToggleNone.isOn) {

            SwitchUseToggles(turnTogglesOn);
        }
    }

    void SwitchUseToggles (bool turnTogglesOn) {

        useToggleAll.isOn = turnTogglesOn;
        useToggleNone.isOn = !turnTogglesOn;
        foreach (Toggle toggle in useToggles) {
            toggle.isOn = turnTogglesOn;
        }
    }

    public void UseToggleSelected () {

        int nTemp = 0;
        foreach (Toggle toggle in useToggles) {

            if (toggle.isOn) {
                nTemp++;
            }
        }

        if (nTemp == useToggles.Length) {
            Debug.Log("All use toggles are on.");
            useToggleAll.isOn = true;

        } else if (nTemp == 0) {
            Debug.Log("All use toggles are off.");
            useToggleNone.isOn = true;
            panelTriggerTypes.SetActive(false);

        } else {
            useToggleAll.isOn = false;
            useToggleNone.isOn = false;
        }

        if (nTemp > 0) {
            panelTriggerTypes.SetActive(true);
        }
        //Debug.Log("Deployment: " + UseDeployment + " Start of Game: " + UseStartOfGame + " Your Turn: " + UseYourTurn + " Opponent's Turn: " + UseOpponentsTurn + " Start of Turn: " + UseStartOfTurn + " Move: " + UseMove +
        //" Psychic: " + UsePsychic + " Shoot: " + UseShoot + " Charge: " + UseCharge + " Fight: " + UseFight + " Morale: " + UseMorale + " End of Turn: " + UseEndOfTurn);
    }

    public void ToggleTriggerTables () {

        if (UseMove && Triggered) {
            panelMoveTriggers.SetActive(true);
        } else {
            panelMoveTriggers.SetActive(false);
        }
        if (UsePsychic && Triggered) {
            panelPsychicTriggers.SetActive(true);
        } else {
            panelPsychicTriggers.SetActive(false);
        }
        if (UseShooting && Triggered) {
            panelShootingTriggers.SetActive(true);
        } else {
            panelShootingTriggers.SetActive(false);
        }
        if (UseCharge && Triggered) {
            panelChargeTriggers.SetActive(true);
            panelOverwatchTriggers.SetActive(true);
        } else {
            panelChargeTriggers.SetActive(false);
            panelOverwatchTriggers.SetActive(false);
        }
        if (UseFight && Triggered) {
            panelFightTriggers.SetActive(true);
            panelMeleeTriggers.SetActive(true);
        } else {
            panelFightTriggers.SetActive(false);
            panelMeleeTriggers.SetActive(false);
        }
        if (UseMorale && Triggered) {
            panelMoraleTriggers.SetActive(true);
        } else {
            panelMoraleTriggers.SetActive(false);
        }
    }

    public void ToggleRange () {

        if ((RuleTarget != 0 &&
            RuleTarget != 9 &&
            RuleTarget != 10) ||
            RuleType == 1) {
            Debug.Log("Enabling range entry");

            textRange.gameObject.SetActive(true);
            inputRange.gameObject.SetActive(true);
        } else {
            Debug.Log("Disabling range entry.");
            textRange.gameObject.SetActive(false);
            inputRange.gameObject.SetActive(false);
        }
    }

    public void ToggleRuleType () {

        if (RuleTarget != 0) { 
            panelRuleType.SetActive(true);
        } else {
            panelRuleType.SetActive(false);
        }
    }

    public void ToggleKeyword () {

        if (RuleTarget == 11) {

            keyword.gameObject.SetActive(true);
            target.gameObject.SetActive(true);
            
        } else {

            keyword.gameObject.SetActive(false);
            target.gameObject.SetActive(false);
        }
    }

    public void ToggleDamage () {

        if ((RuleType == 1 && ReserveDealsMortal)||
            RuleType == 10) {
            textDamage.gameObject.SetActive(true);
            dropdownDamage.gameObject.SetActive(true);
        } else {
            textDamage.gameObject.SetActive(false);
            dropdownDamage.gameObject.SetActive(false);
        }
    }

    public void ToggleRoll () {

        if (RuleType == 2 ||
            RuleType == 3 ||
            RuleType == 10) {

            textRoll.gameObject.SetActive(true);
            dropdownRoll.gameObject.SetActive(true);
        } else {
            textRoll.gameObject.SetActive(false);
            dropdownRoll.gameObject.SetActive(false);
        }
    }

    public void ToggleReserveRange () {

        if (ReserveDealsMortal) {
            inputReserveRange.gameObject.SetActive(true);
        } else {
            inputReserveRange.gameObject.SetActive(false);
        }
    }

    public void ToggleModifiers () {

        if (ModifiedBy == 1 ||
            ModifiedBy == 2 ||
            ModifiedBy == 3) {

            textModifier.gameObject.SetActive(true);
            dropdownModifier.gameObject.SetActive(true);
        } else {
            textModifier.gameObject.SetActive(false);
            dropdownModifier.gameObject.SetActive(false);
        }
    }

    public void ToggleRuleProperties (int ruleType) {

        switch (ruleType) {
            case 1:
                textRoll.gameObject.SetActive(true);
                dropdownRoll.gameObject.SetActive(true);
                panelReserve.SetActive(true);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                break;
            case 2:
                textRoll.gameObject.SetActive(true);
                dropdownRoll.gameObject.SetActive(true);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                break;
            case 3:
                textRoll.gameObject.SetActive(true);
                dropdownRoll.gameObject.SetActive(true);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                break;
            case 4:
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(true);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                break;
            case 5:
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(true);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                break;
            case 6:
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(true);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                break;
            case 9:
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(true);
                panelMortalWounds.SetActive(false);
                break;
            case 10:
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(true);
                break;
            default:
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                break;
        }
    }

    public void ValueCheckNotNegative(string name) {

        int value;
        switch (name) {
            case "Range":
                if (int.TryParse(inputRange.text, out value)) {
                    if (value >= 0) {
                        textRange.color = defaultColor;
                        Range = value;
                    } else {
                        Range = 0;
                        OutputError(textRange, "Range");
                    }
                } else {
                    Range = 0;
                    OutputError(textRange, "Range");
                }
                break;
            case "Reserves":
                if (int.TryParse(inputRange.text, out value)) {
                    if (value >= 0) {
                        textRange.color = defaultColor;
                        ReserveDamageRange = value;
                    } else {
                        ReserveDamageRange = 0;
                        OutputError(textRange, "Reserves");
                    }
                } else {
                    ReserveDamageRange = 0;
                    OutputError(textRange, "Reserves");
                }
                break;
            default:
                Debug.Log("Input field not correctly labeled.");
                break;
        }
    }

    void OutputError(Text text, string name) {
        text.color = Color.red;
        Debug.Log("Value of " + name + " is not legal.");
    }

    public void Continue () {

        panelChargeTriggers.SetActive(false);
        panelFightTriggers.SetActive(false);
        panelMeleeTriggers.SetActive(false);
        panelMoraleTriggers.SetActive(false);
        panelMoveTriggers.SetActive(false);
        panelOverwatchTriggers.SetActive(false);
        panelPsychicTriggers.SetActive(false);
        panelRuleUse.SetActive(false);
        panelShootingTriggers.SetActive(false);
        panelTriggerTypes.SetActive(false);

        panelRuleUse.SetActive(true);

        triggersSet = true;
    }

    public void Save (bool overwrite) {

        rule = new Rule();
        rule.Name = inputName.text;

        instance.ActiveRule = rule;
        bool nameCheck = true;
        for (int i = 0; i < instance.Rules.Count; i++) {
            if (rule.Name == instance.Rules[i].Name) {
                nameCheck = false;
                ruleToLoad = i;
            }
        }

        if (nameCheck) {
            instance.Rules.Add(rule);
            instance.Save();
            buttonLoad.interactable = true;
        } else if (overwrite) {
            instance.Rules[ruleToLoad] = rule;
            panelNameCheck.SetActive(false);
        } else {
            panelNameCheck.SetActive(true);
        }

        Debug.Log("New Rule name is " + rule.Name + ". It has been added to the rule data as " + instance.Rules.Last().Name + ".");
    }

    public void Back() {

        if (triggersSet) {

            panelChargeTriggers.SetActive(true);
            panelFightTriggers.SetActive(true);
            panelMeleeTriggers.SetActive(true);
            panelMoraleTriggers.SetActive(true);
            panelMoveTriggers.SetActive(true);
            panelOverwatchTriggers.SetActive(true);
            panelPsychicTriggers.SetActive(true);
            panelRuleUse.SetActive(true);
            panelShootingTriggers.SetActive(true);
            panelTriggerTypes.SetActive(true);

            panelRuleUse.SetActive(false);

            triggersSet = false;

        } else {
            SceneManager.LoadScene("Start");
        }
    }

    public void Exit() {
        instance.OnDisable();
        Application.Quit();
    }
}
