using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class NameCheckPanel : MonoBehaviour {

    ProfileUI ui;

	// Use this for initialization
	void Start () {

        ui = FindObjectOfType<ProfileUI>();
        Assert.IsNotNull(ui, "Name Check Panel could not locate Profile UI.");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OverwriteProfile () {

        GameManager instance = FindObjectOfType<GameManager>();
        ProfileCopier copier = FindObjectOfType<ProfileCopier>();
        ProfileSaver saver = FindObjectOfType<ProfileSaver>();
        ProfileSetter setter = FindObjectOfType<ProfileSetter>();
        ProfileMessager messager = FindObjectOfType<ProfileMessager>();

        Profile saveProfile = copier.CopyProfile(setter.CurrentProfile);

        instance.Profiles[saver.profileToLoad] = saveProfile;
        instance.SaveProfile();

        ui.Close(ProfileUI.CloseType.nameCheckSave);
    }

    public void LoadProfile () {
        Debug.Log("Attempting to Load the original profile.");

        GameManager instance = FindObjectOfType<GameManager>();
        ProfileSaver saver = FindObjectOfType<ProfileSaver>();
        ProfileCopier copier = FindObjectOfType<ProfileCopier>();
        ProfileLoader loader = FindObjectOfType<ProfileLoader>();
        ProfileSetter setter = FindObjectOfType<ProfileSetter>();
        ProfileMessager messager = FindObjectOfType<ProfileMessager>();

        Debug.Log("Loading profile named " + instance.Profiles[saver.profileToLoad].Name + ".");
        setter.CurrentProfile = copier.CopyProfile(instance.Profiles[saver.profileToLoad]);

        loader.LoadProfile(setter.CurrentProfile);

        ui.Close(ProfileUI.CloseType.nameCheckLoad);
    }

    public void ClosePanel () {

        ui.Close(ProfileUI.CloseType.basic);
    }
}
