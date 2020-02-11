using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class ButtonWeaponRule : MonoBehaviour
{
    public RuleV20200106 Rule { get; set; }
    public bool RuleAdded { get; set; }

    WeaponRuleManager manager;
    WeaponSetter setter;
    WeaponUI ui;
    
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<WeaponRuleManager>();
        Assert.IsNotNull(manager, "Weapon Rule Button can not locate Weapon Rule Manager.");
        setter = FindObjectOfType<WeaponSetter>();
        Assert.IsNotNull(setter, "Weapon Rule Button can not locate Weapon Setter.");
        ui = FindObjectOfType<WeaponUI>();
        Assert.IsNotNull(ui, "Weapon Rule Button can not locate Weapon UI.");

        GetComponent<Button>().onClick.AddListener(AddRemoveRule);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddRemoveRule ()
    {
        if (RuleAdded)
        {
            Debug.Log("Open remove rule panel.");
            manager.ButtonToRemove = gameObject;
            ui.panelRemoveRule.SetActive(true);
        }
        else
        {
            Debug.Log("Adding rule.");
            setter.WeaponRules.Add(Rule.Name);            
            transform.SetParent(ui.panelRulesAdded.transform);
            Debug.Log("Calling Weapon UI to manage rule panel.");
            ui.ManageRulePanel();
            RuleAdded = true;
        }
    }
}
