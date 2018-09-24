using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonRule : MonoBehaviour {

    public Rule Rule { get; set; }

    GameManager instance;
    RuleUI ruleUI;

    // Use this for initialization
    void Start () {
        instance = GameManager.instance;

        GetComponent<Button>().onClick.AddListener(LoadProfile);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadProfile () {

        //Debug.Log("Clicked!");
        if (Rule != null) {

            ruleUI = FindObjectOfType<RuleUI>();
            instance.ActiveRule = Rule;
            ruleUI.ResetLoad(Rule);
        }
    }
}
