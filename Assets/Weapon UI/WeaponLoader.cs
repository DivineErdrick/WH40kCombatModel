using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WeaponLoader : MonoBehaviour
{
    GameManager instance;
    WeaponUI ui;
    WeaponMessenger messenger;
    WeaponSetter setter;

    //public Weapon WeaponToLoad { get; set; }
    public int WeaponToLoad { get; set; }

    public InputField searchField;

    ButtonWeapon[] buttonWeapons;

    bool weaponsLoaded;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Weapon Loader could not find Game Manager.");
        messenger = FindObjectOfType<WeaponMessenger>();
        Assert.IsNotNull(messenger, "Weapon Loader could not find Weapon Messenger.");
        setter = gameObject.GetComponent<WeaponSetter>();
        Assert.IsNotNull(setter, "Weapon Loader could not find Weapon Setter.");
        ui = gameObject.GetComponent<WeaponUI>();
        Assert.IsNotNull(ui, "Weapon Loader could not find Weapon UI.");

        weaponsLoaded = instance.Weapons.Count > 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.panelLoad.activeInHierarchy && weaponsLoaded) {

            string searchTerm = searchField.GetComponent<InputField>().text;

            for (int i = 0; i < buttonWeapons.Length; i++) {
                buttonWeapons[i].gameObject.SetActive(true);
            }

            if (searchTerm.Length > 0) {

                for (int i = 0; i < searchTerm.Length; i++) {

                    for (int n = 0; n < buttonWeapons.Length; n++) {

                        string sTemp = buttonWeapons[n].Weapon.Name;
                        if (searchTerm[i] != sTemp[i]) {

                            buttonWeapons[n].gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    public void StartLoadPanel() {

        if (instance.Weapons.Count > 6) {
            ui.contentLoad.GetComponent<RectTransform>().offsetMin = new Vector2(0, -48 * (instance.Weapons.Count - 6));
        }
        for (int i = 0; i < instance.Weapons.Count; i++) {
            string weaponName = instance.Weapons[i].Name;
            GameObject weaponButton = Instantiate(ui.buttonWeapon);
            weaponButton.transform.SetParent(ui.contentLoad.transform);
            weaponButton.GetComponent<ButtonWeapon>().WeaponIndex = i;
            weaponButton.GetComponent<ButtonWeapon>().Weapon = instance.Weapons[i];
            weaponButton.GetComponent<RectTransform>().localScale = Vector3.one;
            weaponButton.GetComponentInChildren<Text>().text = weaponName;
        }

        buttonWeapons = FindObjectsOfType<ButtonWeapon>();
        //searchField = ui.panelLoad.GetComponentInChildren<InputField>();
        weaponsLoaded = true;
    }

    public void NameCheckLoad ()
    {
        //Called from the Name Check Panel.
        //Find the weapon to load.

        Debug.Log("Load the weapon found by NameCheck.");
        ResetLoad(WeaponToLoad);
        bool usuallyTrue = true;
        ui.Close(usuallyTrue);
    }

    public void ResetLoad(int weaponToLoad) {

        Weapon weapon = instance.Weapons[weaponToLoad];
        setter.Name = weapon.Name;
        ui.InputName.text = setter.Name;
        Debug.Log("Weapon name is " + setter.Name);

        setter.Type = (int)weapon.WeaponType;

        ui.DropdownType.value = setter.Type;

        setter.StrengthIsVar = weapon.StrengthIsVar;
        if (setter.StrengthIsVar)
        {
            setter.VarStrength = (int)weapon.VarStrength;
        }
        else
        {
            setter.Strength = weapon.Strength;
        }

        setter.APIsVar = weapon.APIsVar;
        if (setter.APIsVar)
        {
            setter.VarAP = (int)weapon.VarAP;
        }
        else
        {
            setter.AP = weapon.AP;
        }

        setter.DamageIsVar = weapon.DamageIsVar;
        if (setter.DamageIsVar)
        {
            setter.VarDamage = (int)weapon.VarDamage;
        }
        else
        {
            setter.Damage = weapon.Damage;
        }

        if (setter.Type >= 2)
        {
            setter.RangeIsVar = weapon.RangeIsVar;
            if (setter.RangeIsVar)
            {
                setter.VarRange = (int)weapon.VarRange;
            }
            else
            {
                setter.Range = weapon.Range;
            }

            setter.ShotsAreVar = weapon.ShotsAreVar;
            if (setter.ShotsAreVar)
            {
                setter.VarShots = (int)weapon.VarShots;
            }
            else
            {
                setter.Shots = weapon.Shots;
            }
        }

        ui.ClearRulePanel();
        ui.LoadRulesIntoRulePanel(weapon);

        ui.UpdateUI();
        ui.ManageRulePanel();
        messenger.DisplayMessage("Weapon loaded.");
        
    }

    public void LoadSavedWeapon() {
        ResetLoad(WeaponToLoad);

        //Close Panel
    }
}
