using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class RuleMessenger : MonoBehaviour
{
    public enum Message { NoName, NoActivation, RollTriggerNeeded, NoTarget, NoKeywordTarget, NoRuleType, NoRuleDamage, NoRoll, NoProfileChange, NoRollModifier };

    public RuleSetter setter;

    Color defaultColor;
    string startingText;

    void Awake()
    {
        Assert.IsNotNull(setter, "The Rule Messenger is not connected to the Rule Setter.");
    }

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = gameObject.GetComponent<Text>().color;
        startingText = gameObject.GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage ()
    {
        gameObject.GetComponent<Text>().color = defaultColor;
        if (setter.InputName.Length == 0 || 
          (!setter.UseDeployment &&
           !setter.UseStartOfGame &&
           !setter.UseYourTurn &&
           !setter.UseOpponentsTurn &&
           !setter.UseStartOfTurn &&
           !setter.UseMove &&
           !setter.UsePsychic &&
           !setter.UseShooting &&
           !setter.UseCharge &&
           !setter.UseFight &&
           !setter.UseMorale &&
           !setter.UseEndOfTurn &&
           !setter.UseEndOfGame))
        {
            gameObject.GetComponent<Text>().text = startingText;
        }
        else if (setter.ActivationType == 0)
        {
            gameObject.GetComponent<Text>().text =
            "Select when the rule is activated.";
        }
        else if (setter.RuleTarget == 0)
        {
            if (setter.ActivationType == 3)
            {
                gameObject.GetComponent<Text>().text =
                "Select what triggers the rule to activate and what the rule targets.";
            }
            else
            {
                gameObject.GetComponent<Text>().text =
                "Select what the rule targets.";
            }
        }
        else if (setter.RuleTarget == 11 && setter.InputKeyword.Length == 0)
        {
            gameObject.GetComponent<Text>().text =
            "Input the Keyword affected by the rule.";
        }
        else if (setter.RuleType == 0)
        {
            gameObject.GetComponent<Text>().text =
            "Select the type of rule.";
        }
        else if (setter.RuleTarget != 7 &&
                 setter.RuleTarget != 8 &&
                 setter.RuleTarget != 9 &&
                 setter.RuleTarget != 10 &&
                 setter.Range == 0)
        {
            gameObject.GetComponent<Text>().text =
            "Input a range for the rule.";
        }
        else 
        {
            switch (setter.RuleType)
            {
                case 1:
                    gameObject.GetComponent<Text>().text =
                    "Select the reserve restrictions and range.";
                    break;
                case 2:
                case 3:
                    gameObject.GetComponent<Text>().text =
                    "Select the roll on which the rule succeeds.";
                    break;
                case 4:
                    gameObject.GetComponent<Text>().text =
                    "Select how the profile is changed.";
                    break;
                case 5:
                    gameObject.GetComponent<Text>().text =
                    "Select how the roll is changed.";
                    break;
                case 6:
                    gameObject.GetComponent<Text>().text =
                    "Select what profile or roll ignores penalties.";
                    break;
                case 9:
                    gameObject.GetComponent<Text>().text =
                    "Select if only the specific weapon gains extra attacks and if extra attacks can create more (explode).";
                    break;
                case 10:
                    gameObject.GetComponent<Text>().text =
                    "Select the success and number of mortal wounds and whether the model activating the rule is destroyed.";
                    break;
                default:
                    gameObject.GetComponent<Text>().text =
                    "Check to make sure all the desired options are selected, then select Save.";
                    break;
            }
        }
    }

    public IEnumerator ErrorMessage (Message message)
    {
        gameObject.GetComponent<Text>().color = Color.red;
        switch (message)
        {
            case Message.NoName:
                gameObject.GetComponent<Text>().text =
                    "You need to name your Rule.";
                break;
            case Message.NoActivation:
                gameObject.GetComponent<Text>().text =
                    "You need to select when the rule takes effect.";
                break;
            case Message.RollTriggerNeeded:
                gameObject.GetComponent<Text>().text =
                    "You need to select what roll triggers the effect.";
                break;
            case Message.NoTarget:
                gameObject.GetComponent<Text>().text =
                    "You need to select what the rule targets.";
                break;
            case Message.NoKeywordTarget:
                gameObject.GetComponent<Text>().text =
                    "You need to enter the keyword for units targeted by the rule.";
                break;
            case Message.NoRuleType:
                gameObject.GetComponent<Text>().text =
                    "You need to select the type of rule.";
                break;
            case Message.NoRuleDamage:
                gameObject.GetComponent<Text>().text =
                    "You need to select how much damage the rule deals.";
                break;
            case Message.NoRoll:
                gameObject.GetComponent<Text>().text =
                    "You need to select what roll is needed for the rule to succeed.";
                break;
            case Message.NoProfileChange:
                gameObject.GetComponent<Text>().text =
                    "You need to select how the profile is changed.";
                break;
            case Message.NoRollModifier:
                gameObject.GetComponent<Text>().text =
                    "You need to select how the roll is modified.";
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(5f);
        DisplayMessage();
    }

    public IEnumerator SaveMessage ()
    {
        gameObject.GetComponent<Text>().text =
            "Rule saved.";
        yield return new WaitForSeconds(5f);
        DisplayMessage();
    }
}
