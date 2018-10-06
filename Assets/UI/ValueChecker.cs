using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueChecker : MonoBehaviour {

    Color defaultColor;

    void Start() {

        defaultColor = GetComponentInChildren<Text>().color;
    }

    public void CheckValueNotNegative (string value) {

        int nValue;
        Text[] temp = GetComponentsInChildren<Text>();
        if (int.TryParse(value, out nValue)) {

            if (nValue >= 0) {
                foreach (Text text in temp) {
                    text.color = defaultColor;
                }
            } else {
                OutputError(temp);
            }
        } else {
            OutputError(temp);
        }
    }

    public void CheckValuePositive (string value) {

        int nValue;
        Text[] temp = GetComponentsInChildren<Text>();
        if (int.TryParse(value, out nValue)) {

            if (nValue > 0) {
                foreach (Text text in temp) {
                    text.color = defaultColor;
                }
            } else {
                OutputError(temp);
            }
        } else {
            OutputError(temp);
        }
    }

    public void CheckValueD6 (string value) {

        int nValue;
        Text[] temp = GetComponentsInChildren<Text>();
        if (int.TryParse(value, out nValue)) {

            if (0 < nValue && nValue < 7) {
                foreach (Text text in temp) {
                    text.color = defaultColor;
                }
            } else {
                OutputError(temp);
            }
        } else {
            OutputError(temp);
        }
    }

    public void CheckValueNoEmptyStrings (string value) {

        Text[] temp = GetComponentsInChildren<Text>();
        if (value.Length != 0) {

            foreach (Text text in temp) {
                text.color = defaultColor;
            }
        } else {
            OutputError(temp);
        }
    }

    void OutputError(Text[] temp) {
        GetComponent<InputField>().text = "0";
        foreach (Text text in temp) {
            text.color = Color.red;
        }
        Debug.Log("Value of " + name + " is not legal.");
    }
}
