using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WeaponMessenger : MonoBehaviour
{
    public enum MessageType { standard, error }
    
    Color defaultColor;
    WeaponSetter setter;
    WeaponUI ui;

    // Start is called before the first frame update
    void Start()
    { 
        setter = FindObjectOfType<WeaponSetter>();
        Assert.IsNotNull(setter, "Weapon Messenger could not locate Weapon Setter.");
        ui = FindObjectOfType<WeaponUI>();
        Assert.IsNotNull(ui, "Weapon Messenger could not locate Weapon UI.");

        defaultColor = GetComponent<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateMessage ()
    {
        GetComponent<Text>().color = defaultColor;
        GetComponent<Text>().text = "Updating displayed message.";
        if (ui.panelAddRules.activeInHierarchy)
        {
            GetComponent<Text>().text = "Select Rules to be added to the weapon. Rules can be removed by clicking on them.";
        }
        else if (ui.panelLoad.activeInHierarchy)
        {
            GetComponent<Text>().text = "Select the weapon to load.";
        }
        else if (setter.Name.Length == 0)
        {
            GetComponent<Text>().text = "Enter the weapon's Name.";
        }
        else if (setter.Type == 0)
        {
            GetComponent<Text>().text = "You must select a Type for the weapon.";
        } 
        else if (setter.Type >= 2)
        {
            if (setter.Range == 0)
            {
                GetComponent<Text>().text = "Enter the Range for the weapon.";
            }
            else if (! setter.ShotsAreVar && setter.Shots == 0)
            {
                GetComponent<Text>().text = "Enter the Shots for the weapon. You can select dice by checking variable.";
            }
            else if (setter.ShotsAreVar && setter.VarShots == 0)
            {
                GetComponent<Text>().text = "Select the dice used to determine the weapon's number of shots.";
            }
        }
        else if (! setter.StrengthIsVar && setter.Strength == 0)
        {
            GetComponent<Text>().text = "Enter the weapon's Strength. You can select dice by checking variable.";
        }
        else if (! setter.DamageIsVar && setter.Damage == 0)
        {
            GetComponent<Text>().text = "Enter the weapon's Damage. You can select dice by checking variable.";
        }
        else if (setter.DamageIsVar && setter.VarDamage == 0)
        {
            GetComponent<Text>().text = "Select the dice used to determine damage dealt by the weapon.";
        }
        else
        {
            GetComponent<Text>().text = "The weapon is ready to be save. You can still add rules or an AP if needed.";
        }
        GetComponent<Text>().gameObject.SetActive(false);
        GetComponent<Text>().gameObject.SetActive(true);
    }

    public IEnumerator DisplayMessage (string message, MessageType messageType = MessageType.standard)
    {
        if (messageType == MessageType.error)
        {
            GetComponent<Text>().color = Color.red;
        }
        GetComponent<Text>().text = message;
        Debug.Log("Displaying temporary message.");
        yield return new WaitForSeconds(5.0f);
        UpdateMessage();
    }
}
