using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WeaponRuleManager : MonoBehaviour
{
    GameManager instance;

    public GameObject searchField;

    WeaponUI ui;

    ButtonWeaponRule[] buttonRules;

    bool rulesLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Weapon Rule Manager could not find Game Manager.");
        Assert.IsNotNull(searchField, "Search Field has not been assigned to Weapon Rule Manager.");
        ui = GetComponent<WeaponUI>();
        Assert.IsNotNull(ui, "Weapon Rule Manager could not find Weapon UI.");
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.panelAddRules.activeInHierarchy && rulesLoaded)
        {

            string searchTerm = searchField.GetComponent<InputField>().text;

            for (int i = 0; i < buttonRules.Length; i++)
            {
                buttonRules[i].gameObject.SetActive(true);
            }

            if (searchTerm.Length > 0)
            {

                for (int i = 0; i < searchTerm.Length; i++)
                {

                    for (int n = 0; n < buttonRules.Length; n++)
                    {

                        string sTemp = buttonRules[n].Rule.Name;
                        if (searchTerm[i] != sTemp[i])
                        {

                            buttonRules[n].gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    public void ListRules ()
    {
        Debug.Log("Listing Rules.");
        if (instance.Rules.Count > 6)
        {
            ui.contentRules.GetComponent<RectTransform>().offsetMin = new Vector2(0, -48 * (instance.Weapons.Count - 6));
        }
        for (int i = 0; i < instance.Rules.Count; i++)
        {
            string ruleName = instance.Rules[i].Name;
            GameObject ruleButton = Instantiate(ui.buttonWeaponRule);
            ruleButton.transform.SetParent(ui.contentRules.transform);
            ruleButton.GetComponent<ButtonWeaponRule>().Rule = instance.Rules[i];
            ruleButton.GetComponent<RectTransform>().localScale = Vector3.one;
            ruleButton.GetComponentInChildren<Text>().text = ruleName;
        }

        buttonRules = FindObjectsOfType<ButtonWeaponRule>();
        //searchField = ui.panelLoad.GetComponentInChildren<InputField>();
        rulesLoaded = true;
    }

    public void RemoveRule (string rule)
    {
        Debug.Log("Removing rule.");
        Debug.Log("Calling Weapon UI to manage rule panel.");
    }
}
