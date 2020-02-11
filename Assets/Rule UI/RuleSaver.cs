using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class RuleSaver : MonoBehaviour
{
    GameManager instance;

    RuleV20200106 rule;
    RuleLoader loader;
    RuleMessenger messenger;
    RuleSetter setter;
    RuleUI ui;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Could not find Game Manager.");
        loader = GetComponent<RuleLoader>();
        Assert.IsNotNull(loader, "Could not find Rule Loader.");
        messenger = FindObjectOfType<RuleMessenger>();
        if (messenger == null)
        {
            Debug.Log("Could not find RuleMessenger.");
        }
        setter = GetComponent<RuleSetter>();
        Assert.IsNotNull(setter, "Could not find Rule Setter.");
        ui = GetComponent<RuleUI>();
        Assert.IsNotNull(ui, "Could not find Rule UI.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Save(bool overwrite) {

        Debug.Log("Attempting to save Rule.");
        rule = new RuleV20200106();
        bool datacheckPassed = true;

        datacheckPassed = Datacheck();

        if (datacheckPassed) {
            //instance.ActiveRule = rule;
            Debug.Log("Rule is valid.");
            Debug.Log("Checking if a rule with this name exists.");
            bool nameCheck = true;
            for (int i = 0; i < instance.Rules.Count; i++) {
                if (rule.Name == instance.Rules[i].Name) {
                    nameCheck = false;
                    loader.RuleToLoad = i;
                }
            }

            if (nameCheck) {
                Debug.Log("Saving rule.");
                instance.Rules.Add(rule);
                instance.SaveRules();
                StartCoroutine(messenger.SaveMessage());
            }
            else if (overwrite) {
                Debug.Log("Saving rule.");
                instance.Rules[loader.RuleToLoad] = rule;
                instance.SaveRules();
                ui.panelNameCheck.SetActive(false);
                StartCoroutine(messenger.SaveMessage());
            }
            else {
                Debug.Log("A rule with that name exists. Opening Name Check Panel.");
                ui.panelNameCheck.SetActive(true);
            }

            ui.buttonLoad.interactable = true;
        }
    }

    bool Datacheck() {

        Debug.Log("Checking if the rule is valid.");
        bool dataPassed = true;

        if (setter.InputName.Length == 0) {
            Debug.Log("You must name your rule.");
            dataPassed = false;
            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoName));
            return dataPassed;
        } else {
            rule.Name = setter.InputName;
            Debug.Log("Rule name: " + rule.Name);
        }

        //Uses
        rule.UseTimes = new List<RuleV20200106.Uses>();
        if (setter.UseDeployment) { rule.UseTimes.Add(RuleV20200106.Uses.Deployment); Debug.Log("Rule can be used in deployment."); }
        if (setter.UseStartOfGame) { rule.UseTimes.Add(RuleV20200106.Uses.StartOfGame); Debug.Log("Rule can be used at the start of the game."); }
        if (setter.UseYourTurn) { rule.UseTimes.Add(RuleV20200106.Uses.YourTurn); Debug.Log("Rule can be used on your turn."); }
        if (setter.UseOpponentsTurn) { rule.UseTimes.Add(RuleV20200106.Uses.OpponentsTurn); Debug.Log("Rule can be used during the opponents turn."); }
        if (setter.UseStartOfTurn) { rule.UseTimes.Add(RuleV20200106.Uses.StartOfTurn); Debug.Log("Rule can be used at the start of the turn."); }
        if (setter.UseMove) { rule.UseTimes.Add(RuleV20200106.Uses.Move); Debug.Log("Rule can be used in the move phase."); }
        if (setter.UsePsychic) { rule.UseTimes.Add(RuleV20200106.Uses.Psychic); Debug.Log("Rule can be used in the psychic phase."); }
        if (setter.UseShooting) { rule.UseTimes.Add(RuleV20200106.Uses.Shooting); Debug.Log("Rule can be used in the shooting phase."); }
        if (setter.UseCharge) { rule.UseTimes.Add(RuleV20200106.Uses.Charge); Debug.Log("Rule can be used in the charge phase."); }
        if (setter.UseFight) { rule.UseTimes.Add(RuleV20200106.Uses.Fight); Debug.Log("Rule can be used in the fight phase."); }
        if (setter.UseMorale) { rule.UseTimes.Add(RuleV20200106.Uses.Morale); Debug.Log("Rule can be used in the morale phase."); }
        if (setter.UseEndOfTurn) { rule.UseTimes.Add(RuleV20200106.Uses.EndOfTurn); Debug.Log("Rule can be used at the end of the turn."); }
        if (setter.UseEndOfGame) { rule.UseTimes.Add(RuleV20200106.Uses.EndOfGame); Debug.Log("Rule can be used at the end of the game."); }

        //Activation
        if (setter.ActivationType == 0) {
            Debug.Log("You must select an activation type.");
            dataPassed = false;
            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoActivation));
            return dataPassed;
        }
        rule.ActivationType = (RuleV20200106.ActivationTypes)setter.ActivationType;
        Debug.Log("Rule has an activation type of " + rule.ActivationType);

        //Triggers
        if (setter.ActivationType == 3) {
            if (setter.UseMove) {
                rule.MoveTrigger = new RuleV20200106.MoveTriggers();
                rule.MoveTrigger = (RuleV20200106.MoveTriggers)setter.MoveTriggers;
                Debug.Log("Rule is triggered during the move phase on " + rule.MoveTrigger);
                if (setter.MoveTriggers == 3) {
                    if (setter.RollTrigger != 0) {
                        rule.RollTrigger = setter.RollTrigger;
                        Debug.Log("Rule is triggered on and advance roll of " + rule.RollTrigger);
                    } else {
                        Debug.Log("You must select a value for the roll trigger.");
                        dataPassed = false;
                        StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                        return dataPassed;
                    }
                }
            }
            if (setter.UsePsychic) {
                rule.PsychicTrigger = new RuleV20200106.PsychicTriggers();
                rule.PsychicTrigger = (RuleV20200106.PsychicTriggers)setter.PsychicTriggers;
                Debug.Log("Rule is triggered during the psychic phase on" + rule.PsychicTrigger);
                if (setter.PsychicTriggers == 1) {
                    rule.PowerTrigger = new RuleV20200106.PowerTriggers();
                    rule.PowerTrigger = (RuleV20200106.PowerTriggers)setter.PowerTriggers;
                    Debug.Log("Rule is triggered when a player uses a power on " + rule.PowerTrigger);
                    if (setter.PowerTriggers == 3) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on psychic test rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
                if (setter.PsychicTriggers == 2) {
                    rule.DenyTrigger = new RuleV20200106.DenyTriggers();
                    rule.DenyTrigger = (RuleV20200106.DenyTriggers)setter.DenyTriggers;
                    Debug.Log("Rule is triggered when a player tries to deny a power on " + rule.DenyTrigger);
                    if (setter.DenyTriggers == 1) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on deny rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
            }
            if (setter.UseShooting) {
                rule.ShootingTrigger = new RuleV20200106.ShootingTriggers();
                rule.ShootingTrigger = (RuleV20200106.ShootingTriggers)setter.ShootingTriggers;
                Debug.Log("Rule is triggered during the shooting phase on " + rule.ShootingTrigger);
                if (setter.ShootingTriggers == 1) {
                    rule.AttackTrigger = new RuleV20200106.AttackTriggers();
                    rule.AttackTrigger = (RuleV20200106.AttackTriggers)setter.AttackTriggers;
                    Debug.Log("Rule is triggered when a player shoots on " + rule.AttackTrigger);
                    if (setter.AttackTriggers == 2) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on shooting rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
                if (setter.ShootingTriggers == 2) {
                    rule.WoundTrigger = new RuleV20200106.WoundTriggers();
                    rule.WoundTrigger = (RuleV20200106.WoundTriggers)setter.WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (setter.WoundTriggers == 1) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
            }
            if (setter.UseCharge) {
                rule.ChargeTrigger = new RuleV20200106.ChargeTriggers();
                rule.ChargeTrigger = (RuleV20200106.ChargeTriggers)setter.ChargeTriggers;
                Debug.Log("Rule is triggered during the charge phase on " + rule.ChargeTrigger);
                if (setter.ChargeTriggers == 1) {
                    rule.SpecificChargeTrigger = new RuleV20200106.SpecificChargeTriggers();
                    rule.SpecificChargeTrigger = (RuleV20200106.SpecificChargeTriggers)setter.SpecificChargeTriggers;
                    Debug.Log("Rule is triggered when a charges on " + rule.SpecificChargeTrigger);
                    if (setter.SpecificChargeTriggers == 3) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on charge rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
                if (setter.ChargeTriggers == 2) {
                    rule.AttackTrigger = new RuleV20200106.AttackTriggers();
                    rule.AttackTrigger = (RuleV20200106.AttackTriggers)setter.AttackTriggers;
                    Debug.Log("Rule is triggered when a player can overwatch on " + rule.AttackTrigger);
                    if (setter.AttackTriggers == 2) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on charge rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
                if (setter.ChargeTriggers == 3) {
                    rule.WoundTrigger = new RuleV20200106.WoundTriggers();
                    rule.WoundTrigger = (RuleV20200106.WoundTriggers)setter.WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (setter.WoundTriggers == 1) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
            }
            if (setter.UseFight) {
                rule.FightTrigger = new RuleV20200106.FightTriggers();
                rule.FightTrigger = (RuleV20200106.FightTriggers)setter.FightTriggers;
                Debug.Log("Rule is triggered during the fight phase " + rule.FightTrigger);
                if (setter.FightTriggers == 1 || setter.FightTriggers == 2 || setter.FightTriggers == 3) {
                    rule.SpecificFightsTrigger = new RuleV20200106.SpecificFightsTriggers();
                    rule.SpecificFightsTrigger = (RuleV20200106.SpecificFightsTriggers)setter.SpecificFightsTriggers;
                    Debug.Log("Rule is triggered during fights on " + rule.SpecificFightsTrigger);
                }
                if (setter.FightTriggers == 4) {
                    rule.AttackTrigger = new RuleV20200106.AttackTriggers();
                    rule.AttackTrigger = (RuleV20200106.AttackTriggers)setter.AttackTriggers;
                    Debug.Log("Rule is triggered when a player attacks on " + rule.AttackTrigger);
                    if (setter.AttackTriggers == 2) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
                if (setter.FightTriggers == 5) {
                    rule.WoundTrigger = new RuleV20200106.WoundTriggers();
                    rule.WoundTrigger = (RuleV20200106.WoundTriggers)setter.WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (setter.WoundTriggers == 1) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                            return dataPassed;
                        }
                    }
                }
            }
            if (setter.UseMorale) {
                rule.MoraleTrigger = new RuleV20200106.MoraleTriggers();
                rule.MoraleTrigger = (RuleV20200106.MoraleTriggers)setter.MoraleTriggers;
                Debug.Log("Rule is triggered during the morale " + rule.MoraleTrigger);
                if (setter.MoraleTriggers == 3) {
                    if (setter.RollTrigger != 0) {
                        rule.RollTrigger = setter.RollTrigger;
                        Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                    } else {
                        Debug.Log("You must select a value for the roll trigger.");
                        dataPassed = false;
                        StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.RollTriggerNeeded));
                        return dataPassed;
                    }
                }
            }
        }

        if (setter.RuleTarget == 0) {
            Debug.Log("Your rule requires a target.");
            dataPassed = false;
            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoTarget));
            return dataPassed;
        } else {
            rule.Target = (RuleV20200106.Targets)setter.RuleTarget;
            Debug.Log("The rule targets " + rule.Target);
            if (setter.RuleTarget == 11 && setter.InputKeyword.Length == 0) {
                Debug.Log("Enter the keyword your rule targets.");
                dataPassed = false;
                StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoKeywordTarget));
                return dataPassed;
            } else {
                rule.Keyword = setter.InputKeyword;
                Debug.Log("The rule targets the keyword " + rule.Keyword);
                rule.KeywordTarget = (RuleV20200106.KeywordTargets)setter.KeywordTarget;
            }
        }

        if (setter.RuleType == 0) {
            Debug.Log("Select the type of rule.");
            dataPassed = false;
            StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoRuleType));
            return dataPassed;
        } else {
            rule.RuleType = (RuleV20200106.RuleTypes)setter.RuleType;
            Debug.Log("The rule is a " + rule.RuleType);
            if ((setter.RuleTarget != 9 && setter.RuleTarget != 10) || setter.RuleType == 1) {
                rule.Range = setter.Range;
                Debug.Log("Rule Range is " + rule.Range);
            }
            if ((setter.RuleType == 1 && setter.ReserveDealsMortal) || setter.RuleType == 10) {
                if (setter.Damage != 0) {
                    if (setter.Damage < 7) {
                        rule.Damage = setter.Damage;
                        Debug.Log("Rule Damage is " + rule.Damage);
                    } else {
                        rule.DamageDice = new RuleV20200106.Dice();
                        rule.DamageDice = (RuleV20200106.Dice)(setter.Damage - 7);
                        Debug.Log("Rule Damage is " + rule.DamageDice);
                    }
                } else {
                    Debug.Log("Select the damage the rule deals.");
                    dataPassed = false;
                    StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoRuleDamage));
                    return dataPassed;
                }
            }
            if (setter.RuleType == 2 || setter.RuleType == 3 || setter.RuleType == 10) {
                if (setter.Roll != 0) {
                    rule.Roll = setter.Roll;
                    Debug.Log("Rule passes on rolls of " + rule.Roll);
                } else {
                    Debug.Log("Select the passing roll for the rule.");
                    dataPassed = false;
                    StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoRoll));
                    return dataPassed;
                }
            }
            if (setter.RuleType == 1) {
                rule.Range = setter.Range;
                rule.ReserveOutsideEnemy = setter.ReserveOutsideEnemy;
                if (rule.ReserveOutsideEnemy) Debug.Log("Deploy from reserve " + rule.Range + " inches away from the enemy.");
                rule.ReserveFromObject = setter.ReserveFromObject;
                if (rule.ReserveFromObject) Debug.Log("Deploy from reserve within " + rule.Range + " inches from an object.");
                rule.RerollCharges = setter.ReserveRerollCharges;
                if (rule.RerollCharges) Debug.Log("Reroll charges after deploying from reserve.");
                rule.ReserveMortalWounds = setter.ReserveDealsMortal;
                if (rule.ReserveOutsideEnemy) Debug.Log("Deploying from reserve deals mortal wounds.");
                if (setter.ReserveDealsMortal) {
                    rule.ReserveDamageRange = setter.ReserveDamageRange;
                    Debug.Log("Deal mortal wounds to targets within " + rule.ReserveDamageRange);
                    rule.Roll = setter.Roll;
                    Debug.Log("Rule deals damage on a roll of " + rule.Roll);
                }
            }
            if (setter.RuleType == 4) {
                rule.StatProfile = new RuleV20200106.StatProfiles();
                rule.StatProfile = (RuleV20200106.StatProfiles)setter.StatProfile;
                Debug.Log("Rule changes the following profile " + rule.StatProfile);
                rule.Modify = new RuleV20200106.Modifiers();
                rule.Modify = (RuleV20200106.Modifiers)setter.Modifier;
                Debug.Log("Profile changed by " + rule.Modify);
                if (setter.Change != 0) {
                    if (setter.Change < 7) {
                        rule.ProfileChange = setter.Change;
                        Debug.Log("And modified by " + rule.ProfileChange);
                    } else {
                        rule.ChangeDice = new RuleV20200106.Dice();
                        rule.ChangeDice = (RuleV20200106.Dice)(setter.Change - 7);
                        Debug.Log("And modified by " + rule.ChangeDice);
                    }
                } else {
                    Debug.Log("Select the amount the profile changes.");
                    dataPassed = false;
                    StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoProfileChange));
                    return dataPassed;
                }
            }
            if (setter.RuleType == 5) {
                rule.RollModified = new RuleV20200106.Rolls();
                rule.RollModified = (RuleV20200106.Rolls)setter.RollModified;
                Debug.Log("Rule modifies " + rule.RollModified + " rolls.");
                rule.RollModifiedBy = new RuleV20200106.RollModifiers();
                rule.RollModifiedBy = (RuleV20200106.RollModifiers)setter.ModifiedBy;
                Debug.Log("Roll is modified by " + rule.RollModifiedBy);
                if (setter.ModifiedBy > 0 && setter.RollModifier == 0) {
                    Debug.Log("Select the amount the roll is modified by.");
                    dataPassed = false;
                    StartCoroutine(messenger.ErrorMessage(RuleMessenger.Message.NoRollModifier));
                    return dataPassed;
                }
                else if (setter.ModifiedBy > 0)
                {
                    rule.RollModifierAmount = setter.RollModifier;
                    Debug.Log("Roll is modified by " + rule.RollModifierAmount);
                }
                else
                {
                    rule.RerollType = (RuleV20200106.RerollTypes)setter.RerollType;
                    Debug.Log("Reroll type is " + rule.RerollType);
                    rule.RerollTypeOrLower = setter.RerollTypeOrLower;
                    Debug.Log("Reroll on lower is " + rule.RerollTypeOrLower);
                    rule.RerollTypeOrHigher = setter.RerollTypeOrHigher;
                    Debug.Log("Reroll on higher is " + rule.RerollTypeOrHigher);
                }
                
            }
            if (setter.RuleType == 6) {
                rule.IgnoreProfile = new RuleV20200106.IgnoreProfiles();
                rule.IgnoreProfile = (RuleV20200106.IgnoreProfiles)setter.PenaltyIgnored;
                Debug.Log("Penalties are ignored for " + rule.IgnoreProfile);
            }
            if (setter.RuleType == 9) {
                rule.AdditionalAttackOnly = setter.OnlyAdditionalAttack;
                if (rule.AdditionalAttackOnly) Debug.Log("Rule forces the attack only on additional attacks.");
                rule.AdditionalAttacksCanExplode = setter.CanExplode;
                if (rule.AdditionalAttacksCanExplode) Debug.Log("Additional attacks can explode.");
            }
            if (setter.RuleType == 10) {
                rule.SlayTheModel = setter.SlayTheModel;
                if (rule.SlayTheModel) Debug.Log("Rule slays the target model.");
            }
        }

        return dataPassed;
    }
}
