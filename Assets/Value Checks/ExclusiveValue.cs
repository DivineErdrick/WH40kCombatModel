using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExclusiveValue : MonoBehaviour {

    GameManager instance;
    MoveUI moveUI;

    void Awake () {
        instance = GameManager.instance;
    }

    // Use this for initialization
    void Start () {
        instance = GameManager.instance;
        moveUI = FindObjectOfType<MoveUI>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleValues (bool toggledState) {

        if ( ! instance.MovementRulesSet) {

            Toggle reserveMarker = GameObject.Find("Toggle Reserve Marker").GetComponent<Toggle>();
            Toggle deepStrike = GameObject.Find("Toggle Deepstrike").GetComponent<Toggle>();

            if (reserveMarker && deepStrike) {
                
                if (moveUI.ReserveMarker && ! toggledState) {
                    deepStrike.isOn = false;
                } 
                if (moveUI.DeepStrike) {
                    reserveMarker.isOn = false;
                }
            }

            Debug.Log("Reserve Marker is " + moveUI.ReserveMarker + ". Deep Strike is " + moveUI.DeepStrike);
        }
    }
}
