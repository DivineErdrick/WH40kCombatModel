﻿using System.Collections;
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
    public GameObject panelActivation;
    public GameObject panelTriggers;
    public Dropdown dropdownMove;
    public Dropdown dropdownPsychic;
    public Dropdown dropdownShooting;
    public Dropdown dropdownCharge;
    public Dropdown dropdownFight;
    public Dropdown dropdownMorale;
    public GameObject panelSpecificTriggers;
    public Text textAttacks;
    public Dropdown dropdownAttackTriggers;
    public Dropdown dropdownWoundTriggers;
    public Dropdown dropdownPowerTriggers;
    public Dropdown dropdownDenyTriggers;
    public Dropdown dropdownChargeTriggers;
    public Dropdown dropdownFightsTriggers;
    public Text textRollOf;
    public Dropdown dropdownRollTrigger;

    //public GameObject panelPsychicTriggers;
    //public GameObject panelShootingTriggers;
    //public GameObject panelChargeTriggers;
    //public GameObject panelOverwatchTriggers;
    //public GameObject panelFightTriggers;
    //public GameObject panelMeleeTriggers;
    //public GameObject panelMoraleTriggers;

    public GameObject panelRuleTarget;
    public InputField inputKeyword;
    public Dropdown dropdownTarget;
    public GameObject panelProperties;
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

    public GameObject panelNameCheck;

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
    public bool UseEndOfGame { get; set; }

    //Activation
    public int ActivationType { get; set; }

    //Triggers
    public int MoveTriggers { get; set; }
    public int PsychicTriggers { get; set; }
    public int ShootingTriggers { get; set; }
    public int ChargeTriggers { get; set; }
    public int FightTriggers { get; set; }
    public int MoraleTriggers { get; set; }

    //Specific Triggers
    public int AttackTriggers { get; set; }
    public int WoundTriggers { get; set; }
    public int PowerTriggers { get; set; }
    public int DenyTriggers { get; set; }
    public int SpecificChargeTriggers { get; set; }
    public int SpecificFightsTriggers { get; set; }
    public int RollTrigger { get; set; }

    ////Move Triggers
    //public int MoveTriggers { get; set; }
    //public bool StartOfMove { get; set; }
    //public bool Moves { get; set; }
    //public bool Advances { get; set; }
    //public bool EndOfMove { get; set; }
    ////Psychic Triggers
    //public int PsychicTriggers { get; set; }
    //public bool StartOfPyschic { get; set; }
    //public bool PsykerChosen { get; set; }
    //public bool PowerChosen { get; set; }
    //public bool TargetChosen { get; set; }
    //public bool PsychicTest { get; set; }
    //public bool TestFailed { get; set; }
    //public bool DenyTheWitch { get; set; }
    //public bool DenyRolls { get; set; }
    //public bool PowerDenied { get; set; }
    //public bool DenyFailed { get; set; }
    //public bool Manifests { get; set; }
    //public bool Perils { get; set; }
    //public bool EndOfPsychic { get; set; }

    ////Shooting Triggers
    //public int ShootingTriggers { get; set; }
    //public bool StartOfShooting { get; set; }
    //public bool UnitChosenToShoot { get; set; }
    //public bool TargetsChosenForShooting { get; set; }
    //public bool ShootingRolls { get; set; }
    //public bool ShootingMisses { get; set; }
    //public bool ShootingHits { get; set; }
    //public bool ShootingWoundRolls { get; set; }
    //public bool ShootingFailedWounds { get; set; }
    //public bool ShootingWounds { get; set; }
    //public bool ModelKilledInShooting { get; set; }
    //public bool UnitKilledInShooting { get; set; }
    //public bool EndOfShooting { get; set; }

    ////Charge Triggers
    //public int ChargeTriggers { get; set; }
    //public bool StartOfCharge { get; set; }
    //public bool UnitChosenToCharge { get; set; }
    //public bool TargetsChosenForCharging { get; set; }
    //public bool ChargeRolls { get; set; }
    //public bool FailedCharge { get; set; }
    //public bool ChargeMove { get; set; }
    //public bool EndOfCharge { get; set; }

    ////Overwatch Triggers
    //public bool Overwatch { get; set; }
    //public bool OverwatchRolls { get; set; }
    //public bool OverwatchMisses { get; set; }
    //public bool OverwatchHits { get; set; }
    //public bool OverwatchWoundRolls { get; set; }
    //public bool OverwatchFailedWounds { get; set; }
    //public bool OverwatchWounds { get; set; }
    //public bool ModelKilledInOverwatch { get; set; }
    //public bool UnitKilledInOverwatch { get; set; }

    ////Fight Triggers
    //public int FightTriggers { get; set; }
    //public bool StartOfFight { get; set; }
    //public bool FirstFights { get; set; }
    //public bool ChosenFights { get; set; }
    //public bool LastFights { get; set; }
    //public bool UnitChosenToFight { get; set; }
    //public bool PileIn { get; set; }
    //public bool TargetsChosenToFight { get; set; }
    //public bool EndOfFight { get; set; }

    ////Melee Triggers
    //public bool MeleeHitRolls { get; set; }
    //public bool MeleeMisses { get; set; }
    //public bool MeleeHits { get; set; }
    //public bool MeleeWoundRolls { get; set; }
    //public bool MeleeFailedWounds { get; set; }
    //public bool MeleeWounds { get; set; }
    //public bool ModelKilledInMelee { get; set; }
    //public bool UnitKilledInMelee { get; set; }
    //public bool Consolidates { get; set; }

    ////Morale Triggers
    //public int MoraleTriggers { get; set; }
    //public bool StartOfMorale { get; set; }
    //public bool UnitChosenForMorale { get; set; }
    //public bool MoraleRolled { get; set; }
    //public bool MoralePassed { get; set; }
    //public bool MoraleFailed { get; set; }
    //public bool ModelFlees { get; set; }
    //public bool UnitDestroyedInMorale { get; set; }
    //public bool EndOfMorale { get; set; }

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
    Color panelColor1;
    Color panelColor2;

    void Awake () {

        Assert.IsNotNull(inputName, "The Input Name field has not been added to the Rule UI.");
        Assert.IsNotNull(buttonContinue, "The Continue Button has not been added to the Rule UI.");
        Assert.IsNotNull(buttonLoad, "The Load Button has not been added to the Rule UI.");
        Assert.IsNotNull(buttonSave, "The Save Button has not been added to the Rule UI.");
        Assert.IsNotNull(useToggleAll, "The All use toggle has not been added to the Rule UI.");
        Assert.IsNotNull(useToggleNone, "The None use toggle has not been added to the Rule UI.");
        Assert.IsNotNull(panelRuleUse, "The Rule Use panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelActivation, "The Trigger Types panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelTriggers, "The Triggers panel has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownMove, "The Move dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownPsychic, "The Psychic dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownShooting, "The Shooting dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownCharge, "The Charge dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownFight, "The Fight dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownMorale, "The Morale dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(textAttacks, "The Attacks text has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownAttackTriggers, "The Morale dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownWoundTriggers, "The Morale dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownPowerTriggers, "The Morale dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownDenyTriggers, "The Morale dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownChargeTriggers, "The Morale dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownFightsTriggers, "The Morale dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(textRollOf, "The Roll of text has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownRollTrigger, "The Morale dropdown has not been added to the Rule UI.");

        //Assert.IsNotNull(panelPsychicTriggers, "The Psychic Triggers panel has not been added to the Rule UI.");
        //Assert.IsNotNull(panelShootingTriggers, "The Shooting Triggers panel has not been added to the Rule UI.");
        //Assert.IsNotNull(panelChargeTriggers, "The Charge Triggers panel has not been added to the Rule UI.");
        //Assert.IsNotNull(panelOverwatchTriggers, "The Overwatch Triggers panel has not been added to the Rule UI.");
        //Assert.IsNotNull(panelFightTriggers, "The Fight Triggers panel has not been added to the Rule UI.");
        //Assert.IsNotNull(panelMeleeTriggers, "The Melee Triggers panel has not been added to the Rule UI.");
        //Assert.IsNotNull(panelMoraleTriggers, "The Morale Triggers panel has not been added to the Rule UI.");

        Assert.IsNotNull(panelNameCheck, "The Name Check panel has not been added to the Rule UI.");
        Assert.IsTrue((useToggles.Length > 0), "The Use Toggles have not been added to the Rule UI.");
        Assert.IsNotNull(panelRuleTarget, "The Rule Target panel has not been added to the Rule UI.");
        Assert.IsNotNull(inputKeyword, "The Keyword input has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownTarget, "The Target dropdown has not been added to the Rule UI.");
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
        panelColor1 = panelRuleUse.GetComponent<Image>().color;
        panelColor2 = panelActivation.GetComponent<Image>().color;
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
            panelActivation.SetActive(false);

        } else {
            useToggleAll.isOn = false;
            useToggleNone.isOn = false;
        }

        if (nTemp > 0) {
            panelActivation.SetActive(true);
        }
        //Debug.Log("Deployment: " + UseDeployment + " Start of Game: " + UseStartOfGame + " Your Turn: " + UseYourTurn + " Opponent's Turn: " + UseOpponentsTurn + " Start of Turn: " + UseStartOfTurn + " Move: " + UseMove +
        //" Psychic: " + UsePsychic + " Shoot: " + UseShoot + " Charge: " + UseCharge + " Fight: " + UseFight + " Morale: " + UseMorale + " End of Turn: " + UseEndOfTurn);
    }

    void AdjustPanels () {

        float panelOffset = 0f;

        if (panelTriggers.activeInHierarchy) {
            panelOffset++;
        }
        if (panelSpecificTriggers.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelSpecificTriggers);
        }
        if (panelRuleTarget.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelRuleTarget);
        }
        if (panelRuleType.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelRuleType);
        }
        if (panelProperties.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelProperties);
        }
        if (panelReserve.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelReserve);
        }
        if (panelProfile.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelProfile);
        }
        if (panelIgnore.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelIgnore);
        }
        if (panelAdditionalAttacks.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelAdditionalAttacks);
        }
        if (panelMortalWounds.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelMortalWounds);
        }
    }

    float AdjustAnchors (float offset, GameObject panel) {
        Vector2 min = new Vector2(0.01f, 0.75f);
        Vector2 max = new Vector2(0.99f, 0.8f);

        min.y = min.y - 0.05f * offset;
        max.y = max.y - 0.05f * offset;
        panel.GetComponent<RectTransform>().anchorMin = min;
        panel.GetComponent<RectTransform>().anchorMax = max;
        offset++;

        if (offset % 2 != 0) {
            panel.GetComponent<Image>().color = panelColor1;
        } else {
            panel.GetComponent<Image>().color = panelColor2;
        }

        return offset;
    }

    public void ToggleActivationPanel () {

        if (UseDeployment || UseStartOfGame || UseYourTurn || UseOpponentsTurn || UseStartOfTurn || UseMove || UsePsychic || UseShooting || UseCharge || UseFight || UseMorale || UseEndOfTurn || UseEndOfGame) {
            panelActivation.SetActive(true);
        } else {
            panelActivation.SetActive(false);
        }
    }

    public void ToggleTriggerDropdowns () {

        if (ActivationType == 3 && (UseMove || UsePsychic || UseShooting || UseCharge || UseFight || UseMorale)) {

            panelTriggers.SetActive(true);
            AdjustPanels();

            if (UseMove) {
                dropdownMove.gameObject.SetActive(true);
            } else {
                dropdownMove.gameObject.SetActive(false);
            }
            if (UsePsychic) {
                dropdownPsychic.gameObject.SetActive(true);
            } else {
                dropdownPsychic.gameObject.SetActive(false);
            }
            if (UseShooting) {
                dropdownShooting.gameObject.SetActive(true);
            } else {
                dropdownShooting.gameObject.SetActive(false);
            }
            if (UseCharge) {
                dropdownCharge.gameObject.SetActive(true);
            } else {
                dropdownCharge.gameObject.SetActive(false);
            }
            if (UseFight) {
                dropdownFight.gameObject.SetActive(true);
            } else {
                dropdownFight.gameObject.SetActive(false);
            }
            if (UseMorale) {
                dropdownMorale.gameObject.SetActive(true);
            } else {
                dropdownMorale.gameObject.SetActive(false);
            }
        } else {
            panelTriggers.SetActive(false);
            AdjustPanels();
            dropdownMove.gameObject.SetActive(false);
            dropdownPsychic.gameObject.SetActive(false);
            dropdownShooting.gameObject.SetActive(false);
            dropdownCharge.gameObject.SetActive(false);
            dropdownFight.gameObject.SetActive(false);
            dropdownMorale.gameObject.SetActive(false);
        }
        //if (UseMove && Triggered) {
        //    panelMoveTriggers.SetActive(true);
        //} else {
        //    panelMoveTriggers.SetActive(false);
        //}
        //if (UsePsychic && Triggered) {
        //    panelPsychicTriggers.SetActive(true);
        //} else {
        //    panelPsychicTriggers.SetActive(false);
        //}
        //if (UseShooting && Triggered) {
        //    panelShootingTriggers.SetActive(true);
        //} else {
        //    panelShootingTriggers.SetActive(false);
        //}
        //if (UseCharge && Triggered) {
        //    panelChargeTriggers.SetActive(true);
        //    panelOverwatchTriggers.SetActive(true);
        //} else {
        //    panelChargeTriggers.SetActive(false);
        //    panelOverwatchTriggers.SetActive(false);
        //}
        //if (UseFight && Triggered) {
        //    panelFightTriggers.SetActive(true);
        //    panelMeleeTriggers.SetActive(true);
        //} else {
        //    panelFightTriggers.SetActive(false);
        //    panelMeleeTriggers.SetActive(false);
        //}
        //if (UseMorale && Triggered) {
        //    panelMoraleTriggers.SetActive(true);
        //} else {
        //    panelMoraleTriggers.SetActive(false);
        //}
    }

    public void ToggleSpecificTriggers () {

        if (MoraleTriggers == 3 ||
            PsychicTriggers == 1 || PsychicTriggers == 2 ||
            ShootingTriggers == 1 || ShootingTriggers == 2 ||
            (ChargeTriggers != 0 && ChargeTriggers != 4) ||
            (FightTriggers != 0 && FightTriggers != 6)) {

            panelSpecificTriggers.SetActive(true);
            AdjustPanels();

            switch (PsychicTriggers) {
                case 1:
                    dropdownPowerTriggers.gameObject.SetActive(true);
                    dropdownDenyTriggers.gameObject.SetActive(false);
                    break;
                case 2:
                    dropdownPowerTriggers.gameObject.SetActive(false);
                    dropdownDenyTriggers.gameObject.SetActive(true);
                    break;
                default:
                    dropdownPowerTriggers.gameObject.SetActive(false);
                    dropdownDenyTriggers.gameObject.SetActive(false);
                    break;
            }
            switch (ShootingTriggers) {
                case 1:
                    textAttacks.gameObject.SetActive(true);
                    dropdownAttackTriggers.gameObject.SetActive(true);
                    break;
                case 2:
                    textAttacks.gameObject.SetActive(true);
                    dropdownWoundTriggers.gameObject.SetActive(true);
                    break;
                default:
                    break;
            }
            switch (ChargeTriggers) {
                case 1:
                    dropdownChargeTriggers.gameObject.SetActive(true);
                    break;
                case 2:
                    textAttacks.gameObject.SetActive(true);
                    dropdownAttackTriggers.gameObject.SetActive(true);
                    dropdownChargeTriggers.gameObject.SetActive(false);
                    break;
                case 3:
                    textAttacks.gameObject.SetActive(true);
                    dropdownWoundTriggers.gameObject.SetActive(true);
                    dropdownChargeTriggers.gameObject.SetActive(false);
                    break;
                default:
                    dropdownChargeTriggers.gameObject.SetActive(false);
                    break;
            }
            switch (FightTriggers) {
                case 1:
                case 2:
                case 3:
                    dropdownFightsTriggers.gameObject.SetActive(true);
                    break;
                case 4:
                    textAttacks.gameObject.SetActive(true);
                    dropdownAttackTriggers.gameObject.SetActive(true);
                    dropdownFightsTriggers.gameObject.SetActive(false);
                    break;
                case 5:
                    textAttacks.gameObject.SetActive(true);
                    dropdownWoundTriggers.gameObject.SetActive(true);
                    dropdownFightsTriggers.gameObject.SetActive(false);
                    break;
                default:
                    dropdownFightsTriggers.gameObject.SetActive(false);
                    break;
            }
            if (ShootingTriggers != 1 && 
                ChargeTriggers != 2 &&
                FightTriggers != 4) 
            {
                dropdownAttackTriggers.gameObject.SetActive(false);
            }
            if (ShootingTriggers != 2 &&
                ChargeTriggers != 3 &&
                FightTriggers != 5) 
            {
                dropdownWoundTriggers.gameObject.SetActive(false);
            }
            if (ShootingTriggers != 1 &&
                ChargeTriggers != 2 &&
                FightTriggers != 4 &&
                ShootingTriggers != 2 &&
                ChargeTriggers != 3 &&
                FightTriggers != 5) 
            {
                textAttacks.gameObject.SetActive(false);
            }
            if ((dropdownMorale.IsActive() && MoraleTriggers == 3) || 
                (dropdownAttackTriggers.IsActive() && AttackTriggers == 3) || 
                (dropdownWoundTriggers.IsActive() && WoundTriggers == 1) || 
                (dropdownPowerTriggers.IsActive() && PowerTriggers == 3) ||
                (dropdownDenyTriggers.IsActive() && DenyTriggers == 1) ||
                (dropdownChargeTriggers.IsActive() && SpecificChargeTriggers == 3)) 
            {
                textRollOf.gameObject.SetActive(true);
                dropdownRollTrigger.gameObject.SetActive(true);
            } else {
                textRollOf.gameObject.SetActive(false);
                dropdownRollTrigger.gameObject.SetActive(false);
            }
        } else {
            dropdownPowerTriggers.gameObject.SetActive(false);
            dropdownDenyTriggers.gameObject.SetActive(false);
            textAttacks.gameObject.SetActive(false);
            dropdownAttackTriggers.gameObject.SetActive(false);
            dropdownWoundTriggers.gameObject.SetActive(false);
            dropdownChargeTriggers.gameObject.SetActive(false);
            dropdownFightsTriggers.gameObject.SetActive(false);
            textRollOf.gameObject.SetActive(false);
            dropdownRollTrigger.gameObject.SetActive(false);
            panelSpecificTriggers.SetActive(false);
            AdjustPanels();
        }
    }

    public void ToggleRuleTarget () {

        if (ActivationType != 0) {
            panelRuleTarget.SetActive(true);
            AdjustPanels();
        } else {
            panelRuleTarget.SetActive(false);
            AdjustPanels();
        }
    }

    public void ToggleRuleType () {

        if (RuleTarget != 0) {
            panelRuleType.SetActive(true);
            AdjustPanels();
        } else {
            panelRuleType.SetActive(false);
            AdjustPanels();
        }
    }

    public void ToggleKeyword () {

        if (RuleTarget == 11) {

            inputKeyword.gameObject.SetActive(true);
            dropdownTarget.gameObject.SetActive(true);
            
        } else {

            inputKeyword.gameObject.SetActive(false);
            dropdownTarget.gameObject.SetActive(false);
        }
    }

    public void ToggleProperties () {

        if ((RuleTarget != 0 && RuleTarget != 9 && RuleTarget != 10) ||
            RuleType == 1 || RuleType == 2 || RuleType == 3 || RuleType == 10) {

            panelProperties.SetActive(true);
            AdjustPanels();

            if ((RuleTarget != 0 &&
                 RuleTarget != 9 &&
                 RuleTarget != 10) ||
                 RuleType == 1) {

                panelProperties.SetActive(true);
                textRange.gameObject.SetActive(true);
                inputRange.gameObject.SetActive(true);
            } else {
                textRange.gameObject.SetActive(false);
                inputRange.gameObject.SetActive(false);
            }

            if ((RuleType == 1 && ReserveDealsMortal) ||
                RuleType == 10) {
                textDamage.gameObject.SetActive(true);
                dropdownDamage.gameObject.SetActive(true);
            } else {
                textDamage.gameObject.SetActive(false);
                dropdownDamage.gameObject.SetActive(false);
            }

            if (RuleType == 2 ||
                RuleType == 3 ||
                RuleType == 10 ||
                ReserveDealsMortal) {

                textRoll.gameObject.SetActive(true);
                dropdownRoll.gameObject.SetActive(true);
            } else {
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
            }

        } else {
            panelProperties.SetActive(false);
            AdjustPanels();
        }
    }

    //public void ToggleRange() {

    //    if ((RuleTarget != 0 &&
    //        RuleTarget != 9 &&
    //        RuleTarget != 10) ||
    //        RuleType == 1) {

    //        panelProperties.SetActive(true);
    //        textRange.gameObject.SetActive(true);
    //        inputRange.gameObject.SetActive(true);
    //    } else {
    //        textRange.gameObject.SetActive(false);
    //        inputRange.gameObject.SetActive(false);
    //    }
    //}

    //public void ToggleDamage () {

    //    if ((RuleType == 1 && ReserveDealsMortal)||
    //        RuleType == 10) {
    //        textDamage.gameObject.SetActive(true);
    //        dropdownDamage.gameObject.SetActive(true);
    //    } else {
    //        textDamage.gameObject.SetActive(false);
    //        dropdownDamage.gameObject.SetActive(false);
    //    }
    //}

    //public void ToggleRoll () {

    //    if (RuleType == 2 ||
    //        RuleType == 3 ||
    //        RuleType == 10) {

    //        textRoll.gameObject.SetActive(true);
    //        dropdownRoll.gameObject.SetActive(true);
    //    } else {
    //        textRoll.gameObject.SetActive(false);
    //        dropdownRoll.gameObject.SetActive(false);
    //    }
    //}

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
                if (ReserveDealsMortal) {
                    textRoll.gameObject.SetActive(true);
                    dropdownRoll.gameObject.SetActive(true);
                }
                panelReserve.SetActive(true);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                AdjustPanels();
                break;
            case 2:
                textDamage.gameObject.SetActive(false);
                dropdownDamage.gameObject.SetActive(false);
                textRoll.gameObject.SetActive(true);
                dropdownRoll.gameObject.SetActive(true);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                AdjustPanels();
                break;
            case 3:
                textDamage.gameObject.SetActive(false);
                dropdownDamage.gameObject.SetActive(false);
                textRoll.gameObject.SetActive(true);
                dropdownRoll.gameObject.SetActive(true);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                AdjustPanels();
                break;
            case 4:
                textDamage.gameObject.SetActive(false);
                dropdownDamage.gameObject.SetActive(false);
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(true);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                AdjustPanels();
                break;
            case 5:
                textDamage.gameObject.SetActive(false);
                dropdownDamage.gameObject.SetActive(false);
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(true);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                AdjustPanels();
                break;
            case 6:
                textDamage.gameObject.SetActive(false);
                dropdownDamage.gameObject.SetActive(false);
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(true);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                AdjustPanels();
                break;
            case 9:
                textDamage.gameObject.SetActive(false);
                dropdownDamage.gameObject.SetActive(false);
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(true);
                panelMortalWounds.SetActive(false);
                AdjustPanels();
                break;
            case 10:
                textDamage.gameObject.SetActive(true);
                dropdownDamage.gameObject.SetActive(true);
                textRoll.gameObject.SetActive(true);
                dropdownRoll.gameObject.SetActive(true);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(true);
                AdjustPanels();
                break;
            default:
                textDamage.gameObject.SetActive(false);
                dropdownDamage.gameObject.SetActive(false);
                textRoll.gameObject.SetActive(false);
                dropdownRoll.gameObject.SetActive(false);
                panelReserve.SetActive(false);
                panelProfile.SetActive(false);
                panelRoll.SetActive(false);
                panelIgnore.SetActive(false);
                panelAdditionalAttacks.SetActive(false);
                panelMortalWounds.SetActive(false);
                AdjustPanels();
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

        //panelChargeTriggers.SetActive(false);
        //panelFightTriggers.SetActive(false);
        //panelMeleeTriggers.SetActive(false);
        //panelMoraleTriggers.SetActive(false);

        panelTriggers.SetActive(false);

        //panelOverwatchTriggers.SetActive(false);
        //panelPsychicTriggers.SetActive(false);

        panelRuleUse.SetActive(false);

        //panelShootingTriggers.SetActive(false);

        panelActivation.SetActive(false);
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

            //panelChargeTriggers.SetActive(true);
            //panelFightTriggers.SetActive(true);
            //panelMeleeTriggers.SetActive(true);
            //panelMoraleTriggers.SetActive(true);
            panelTriggers.SetActive(true);
            //panelOverwatchTriggers.SetActive(true);
            //panelPsychicTriggers.SetActive(true);
            panelRuleUse.SetActive(true);
            //panelShootingTriggers.SetActive(true);
            panelActivation.SetActive(true);

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
