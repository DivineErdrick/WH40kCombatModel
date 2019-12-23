using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WeaponSaver : MonoBehaviour
{
    GameManager instance;

    WeaponLoader loader;
    WeaponMessenger messenger;
    WeaponSetter setter;
    WeaponUI ui;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.instance;
        loader = GetComponent<WeaponLoader>();
        messenger = FindObjectOfType<WeaponMessenger>();
        setter = GetComponent<WeaponSetter>();
        ui = GetComponent<WeaponUI>();

        Assert.IsNotNull(instance, "Weapon Saver could not locate Game Manager");
        Assert.IsNotNull(loader, "Weapon Saver could not locate Weapon Loader.");
        Assert.IsNotNull(messenger, "Weapon Saver could not locate Weapon Messenger.");
        Assert.IsNotNull(setter, "Weapon Saver could not locate Weapon Setter.");
        Assert.IsNotNull(ui, "Weapon Saver could not locate Weapon Ui.");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Save (bool overwriteSavedRule)
    {
        Debug.Log("Attempting to save weapon.");
        bool dataCheckPassed;
        Weapon weapon = new Weapon();

        dataCheckPassed = DataCheck();
        
        if (dataCheckPassed)
        {
            Debug.Log("Weapon is ready to be saved.");

            Debug.Log("Check to see if the weapon exists.");
            bool nameDoesntExist = true;
            for (int i = 0; i < instance.Weapons.Count; i++)
            {
                if (instance.Weapons[i].Name == setter.Name)
                {
                    Debug.Log("A weapon with that name already exists.");
                    loader.WeaponToLoad = i;
                    nameDoesntExist = false;
                }
            }

            if (nameDoesntExist || overwriteSavedRule)
            {
                Debug.Log("Saving weapon profile.");

                weapon.Name = setter.Name;
                Debug.Log("Weapon name saved as " + weapon.Name + ".");

                weapon.WeaponType = (Weapon.WeaponTypes)setter.Type;
                Debug.Log("Weapon type saved as " + weapon.WeaponType);

                weapon.StrengthIsVar = setter.StrengthIsVar;
                if (weapon.StrengthIsVar)
                {
                    weapon.VarStrength = (Weapon.VarStrengths)setter.VarStrength;
                    Debug.Log("Weapon strength saved as " + weapon.VarStrength);
                } 
                else
                {
                    weapon.Strength = setter.Strength;
                    Debug.Log("Weapon strength saved as " + weapon.Strength);
                }

                weapon.APIsVar = setter.APIsVar;
                if (weapon.APIsVar)
                {
                    weapon.VarAP = (Weapon.VarAPs)setter.VarAP;
                    Debug.Log("Weapon AP saved as " + weapon.VarAP);
                }
                else
                {
                    weapon.AP = setter.AP;
                    Debug.Log("Weapon AP saved as " + weapon.AP);
                }

                weapon.DamageIsVar = setter.DamageIsVar;
                if (weapon.DamageIsVar)
                {
                    weapon.VarDamage = (Weapon.VarDamages)setter.VarDamage;
                    Debug.Log("Weapon Damage saved as " + weapon.VarDamage);
                }
                else
                {
                    weapon.Damage = setter.Damage;
                    Debug.Log("Weapon Damage saved as " + weapon.Damage);
                }

                if (setter.Type >= 2)
                {
                    Debug.Log("Weapon needs ranged weapon statistics.");

                    weapon.RangeIsVar = setter.RangeIsVar;
                    if (weapon.RangeIsVar)
                    {
                        weapon.VarRange = (Weapon.VarRanges)setter.VarRange;
                        Debug.Log("Weapon Range saved as " + weapon.VarRange);
                    }
                    else
                    {
                        weapon.Range = setter.Range;
                        Debug.Log("Weapon Range saved as " + weapon.Range);
                    }

                    weapon.ShotsAreVar = setter.ShotsAreVar;
                    if (weapon.ShotsAreVar)
                    {
                        weapon.VarShots = (Weapon.VarShotTypes)setter.VarShots;
                        Debug.Log("Weapon Shots saved as " + weapon.VarShots);
                    }
                    else
                    {
                        weapon.Shots = setter.Shots;
                        Debug.Log("Weapon Shots saved as " + weapon.Shots);
                    }
                }
                weapon.Rules = new List<string>();
                foreach(string weaponRule in setter.WeaponRules)
                {
                    weapon.Rules.Add(weaponRule);
                    Debug.Log(weaponRule + " has been saved into Weapons.");
                }

                Debug.Log("Saving weapon.");
                if (overwriteSavedRule)
                {
                    Debug.Log("Overwriting rule.");
                    instance.Weapons[loader.WeaponToLoad] = weapon;
                    bool usuallyTrue = true;
                    ui.Close(usuallyTrue);
                }
                else
                {
                    instance.Weapons.Add(weapon);
                    ui.buttonLoad.interactable = true;
                }
                instance.SaveWeapons();
            }
            else
            {
                Debug.Log("Opening name check panel.");
                ui.OpenNameCheck();
            } 
        }
        else
        {
            Debug.Log("Weapon is not ready to be saved.");
        }
    }

    bool DataCheck () 
    {
        if (setter.Name.Length == 0)
        {
            StartCoroutine(messenger.DisplayMessage("You must enter a Name for the weapon.", WeaponMessenger.MessageType.error));
            return false;
        }

        if (setter.Type == 0)
        {
            StartCoroutine(messenger.DisplayMessage("You must select the weapon's type.", WeaponMessenger.MessageType.error));
            return false;
        }

        if (!setter.StrengthIsVar)
        {
            if (setter.Strength <= 0)
            {
                StartCoroutine(messenger.DisplayMessage("Strength must be a positive number.", WeaponMessenger.MessageType.error));
                return false;
            }
        }

        if (! setter.APIsVar)
        {
            if (setter.AP > 0)
            {
                StartCoroutine(messenger.DisplayMessage("AP cannot be a positive number.", WeaponMessenger.MessageType.error));
                return false;
            }
        }

        if (setter.DamageIsVar)
        {
            if (setter.VarDamage == 0)
            {
                StartCoroutine(messenger.DisplayMessage("You must select the weapon's Damage.", WeaponMessenger.MessageType.error));
                return false;
            }
        }
        else
        {
            if (setter.Damage <= 0)
            {
                StartCoroutine(messenger.DisplayMessage("Damage must be a positive number.", WeaponMessenger.MessageType.error));
                return false;
            }
        }

        if (setter.Type >= 2)
        {
            if (setter.RangeIsVar)
            {
                if (setter.VarRange == 0)
                {
                    StartCoroutine(messenger.DisplayMessage("You must select the weapon's Range.", WeaponMessenger.MessageType.error));
                    return false;
                }
            }
            else
            {
                if (setter.Range <= 0)
                {
                    StartCoroutine(messenger.DisplayMessage("Range must be a positive number.", WeaponMessenger.MessageType.error));
                    return false;
                }
            }

            if (!setter.ShotsAreVar)
            {
                if (setter.Shots <= 0)
                {
                    StartCoroutine(messenger.DisplayMessage("Shots must be a positive number.", WeaponMessenger.MessageType.error));
                    return false;
                }
            }
        }

        return true;    
    }
}
