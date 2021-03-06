﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public enum NavigationType { next, previous, up, down, left, right }
    enum Stats { Strength, AP, Damage, Range, Shots }

    GameManager instance;

    public InputField InputName;
    public Dropdown DropdownType;

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

    public GameObject panelAddRules;
    public GameObject contentRules;
    public GameObject buttonWeaponRule;
    public GameObject panelRulesAdded;
    public GameObject panelRemoveRule;

    public Button buttonSave;
    public GameObject panelNameCheck;
    public Button buttonLoad;
    public GameObject panelLoad;
    public GameObject contentLoad;
    public GameObject buttonWeapon;

    WeaponLoader loader;
    WeaponRuleManager manager;
    WeaponMessenger messenger;
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
        Assert.IsNotNull(panelAddRules, "The Rules Panel has not been added to the Weapon UI.");
        Assert.IsNotNull(contentRules, "The Rules Content ui object has not been added to the Weapon UI.");
        Assert.IsNotNull(buttonWeaponRule, "The Rule Button has not been added to the Weapon UI.");
        Assert.IsNotNull(panelRulesAdded, "The Rules Added panel has not been added to the Weapon UI.");
        Assert.IsNotNull(panelRemoveRule, "The Remove Rule panel has not been added to the Weapon UI.");
        Assert.IsNotNull(buttonSave, "The Save Button has not been added to the Weapon UI.");
        Assert.IsNotNull(panelNameCheck, "The Name Check Panel has not been added to the Weapon UI.");
        Assert.IsNotNull(buttonLoad, "The Load Button has not been added to the Weapon UI.");
        Assert.IsNotNull(panelLoad, "The Load Panel has not been added to the Weapon UI.");
        Assert.IsNotNull(contentLoad, "The Load Content ui object has not been added to the Weapon UI.");
        
        instance = GameManager.instance;
        Assert.IsNotNull(instance, "The Weapon UI could not find the Game Manager.");
        loader = gameObject.GetComponent<WeaponLoader>();
        Assert.IsNotNull(loader, "The Weapon UI could not find the Weapon Loader.");
        manager = gameObject.GetComponent<WeaponRuleManager>();
        Assert.IsNotNull(manager, "The Weapon UI could not find the Weapon Rule Manager.");
        messenger = FindObjectOfType<WeaponMessenger>();
        Assert.IsNotNull(messenger, "The Weapon UI could not find the Weapon Messenger.");
        setter = gameObject.GetComponent<WeaponSetter>();
        Assert.IsNotNull(setter, "The Weapon UI could not find the Weapon Setter.");
        defaultColor = InputRange.GetComponentInChildren<Text>().color;

        if (instance.Weapons.Count > 0)
        {
            buttonLoad.interactable = true;
        }

        StartCoroutine(messenger.DisplayMessage("Fill in the weapon's profile."));
    }

    // Update is called once per frame
    void Update()
    {
        GameObject uiObject = EventSystem.current.currentSelectedGameObject;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                Debug.Log("Checking if a UI Object is selected.");
                if (uiObject)
                {
                    KeyboardNavigation(uiObject, NavigationType.previous);
                }
                else
                {
                    Debug.Log("No game object is selected.");
                    SelectUIElement(NavigationType.previous);
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Debug.Log("Checking if a UI Object is selected.");
            if (uiObject)
            {
                KeyboardNavigation(uiObject, NavigationType.next);
            }
            else
            {
                Debug.Log("No game object is selected.");
                SelectUIElement(NavigationType.next);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Debug.Log("Checking if a UI Object is selected.");
            if (uiObject)
            {
                KeyboardNavigation(uiObject, NavigationType.left);
            }
            else
            {
                Debug.Log("No game object is selected.");
                SelectUIElement(NavigationType.left);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("Checking if a UI Object is selected.");
            if (uiObject)
            {
                KeyboardNavigation(uiObject, NavigationType.right);
            }
            else
            {
                Debug.Log("No game object is selected.");
                SelectUIElement(NavigationType.right);
            }
        }
        //else if (Input.GetKeyUp(KeyCode.UpArrow))
        //{
        //    Debug.Log("Checking if a UI Object is selected.");
        //    if (uiObject)
        //    {
        //        KeyboardNavigation(uiObject, NavigationType.up);
        //    }
        //    else
        //    {
        //        Debug.Log("No game object is selected.");
        //        SelectUIElement(NavigationType.up);
        //    }
        //}
        //else if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    Debug.Log("Checking if a UI Object is selected.");
        //    if (uiObject)
        //    {
        //        KeyboardNavigation(uiObject, NavigationType.down);
        //    }
        //    else
        //    {
        //        Debug.Log("No game object is selected.");
        //        SelectUIElement(NavigationType.down);
        //    }
        //}
    }

    void SelectUIElement(NavigationType navigate = NavigationType.next)
    {
        Debug.Log("No selected object. Selecting an object using keyboard navigation.");
        switch (navigate)
        {
            case NavigationType.previous:
            case NavigationType.left:
                if (InputDamage[0].gameObject.activeInHierarchy)
                {
                    EventSystem.current.SetSelectedGameObject(InputDamage[0].gameObject);
                }
                else if (InputDamage[1].gameObject.activeInHierarchy)
                {
                    EventSystem.current.SetSelectedGameObject(InputDamage[1].gameObject);
                }
                else if (DropdownDamage[0].gameObject.activeInHierarchy)
                {
                    OpenDropdown(DropdownDamage[0]);
                }
                else if (DropdownDamage[1].gameObject.activeInHierarchy)
                {
                    OpenDropdown(DropdownDamage[1]);
                }
                else
                {
                    OpenDropdown(DropdownType);
                }
                break;
            case NavigationType.next:
            case NavigationType.right:
            default:
                EventSystem.current.SetSelectedGameObject(InputName.gameObject);
                break;
        }
    }

    void KeyboardNavigation(GameObject uiObject, NavigationType navigate = NavigationType.next)
    {
        Debug.Log("Keyboard navigating from a selected object.");
        if (uiObject == InputName.gameObject)
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    EventSystem.current.SetSelectedGameObject(null);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    OpenDropdown(DropdownType);
                    break;
            }
        }
        else if (uiObject == DropdownType.gameObject || uiObject.transform.IsChildOf(DropdownType.transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    DropdownType.Hide();
                    EventSystem.current.SetSelectedGameObject(InputName.gameObject);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    DropdownType.Hide();
                    if (InputStrength[0].gameObject.activeInHierarchy)
                    {
                        EventSystem.current.SetSelectedGameObject(InputStrength[0].gameObject);
                    }
                    else if (DropdownStrength[0].gameObject.activeInHierarchy)
                    {
                        OpenDropdown(DropdownStrength[0]);
                    }
                    else if (InputRange.gameObject.activeInHierarchy)
                    {
                        EventSystem.current.SetSelectedGameObject(InputRange.gameObject);
                    }
                    else if (DropdownRange.gameObject.activeInHierarchy)
                    {
                        OpenDropdown(DropdownRange);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(null);
                    }
                    break;
            }
        }
        else if (uiObject == InputRange.gameObject ||
                 uiObject == DropdownRange.gameObject ||
                 uiObject.transform.IsChildOf(DropdownRange.transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    if (uiObject == DropdownRange.gameObject || uiObject.transform.IsChildOf(DropdownRange.transform))
                        DropdownRange.Hide();
                    OpenDropdown(DropdownType);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    if (uiObject == DropdownRange.gameObject || uiObject.transform.IsChildOf(DropdownRange.transform))
                        DropdownRange.Hide();
                    if (InputShots.gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputShots.gameObject);
                    else if (DropdownShots.gameObject.activeInHierarchy)
                        OpenDropdown(DropdownShots);
                    break;
            }
        }
        else if (uiObject == InputShots.gameObject ||
                 uiObject == DropdownShots.gameObject ||
                 uiObject.transform.IsChildOf(DropdownShots.transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    if (uiObject == DropdownShots.gameObject || uiObject.transform.IsChildOf(DropdownShots.transform))
                        DropdownShots.Hide();
                    if (InputRange.gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputRange.gameObject);
                    else if (DropdownRange.gameObject.activeInHierarchy)
                        OpenDropdown(DropdownRange);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    if (uiObject == DropdownShots.gameObject || uiObject.transform.IsChildOf(DropdownShots.transform))
                        DropdownShots.Hide();
                    if (InputStrength[1].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputStrength[1].gameObject);
                    else if (DropdownStrength[1].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownStrength[1]);
                    break;
            }
        }
        else if (uiObject == InputStrength[0].gameObject ||
                 uiObject == DropdownStrength[0].gameObject ||
                 uiObject.transform.IsChildOf(DropdownStrength[0].transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    if (uiObject == DropdownStrength[0].gameObject || uiObject.transform.IsChildOf(DropdownStrength[0].transform))
                        DropdownStrength[0].Hide();
                    OpenDropdown(DropdownType);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    if (uiObject == DropdownStrength[0].gameObject || uiObject.transform.IsChildOf(DropdownStrength[0].transform))
                        DropdownStrength[0].Hide();
                    if (InputAP[0].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputAP[0].gameObject);
                    else if (DropdownAP[0].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownAP[0]);
                    break;
            }
        }
        else if (uiObject == InputStrength[1].gameObject ||
                 uiObject == DropdownStrength[1].gameObject ||
                 uiObject.transform.IsChildOf(DropdownStrength[1].transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    if (uiObject == DropdownStrength[1].gameObject || uiObject.transform.IsChildOf(DropdownStrength[1].transform))
                        DropdownStrength[1].Hide();
                    if (InputShots.gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputShots.gameObject);
                    else if (DropdownShots.gameObject.activeInHierarchy)
                        OpenDropdown(DropdownShots);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    if (uiObject == DropdownStrength[1].gameObject || uiObject.transform.IsChildOf(DropdownStrength[1].transform))
                        DropdownStrength[1].Hide();
                    if (InputAP[1].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputAP[1].gameObject);
                    else if (DropdownAP[1].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownAP[1]);
                    break;
            }
        }
        else if (uiObject == InputAP[0].gameObject ||
                 uiObject == DropdownAP[0].gameObject ||
                 uiObject.transform.IsChildOf(DropdownAP[0].transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    if (uiObject == DropdownAP[0].gameObject || uiObject.transform.IsChildOf(DropdownAP[0].transform))
                        DropdownAP[0].Hide();
                    if (InputStrength[0].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputStrength[0].gameObject);
                    else if (DropdownStrength[0].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownStrength[0]);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    if (uiObject == DropdownAP[0].gameObject || uiObject.transform.IsChildOf(DropdownAP[0].transform))
                        DropdownAP[0].Hide();
                    if (InputDamage[0].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputDamage[0].gameObject);
                    else if (DropdownDamage[0].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownDamage[0]);
                    break;
            }
        }
        else if (uiObject == InputAP[1].gameObject ||
                 uiObject == DropdownAP[1].gameObject ||
                 uiObject.transform.IsChildOf(DropdownAP[1].transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    if (uiObject == DropdownAP[1].gameObject || uiObject.transform.IsChildOf(DropdownAP[1].transform))
                        DropdownAP[1].Hide();
                    if (InputStrength[1].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputStrength[1].gameObject);
                    else if (DropdownStrength[1].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownStrength[1]);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    if (uiObject == DropdownAP[1].gameObject || uiObject.transform.IsChildOf(DropdownAP[1].transform))
                        DropdownAP[1].Hide();
                    if (InputDamage[1].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputDamage[1].gameObject);
                    else if (DropdownDamage[1].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownDamage[1]);
                    break;
            }
        }
        else if (uiObject == InputDamage[0].gameObject ||
                 uiObject == DropdownDamage[0].gameObject ||
                 uiObject.transform.IsChildOf(DropdownDamage[0].transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    if (uiObject == DropdownDamage[0].gameObject || uiObject.transform.IsChildOf(DropdownDamage[0].transform))
                        DropdownDamage[0].Hide();
                    if (InputAP[0].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputAP[0].gameObject);
                    else if (DropdownAP[0].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownAP[0]);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    if (uiObject == DropdownDamage[0].gameObject || uiObject.transform.IsChildOf(DropdownDamage[0].transform))
                        DropdownDamage[0].Hide();
                    EventSystem.current.SetSelectedGameObject(null);
                    break;
            }
        }
        else if (uiObject == InputDamage[1].gameObject ||
                 uiObject == DropdownDamage[1].gameObject ||
                 uiObject.transform.IsChildOf(DropdownDamage[1].transform))
        {
            switch (navigate)
            {
                case NavigationType.left:
                case NavigationType.previous:
                    if (uiObject == DropdownDamage[1].gameObject || uiObject.transform.IsChildOf(DropdownDamage[1].transform))
                        DropdownDamage[1].Hide();
                    if (InputAP[1].gameObject.activeInHierarchy)
                        EventSystem.current.SetSelectedGameObject(InputAP[1].gameObject);
                    else if (DropdownAP[1].gameObject.activeInHierarchy)
                        OpenDropdown(DropdownAP[1]);
                    break;
                case NavigationType.right:
                case NavigationType.next:
                default:
                    if (uiObject == DropdownDamage[1].gameObject || uiObject.transform.IsChildOf(DropdownDamage[1].transform))
                        DropdownDamage[1].Hide();
                    EventSystem.current.SetSelectedGameObject(null);
                    break;
            }
        }
    }

    void OpenDropdown(Dropdown dropdown)
    {
        EventSystem.current.SetSelectedGameObject(dropdown.gameObject);
        dropdown.Show();
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
        messenger.UpdateMessage();
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

    public void AddRule ()
    {
        Debug.Log("Open Add rules panel.");
        panelAddRules.SetActive(true);
        
        Debug.Log("Calling rule manager to find and list rules.");
        manager.ListRules();
    }

    public void ManageRulePanel ()
    {
        Debug.Log("Managing rule panel.");
        Debug.Log("Checking number Weapon Setter for number of rules added to weapon.");
        if (setter.WeaponRules.Count == 0)
        {
            panelRulesAdded.SetActive(false);
        }
        else
        {
            panelRulesAdded.SetActive(true);
            Debug.Log(setter.WeaponRules.Count);
            int lines = 1 + (int)Math.Truncate(setter.WeaponRules.Count / (decimal)6.0);
            Debug.Log("Rules Added Panel should have " + lines + "lines.");
            panelRulesAdded.GetComponent<RectTransform>().anchorMin = new Vector2(0.01f, 0.73f - (0.05f * lines));
        }
    }

    public void ClearRulePanel ()
    {
        Debug.Log("Clearing rule panel.");
        Button[] ruleButtons = panelRulesAdded.GetComponentsInChildren<Button>();
        for (int i = 0; i < ruleButtons.Length; i++)
        {
            Destroy(ruleButtons[i].gameObject);
        }
    }

    public void LoadRulesIntoRulePanel (Weapon weapon)
    {
        Debug.Log("Loading Weapon Rules into Rules Panel.");
        setter.WeaponRules = new List<string>();
        foreach(string weaponRule in weapon.Rules)
        {
            RuleV20200106 ruleToLoad = new RuleV20200106 { Name = "Missing Rule" };
            foreach (RuleV20200106 rule in instance.Rules)
            {
                if (rule.Name == weaponRule)
                {
                    ruleToLoad = rule;
                    setter.WeaponRules.Add(rule.Name);
                    Debug.Log("Loading " + rule.Name + " from Weapon.");
                }
            }

            GameObject ruleButton = Instantiate(buttonWeaponRule);
            ruleButton.transform.SetParent(panelRulesAdded.transform);
            ruleButton.GetComponent<ButtonWeaponRule>().Rule = ruleToLoad;
            ruleButton.GetComponent<ButtonWeaponRule>().RuleAdded = true;
            ruleButton.GetComponent<RectTransform>().localScale = Vector3.one;
            ruleButton.GetComponentInChildren<Text>().text = ruleToLoad.Name;
            ManageRulePanel();
        }
    }

    public void OpenNameCheck ()
    {
        panelNameCheck.SetActive(true);
    }

    public void Close(bool overwrite)
    {
        if (!overwrite)
        {
            Button[] buttons = contentLoad.GetComponentsInChildren<Button>();
            Button[] ruleButtons = contentRules.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                Destroy(buttons[i].gameObject);
            }
            for (int i = 0; i < ruleButtons.Length; i++)
            {
                Destroy(ruleButtons[i].gameObject);
            }

            buttonSave.interactable = true;
            buttonLoad.interactable = true;
            //searchField = null;
            panelLoad.SetActive(false);
            panelAddRules.SetActive(false);
            messenger.UpdateMessage();
        }
        else
        {
            panelNameCheck.SetActive(false);
            panelRemoveRule.SetActive(false);
            panelLoad.SetActive(false);
            messenger.UpdateMessage();
        }
    }

    public void Load ()
    {
        Debug.Log("Opening Load Panel");
        panelLoad.SetActive(true);
        loader.StartLoadPanel();
    }

    public void Back ()
    {

        SceneManager.LoadScene("Start");

        //if (triggersSet) {

        //    //panelChargeTriggers.SetActive(true);
        //    //panelFightTriggers.SetActive(true);
        //    //panelMeleeTriggers.SetActive(true);
        //    //panelMoraleTriggers.SetActive(true);
        //    panelTriggers.SetActive(true);
        //    //panelOverwatchTriggers.SetActive(true);
        //    //panelPsychicTriggers.SetActive(true);
        //    panelRuleUse.SetActive(true);
        //    //panelShootingTriggers.SetActive(true);
        //    panelActivation.SetActive(true);

        //    panelRuleUse.SetActive(false);

        //    triggersSet = false;

        //} else {
        //    SceneManager.LoadScene("Start");
        //}
    }

    public void Exit()
    {
        instance.OnDisable();
        Application.Quit();
    }
}
