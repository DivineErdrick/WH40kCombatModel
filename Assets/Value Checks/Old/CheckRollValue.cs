using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRollValue : MonoBehaviour {

    Color defaultColor;

    void Start () {

        defaultColor = GetComponentInChildren<Text>().color;
    }

    public void CheckValue (string value) {

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

    void OutputError (Text[] temp) {
        GetComponent<InputField>().text = "0";
        foreach (Text text in temp) {
            text.color = Color.red;
        }
        Debug.Log("Value of " + name + " is not legal.");
    }
}
