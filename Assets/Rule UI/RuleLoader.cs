using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class RuleLoader : MonoBehaviour
{
    GameManager instance;
    RuleUI ui;
    RuleSetter setter;

    public int RuleToLoad { get; set; }

    public InputField searchField;

    ButtonRule[] buttonRules;

    bool rulesLoaded;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Could not find Game Manager.");
        setter = FindObjectOfType<RuleSetter>();
        Assert.IsNotNull(setter, "Could not find Rule Setter.");
        ui = FindObjectOfType<RuleUI>();
        Assert.IsNotNull(ui, "Could not find Rule UI.");
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.panelLoad.activeInHierarchy && rulesLoaded) {

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

    public void StartLoadPanel() {

        instance = GameManager.instance;
        ui = FindObjectOfType<RuleUI>();

        if (instance.Rules.Count > 6) {
            ui.contentLoad.GetComponent<RectTransform>().offsetMin = new Vector2(0, -48 * (instance.Rules.Count - 6));
        }
        for (int i = 0; i < instance.Rules.Count; i++) {
            string ruleName = instance.Rules[i].Name;
            GameObject ruleButton = Instantiate(ui.buttonRule);
            ruleButton.transform.SetParent(ui.contentLoad.transform);
            ruleButton.GetComponent<ButtonRule>().Rule = instance.Rules[i];
            ruleButton.GetComponent<RectTransform>().localScale = Vector3.one;
            ruleButton.GetComponentInChildren<Text>().text = ruleName;
        }

        buttonRules = FindObjectsOfType<ButtonRule>();
        //searchField = ui.panelLoad.GetComponentInChildren<InputField>();
        rulesLoaded = true;
    }

    public void ResetLoad(Rule rule) {

        setter.InputName = rule.Name;
        ui.inputName.text = setter.InputName;
        Debug.Log("Rule name is " + setter.InputName);

        Debug.Log("Resetting toggles.");
        ui.SwitchUseToggles(false);

        for (int i = 0; i < rule.UseTimes.Count; i++) {
            if (rule.UseTimes[i] == Rule.Uses.Deployment) {
                setter.UseDeployment = true;
                Debug.Log("Rule can be used during deployment.");
                ui.useToggles[0].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.StartOfGame) {
                setter.UseStartOfGame = true;
                Debug.Log("Rule can be used at the start of the game.");
                ui.useToggles[1].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.YourTurn) {
                setter.UseYourTurn = true;
                Debug.Log("Rule can be used during your turn.");
                ui.useToggles[2].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.OpponentsTurn) {
                setter.UseOpponentsTurn = true;
                Debug.Log("Rule can be used during your opponents turn.");
                ui.useToggles[3].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.StartOfTurn) {
                setter.UseStartOfTurn = true;
                Debug.Log("Rule can be used at the start of the turn.");
                ui.useToggles[4].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Move) {
                setter.UseMove = true;
                Debug.Log("Rule can be used during the movement phase.");
                ui.useToggles[5].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Psychic) {
                setter.UsePsychic = true;
                Debug.Log("Rule can be used during the psychic phase.");
                ui.useToggles[6].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Shooting) {
                setter.UseShooting = true;
                Debug.Log("Rule can be used during the shooting phase.");
                ui.useToggles[7].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Charge) {
                setter.UseCharge = true;
                Debug.Log("Rule can be used during the charge phase.");
                ui.useToggles[8].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Fight) {
                setter.UseFight = true;
                Debug.Log("Rule can be used during the fight phase.");
                ui.useToggles[9].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Morale) {
                setter.UseMorale = true;
                Debug.Log("Rule can be used during the morale phase.");
                ui.useToggles[10].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.EndOfTurn) {
                setter.UseEndOfTurn = true;
                Debug.Log("Rule can be used at the end of the turn.");
                ui.useToggles[11].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.EndOfGame) {
                setter.UseEndOfGame = true;
                Debug.Log("Rule can be used at the end of the game.");
                ui.useToggles[12].isOn = true;
            }
        }

        ui.ToggleActivationPanel();
        setter.ActivationType = (int)rule.ActivationType;
        ui.panelActivation.GetComponentInChildren<Dropdown>().value = setter.ActivationType;
        Debug.Log("Rule has an activation type of " + (Rule.ActivationTypes)setter.ActivationType);

        if (setter.ActivationType == 3) {
            if (rule.MoveTrigger != 0) {
                setter.MoveTriggers = (int)rule.MoveTrigger;
                ui.dropdownMove.value = setter.MoveTriggers;
                Debug.Log("Rule has a movement trigger of ." + (Rule.MoveTriggers)setter.MoveTriggers);
            }
            if (rule.PsychicTrigger != 0) {
                setter.PsychicTriggers = (int)rule.PsychicTrigger;
                ui.dropdownPsychic.value = setter.PsychicTriggers;
                Debug.Log("Rule has a psychic trigger of ." + (Rule.PsychicTriggers)setter.PsychicTriggers);
            }
            if (rule.ShootingTrigger != 0) {
                setter.ShootingTriggers = (int)rule.ShootingTrigger;
                ui.dropdownShooting.value = setter.ShootingTriggers;
                Debug.Log("Rule has a shooting trigger of ." + (Rule.ShootingTriggers)setter.ShootingTriggers);
            }
            if (rule.ChargeTrigger != 0) {
                setter.ChargeTriggers = (int)rule.ChargeTrigger;
                ui.dropdownCharge.value = setter.ChargeTriggers;
                Debug.Log("Rule has a charge trigger of ." + (Rule.ChargeTriggers)setter.ChargeTriggers);
            }
            if (rule.FightTrigger != 0) {
                setter.FightTriggers = (int)rule.FightTrigger;
                ui.dropdownFightsTriggers.value = setter.FightTriggers;
                Debug.Log("Rule has a fight trigger of ." + (Rule.FightTriggers)setter.FightTriggers);
            }
            if (rule.MoraleTrigger != 0) {
                setter.MoraleTriggers = (int)rule.MoraleTrigger;
                ui.dropdownMorale.value = setter.MoraleTriggers;
                Debug.Log("Rule has a morale trigger of ." + (Rule.MoraleTriggers)setter.MoraleTriggers);
            }
            ui.ToggleSpecificTriggers();
            if (rule.AttackTrigger != 0) {
                setter.AttackTriggers = (int)rule.AttackTrigger;
                ui.dropdownAttackTriggers.value = setter.AttackTriggers;
                Debug.Log("Rule has a movement attack of ." + (Rule.AttackTriggers)setter.AttackTriggers);
            }
            if (rule.WoundTrigger != 0) {
                setter.WoundTriggers = (int)rule.WoundTrigger;
                ui.dropdownWoundTriggers.value = setter.WoundTriggers;
                Debug.Log("Rule has a wound trigger of ." + (Rule.WoundTriggers)setter.WoundTriggers);
            }
            if (rule.PowerTrigger != 0) {
                setter.PowerTriggers = (int)rule.PowerTrigger;
                ui.dropdownPowerTriggers.value = setter.PowerTriggers;
                Debug.Log("Rule has a power trigger of ." + (Rule.PowerTriggers)setter.PowerTriggers);
            }
            if (rule.DenyTrigger != 0) {
                setter.DenyTriggers = (int)rule.DenyTrigger;
                ui.dropdownDenyTriggers.value = setter.DenyTriggers;
                Debug.Log("Rule has a Deny the Witch trigger of ." + (Rule.DenyTriggers)setter.DenyTriggers);
            }
            if (rule.ChargeTrigger != 0) {
                setter.SpecificChargeTriggers = (int)rule.SpecificChargeTrigger;
                ui.dropdownChargeTriggers.value = setter.SpecificChargeTriggers;
                Debug.Log("Rule has a specific charge trigger of ." + (Rule.SpecificChargeTriggers)setter.SpecificChargeTriggers);
            }
            if (rule.SpecificFightsTrigger != 0) {
                setter.SpecificFightsTriggers = (int)rule.SpecificFightsTrigger;
                ui.dropdownFightsTriggers.value = setter.SpecificFightsTriggers;
                Debug.Log("Rule has a specific fight trigger of ." + (Rule.SpecificFightsTriggers)setter.SpecificFightsTriggers);
            }
        }

        ui.ToggleRuleTarget();
        setter.RuleTarget = (int)rule.Target;
        ui.dropdownTarget.value = setter.RuleTarget;
        Debug.Log("Rule has a target of " + (Rule.Targets)setter.RuleTarget);
        if (setter.RuleTarget != 9 &&
            setter.RuleTarget != 10) {

            setter.Range = rule.Range;
            ui.inputRange.text = setter.Range.ToString();
            Debug.Log("rule has a range of " + setter.Range);

            if (setter.RuleTarget == 11) {
                ui.ToggleKeyword();
                setter.InputKeyword = rule.Keyword;
                ui.inputKeyword.text = setter.InputKeyword;
                setter.KeywordTarget = (int)rule.KeywordTarget;
                ui.dropdownKeywordTarget.value = setter.KeywordTarget;
                Debug.Log("Rule has the '" + setter.InputKeyword + "' keyword and targets " + (Rule.KeywordTargets)setter.KeywordTarget);
            }
        }

        ui.ToggleRuleType();
        setter.RuleType = (int)rule.RuleType;
        ui.panelRuleType.GetComponentInChildren<Dropdown>().value = setter.RuleType;
        Debug.Log("Rule type is " + (Rule.RuleTypes)setter.RuleType);
        ui.ToggleProperties();
        ui.ToggleRuleProperties(-1);
        switch (setter.RuleType) {
            case 1:
                setter.Range = rule.Range;
                ui.inputRange.text = setter.Range.ToString();
                setter.ReserveOutsideEnemy = rule.ReserveOutsideEnemy;
                ui.toggleOutsideEnemy.isOn = setter.ReserveOutsideEnemy;
                if (setter.ReserveOutsideEnemy) Debug.Log("Reserves are setup away from the enemy.");
                setter.ReserveFromObject = rule.ReserveFromObject;
                ui.toggleFromObject.isOn = setter.ReserveFromObject;
                if (setter.ReserveFromObject) Debug.Log("Reserves are setup near an object.");
                setter.ReserveRerollCharges = rule.RerollCharges;
                ui.toggleRerollCharges.isOn = setter.ReserveRerollCharges;
                if (setter.ReserveRerollCharges) Debug.Log("Reserves may reroll charges.");
                setter.ReserveDealsMortal = rule.ReserveMortalWounds;
                ui.toggleReserveMortal.isOn = setter.ReserveDealsMortal;
                if (setter.ReserveDealsMortal) Debug.Log("Reserves deal mortal wounds to nearby enemies.");

                if (setter.ReserveDealsMortal) {
                    ui.ToggleReserveRange();
                    setter.ReserveDamageRange = rule.ReserveRange;
                    ui.inputReserveRange.text = setter.ReserveDamageRange.ToString();
                    Debug.Log("Reserves deal damage within " + setter.ReserveDamageRange + " inches.");
                    if (rule.Damage == 0)
                    {
                        setter.Damage = (int)rule.DamageDice + 7;
                        Debug.Log("Rule deals " + (Rule.Dice)(setter.Damage - 7) + " damage.");
                    } else Debug.Log("Rule deals " + setter.Damage + " damage.");
                    ui.dropdownDamage.value = setter.Damage;
                }
                break;
            case 2:
            case 3:
                setter.Roll = rule.Roll;
                ui.dropdownRoll.value = setter.Roll;
                Debug.Log("Rule succeeds on a " + setter.Roll + "+");
                break;
            case 4:
                setter.StatProfile = (int)rule.StatProfile;
                ui.dropdownProfile.value = setter.StatProfile;
                Debug.Log("Rule effects " + setter.StatProfile);
                setter.Modifier = (int)rule.Modify;
                ui.dropdownProfileModifier.value = setter.Modifier;
                Debug.Log("Profile modifier " + (Rule.Modifiers)setter.Modifier);
                if (rule.ProfileChange == 0) {
                    setter.Change = (int)rule.ChangeDice + 7;
                    Debug.Log("Modify by " + (Rule.Dice)(setter.Change-7));
                } else {
                    setter.Change = rule.ProfileChange;
                    Debug.Log("Modify by " + setter.Change);
                }
                ui.dropdownProfileChange.value = setter.Change;
                break;
            case 5:
                setter.RollModified = (int)rule.RollModified;
                ui.dropdownModifiedRoll.value = setter.RollModified;
                setter.ModifiedBy = (int)rule.RollModifiedBy;
                ui.dropdownModifiedBy.value = setter.ModifiedBy;
                setter.RollModifier = rule.RollModifierAmount;
                ui.ToggleModifiers();
                ui.dropdownModifier.value = setter.RollModifier;
                Debug.Log("Rule modifies " + (Rule.Rolls)setter.RollModified +
                          " rolls with a " + setter.RollModifier +
                          " " + (Rule.RollModifiers)setter.ModifiedBy);
                break;
            case 6:
                setter.PenaltyIgnored = (int)rule.IgnoreProfile;
                ui.panelIgnore.GetComponentInChildren<Dropdown>().value = setter.PenaltyIgnored;
                Debug.Log("Rule ignores penalty for " + (Rule.IgnoreProfiles)setter.PenaltyIgnored);
                break;
            case 9:
                setter.OnlyAdditionalAttack = rule.AdditionalAttackOnly;
                ui.toggleOnlyAttack.isOn = setter.OnlyAdditionalAttack;
                if (setter.OnlyAdditionalAttack) Debug.Log("Additional attacks only with this weapon.");
                setter.CanExplode = rule.AdditionalAttacksCanExplode;
                ui.toggleCanExplode.isOn = setter.CanExplode;
                if (setter.CanExplode) Debug.Log("Additional attacks can explode.");
                break;
            case 10:
                if (rule.Damage == 0)
                {
                    setter.Damage = (int)rule.DamageDice + 7;
                    Debug.Log("The rule deals " + (Rule.Dice)(setter.Damage - 7) + " damage.");
                } else Debug.Log("The rule deals " + setter.Damage + " damage.");
                ui.dropdownDamage.value = setter.Damage;
                setter.Roll = rule.Roll;
                ui.dropdownRoll.value = setter.Roll;
                Debug.Log("Rule deals damge on a roll of " + setter.Roll);
                setter.SlayTheModel = rule.SlayTheModel;
                ui.panelMortalWounds.GetComponentInChildren<Toggle>().isOn = setter.SlayTheModel;
                if (setter.SlayTheModel) Debug.Log("Model dies when the rule is triggered.");
                break;
        }
    }

    public void LoadSavedRule() {
        ResetLoad(instance.Rules[RuleToLoad]);
        ui.Close(true);
    }
}
