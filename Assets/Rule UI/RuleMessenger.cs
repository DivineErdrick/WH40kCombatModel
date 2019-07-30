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
    }
}
