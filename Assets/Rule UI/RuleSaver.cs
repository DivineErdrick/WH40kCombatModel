using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;

public class RuleSaver : MonoBehaviour
{
    GameManager instance;

    Rule rule;
    RuleLoader loader;
    RuleSetter setter;
    RuleUI ui;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Could not find Game Manager.");
        loader = GetComponent<RuleLoader>();
        Assert.IsNotNull(loader, "Could not find Rule Loader.");
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

        rule = new Rule();
        bool datacheckPassed = true;

        datacheckPassed = Datacheck();

        if (datacheckPassed) {
            //instance.ActiveRule = rule;
            bool nameCheck = true;
            for (int i = 0; i < instance.Rules.Count; i++) {
                if (rule.Name == instance.Rules[i].Name) {
                    nameCheck = false;
                    loader.RuleToLoad = i;
                }
            }

            if (nameCheck) {
                instance.Rules.Add(rule);
                instance.SaveRules();
                ui.buttonLoad.interactable = true;
            } else if (overwrite) {
                instance.Rules[loader.RuleToLoad] = rule;
                ui.panelNameCheck.SetActive(false);
            } else {
                ui.panelNameCheck.SetActive(true);
            }

            Debug.Log("New Rule name is " + rule.Name + ". It has been added to the rule data as " + instance.Rules.Last().Name + ".");
            ui.buttonLoad.interactable = true;
        }
    }

    bool Datacheck() {

        bool dataPassed = true;

        if (setter.InputName.Length == 0) {
            Debug.Log("You must name your rule.");
            dataPassed = false;
            return dataPassed;
        } else {
            rule.Name = setter.InputName;
            Debug.Log("Rule name: " + rule.Name);
        }

        //Uses
        if (setter.UseDeployment) { rule.UseTimes.Add(Rule.Uses.Deployment); Debug.Log("Rule can be used in deployment."); }
        if (setter.UseStartOfGame) { rule.UseTimes.Add(Rule.Uses.StartOfGame); Debug.Log("Rule can be used at the start of the game."); }
        if (setter.UseYourTurn) { rule.UseTimes.Add(Rule.Uses.YourTurn); Debug.Log("Rule can be used on your turn."); }
        if (setter.UseOpponentsTurn) { rule.UseTimes.Add(Rule.Uses.OpponentsTurn); Debug.Log("Rule can be used during the opponents turn."); }
        if (setter.UseStartOfTurn) { rule.UseTimes.Add(Rule.Uses.StartOfTurn); Debug.Log("Rule can be used at the start of the turn."); }
        if (setter.UseMove) { rule.UseTimes.Add(Rule.Uses.Move); Debug.Log("Rule can be used in the move phase."); }
        if (setter.UsePsychic) { rule.UseTimes.Add(Rule.Uses.Psychic); Debug.Log("Rule can be used in the psychic phase."); }
        if (setter.UseShooting) { rule.UseTimes.Add(Rule.Uses.Shooting); Debug.Log("Rule can be used in the shooting phase."); }
        if (setter.UseCharge) { rule.UseTimes.Add(Rule.Uses.Charge); Debug.Log("Rule can be used in the charge phase."); }
        if (setter.UseFight) { rule.UseTimes.Add(Rule.Uses.Fight); Debug.Log("Rule can be used in the fight phase."); }
        if (setter.UseMorale) { rule.UseTimes.Add(Rule.Uses.Morale); Debug.Log("Rule can be used in the morale phase."); }
        if (setter.UseEndOfTurn) { rule.UseTimes.Add(Rule.Uses.EndOfTurn); Debug.Log("Rule can be used at the end of the turn."); }
        if (setter.UseEndOfGame) { rule.UseTimes.Add(Rule.Uses.EndOfGame); Debug.Log("Rule can be used at the end of the game."); }

        //Activation
        if (setter.ActivationType == 0) {
            Debug.Log("You must select an activation type.");
            dataPassed = false;
            return dataPassed;
        }
        rule.ActivationType = (Rule.ActivationTypes)setter.ActivationType;
        Debug.Log("Rule has an activation type of " + rule.ActivationType);

        //Triggers
        if (setter.ActivationType == 3) {
            if (setter.UseMove) {
                rule.MoveTrigger = new Rule.MoveTriggers();
                rule.MoveTrigger = (Rule.MoveTriggers)setter.MoveTriggers;
                Debug.Log("Rule is triggered during the move phase on " + rule.MoveTrigger);
                if (setter.MoveTriggers == 3) {
                    if (setter.RollTrigger != 0) {
                        rule.RollTrigger = setter.RollTrigger;
                        Debug.Log("Rule is triggered on and advance roll of " + rule.RollTrigger);
                    } else {
                        Debug.Log("You must select a value for the roll trigger.");
                        dataPassed = false;
                        return dataPassed;
                    }
                }
            }
            if (setter.UsePsychic) {
                rule.PsychicTrigger = new Rule.PsychicTriggers();
                rule.PsychicTrigger = (Rule.PsychicTriggers)setter.PsychicTriggers;
                Debug.Log("Rule is triggered during the psychic phase on" + rule.PsychicTrigger);
                if (setter.PsychicTriggers == 1) {
                    rule.PowerTrigger = new Rule.PowerTriggers();
                    rule.PowerTrigger = (Rule.PowerTriggers)setter.PowerTriggers;
                    Debug.Log("Rule is triggered when a player uses a power on " + rule.PowerTrigger);
                    if (setter.PowerTriggers == 3) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on psychic test rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (setter.PsychicTriggers == 2) {
                    rule.DenyTrigger = new Rule.DenyTriggers();
                    rule.DenyTrigger = (Rule.DenyTriggers)setter.DenyTriggers;
                    Debug.Log("Rule is triggered when a player tries to deny a power on " + rule.DenyTrigger);
                    if (setter.DenyTriggers == 1) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on deny rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
            }
            if (setter.UseShooting) {
                rule.ShootingTrigger = new Rule.ShootingTriggers();
                rule.ShootingTrigger = (Rule.ShootingTriggers)setter.ShootingTriggers;
                Debug.Log("Rule is triggered during the shooting phase on " + rule.ShootingTrigger);
                if (setter.ShootingTriggers == 1) {
                    rule.AttackTrigger = new Rule.AttackTriggers();
                    rule.AttackTrigger = (Rule.AttackTriggers)setter.AttackTriggers;
                    Debug.Log("Rule is triggered when a player shoots on " + rule.AttackTrigger);
                    if (setter.AttackTriggers == 2) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on shooting rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (setter.ShootingTriggers == 2) {
                    rule.WoundTrigger = new Rule.WoundTriggers();
                    rule.WoundTrigger = (Rule.WoundTriggers)setter.WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (setter.WoundTriggers == 1) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
            }
            if (setter.UseCharge) {
                rule.ChargeTrigger = new Rule.ChargeTriggers();
                rule.ChargeTrigger = (Rule.ChargeTriggers)setter.ChargeTriggers;
                Debug.Log("Rule is triggered during the charge phase on " + rule.ChargeTrigger);
                if (setter.ChargeTriggers == 1) {
                    rule.SpecificChargeTrigger = new Rule.SpecificChargeTriggers();
                    rule.SpecificChargeTrigger = (Rule.SpecificChargeTriggers)setter.SpecificChargeTriggers;
                    Debug.Log("Rule is triggered when a charges on " + rule.SpecificChargeTrigger);
                    if (setter.SpecificChargeTriggers == 3) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on charge rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (setter.ChargeTriggers == 2) {
                    rule.AttackTrigger = new Rule.AttackTriggers();
                    rule.AttackTrigger = (Rule.AttackTriggers)setter.AttackTriggers;
                    Debug.Log("Rule is triggered when a player can overwatch on " + rule.AttackTrigger);
                    if (setter.AttackTriggers == 2) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on charge rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (setter.ChargeTriggers == 3) {
                    rule.WoundTrigger = new Rule.WoundTriggers();
                    rule.WoundTrigger = (Rule.WoundTriggers)setter.WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (setter.WoundTriggers == 1) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
            }
            if (setter.UseFight) {
                rule.FightTrigger = new Rule.FightTriggers();
                rule.FightTrigger = (Rule.FightTriggers)setter.FightTriggers;
                Debug.Log("Rule is triggered during the fight phase " + rule.FightTrigger);
                if (setter.FightTriggers == 1 || setter.FightTriggers == 2 || setter.FightTriggers == 3) {
                    rule.SpecificFightsTrigger = new Rule.SpecificFightsTriggers();
                    rule.SpecificFightsTrigger = (Rule.SpecificFightsTriggers)setter.SpecificFightsTriggers;
                    Debug.Log("Rule is triggered during fights on " + rule.SpecificFightsTrigger);
                }
                if (setter.FightTriggers == 4) {
                    rule.AttackTrigger = new Rule.AttackTriggers();
                    rule.AttackTrigger = (Rule.AttackTriggers)setter.AttackTriggers;
                    Debug.Log("Rule is triggered when a player attacks on " + rule.AttackTrigger);
                    if (setter.AttackTriggers == 2) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
                if (setter.FightTriggers == 5) {
                    rule.WoundTrigger = new Rule.WoundTriggers();
                    rule.WoundTrigger = (Rule.WoundTriggers)setter.WoundTriggers;
                    Debug.Log("Rule is triggered when a player hits on " + rule.WoundTrigger);
                    if (setter.WoundTriggers == 1) {
                        if (setter.RollTrigger != 0) {
                            rule.RollTrigger = setter.RollTrigger;
                            Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                        } else {
                            Debug.Log("You must select a value for the roll trigger.");
                            dataPassed = false;
                            return dataPassed;
                        }
                    }
                }
            }
            if (setter.UseMorale) {
                rule.MoraleTrigger = new Rule.MoraleTriggers();
                rule.MoraleTrigger = (Rule.MoraleTriggers)setter.MoraleTriggers;
                Debug.Log("Rule is triggered during the morale " + rule.MoraleTrigger);
                if (setter.MoraleTriggers == 3) {
                    if (setter.RollTrigger != 0) {
                        rule.RollTrigger = setter.RollTrigger;
                        Debug.Log("Rule is triggered on wound rolls of " + rule.RollTrigger);
                    } else {
                        Debug.Log("You must select a value for the roll trigger.");
                        dataPassed = false;
                        return dataPassed;
                    }
                }
            }
        }

        if (setter.RuleTarget == 0) {
            Debug.Log("Your rule requires a target.");
            dataPassed = false;
            return dataPassed;
        } else {
            rule.Target = (Rule.Targets)setter.RuleTarget;
            Debug.Log("The rule targets " + rule.Target);
            if (setter.RuleTarget == 11 && setter.InputKeyword.Length == 0) {
                Debug.Log("Enter the keyword your rule targets.");
                dataPassed = false;
                return dataPassed;
            } else {
                rule.Keyword = setter.InputKeyword;
                Debug.Log("The rule targets the keyword " + rule.Keyword);
                rule.KeywordTarget = (Rule.KeywordTargets)setter.KeywordTarget;
            }
        }

        if (setter.RuleType == 0) {
            Debug.Log("Select the type of rule.");
            dataPassed = false;
            return dataPassed;
        } else {
            rule.RuleType = (Rule.RuleTypes)setter.RuleType;
            Debug.Log("The rule is a " + rule.RuleType);
            if ((setter.RuleTarget != 9 && setter.RuleTarget != 10) || setter.RuleType == 1) {
                rule.Range = setter.Range;
                Debug.Log("Rule Range is " + rule.Range);
            }
            if ((setter.RuleType == 1 && setter.ReserveDealsMortal) || setter.RuleType == 10) {
                if (setter.Damage != 0) {
                    if (setter.Damage < 7) {
                        rule.Damage = setter.Damage;
                        Debug.Log("Rule Damage is " + rule.Range);
                    } else {
                        rule.DamageDice = new Rule.Dice();
                        rule.DamageDice = (Rule.Dice)(setter.Damage - 7);
                        Debug.Log("Rule Damage is " + rule.DamageDice);
                    }
                } else {
                    Debug.Log("Select the damage the rule deals.");
                    dataPassed = false;
                    return dataPassed;
                }
            }
            if (setter.RuleType == 2 || setter.RuleType == 3 || setter.RuleType == 10) {
                if (setter.Roll != 0) {
                    rule.Roll = setter.Roll;
                    Debug.Log("Rule passes on rolls of " + rule.Range);
                } else {
                    Debug.Log("Select the passing roll for the rule.");
                    dataPassed = false;
                    return dataPassed;
                }
            }
            if (setter.RuleType == 1) {
                rule.ReserveOutsideEnemy = setter.ReserveOutsideEnemy;
                if (rule.ReserveOutsideEnemy) Debug.Log("Deploy from reserve away from the enemy.");
                rule.ReserveFromObject = setter.ReserveFromObject;
                if (rule.ReserveFromObject) Debug.Log("Deploy from reserve near an object.");
                rule.RerollCharges = setter.ReserveRerollCharges;
                if (rule.RerollCharges) Debug.Log("Reroll charges after deploying from reserve.");
                rule.ReserveMortalWounds = setter.ReserveDealsMortal;
                if (rule.ReserveOutsideEnemy) Debug.Log("Deploying from reserve deals mortal wounds.");
                if (setter.ReserveDealsMortal) {
                    rule.ReserveRange = setter.ReserveDamageRange;
                    Debug.Log("Deal mortal wounds to targets within " + rule.ReserveRange);
                }
            }
            if (setter.RuleType == 4) {
                rule.StatProfile = new Rule.StatProfiles();
                rule.StatProfile = (Rule.StatProfiles)setter.StatProfile;
                Debug.Log("Rule changes the following profile " + rule.StatProfile);
                rule.Modify = new Rule.Modifiers();
                rule.Modify = (Rule.Modifiers)setter.Modifier;
                Debug.Log("Profile changed by " + rule.Modify);
                if (setter.Change != 0) {
                    if (setter.Change < 7) {
                        rule.ProfileChange = setter.Change;
                        Debug.Log("And modified by " + rule.ProfileChange);
                    } else {
                        rule.ChangeDice = new Rule.Dice();
                        rule.ChangeDice = (Rule.Dice)(setter.Change - 7);
                        Debug.Log("And modified by " + rule.ChangeDice);
                    }
                } else {
                    Debug.Log("Select the amount the profile changes.");
                    dataPassed = false;
                    return dataPassed;
                }
            }
            if (setter.RuleType == 5) {
                rule.RollModified = new Rule.Rolls();
                rule.RollModified = (Rule.Rolls)setter.RollModified;
                Debug.Log("Rule modifies " + rule.RollModified + " rolls.");
                rule.RollModifiedBy = new Rule.RollModifiers();
                rule.RollModifiedBy = (Rule.RollModifiers)setter.ModifiedBy;
                Debug.Log("Roll is modified by " + rule.RollModifiedBy);
                if (setter.RollModifier == 0) {
                    Debug.Log("Select the amount the roll is modified by.");
                    dataPassed = false;
                    return dataPassed;
                } else {
                    rule.RollModifierAmount = setter.RollModifier;
                    Debug.Log("Roll is modified by " + rule.RollModifierAmount);
                }
            }
            if (setter.RuleType == 6) {
                rule.IgnoreProfile = new Rule.IgnoreProfiles();
                rule.IgnoreProfile = (Rule.IgnoreProfiles)setter.PenaltyIgnored;
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
