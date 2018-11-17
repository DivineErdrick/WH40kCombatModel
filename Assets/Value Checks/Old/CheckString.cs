using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckString : MonoBehaviour {

    Color defaultColor;

    void Start() {

        defaultColor = GetComponentInChildren<Text>().color;
    }

    public void CheckValue (string value) {

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
        foreach (Text text in temp) {
            text.color = Color.red;
        }
        Debug.Log("Value of " + name + " is not legal.");
    }
}
