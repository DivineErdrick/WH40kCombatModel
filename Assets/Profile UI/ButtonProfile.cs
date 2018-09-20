using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonProfile : MonoBehaviour {

    public Profile Profile { get; set; }

    GameManager instance;
    ProfileUI profileUI;

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
        if (Profile != null) {

            profileUI = FindObjectOfType<ProfileUI>();
            instance.ActiveProfile = Profile;
            profileUI.ResetLoad(Profile);
        }
    }
}
