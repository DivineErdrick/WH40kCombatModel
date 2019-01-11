using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonProfile : MonoBehaviour {

    public Profile Profile { get; set; }

    GameManager instance;

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

            ProfileCopier copier = FindObjectOfType<ProfileCopier>();
            ProfileLoader loader = FindObjectOfType<ProfileLoader>();
            ProfileSetter setter = FindObjectOfType<ProfileSetter>();

            setter.CurrentProfile = copier.CopyProfile(Profile);
            loader.LoadProfile(setter.CurrentProfile);
        }
    }
}
