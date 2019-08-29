using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class WeaponLoader : MonoBehaviour
{
    GameManager instance;
    WeaponUI ui;
    WeaponSetter setter;

    public int WeaponToLoad { get; set; }

    public InputField searchField;

    ButtonRule[] buttonRules;

    bool rulesLoaded;

    // Start is called before the first frame update
    void Start()
    {
        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Could not find Game Manager.");
        setter = FindObjectOfType<WeaponSetter>();
        Assert.IsNotNull(setter, "Could not find Rule Setter.");
        ui = FindObjectOfType<WeaponUI>();
        Assert.IsNotNull(ui, "Could not find Rule UI.");
    }

    // Update is called once per frame
    void Update()
    {
        if (ui.panelLoad.activeInHierarchy && rulesLoaded) {

            string searchTerm = searchField.GetComponent<InputField>().text;

            for (int i = 0; i < buttonRules.Length; i++) {
                buttonRules[i].gameObject.SetActive(true);
            }

            if (searchTerm.Length > 0) {

                for (int i = 0; i < searchTerm.Length; i++) {

                    for (int n = 0; n < buttonRules.Length; n++) {

                        string sTemp = buttonRules[n].Rule.Name;
                        if (searchTerm[i] != sTemp[i]) {

                            buttonRules[n].gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    public void StartLoadPanel() {

        instance = GameManager.instance;
        ui = FindObjectOfType<WeaponUI>();

        if (instance.Rules.Count > 6) {
            ui.contentLoad.GetComponent<RectTransform>().offsetMin = new Vector2(0, -48 * (instance.Rules.Count - 6));
        }
        for (int i = 0; i < instance.Rules.Count; i++) {
            string weaponName = instance.Rules[i].Name;
            GameObject weaponButton = Instantiate(ui.buttonRule);
            weaponButton.transform.SetParent(ui.contentLoad.transform);
            weaponButton.GetComponent<ButtonRule>().Rule = instance.Rules[i];
            weaponButton.GetComponent<RectTransform>().localScale = Vector3.one;
            weaponButton.GetComponentInChildren<Text>().text = weaponName;
        }

        buttonRules = FindObjectsOfType<ButtonRule>();
        //searchField = ui.panelLoad.GetComponentInChildren<InputField>();
        rulesLoaded = true;
    }

    public void ResetLoad(Rule weapon) {

        setter.Name = weapon.Name;
        ui.InputName.text = setter.Name;
        Debug.Log("Rule name is " + setter.Name);

        //Load weapon into setter and ui

    }

    public void LoadSavedRule() {
        ResetLoad(instance.Rules[WeaponToLoad]);

        //Close Panel
    }
}
