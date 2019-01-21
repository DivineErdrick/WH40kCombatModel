using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileSaver : MonoBehaviour {

    [HideInInspector]
    public int profileToLoad;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveProfile () {

        ProfileValueChecker valueChecker = FindObjectOfType<ProfileValueChecker>(); ;

        Debug.Log("Profile Saver is attempting to save the current Profile");
        ProfileSetter profileSetter = FindObjectOfType<ProfileSetter>();
        bool profileSetCorrectly = valueChecker.CheckFullProfile();

        if (profileSetCorrectly) {

            Debug.Log("Profile appears correct, attempting to save.");
            GameManager instance = FindObjectOfType<GameManager>(); ;
            ProfileUI profileUI = FindObjectOfType<ProfileUI>(); ;
            bool nameCheck = true;
            for (int i = 0; i < instance.Profiles.Count; i++) {
                if (profileSetter.CurrentProfile.Name == instance.Profiles[i].Name) {
                    Debug.Log("A profile with the name " + instance.Profiles[i].Name + " has been found.");
                    nameCheck = false;
                    profileToLoad = i;
                }
            }

            if (nameCheck) {

                ProfileMessager messager = FindObjectOfType<ProfileMessager>();
                Debug.Log("The profile is okay to save.");
                //profileSetter.ClearExcessDamageChartEntries();
                Debug.Log("Attempting to add the profile to the profile list.");
                ProfileCopier copier = FindObjectOfType<ProfileCopier>();
                Profile saveProfile = copier.CopyProfile(profileSetter.CurrentProfile);
                instance.Profiles.Add(saveProfile);
                instance.SaveProfile();
                profileUI.EnableLoad();
                StartCoroutine(messager.DisplayTemporaryMessage("Profile Saved.", false));

            //} else if (overwrite) {

            //    instance.Profiles[profileToLoad] = profile;
            //    overwritePanel.SetActive(false);
            //    instance.Save();

            } else {

                profileUI.OpenNameCheckPanel();
            }
        }
    }

    //bool CheckProfile (Profile profile) {

    //    Debug.Log("Profile Saver is checking values in the current Profile");
    //    ProfileUI profileUI = FindObjectOfType<ProfileUI>();

    //    Debug.Log("Profile Saver is checking Points Value in Profile");
    //    Debug.Log("Current Points Value is " + profile.PointsValue);
    //    if ( ! valueChecker.CheckValue("Points", profile.PointsValue)) {
    //        profileUI.OutputProfileError("Input Points Value", 0);
    //        Debug.Log("Value of Points Value is not legal.");
    //        return false;
    //    }

    //    Debug.Log("Profile Saver is checking Name in Profile");
    //    Debug.Log("Current profile Name is " + profile.Name);
    //    if ( ! valueChecker.CheckValue("Name", profile.Name)) {
    //        profileUI.OutputProfileError("Input Name", 0);
    //        Debug.Log("Value of Name is not legal.");
    //        return false;
    //    }

    //    Debug.Log("Profile Saver is checking Move in Profile");
    //    Debug.Log("Checking Move capacity is " + (profile.DamageCharts + 1));
    //    if (profile.Move.Count <= profile.DamageCharts) {
    //        Debug.Log("You must enter a value for Move for each damage profile.");
    //        profileUI.OutputProfileError("Input M" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Move capacity is " + profile.Move.Count);
    //    for (int i = profile.Move.Count - 1; i > -1; i--) {
    //        Debug.Log("Checking if current index is too high.");
    //        if (i > profile.DamageCharts) {
    //            Debug.Log("Index is too high, removing it.");
    //            profile.Move.RemoveAt(i);
    //            profile.Move.TrimExcess();
    //            Debug.Log("Current Move cpacity is " + profile.Move.Count);
    //        } else {
    //            Debug.Log("Current Move is " + profile.Move[i]);
    //            if (!valueChecker.CheckValue("M" + i, profile.Move[i])) {
    //                profileUI.OutputProfileError("Input M" + i, i);
    //                Debug.Log("Value of M" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }        
    //    Debug.Log("Profile Saver is checking Weapon Skill in Profile");
    //    Debug.Log("Checking Weapon Skill capacity is " + (profile.DamageCharts + 1));
    //    if (profile.WeaponSkill.Count <= profile.DamageCharts) {
    //        Debug.Log("You must enter a value for Weapon Skill for each damage profile.");
    //        profileUI.OutputProfileError("Input WS" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Weapon Skill capacity is " + profile.WeaponSkill.Count);
    //    for (int i = profile.WeaponSkill.Count - 1; i > -1; i--) {
    //        if (i > profile.DamageCharts) {
    //            profile.WeaponSkill.RemoveAt(i);
    //            profile.WeaponSkill.TrimExcess();
    //        } else {
    //            Debug.Log("Current Weapon Skill is " + profile.WeaponSkill[i]);
    //            if (!valueChecker.CheckValue("WS" + i, profile.WeaponSkill[i])) {
    //                profileUI.OutputProfileError("Input WS" + i, i);
    //                Debug.Log("Value of WS" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }        
    //    Debug.Log("Profile Saver is checking Ballistic Skill in Profile");
    //    Debug.Log("Checking Ballistic Skill capacity is " + (profile.DamageCharts + 1));
    //    if (profile.BallisticSkill.Count <= profile.DamageCharts) {
    //        Debug.Log("You must enter a value for Ballistic Skill for each damage profile.");
    //        profileUI.OutputProfileError("Input BS" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Ballistic Skill capacity is " + profile.BallisticSkill.Count);
    //    for (int i = profile.BallisticSkill.Count - 1; i > -1; i--) {
    //        if (i > profile.DamageCharts) {
    //            profile.BallisticSkill.RemoveAt(i);
    //            profile.BallisticSkill.TrimExcess();
    //        } else {
    //            Debug.Log("Current Ballistic Skill is " + profile.BallisticSkill[i]);
    //            if (!valueChecker.CheckValue("BS" + i, profile.BallisticSkill[i])) {
    //                profileUI.OutputProfileError("Input BS" + i, i);
    //                Debug.Log("Value of BS" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }        
    //    Debug.Log("Profile Saver is checking Strength in Profile");
    //    Debug.Log("Checking Strength capacity is " + (profile.DamageCharts + 1));
    //    if (profile.Strength.Count <= profile.DamageCharts) {
    //        Debug.Log("You must enter a value for Strength for each damage profile.");
    //        profileUI.OutputProfileError("Input S" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Strength capacity is " + profile.Strength.Count);
    //    for (int i = profile.Strength.Count - 1; i > -1; i--) {
    //        if (i > profile.DamageCharts) {
    //            profile.Strength.RemoveAt(i);
    //            profile.Strength.TrimExcess();
    //        } else {
    //            Debug.Log("Current Strength is " + profile.Strength[i]);
    //            if (!valueChecker.CheckValue("S" + i, profile.Strength[i])) {
    //                profileUI.OutputProfileError("Input S" + i, i);
    //                Debug.Log("Value of S" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }     
    //    Debug.Log("Profile Saver is checking Toughness in Profile");
    //    if (profile.Toughness.Count <= profile.DamageCharts) {
    //        Debug.Log("Not enough entries for Toughness have been recorded.");
    //        Debug.Log("You must enter a value for Toughness for each damage profile.");
    //        profileUI.OutputProfileError("Input T" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Toughness capacity is " + profile.Toughness.Count);
    //    for (int i = profile.Toughness.Count - 1; i > -1; i--) {
    //        if (i > profile.DamageCharts) {
    //            //Debug.Log("Too many Toughness entries recorded.");
    //            //for (int n = 0; n < profile.Toughness.Capacity; n++) {
    //            //    Debug.Log("T" + n + ": " + profile.Toughness[n]);
    //            //}
    //            //Debug.Log("Attempting to trim down Toughness entries.");
    //            profile.Toughness.RemoveAt(i);
    //            profile.Toughness.TrimExcess();
    //            for (int n = 0; n < profile.Toughness.Count; n++) {
    //                Debug.Log("T" + n + ": " + profile.Toughness[n]);
    //            }
    //        } else {
    //            Debug.Log("Current Toughness is " + profile.Toughness[i]);
    //            if ( ! valueChecker.CheckValue("T" + i, profile.Toughness[i])) {
    //                profileUI.OutputProfileError("Input T" + i, i);
    //                Debug.Log("Value of T" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }

    //    Debug.Log("Profile Saver is checking Wounds in Profile");
    //    if (profile.Wounds.Count <= profile.DamageCharts) {
    //        Debug.Log("Not enough entries for Wounds have been recorded.");
    //        Debug.Log("You must enter a value for Wounds for each damage profile.");
    //        profileUI.OutputProfileError("Input W" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Wounds capacity is " + profile.Wounds.Count);
    //    for (int i = profile.Wounds.Count - 1; i > -1; i--) {
    //        if (i > profile.DamageCharts) {
    //            profile.Wounds.RemoveAt(i);
    //            profile.Wounds.TrimExcess();
    //        } else {
    //            Debug.Log("Current Wounds is " + profile.Wounds[i]);
    //            if ( ! valueChecker.CheckValue("W" + i, profile.Wounds[i])) {
    //                profileUI.OutputProfileError("Input W" + i, i);
    //                Debug.Log("Value of W" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }

    //    Debug.Log("Profile Saver is checking Attacks in Profile");
    //    if (profile.Attacks.Count <= profile.DamageCharts) {
    //        Debug.Log("Not enough entries for Attacks have been recorded.");
    //        Debug.Log("You must enter a value for Attacks for each damage profile.");
    //        profileUI.OutputProfileError("Input A" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Attacks capacity is " + profile.Attacks.Count);
    //    for (int i = profile.Attacks.Count - 1; i > -1; i--) {
    //        if (i > profile.DamageCharts) {
    //            profile.Attacks.RemoveAt(i);
    //            profile.Attacks.TrimExcess();
    //        } else {
    //            Debug.Log("Current Attacks is " + profile.Attacks[i]);
    //            if ( ! valueChecker.CheckValue("A" + i, profile.Attacks[i])) {
    //                profileUI.OutputProfileError("Input A" + i, i);
    //                Debug.Log("Value of A" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }

    //    Debug.Log("Profile Saver is checking Leadership in Profile");
    //    if (profile.Leadership.Count <= profile.DamageCharts) {
    //        Debug.Log("Not enough entries for Leadership have been recorded.");
    //        Debug.Log("You must enter a value for Leadership for each damage profile.");
    //        profileUI.OutputProfileError("Input Ld" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Leadership capacity is " + profile.Leadership.Count);
    //    for (int i = profile.Leadership.Count - 1; i > -1; i--) {
    //        if (i > profile.DamageCharts) {
    //            profile.Leadership.RemoveAt(i);
    //            profile.Leadership.TrimExcess();
    //        } else {
    //            Debug.Log("Current Leadership is " + profile.Leadership[i]);
    //            if ( ! valueChecker.CheckValue("Ld" + i, profile.Leadership[i])) {
    //                profileUI.OutputProfileError("Input Ld" + i, i);
    //                Debug.Log("Value of Ld" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }

    //    Debug.Log("Profile Saver is checking Save in Profile");
    //    if (profile.Save.Count <= profile.DamageCharts) {
    //        Debug.Log("Not enough entries for Save have been recorded.");
    //        Debug.Log("You must enter a value for Save for each damage profile.");
    //        profileUI.OutputProfileError("Input Sv" + profile.DamageCharts, profile.DamageCharts);
    //        return false;
    //    }
    //    Debug.Log("Current Save capacity is " + profile.Save.Count);
    //    for (int i = profile.Save.Count - 1; i > -1; i--) {
    //        if (i > profile.DamageCharts) {
    //            profile.Save.RemoveAt(i);
    //            profile.Save.TrimExcess();
    //        } else {
    //            Debug.Log("Current Save is " + profile.Save[i]);
    //            if ( ! valueChecker.CheckValue("Sv" + i, profile.Save[i])) {
    //                profileUI.OutputProfileError("Input Sv" + i, i);
    //                Debug.Log("Value of Sv" + i + " is not legal.");
    //                return false;
    //            }
    //        }
    //    }
    //    //Debug
    //    for (int i = 0; i < profile.Toughness.Count; i++) {
    //        Debug.Log("T" + i + ": " + profile.Toughness[i]);
    //    }

    //    return true;
    //}
}
