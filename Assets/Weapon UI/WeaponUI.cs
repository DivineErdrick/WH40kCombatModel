using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    enum Stats { Strength, AP, Damage, Range, Shots }

    public GameObject PanelMelee;
    public GameObject PanelRange;

    public Toggle[] ToggleStrength;
    public InputField[] InputStrength;
    public Dropdown[] DropdownStrength;

    public Toggle[] ToggleAP;
    public InputField[] InputAP;
    public Dropdown[] DropdownAP;

    public Toggle[] ToggleDamage;
    public InputField[] InputDamage;
    public Dropdown[] DropdownDamage;

    public Toggle ToggleRange;
    public InputField InputRange;
    public Dropdown DropdownRange;

    public Toggle ToggleShots;
    public InputField InputShots;
    public Dropdown DropdownShots;

    WeaponSetter setter;

    Color defaultColor;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(PanelMelee, "The Melee Panel has not been added to the Weapon UI.");
        Assert.IsNotNull(PanelRange, "The Range Panel has not been added to the Weapon UI.");
        Assert.IsNotNull(InputStrength, "The Strength Input has not been added to the Weapon UI.");
        Assert.IsNotNull(DropdownStrength, "The Strength Dropdown has not been added to the Weapon UI.");
        Assert.IsNotNull(InputAP, "The AP Input has not been added to the Weapon UI.");
        Assert.IsNotNull(DropdownAP, "The AP Dropdown has not been added to the Weapon UI.");
        Assert.IsNotNull(InputDamage, "The Damage Input has not been added to the Weapon UI.");
        Assert.IsNotNull(DropdownDamage, "The Damage Dropdown has not been added to the Weapon UI.");
        Assert.IsNotNull(InputRange, "The Range Input has not been added to the Weapon UI.");
        Assert.IsNotNull(DropdownRange, "The Range Dropdown has not been added to the Weapon UI.");
        Assert.IsNotNull(InputShots, "The Shots Input has not been added to the Weapon UI.");
        Assert.IsNotNull(DropdownShots, "The Shots Dropdown has not been added to the Weapon UI.");
        setter = gameObject.GetComponent<WeaponSetter>();
        Assert.IsNotNull(setter, "The Weapon UI could not find the Weapon Setter.");
        defaultColor = InputRange.GetComponentInChildren<Text>().color;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateUI ()
    {
        if (setter.Type != 0)
        {
            if (setter.Type == 1)
            {
                PanelMelee.SetActive(true);
                PanelRange.SetActive(false);
            }
            else
            {
                PanelMelee.SetActive(false);
                PanelRange.SetActive(true);
            }
            foreach (Toggle strength in ToggleStrength)
            {
                strength.isOn = setter.StrengthIsVar;
            }
            foreach (Toggle AP in ToggleAP)
            {
                AP.isOn = setter.APIsVar;
            }
            foreach (Toggle Damage in ToggleDamage)
            {
                Damage.isOn = setter.DamageIsVar;
            }
            ToggleRange.isOn = setter.RangeIsVar;
            ToggleShots.isOn = setter.ShotsAreVar;
            if (setter.StrengthIsVar)
            {
                foreach (InputField strength in InputStrength)
                {
                    strength.gameObject.SetActive(false);
                }
                foreach (Dropdown strength in DropdownStrength)
                {
                    strength.gameObject.SetActive(true);
                    strength.value = setter.VarStrength;
                }
            }
            else
            {
                foreach (InputField strength in InputStrength)
                {
                    strength.gameObject.SetActive(true);
                    if (setter.Strength == 0)
                    {
                        strength.text = "";
                    }
                    else
                    {
                        strength.text = setter.Strength.ToString();
                        CheckForErrors(setter.Strength, true, Stats.Strength);
                    }
                }
                foreach (Dropdown strength in DropdownStrength)
                {
                    strength.gameObject.SetActive(false);
                }
            }
            if (setter.APIsVar)
            {
                foreach (InputField AP in InputAP)
                {
                    AP.gameObject.SetActive(false);
                }
                foreach (Dropdown AP in DropdownAP)
                {
                    AP.gameObject.SetActive(true);
                    AP.value = setter.VarAP;
                }
            }
            else
            {
                foreach (InputField AP in InputAP)
                {
                    AP.gameObject.SetActive(true);
                    if (setter.AP == 0)
                    {
                        AP.text = "";
                    }
                    else
                    {
                        AP.text = setter.AP.ToString();
                        CheckForErrors(setter.AP, false, Stats.AP);
                    }
                }
                foreach (Dropdown AP in DropdownAP)
                {
                    AP.gameObject.SetActive(false);
                }
            }
            if (setter.DamageIsVar)
            {
                foreach (InputField damage in InputDamage)
                {
                    damage.gameObject.SetActive(false);
                }
                foreach (Dropdown damage in DropdownDamage)
                {
                    damage.gameObject.SetActive(true);
                    damage.value = setter.VarDamage;
                }
            }
            else
            {
                foreach (InputField damage in InputDamage)
                {
                    damage.gameObject.SetActive(true);
                    if (setter.Damage == 0)
                    {
                        damage.text = "";
                    }
                    else
                    {
                        damage.text = setter.Damage.ToString();
                        CheckForErrors(setter.Damage, true, Stats.Damage);
                    }
                }
                foreach (Dropdown damage in DropdownDamage)
                {
                    damage.gameObject.SetActive(false);
                }
            }
            if (setter.RangeIsVar)
            {
                InputRange.gameObject.SetActive(false);
                DropdownRange.gameObject.SetActive(true);
                DropdownRange.value = setter.VarRange;
            }
            else
            {
                InputRange.gameObject.SetActive(true);
                if (setter.Range == 0)
                {
                    InputRange.text = "";
                }
                else
                {
                    InputRange.text = setter.Range.ToString();
                    CheckForErrors(setter.Range, true, Stats.Range);
                }
                DropdownRange.gameObject.SetActive(false);
            }
            if (setter.ShotsAreVar)
            {
                InputShots.gameObject.SetActive(false);
                DropdownShots.gameObject.SetActive(true);
                DropdownShots.value = setter.VarShots;
            }
            else
            {
                InputShots.gameObject.SetActive(true);
                if (setter.Shots == 0)
                {
                    InputShots.text = "";
                }
                else
                {
                    InputShots.text = setter.Shots.ToString();
                    CheckForErrors(setter.Shots, true, Stats.Shots);
                }
                DropdownShots.gameObject.SetActive(false);
            }
        }
        else
        {
            PanelMelee.SetActive(false);
            PanelRange.SetActive(false);
        }
    }
    void CheckForErrors(int value, bool isPositive, Stats stat)
    {
        Color colorToUse;

        colorToUse = ((value > 0) == isPositive) ? defaultColor : Color.red;

        switch (stat)
        {
            case Stats.Strength:
                ChangeInputGroupColors(InputStrength, colorToUse);
                break;
            case Stats.AP:
                ChangeInputGroupColors(InputAP, colorToUse);
                break;
            case Stats.Damage:
                ChangeInputGroupColors(InputDamage, colorToUse);
                break;
            case Stats.Range:
                ChangeTextColors(InputRange.gameObject, colorToUse);
                break;
            case Stats.Shots:
                ChangeTextColors(InputRange.gameObject, colorToUse);
                break;
        }
    }

    void ChangeInputGroupColors (InputField[] inputGroup, Color colorToUse)
    {
        foreach (InputField field in inputGroup)
        {
            ChangeTextColors(field.gameObject, colorToUse);
        }
    }

    void ChangeTextColors(GameObject textObject, Color colorToUse)
    {
        Text[] texts = textObject.GetComponentsInChildren<Text>();
        foreach (Text text in texts)
        {
            text.color = colorToUse;
        }
    }
}
