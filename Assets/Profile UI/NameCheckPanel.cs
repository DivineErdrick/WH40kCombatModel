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
        ProfileSaver saver = FindObjectOfType<ProfileSaver>();
        ProfileSetter setter = FindObjectOfType<ProfileSetter>();

        Profile saveProfile = saver.CopyProfile(setter.CurrentProfile);
        instance.Profiles[saver.profileToLoad] = saveProfile;
        instance.SaveProfile();
        ClosePanel();
    }

    public void LoadProfile () {
        Debug.Log("Attempting to Load the original profile.");

        GameManager instance = FindObjectOfType<GameManager>();
        ProfileSaver saver = FindObjectOfType<ProfileSaver>();
        ProfileSetter setter = FindObjectOfType<ProfileSetter>();
        ProfileUI UI = FindObjectOfType<ProfileUI>();

        Debug.Log("Loading profile named " + instance.Profiles[saver.profileToLoad].Name + ".");
        setter.CurrentProfile = instance.Profiles[saver.profileToLoad];

        for (int i = 0; i <= setter.CurrentProfile.DamageCharts; i++) {
            Debug.Log("M" + i + ": " + setter.CurrentProfile.Move[i] +
                     " WS" + i + ": " + setter.CurrentProfile.WeaponSkill[i] +
                     " BS" + i + ": " + setter.CurrentProfile.BallisticSkill[i] +
                     " S" + i + ": " + setter.CurrentProfile.Strength[i] +
                     " T" + i + ": " + setter.CurrentProfile.Toughness[i] +
                     " W" + i + ": " + setter.CurrentProfile.Wounds[i] +
                     " A" + i + ": " + setter.CurrentProfile.Attacks[i] +
                     " Ld" + i + ": " + setter.CurrentProfile.Leadership[i] +
                     " Sv" + i + ": " + setter.CurrentProfile.Save[i]);
        }

        Debug.Log("Setting Damage Profiles to " + setter.CurrentProfile.DamageCharts + ".");
        UI.dropdownDamage.value = setter.CurrentProfile.DamageCharts;

        Debug.Log("Loading the current profile into the UI.");
        if (setter.CurrentProfile.DamageCharts == 0) {

            UI.ReadProfile();

        } else {

            UI.CreateDamageProfiles();
        }

        ClosePanel();
    }

    public void ClosePanel () {

        ProfileUI UI = FindObjectOfType<ProfileUI>();

        UI.save.interactable = true;
        UI.load.interactable = true;

        gameObject.SetActive(false);
    }
}
