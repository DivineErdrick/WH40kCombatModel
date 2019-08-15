using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponValueNegative : MonoBehaviour
{
    Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        defaultColor = GetComponentsInChildren<Text>()[0].color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckForError(string value)
    {
        if (ReadIntString(value) < 0)
        {
            ChangeTextColors(defaultColor);
        }
        else
        {
            ChangeTextColors(Color.red);
        }
    }

    int ReadIntString(string value)
    {

        int nValue;
        if (!int.TryParse(value, out nValue))
        {
            nValue = 1;
        }
        return nValue;
    }

    void ChangeTextColors(Color colorToUse)
    {
        Text[] texts = GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            text.color = colorToUse;
        }
    }
}
