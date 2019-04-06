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

        for (int i = 0; i < rule.UseTimes.Count; i++) {
            if (rule.UseTimes[i] == Rule.Uses.Deployment) {
                setter.UseDeployment = true;
                ui.useToggles[0].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.StartOfGame) {
                setter.UseStartOfGame = true;
                ui.useToggles[1].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.YourTurn) {
                setter.UseYourTurn = true;
                ui.useToggles[2].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.OpponentsTurn) {
                setter.UseOpponentsTurn = true;
                ui.useToggles[3].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.StartOfTurn) {
                setter.UseStartOfTurn = true;
                ui.useToggles[4].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Move) {
                setter.UseMove = true;
                ui.useToggles[5].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Psychic) {
                setter.UsePsychic = true;
                ui.useToggles[6].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Shooting) {
                setter.UseShooting = true;
                ui.useToggles[7].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Charge) {
                setter.UseCharge = true;
                ui.useToggles[8].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Fight) {
                setter.UseFight = true;
                ui.useToggles[9].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.Morale) {
                setter.UseMorale = true;
                ui.useToggles[10].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.EndOfTurn) {
                setter.UseEndOfTurn = true;
                ui.useToggles[11].isOn = true;
            }
            if (rule.UseTimes[i] == Rule.Uses.EndOfGame) {
                setter.UseEndOfGame = true;
                ui.useToggles[12].isOn = true;
            }
        }

        setter.ActivationType = (int)rule.ActivationType;
        ui.panelActivation.GetComponentInChildren<Dropdown>().value = setter.ActivationType;

        if (setter.ActivationType == 3) {
            if (rule.MoveTrigger != 0) {
                setter.MoveTriggers = (int)rule.MoveTrigger;
                ui.dropdownMove.value = setter.MoveTriggers;
            }
            if (rule.PsychicTrigger != 0) {
                setter.PsychicTriggers = (int)rule.PsychicTrigger;
                ui.dropdownPsychic.value = setter.PsychicTriggers;
            }
            if (rule.ShootingTrigger != 0) {
                setter.ShootingTriggers = (int)rule.ShootingTrigger;
                ui.dropdownShooting.value = setter.ShootingTriggers;
            }
            if (rule.ChargeTrigger != 0) {
                setter.ChargeTriggers = (int)rule.ChargeTrigger;
                ui.dropdownCharge.value = setter.ChargeTriggers;
            }
            if (rule.FightTrigger != 0) {
                setter.FightTriggers = (int)rule.FightTrigger;
                ui.dropdownFightsTriggers.value = setter.FightTriggers;
            }
            if (rule.MoraleTrigger != 0) {
                setter.MoraleTriggers = (int)rule.MoraleTrigger;
                ui.dropdownMorale.value = setter.MoraleTriggers;
            }
            if (rule.AttackTrigger != 0) {
                setter.AttackTriggers = (int)rule.AttackTrigger;
                ui.dropdownAttackTriggers.value = setter.AttackTriggers;
            }
            if (rule.WoundTrigger != 0) {
                setter.WoundTriggers = (int)rule.WoundTrigger;
                ui.dropdownWoundTriggers.value = setter.WoundTriggers;
            }
            if (rule.PowerTrigger != 0) {
                setter.PowerTriggers = (int)rule.PowerTrigger;
                ui.dropdownPowerTriggers.value = setter.PowerTriggers;
            }
            if (rule.DenyTrigger != 0) {
                setter.DenyTriggers = (int)rule.DenyTrigger;
                ui.dropdownDenyTriggers.value = setter.DenyTriggers;
            }
            if (rule.ChargeTrigger != 0) {
                setter.ChargeTriggers = (int)rule.ChargeTrigger;
                ui.dropdownChargeTriggers.value = setter.ChargeTriggers;
            }
            if (rule.SpecificFightsTrigger != 0) {
                setter.SpecificFightsTriggers = (int)rule.SpecificFightsTrigger;
                ui.dropdownFightsTriggers.value = setter.SpecificFightsTriggers;
            }
        }

        setter.RuleTarget = (int)rule.Target;
        ui.dropdownTarget.value = setter.RuleTarget;
        if (setter.RuleTarget != 9 &&
            setter.RuleTarget != 10) {

            setter.Range = rule.Range;
            ui.inputRange.text = setter.Range.ToString();

            if (setter.RuleTarget == 11) {
                setter.InputKeyword = rule.Keyword;
                ui.inputKeyword.text = setter.InputKeyword;
                setter.KeywordTarget = (int)rule.KeywordTarget;
                ui.dropdownKeywordTarget.value = setter.KeywordTarget;
            }
        }

        setter.RuleType = (int)rule.RuleType;
        ui.panelRuleType.GetComponentInChildren<Dropdown>().value = setter.RuleType;
        switch (setter.RuleType) {
            case 1:
                setter.ReserveOutsideEnemy = rule.ReserveOutsideEnemy;
                ui.toggleOutsideEnemy.isOn = setter.ReserveOutsideEnemy;
                setter.ReserveFromObject = rule.ReserveFromObject;
                ui.toggleFromObject.isOn = setter.ReserveFromObject;
                setter.ReserveRerollCharges = rule.RerollCharges;
                ui.toggleRerollCharges.isOn = setter.ReserveRerollCharges;
                setter.ReserveDealsMortal = rule.ReserveMortalWounds;
                ui.toggleReserveMortal.isOn = setter.ReserveDealsMortal;

                if (setter.ReserveDealsMortal) {
                    setter.ReserveDamageRange = rule.ReserveRange;
                    ui.inputReserveRange.text = setter.ReserveDamageRange.ToString();
                    if (rule.Damage == 0) {
                        setter.Damage = (int)rule.DamageDice + 7;
                    }
                    ui.dropdownDamage.value = setter.Damage;
                }
                break;
            case 2:
            case 3:
                setter.Roll = rule.Roll;
                ui.dropdownRoll.value = setter.Roll;
                break;
            case 4:
                setter.StatProfile = (int)rule.StatProfile;
                ui.dropdownProfile.value = setter.StatProfile;
                setter.Modifier = (int)rule.Modify;
                ui.dropdownProfileModifier.value = setter.Modifier;
                if (rule.ProfileChange == 0) {
                    setter.Change = (int)rule.ChangeDice + 7;
                } else {
                    setter.Change = rule.ProfileChange;
                }
                ui.dropdownProfileChange.value = setter.Change;
                break;
            case 5:
                setter.RollModified = (int)rule.RollModified;
                ui.dropdownModifiedRoll.value = setter.RollModified;
                setter.ModifiedBy = (int)rule.RollModifiedBy;
                ui.dropdownModifiedBy.value = setter.ModifiedBy;
                setter.RollModifier = (int)rule.RollModifierAmount;
                ui.dropdownModifier.value = setter.RollModifier;
                break;
            case 6:
                setter.PenaltyIgnored = (int)rule.IgnoreProfile;
                ui.panelIgnore.GetComponentInChildren<Dropdown>().value = setter.PenaltyIgnored;
                break;
            case 9:
                setter.OnlyAdditionalAttack = rule.AdditionalAttackOnly;
                ui.toggleOnlyAttack.isOn = setter.OnlyAdditionalAttack;
                setter.CanExplode = rule.AdditionalAttacksCanExplode;
                ui.toggleCanExplode.isOn = setter.CanExplode;
                break;
            case 10:
                if (rule.Damage == 0) {
                    setter.Damage = (int)rule.DamageDice + 7;
                }
                ui.dropdownDamage.value = setter.Damage;
                setter.Roll = rule.Roll;
                ui.dropdownRoll.value = setter.Roll;
                setter.SlayTheModel = rule.SlayTheModel;
                ui.panelMortalWounds.GetComponentInChildren<Toggle>().isOn = setter.SlayTheModel;
                break;
        }
    }

    public void LoadSavedRule() {
        ResetLoad(instance.Rules[RuleToLoad]);
        ui.Close(true);
    }
}
