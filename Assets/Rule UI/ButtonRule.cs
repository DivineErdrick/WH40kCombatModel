using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ButtonRule : MonoBehaviour {

    public Rule Rule { get; set; }

    GameManager instance;
    RuleLoader loader;
    RuleSetter setter;
    WeaponUI ui;

    // Use this for initialization
    void Start () {

        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Can not find Game Manger.");
        loader = FindObjectOfType<RuleLoader>();
        Assert.IsNotNull(loader, "Can not find Rule Loader.");
        setter = FindObjectOfType<RuleSetter>();
        Assert.IsNotNull(setter, "Can not find Rule Setter.");
        ui = FindObjectOfType<WeaponUI>();
        Assert.IsNotNull(ui, "Can not find Rule UI.");

        GetComponent<Button>().onClick.AddListener(LoadRule);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadRule () {

        //Debug.Log("Clicked!");
        if (Rule != null) {

            setter.CurrentRule = Rule;
            loader.ResetLoad(Rule);
        }
    }
}
