using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameCheckPanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OverwriteProfile () {

        GameManager instance = FindObjectOfType<GameManager>();
        ProfileCopier copier = FindObjectOfType<ProfileCopier>();
        ProfileSaver saver = FindObjectOfType<ProfileSaver>();
        ProfileSetter setter = FindObjectOfType<ProfileSetter>();

        Profile saveProfile = copier.CopyProfile(setter.CurrentProfile);
        instance.Profiles[saver.profileToLoad] = saveProfile;
        instance.SaveProfile();
        ClosePanel();
    }

    public void LoadProfile () {
        Debug.Log("Attempting to Load the original profile.");

        GameManager instance = FindObjectOfType<GameManager>();
        ProfileSaver saver = FindObjectOfType<ProfileSaver>();
        ProfileCopier copier = FindObjectOfType<ProfileCopier>();
        ProfileLoader loader = FindObjectOfType<ProfileLoader>();
        ProfileSetter setter = FindObjectOfType<ProfileSetter>();

        Debug.Log("Loading profile named " + instance.Profiles[saver.profileToLoad].Name + ".");
        setter.CurrentProfile = copier.CopyProfile(instance.Profiles[saver.profileToLoad]);

        loader.LoadProfile(setter.CurrentProfile);
        
        ClosePanel();
    }

    public void ClosePanel () {

        ProfileUI UI = FindObjectOfType<ProfileUI>();

        UI.SetInteractable(true);
        gameObject.SetActive(false);
    }
}
