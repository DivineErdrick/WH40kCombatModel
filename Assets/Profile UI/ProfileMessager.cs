using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileMessager : MonoBehaviour
{
    public enum State { basic, warning }

    public Color defaultColor;
    public State CurrentState { get; set; }

    public bool MWarning { get; set; }
    public bool WSWarning { get; set; }
    public bool BSWarning { get; set; }
    public bool SWarning { get; set; }
    public bool TWarning { get; set; }    
    public bool AWarning { get; set; }
    public bool LdWarning { get; set; }
    public bool SvWarning { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage (string message, bool error) {

        if (error) {

            GetComponent<Text>().color = Color.red;
        } else {

            GetComponent<Text>().color = defaultColor;
        }

        GetComponent<Text>().text = message;
    }

    public IEnumerator DisplayTemporaryMessage (string message, bool error) {

        DisplayMessage(message, error);
        yield return new WaitForSeconds(2);
        ReturnToCurrentState();
    }

    public void LoadAndCloseMessage () {


    }

    public void ReturnToCurrentState () {

        GetComponent<Text>().color = defaultColor;

        switch (CurrentState) {

            case State.basic:
                GetComponent<Text>().text =
                    "Enter the model's profile. Select the number of damage charts below. You can leave blank stats blank, or enter '0'.";
                break;

            case State.warning:
                if (MWarning || WSWarning || BSWarning || SWarning || AWarning || LdWarning || SvWarning) {

                    string warningMessage = "Warning. The Profile has unusual stats:";
                    if (MWarning) warningMessage += " Move ";
                    if (WSWarning) warningMessage += " Weapon Skill ";
                    if (BSWarning) warningMessage += " Ballistic Skill ";
                    if (SWarning) warningMessage += " Strength ";
                    if (TWarning) warningMessage += " Toughness ";
                    if (AWarning) warningMessage += " Attacks ";
                    if (LdWarning) warningMessage += " Leadership ";
                    if (SvWarning) warningMessage += " Save ";

                    GetComponent<Text>().text = warningMessage;

                } else {

                    GetComponent<Text>().text =
                        "Enter the model's profile. Select the number of damage charts below. You can leave blank stats blank, or enter '0'.";
                    CurrentState = State.basic;
                }
                break;
        }
    }

    public void SetWarning () {

        Debug.Log("Setting warning.");
        CurrentState = State.warning;
        ReturnToCurrentState();
    }
}
