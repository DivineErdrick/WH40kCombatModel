using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChecker : MonoBehaviour {

    public Color defaultColor;

    void Start() {

    }

    public void CheckValueNotNegative (string value) {

        ProfileSetter profileSetter = FindObjectOfType<ProfileSetter>();
        int nValue = ReadIntString(value);

        if (nValue >= 0) {
            CorrectInputColor(gameObject);
            profileSetter.SetProfile(name, value);
        } else {
            OutputError(gameObject);
        }
    }

    public void CheckValuePositive (string value) {

        ProfileSetter profileSetter = FindObjectOfType<ProfileSetter>();
        int nValue = ReadIntString(value);

        if (nValue > 0) {
            CorrectInputColor(gameObject);
            profileSetter.SetProfile(name, value);
        } else {
            OutputError(gameObject);
        }
    }

    public void CheckValueD6 (string value) {

        ProfileSetter profileSetter = FindObjectOfType<ProfileSetter>();
        int nValue = ReadIntString(value);

        if (-1 < nValue && nValue < 8) {
            CorrectInputColor(gameObject);
            profileSetter.SetProfile(name, value);
        } else {
            OutputError(gameObject);
        }
    }

    public void CheckValueNoEmptyStrings (string value) {

        ProfileSetter profileSetter = FindObjectOfType<ProfileSetter>();
        if (value.Length != 0) {
            CorrectInputColor(gameObject);
            profileSetter.SetProfile(name, value);
        } else {
            OutputError(gameObject);
        }
    }

    int ReadIntString (string value) {

        int nValue;
        if (int.TryParse(value, out nValue)) {
            
        } else {
            nValue = -1;
        }
        return nValue;
    }

    private void CorrectInputColor(GameObject input) {

        Text[] temp = input.GetComponentsInChildren<Text>();
        foreach (Text text in temp) {
            text.color = defaultColor;

            switch (text.gameObject.name.Length) {

                case 13:
                    if (text.gameObject.name[8] == 'P') {
                        text.text = "";
                    }
                    break;
                case 14:
                    if (text.gameObject.name[9] == 'P') {
                        text.text = "";
                    }
                    break;
                case 15:
                    if (text.gameObject.name[10] == 'P') {
                        text.text = "Name";
                    }
                    break;
                case 23:
                    if (text.gameObject.name[18] == 'P') {
                        text.text = "";
                    }
                    break;
                default:
                    break;
            }
        }
    }

    void OutputError(GameObject input) {

        Text[] temp = input.GetComponentsInChildren<Text>();
        foreach (Text text in temp) {
            text.color = Color.red;

            switch (text.gameObject.name.Length) {

                case 13:
                    if (text.gameObject.name[8] == 'P') {
                        text.text = "E";
                    }
                    break;
                case 14:
                    if (text.gameObject.name[9] == 'P') {
                        text.text = "E";
                    }
                    break;
                case 15:
                    if (text.gameObject.name[10] == 'P') {
                        text.text = "Error";
                    }
                    break;
                case 23:
                    if (text.gameObject.name[18] == 'P') {
                        text.text = "E";
                    }
                    break;
                default:
                    break;
            }
        }
        Debug.Log("Value of " + input.name + " is not legal.");
    }
}
