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
    public Dropdown dropdownTarget;
    public InputField inputKeyword;
    public Dropdown dropdownKeywordTarget;
    public GameObject panelProperties;
    public Text textRange;
    public InputField inputRange;
    public Text textDamage;
    public Dropdown dropdownDamage;
    public Text textRoll;
    public Dropdown dropdownRoll;
    public GameObject panelRuleType;
    public GameObject panelReserve;
    public Toggle toggleOutsideEnemy;
    public Toggle toggleFromObject;
    public Toggle toggleRerollCharges;
    public Toggle toggleReserveMortal;
    public InputField inputReserveRange;
    public GameObject panelProfile;
    public Dropdown dropdownProfile;
    public Dropdown dropdownProfileModifier;
    public Dropdown dropdownProfileChange;
    public GameObject panelRoll;
    public Text textModifier;
    public Dropdown dropdownModifiedRoll;
    public Dropdown dropdownModifiedBy;
    public Dropdown dropdownModifier;
    public GameObject panelIgnore;
    public GameObject panelAdditionalAttacks;
    public Toggle toggleOnlyAttack;
    public Toggle toggleCanExplode;
    public GameObject panelMortalWounds;

    public GameObject panelNameCheck;
    public GameObject panelLoad;
    public GameObject contentLoad;
    public GameObject buttonRule;
    public InputField searchField;

    public string InputName { get; set; }

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
    public int RuleType { get; set; }

    //Properties
    public int Range { get; set; }
    public int Damage { get; set; }
    public int Roll { get; set; }

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
    //bool triggersSet = false;
    int ruleToLoad;
    Color defaultColor;
    Color panelColor1;
    Color panelColor2;
    ButtonRule[] buttonRules;

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

        Assert.IsTrue((useToggles.Length > 0), "The Use Toggles have not been added to the Rule UI.");
        Assert.IsNotNull(panelRuleTarget, "The Rule Target panel has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownTarget, "The Target dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(inputKeyword, "The Keyword input has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownKeywordTarget, "The Keyword Target dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(textRange, "The Range default text has not been added to the Rule UI.");
        Assert.IsNotNull(inputRange, "The Range input field has not been added to the Rule UI.");
        Assert.IsNotNull(textDamage, "The Damage text has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownDamage, "The Damage dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(textRoll, "The Roll text has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownRoll, "The Roll dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(inputReserveRange, "The Range input field has not been added to the Rule UI.");
        Assert.IsNotNull(panelRuleType, "The Rule Type panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelReserve, "The Reserve panel has not been added to the Rule UI.");
        Assert.IsNotNull(toggleOutsideEnemy, "The Reserve Outside Enemy toggle has not been added to the Rule UI.");
        Assert.IsNotNull(toggleFromObject, "The Reserve From Object toggle has not been added to the Rule UI.");
        Assert.IsNotNull(toggleRerollCharges, "The Reserve Re-roll Charges toggle has not been added to the Rule UI.");
        Assert.IsNotNull(toggleReserveMortal, "The Reserve Mortal Wounds toggle has not been added to the Rule UI.");
        Assert.IsNotNull(panelProfile, "The Profile panel has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownProfile, "The Profile dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownProfileModifier, "The Profile Modifier dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownProfileChange, "The Profile Change dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(panelRoll, "The Pass Roll panel has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownModifiedRoll, "The Modified Roll dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownModifiedBy, "The Modified By dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(textModifier, "The Modifier text has not been added to the Rule UI.");
        Assert.IsNotNull(dropdownModifier, "The Modifier dropdown has not been added to the Rule UI.");
        Assert.IsNotNull(panelIgnore, "The Ignore panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelAdditionalAttacks, "The Aditional Attack panel has not been added to the Rule UI.");
        Assert.IsNotNull(toggleOnlyAttack, "The Only Attack toggle has not been added to the Rule UI.");
        Assert.IsNotNull(toggleCanExplode, "The Can Explode toggle has not been added to the Rule UI.");
        Assert.IsNotNull(panelRuleUse, "The Rule Use panel has not been added to the Rule UI.");

        Assert.IsNotNull(panelNameCheck, "The Name Check panel has not been added to the Rule UI.");
        Assert.IsNotNull(panelLoad, "The Load panel has not been added to the Rule UI.");
    }
    // Use this for initialization
    void Start () {

        instance = GameManager.instance;
        defaultColor = textRange.color;
        panelColor1 = panelRuleUse.GetComponent<Image>().color;
        panelColor2 = panelActivation.GetComponent<Image>().color;

        if (instance.Rules.Count > 0) {
            buttonLoad.interactable = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (searchField) {

            string searchTerm = searchField.GetComponent<InputField>().text;

            for (int i = 0; i < buttonRules.Length; i++) {
                buttonRules[i].gameObject.SetActive(true);
            }

            if (searchTerm.Length > 0) {

                for (int i = 0; i < searchTerm.Length; i++) {

                    for (int n = 0; n < buttonRules.Length; n++) {

                        string sTemp = buttonRules[n].Rule.Name;
                        if (searchTerm[i] != sTemp[i]) {

                            buttonRules[n].gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
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
        if (panelRoll.activeInHierarchy) {
            panelOffset = AdjustAnchors(panelOffset, panelRoll);
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
            if ((dropdownMove.IsActive() && MoveTriggers == 3) ||
                (dropdownMorale.IsActive() && MoraleTriggers == 3) || 
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
            dropdownKeywordTarget.gameObject.SetActive(true);
            
        } else {

            inputKeyword.gameObject.SetActive(false);
            dropdownKeywordTarget.gameObject.SetActive(false);
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

    //public void Continue () {

    //    //panelChargeTriggers.SetActive(false);
    //    //panelFightTriggers.SetActive(false);
    //    //panelMeleeTriggers.SetActive(false);
    //    //panelMoraleTriggers.SetActive(false);

    //    panelTriggers.SetActive(false);

    //    //panelOverwatchTriggers.SetActive(false);
    //    //panelPsychicTriggers.SetActive(false);

    //    panelRuleUse.SetActive(false);

    //    //panelShootingTriggers.SetActive(false);

    //    panelActivation.SetActive(false);
    //    panelRuleUse.SetActive(true);

    //    triggersSet = true;
    //}

    public void Save (bool overwrite) {

        rule = new Rule();
        bool datacheckPassed = true;

        datacheckPassed = Datacheck();

        if (datacheckPassed) {
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
                instance.SaveProfile();
                buttonLoad.interactable = true;
            } else if (overwrite) {
                instance.Rules[ruleToLoad] = rule;
                panelNameCheck.SetActive(false);
            } else {
                panelNameCheck.SetActive(true);
            }

            Debug.Log("New Rule name is " + rule.Name + ". It has been added to the rule data as " + instance.Rules.Last().Name + ".");
            buttonLoad.interactable = true;
        }
    }

    bool Datacheck () {

        bool dataPassed = true;

        if (inputName.text.Length == 0) {
            Debug.Log("You must name your rule.");
            dataPassed = false;
            return dataPassed;
        } else {
            rule.Name = inputName.text;
            Debug.Log("Rule name: " + rule.Name);
        }

        //Uses
        if (UseDeployment) { rule.UseTimes.Add(Rule.Uses.Deployment); Debug.Log("Rule can be used in deployment."); }
        if (UseStartOfGame) { rule.UseTimes.Add(Rule.Uses.StartOfGame); Debug.Log("Rule can be used at the start of the game."); }
        if (UseYourTurn) { rule.UseTimes.Add(Rule.Uses.YourTurn); Debug.Log("Rule can be used on your turn."); }
        if (UseOpponentsTurn) { rule.UseTimes.Add(Rule.Uses.OpponentsTurn); Debug.Log("Rule can be used during the opponents turn."); }
        if (UseStartOfTurn) { rule.UseTimes.Add(Rule.Uses.StartOfTurn); Debug.Log("Rule can be used at the start of the turn."); }
        if (UseMove) { rule.UseTimes.Add(Rule.Uses.Move); Debug.Log("Rule can be used in the move phase."); }
        if (UsePsychic) { rule.UseTimes.Add(Rule.Uses.Psychic); Debug.Log("Rule can be used in the psychic phase."); }
        if (UseShooting) { rule.UseTimes.Add(Rule.Uses.Shooting); Debug.Log("Rule can be used in the shooting phase."); }
        if (UseCharge) { rule.UseTimes.Add(Rule.Uses.Charge); Debug.Log("Rule can be used in the charge phase."); }
        if (UseFight) { rule.UseTimes.Add(Rule.Uses.Fight); Debug.Log("Rule can be used in the fight phase."); }
        if (UseMorale) { rule.UseTimes.Add(Rule.Uses.Morale); Debug.Log("Rule can be used in the morale phase."); }
        if (UseEndOfTurn) { rule.UseTimes.Add(Rule.Uses.EndOfTurn); Debug.Log("Rule can be used at the end of the turn."); }
        if (UseEndOfGame) { rule.UseTimes.Add(Rule.Uses.EndOfGame); Debug.Log("Rule can be used at the end of the game."); }

        //Activation
        if (ActivationType == 0) {
            Debug.Log("You must select an activation type.");
            dataPassed = false;
            return dataPassed;
        }
        rule.ActivationType = (Rule.ActivationTypes)ActivationType;
        Debug.Log("Rule has an activation type of " + rule.ActivationType);

        //Triggers
        if (ActivationType == 3) {
            if (UseMove) {
                rule.MoveTrigger = new Rule.MoveTriggers();
                rule.MoveTrigger = (Rule.MoveTriggers)MoveTriggers;
                Debug.Log("Rule is triggered during the move phase on " + rule.MoveTrigger);
                if (MoveTriggers == 3) {
                    if (RollTrigger != 0) {
                        rule.RollTrigger = RollTrigger;
                        Debug.Log("Rule is triggered on and advance roll of " + rule.RollTrigger);
                    } else {
                        Debug.Log("You must select a value for the roll trigger.");
                        dataPassed = false;
                        return dataPassed;
                    }
                }
            }
            if (UsePsychic) {
                rule.PsychicTrigger = new Rule.PsychicTriggers();
                rule.PsychicTrigger = (Rule.PsychicTriggers)PsychicTriggers;
                Debug.Log("Rule is triggered during the psychic phase on" + rule.PsychicTrigger);
                if (PsychicTriggers == 1) {
                    rule.PowerTrigger = new Rule.PowerTriggers();
                    rule.PowerTrigger = (Rule.PowerTriggers)PowerTriggers;
                    Debug.Log("Rule is triggered when a player uses a power on " + rule.PowerTrigger);
                    if (PowerTriggers == 3) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on psychic test rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (PsychicTriggers == 2) {
                    rule.DenyTrigger = new Rule.DenyTriggers();
                    rule.DenyTrigger = (Rule.DenyTriggers)DenyTriggers;
                    Debug.Log("Rule is triggered when a player tries to deny a power on " + rule.DenyTrigger);
                    if (DenyTriggers == 1) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on deny rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
            }
            if (UseShooting) {
                rule.ShootingTrigger = new Rule.ShootingTriggers();
                rule.ShootingTrigger = (Rule.ShootingTriggers)ShootingTriggers;
                Debug.Log("Rule is triggered during the shooting phase on " + rule.ShootingTrigger);
                if (ShootingTriggers == 1) {
                    rule.AttackTrigger = new Rule.AttackTriggers();
                    rule.AttackTrigger = (Rule.AttackTriggers)AttackTriggers;
                    Debug.Log("Rule is triggered when a player shoots on " + rule.AttackTrigger);
                    if (AttackTriggers == 2) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on shooting rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (ShootingTriggers == 2) {
                    rule.WoundTrigger = new Rule.WoundTriggers();
                    rule.WoundTrigger = (Rule.WoundTriggers)WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (WoundTriggers == 1) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
            }
            if (UseCharge) {
                rule.ChargeTrigger = new Rule.ChargeTriggers();
                rule.ChargeTrigger = (Rule.ChargeTriggers)ChargeTriggers;
                Debug.Log("Rule is triggered during the charge phase on " + rule.ChargeTrigger);
                if (ChargeTriggers == 1) {
                    rule.SpecificChargeTrigger = new Rule.SpecificChargeTriggers();
                    rule.SpecificChargeTrigger = (Rule.SpecificChargeTriggers)SpecificChargeTriggers;
                    Debug.Log("Rule is triggered when a charges on " + rule.SpecificChargeTrigger);
                    if (SpecificChargeTriggers == 3) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on charge rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (ChargeTriggers == 2) {
                    rule.AttackTrigger = new Rule.AttackTriggers();
                    rule.AttackTrigger = (Rule.AttackTriggers)AttackTriggers;
                    Debug.Log("Rule is triggered when a player can overwatch on " + rule.AttackTrigger);
                    if (AttackTriggers == 2) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on charge rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (ChargeTriggers == 3) {
                    rule.WoundTrigger = new Rule.WoundTriggers();
                    rule.WoundTrigger = (Rule.WoundTriggers)WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (WoundTriggers == 1) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
            }
            if (UseFight) {
                rule.FightTrigger = new Rule.FightTriggers();
                rule.FightTrigger = (Rule.FightTriggers)FightTriggers;
                Debug.Log("Rule is triggered during the fight phase " + rule.FightTrigger);
                if (FightTriggers == 1 || FightTriggers == 2 || FightTriggers == 3) {
                    rule.SpecificFightsTrigger = new Rule.SpecificFightsTriggers();
                    rule.SpecificFightsTrigger = (Rule.SpecificFightsTriggers)SpecificFightsTriggers;
                    Debug.Log("Rule is triggered during fights on " + rule.SpecificFightsTrigger);
                }
                if (FightTriggers == 4) {
                    rule.AttackTrigger = new Rule.AttackTriggers();
                    rule.AttackTrigger = (Rule.AttackTriggers)AttackTriggers;
                    Debug.Log("Rule is triggered when a player attacks on " + rule.AttackTrigger);
                    if (AttackTriggers == 2) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (FightTriggers == 5) {
                    rule.WoundTrigger = new Rule.WoundTriggers();
                    rule.WoundTrigger = (Rule.WoundTriggers)WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (WoundTriggers == 1) {
                        if (RollTrigger != 0) {
                            rule.RollTrigger = RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
            }
            if (UseMorale) {
                rule.MoraleTrigger = new Rule.MoraleTriggers();
                rule.MoraleTrigger = (Rule.MoraleTriggers)MoraleTriggers;
                Debug.Log("Rule is triggered during the morale " + rule.MoraleTrigger);
                if (MoraleTriggers == 3) {
                    if (RollTrigger != 0) {
                        rule.RollTrigger = RollTrigger;
                        Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                    } else {
                        Debug.Log("You must select a value for the roll trigger.");
                        dataPassed = false;
                        return dataPassed;
                    }
                }
            }
        }

        if (RuleTarget == 0) {
            Debug.Log("Your rule requires a target.");
            dataPassed = false;
            return dataPassed;
        } else {
            rule.Target = (Rule.Targets)RuleTarget;
            Debug.Log("The rule targets " + rule.Target);
            if (RuleTarget == 11 && InputKeyword.Length == 0) {
                Debug.Log("Enter the keyword your rule targets.");
                dataPassed = false;
                return dataPassed;
            } else {
                rule.Keyword = InputKeyword;
                Debug.Log("The rule targets the keyword " + rule.Keyword);
                rule.KeywordTarget = (Rule.KeywordTargets)KeywordTarget;
            }
        }

        if (RuleType == 0) {
            Debug.Log("Select the type of rule.");
            dataPassed = false;
            return dataPassed;
        } else {
            rule.RuleType = (Rule.RuleTypes)RuleType;
            Debug.Log("The rule is a " + rule.RuleType);
            if ((RuleTarget != 9 && RuleTarget != 10) || RuleType == 1) {
                rule.Range = Range;
                Debug.Log("Rule Range is " + rule.Range);
            }
            if ((RuleType == 1 && ReserveDealsMortal) || RuleType == 10) {
                if (Damage != 0) {
                    if (Damage < 7) {
                        rule.Damage = Damage;
                        Debug.Log("Rule Damage is " + rule.Range);
                    } else {
                        rule.DamageDice = new Rule.Dice();
                        rule.DamageDice = (Rule.Dice)(Damage - 7);
                        Debug.Log("Rule Damage is " + rule.DamageDice);
                    }
                } else {
                    Debug.Log("Select the damage the rule deals.");
                    dataPassed = false;
                    return dataPassed;
                }
            }
            if (RuleType == 2 || RuleType == 3 || RuleType == 10) {
                if (Roll != 0) {
                    rule.Roll = Roll;
                    Debug.Log("Rule passes on rolls of " + rule.Range);
                } else {
                    Debug.Log("Select the passing roll for the rule.");
                    dataPassed = false;
                    return dataPassed;
                }
            }
            if (RuleType == 1) {
                rule.ReserveOutsideEnemy = ReserveOutsideEnemy;
                if (rule.ReserveOutsideEnemy) Debug.Log("Deploy from reserve away from the enemy.");
                rule.ReserveFromObject = ReserveFromObject;
                if (rule.ReserveFromObject) Debug.Log("Deploy from reserve near an object.");
                rule.RerollCharges = ReserveRerollCharges;
                if (rule.RerollCharges) Debug.Log("Reroll charges after deploying from reserve.");
                rule.ReserveMortalWounds = ReserveDealsMortal;
                if (rule.ReserveOutsideEnemy) Debug.Log("Deploying from reserve deals mortal wounds.");
                if (ReserveDealsMortal) {
                    rule.ReserveRange = ReserveDamageRange;
                    Debug.Log("Deal mortal wounds to targets within " + rule.ReserveRange);
                }
            }
            if (RuleType == 4) {
                rule.Profile = new Rule.Profiles();
                rule.Profile = (Rule.Profiles)Profile;
                Debug.Log("Rule changes the following profile " + rule.Profile);
                rule.Modify = new Rule.Modifiers();
                rule.Modify = (Rule.Modifiers)Modifier;
                Debug.Log("Profile changed by " + rule.Modify);
                if (Change != 0) {
                    if (Change < 7) {
                        rule.ProfileChange = Change;
                        Debug.Log("And modified by " + rule.ProfileChange);
                    } else {
                        rule.ChangeDice = new Rule.Dice();
                        rule.ChangeDice = (Rule.Dice)(Change - 7);
                        Debug.Log("And modified by " + rule.ChangeDice);
                    }
                } else {
                    Debug.Log("Select the amount the profile changes.");
                    dataPassed = false;
                    return dataPassed;
                }
            }
            if (RuleType == 5) {
                rule.RollModified = new Rule.Rolls();
                rule.RollModified = (Rule.Rolls)RollModified;
                Debug.Log("Rule modifies " + rule.RollModified + " rolls.");
                rule.RollModifiedBy = new Rule.RollModifiers();
                rule.RollModifiedBy = (Rule.RollModifiers)ModifiedBy;
                Debug.Log("Roll is modified by " + rule.RollModifiedBy);
                if (RollModifier == 0) {
                    Debug.Log("Select the amount the roll is modified by.");
                    dataPassed = false;
                    return dataPassed;
                } else {
                    rule.RollModifierAmount = RollModifier;
                    Debug.Log("Roll is modified by " + rule.RollModifierAmount);
                }
            }
            if (RuleType == 6) {
                rule.IgnoreProfile = new Rule.IgnoreProfiles();
                rule.IgnoreProfile = (Rule.IgnoreProfiles)PenaltyIgnored;
                Debug.Log("Penalties are ignored for " + rule.IgnoreProfile);
            }
            if (RuleType == 9) {
                rule.AdditionalAttackOnly = OnlyAdditionalAttack;
                if (rule.AdditionalAttackOnly) Debug.Log("Rule forces the attack only on additional attacks.");
                rule.AdditionalAttacksCanExplode = CanExplode;
                if (rule.AdditionalAttacksCanExplode) Debug.Log("Additional attacks can explode.");
            }
            if (RuleType == 10) {
                rule.SlayTheModel = SlayTheModel;
                if (rule.SlayTheModel) Debug.Log("Rule slays the target model.");
            }
        }

        return dataPassed;
    }

    public void Close(bool overwrite) {
        if ( ! overwrite) {
            Button[] buttons = contentLoad.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++) {
                Destroy(buttons[i].gameObject);
            }

            buttonSave.interactable = true;
            buttonLoad.interactable = true;
            searchField = null;
            panelLoad.SetActive(false);
        } else {
            panelNameCheck.SetActive(false);
        }
    }

    public void LoadSavedRule() {
        ResetLoad(instance.Rules[ruleToLoad]);
        panelNameCheck.SetActive(false);
    }

    public void Load() {
        buttonSave.interactable = false;
        buttonLoad.interactable = false;

        panelLoad.SetActive(true);
        if (instance.Rules.Count > 6) {
            contentLoad.GetComponent<RectTransform>().offsetMin = new Vector2(0, -48 * (instance.Rules.Count - 6));
        }
        for (int i = 0; i < instance.Rules.Count; i++) {
            string ruleName = instance.Rules[i].Name;
            GameObject ruleButton = Instantiate(buttonRule);
            ruleButton.transform.SetParent(contentLoad.transform);
            ruleButton.GetComponent<ButtonRule>().Rule = instance.Rules[i];
            ruleButton.GetComponent<RectTransform>().localScale = Vector3.one;
            ruleButton.GetComponentInChildren<Text>().text = ruleName;
        }

        buttonRules = FindObjectsOfType<ButtonRule>();
        searchField = panelLoad.GetComponentInChildren<InputField>();
    }

    public void ResetLoad(Rule rule) {

        InputName = rule.Name;
        inputName.text = InputName;

        for (int i = 0; i < rule.UseTimes.Count; i++) {
            if (rule.UseTimes[i] == Rule.Uses.Deployment) {
                UseDeployment = true;
                useToggles[0].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.StartOfGame) {
                UseStartOfGame = true;
                useToggles[1].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.YourTurn) {
                UseYourTurn = true;
                useToggles[2].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.OpponentsTurn) {
                UseOpponentsTurn = true;
                useToggles[3].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.StartOfTurn) {
                UseStartOfTurn = true;
                useToggles[4].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Move) {
                UseMove = true;
                useToggles[5].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Psychic) {
                UsePsychic = true;
                useToggles[6].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Shooting) {
                UseShooting = true;
                useToggles[7].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Charge) {
                UseCharge = true;
                useToggles[8].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Fight) {
                UseFight = true;
                useToggles[9].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Morale) {
                UseMorale = true;
                useToggles[10].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.EndOfTurn) {
                UseEndOfTurn = true;
                useToggles[11].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.EndOfGame) {
                UseEndOfGame = true;
                useToggles[12].isOn = true;
            }
        }

        ActivationType = (int)rule.ActivationType;
        panelActivation.GetComponentInChildren<Dropdown>().value = ActivationType;

        if (ActivationType == 3) {
            if (rule.MoveTrigger != 0) {
                MoveTriggers = (int)rule.MoveTrigger;
                dropdownMove.value = MoveTriggers;
            }
            if (rule.PsychicTrigger != 0) {
                PsychicTriggers = (int)rule.PsychicTrigger;
                dropdownPsychic.value = PsychicTriggers;
            }
            if (rule.ShootingTrigger != 0) {
                ShootingTriggers = (int)rule.ShootingTrigger;
                dropdownShooting.value = ShootingTriggers;
            }
            if (rule.ChargeTrigger != 0) {
                ChargeTriggers = (int)rule.ChargeTrigger;
                dropdownCharge.value = ChargeTriggers;
            }
            if (rule.FightTrigger != 0) {
                FightTriggers = (int)rule.FightTrigger;
                dropdownFightsTriggers.value = FightTriggers;
            }
            if (rule.MoraleTrigger != 0) {
                MoraleTriggers = (int)rule.MoraleTrigger;
                dropdownMorale.value = MoraleTriggers;
            }
            if (rule.AttackTrigger != 0) {
                AttackTriggers = (int)rule.AttackTrigger;
                dropdownAttackTriggers.value = AttackTriggers;
            }
            if (rule.WoundTrigger != 0) {
                WoundTriggers = (int)rule.WoundTrigger;
                dropdownWoundTriggers.value = WoundTriggers;
            }
            if (rule.PowerTrigger != 0) {
                PowerTriggers = (int)rule.PowerTrigger;
                dropdownPowerTriggers.value = PowerTriggers;
            }
            if (rule.DenyTrigger != 0) {
                DenyTriggers = (int)rule.DenyTrigger;
                dropdownDenyTriggers.value = DenyTriggers;
            }
            if (rule.ChargeTrigger != 0) {
                ChargeTriggers = (int)rule.ChargeTrigger;
                dropdownChargeTriggers.value = ChargeTriggers;
            }
            if (rule.SpecificFightsTrigger != 0) {
                SpecificFightsTriggers = (int)rule.SpecificFightsTrigger;
                dropdownFightsTriggers.value = SpecificFightsTriggers;
            }
        }

        RuleTarget = (int)rule.Target;
        dropdownTarget.value = RuleTarget;
        if (RuleTarget != 9 &&
            RuleTarget != 10) {

            Range = rule.Range;
            inputRange.text = Range.ToString();

            if (RuleTarget == 11) {
                InputKeyword = rule.Keyword;
                inputKeyword.text = InputKeyword;
                KeywordTarget = (int)rule.KeywordTarget;
                dropdownKeywordTarget.value = KeywordTarget;
            }
        }

        RuleType = (int)rule.RuleType;
        panelRuleType.GetComponentInChildren<Dropdown>().value = RuleType;
        switch (RuleType) {
            case 1: 
                ReserveOutsideEnemy = rule.ReserveOutsideEnemy;
                toggleOutsideEnemy.isOn = ReserveOutsideEnemy;
                ReserveFromObject = rule.ReserveFromObject;
                toggleFromObject.isOn = ReserveFromObject;
                ReserveRerollCharges = rule.RerollCharges;
                toggleRerollCharges.isOn = ReserveRerollCharges;
                ReserveDealsMortal = rule.ReserveMortalWounds;
                toggleReserveMortal.isOn = ReserveDealsMortal;

                if (ReserveDealsMortal) {
                    ReserveDamageRange = rule.ReserveRange;
                    inputReserveRange.text = ReserveDamageRange.ToString();
                    if (rule.Damage == 0) {
                        Damage = (int)rule.DamageDice + 7;
                    }
                    dropdownDamage.value = Damage;
                }
                break;
            case 2:
            case 3:
                Roll = rule.Roll;
                dropdownRoll.value = Roll;
                break;
            case 4:
                Profile = (int)rule.Profile;
                dropdownProfile.value = Profile;
                Modifier = (int)rule.Modify;
                dropdownProfileModifier.value = Modifier;
                if (rule.ProfileChange == 0) {
                    Change = (int)rule.ChangeDice + 7;
                } else {
                    Change = rule.ProfileChange;
                }
                dropdownProfileChange.value = Change;
                break;
            case 5:
                RollModified = (int)rule.RollModified;
                dropdownModifiedRoll.value = RollModified;
                ModifiedBy = (int)rule.RollModifiedBy;
                dropdownModifiedBy.value = ModifiedBy;
                RollModifier = (int)rule.RollModifierAmount;
                dropdownModifier.value = RollModifier;
                break;
            case 6:
                PenaltyIgnored = (int)rule.IgnoreProfile;
                panelIgnore.GetComponentInChildren<Dropdown>().value = PenaltyIgnored;
                break;
            case 9:
                OnlyAdditionalAttack = rule.AdditionalAttackOnly;
                toggleOnlyAttack.isOn = OnlyAdditionalAttack;
                CanExplode = rule.AdditionalAttacksCanExplode;
                toggleCanExplode.isOn = CanExplode;
                break;
            case 10:
                if (rule.Damage == 0) {
                    Damage = (int)rule.DamageDice + 7;
                }
                dropdownDamage.value = Damage;
                Roll = rule.Roll;
                dropdownRoll.value = Roll;
                SlayTheModel = rule.SlayTheModel;
                panelMortalWounds.GetComponentInChildren<Toggle>().isOn = SlayTheModel;
                break;
        }
    }

    public void Back() {

        SceneManager.LoadScene("Start");

        //if (triggersSet) {

        //    //panelChargeTriggers.SetActive(true);
        //    //panelFightTriggers.SetActive(true);
        //    //panelMeleeTriggers.SetActive(true);
        //    //panelMoraleTriggers.SetActive(true);
        //    panelTriggers.SetActive(true);
        //    //panelOverwatchTriggers.SetActive(true);
        //    //panelPsychicTriggers.SetActive(true);
        //    panelRuleUse.SetActive(true);
        //    //panelShootingTriggers.SetActive(true);
        //    panelActivation.SetActive(true);

        //    panelRuleUse.SetActive(false);

        //    triggersSet = false;

        //} else {
        //    SceneManager.LoadScene("Start");
        //}
    }

    public void Exit() {
        instance.OnDisable();
        Application.Quit();
    }
}
