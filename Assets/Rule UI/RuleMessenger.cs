using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class RuleMessenger : MonoBehaviour
{
    public RuleSetter setter;

    string startingText;

    void Awake()
    {
        Assert.IsNotNull(setter, "The Rule Messenger is not connected to the Rule Setter.");
    }

    // Start is called before the first frame update
    void Start()
    {
        startingText = gameObject.GetComponent<Text>().text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage ()
    {
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
                    "Select whether the reserve restrictions and range.";
                    break;
            }
        }
    }
}
