using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileValueChecker : MonoBehaviour {

    GameObject input;
    string profileName;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetInput(GameObject newInput) {
        input = newInput;
    }

    public void SetProfileName (string newName) {
        profileName = newName;
    }


    public void CheckValue(string value) {

        ProfileUI profileUI = GetComponent<ProfileUI>();
        ProfileSetter profileSetter = GetComponent<ProfileSetter>();

        Debug.Log("Checking profile Name from Profile Value Checker.");
        if (profileName == "Name") {

            if (value.Length > 0) {
                Debug.Log("Saving Name, " + value + ", to Profile.");
                profileUI.SetColor(profileName, true);
                profileSetter.SetProfile(profileName, value);

            } else {

                profileUI.SetColor(profileName, false);
                Debug.Log("Value of " + profileName + " is not legal.");
            }
        } else {

            int nValue = ReadIntString(value);
            bool valueChecks = false;

            Debug.Log("Profile Value Checker is checking a numeric Profile: " + profileName);
            switch (profileName) {
                case "Points":
                case "M0":
                case "M1":
                case "M2":
                case "M3":
                case "M4":
                case "S0":
                case "S1":
                case "S2":
                case "S3":
                case "S4":
                case "A0":
                case "A1":
                case "A2":
                case "A3":
                case "A4":
                case "Ld0":
                case "Ld1":
                case "Ld2":
                case "Ld3":
                case "Ld4":
                    valueChecks = (nValue >= 0);
                    break;
                case "T0":
                case "T1":
                case "T2":
                case "T3":
                case "T4":
                case "W0":
                case "W1":
                case "W2":
                case "W3":
                case "W4":
                    valueChecks = (nValue > 0);
                    break;
                case "WS0":
                case "WS1":
                case "WS2":
                case "WS3":
                case "WS4":
                case "BS0":
                case "BS1":
                case "BS2":
                case "BS3":
                case "BS4":
                case "Sv0":
                case "Sv1":
                case "Sv2":
                case "Sv3":
                case "Sv4":
                    valueChecks = (0 <= nValue && nValue <= 7);
                    break;
                default:
                    break;
            }

            if (valueChecks) {
                Debug.Log("Profile Value Checker is saving a numeric profile to Profile: " + profileName);
                profileUI.SetColor(profileName, valueChecks);
                profileSetter.SetProfile(profileName, nValue);
            } else {
                profileUI.SetColor(profileName, valueChecks);
                Debug.Log("Value of " + profileName + " is not legal.");
            }
        }
    }

    public bool CheckFullProfile() {

        Debug.Log("Profile Saver has called Profile Checker for the current Profile");
        ProfileUI profileUI = FindObjectOfType<ProfileUI>();
        Profile profile = FindObjectOfType<ProfileSetter>().CurrentProfile;

        int nTemp;

        Debug.Log("Profile Checker is checking Points Value in Profile");
        Debug.Log("Current Points Value is " + profile.PointsValue);
        if (profile.PointsValue < 0) {
            profileUI.OutputProfileError("Input Points Value", 0);
            Debug.Log("Value of Points Value is not legal.");
            return false;
        }

        Debug.Log("Profile Checker is checking Name in Profile");
        Debug.Log("Current profile Name is " + profile.Name);
        if (profile.Name.Length == 0) {
            profileUI.OutputProfileError("Input Name", 0);
            Debug.Log("Value of Name is not legal.");
            return false;
        }
        nTemp = 100;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Move is " + profile.Move[i]);
            if (profile.Move[i] < 0) {
                profileUI.OutputProfileError("Input M" + i, i);
                Debug.Log("Value of M" + i + " is not legal.");
                return false;
            }
            if (nTemp < profile.Move[i]) {
                Debug.Log("Warning: Value of M" + i + " is greater than value of M" + (i-1));
            }
            nTemp = profile.Move[i];
        }
        nTemp = 0;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Weapon Skill is " + profile.WeaponSkill[i]);
            if (0 > profile.WeaponSkill[i] || profile.WeaponSkill[i] > 7) {
                profileUI.OutputProfileError("Input WS" + i, i);
                Debug.Log("Value of WS" + i + " is not legal.");
                return false;
            }
            if (nTemp > profile.WeaponSkill[i]) {
                Debug.Log("Warning: Value of WS" + i + " is better than value of WS" + (i-1));
            }
            nTemp = profile.WeaponSkill[i];
        }
        nTemp = 0;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Ballistic Skill is " + profile.BallisticSkill[i]);
            if (0 > profile.BallisticSkill[i] || profile.BallisticSkill[i] > 7) {
                profileUI.OutputProfileError("Input BS" + i, i);
                Debug.Log("Value of BS" + i + " is not legal.");
                return false;
            }
            if (nTemp > profile.BallisticSkill[i]) {
                Debug.Log("Warning: Value of BS" + i + " is better than value of BS" + (i-1));
            }
            nTemp = profile.BallisticSkill[i];
        }
        nTemp = 100;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Strength is " + profile.Strength[i]);
            if (profile.Strength[i] < 0) {
                profileUI.OutputProfileError("Input S" + i, i);
                Debug.Log("Value of S" + i + " is not legal.");
                return false;
            }
            if (nTemp < profile.Strength[i]) {
                Debug.Log("Warning: Value of S" + i + " is greater than value of S" + (i-1));
            }
            nTemp = profile.Strength[i];
        }
        nTemp = 20;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Toughness is " + profile.Toughness[i]);
            if (profile.Toughness[i] < 1) {
                profileUI.OutputProfileError("Input T" + i, i);
                Debug.Log("Value of T" + i + " is not legal.");
                return false;
            }
            if (nTemp < profile.Toughness[i]) {
                Debug.Log("Warning: Value of T" + i + " is better than value of T" + (i-1));
            }
            nTemp = profile.Toughness[i];
        }
        nTemp = 100;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Wounds is " + profile.Wounds[i]);
            if (profile.Wounds[i] < 1) {
                profileUI.OutputProfileError("Input W" + i, i);
                Debug.Log("Value of W" + i + " is not legal.");
                return false;
            }
            if (nTemp <= profile.Wounds[i]) {
                Debug.Log("Value of W must decrease at each damage level.");
                return false;
            }
            nTemp = profile.Wounds[i];
        }
        nTemp = 20;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Attacks is " + profile.Attacks[i]);
            if (profile.Attacks[i] < 0) {
                profileUI.OutputProfileError("Input A" + i, i);
                Debug.Log("Value of A" + i + " is not legal.");
                return false;
            }
            if (nTemp < profile.Attacks[i]) {
                Debug.Log("Warning: Value of A" + i + " is greater than value of A" + (i-1));
            }
            nTemp = profile.Attacks[i];
        }
        nTemp = 20;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Leadership is " + profile.Leadership[i]);
            if (profile.Leadership[i] < 0) {
                profileUI.OutputProfileError("Input Ld" + i, i);
                Debug.Log("Value of Ld" + i + " is not legal.");
                return false;
            }
            if (nTemp < profile.Leadership[i]) {
                Debug.Log("Warning: Value of Ld" + i + " is greater than value of Ld" + (i-1));
            }
            nTemp = profile.Leadership[i];
        }
        nTemp = 0;
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Current Save is " + profile.Save[i]);
            if (0 > profile.Save[i] || profile.Save[i] > 7) {
                profileUI.OutputProfileError("Input Sv" + i, i);
                Debug.Log("Value of Sv" + i + " is not legal.");
                return false;
            }
            if (nTemp > profile.Save[i]) {
                Debug.Log("Warning: Value of Sv" + (i) + " is better than value of Sv" + (i-1));
            }
            nTemp = profile.Save[i];
        }
        //Debug
        //for (int i = 0; i < profile.Toughness.Count; i++) {
        //    Debug.Log("T" + i + ": " + profile.Toughness[i]);
        //}

        return true;
    }



    public bool CheckValue(string name, string value) {

        Debug.Log("Check Value has been called for the profile Name from Profile Saver.");
        return (value.Length > 0);
    }

    public bool CheckValue(string name, int value) {

        bool valueChecks = false;
        
        switch (name) {
            case "Points":
            case "M0":
            case "M1":
            case "M2":
            case "M3":
            case "M4":
            case "St0":
            case "St1":
            case "St2":
            case "St3":
            case "St4":
            case "A0":
            case "A1":
            case "A2":
            case "A3":
            case "A4":
            case "Ld0":
            case "Ld1":
            case "Ld2":
            case "Ld3":
            case "Ld4":
                Debug.Log("Check Value has been called for a numeric value from Profile Saver: " + name);
                valueChecks = (value >= 0);
                break;
            case "T0":
            case "T1":
            case "T2":
            case "T3":
            case "T4":
            case "W0":
            case "W1":
            case "W2":
            case "W3":
            case "W4":
                Debug.Log("Check Value has been called for a numeric value from Profile Saver: " + name);
                valueChecks = (value > 0);
                break;
            case "WS0":
            case "WS1":
            case "WS2":
            case "WS3":
            case "WS4":
            case "BS0":
            case "BS1":
            case "BS2":
            case "BS3":
            case "BS4":
            case "Sv0":
            case "Sv1":
            case "Sv2":
            case "Sv3":
            case "Sv4":
                Debug.Log("Check Value has been called for a numeric value from Profile Saver: " + name);
                valueChecks = (0 <= value && value <= 7);
                break;
            default:
                break;
        }
        return valueChecks;
    }

    public int ReadIntString(string value) {

        int nValue;
        if (int.TryParse(value, out nValue)) {

        } else {
            nValue = -1;
        }
        return nValue;
    }

    //void SetProfile(string value) {

    //    ProfileUI profileUI = GetComponent<ProfileUI>();
    //    profileUI.SetColor(ProfileName, true);
    //    ProfileSetter profileSetter = GetComponent<ProfileSetter>();
    //    profileSetter.SetProfile(name, value);

        //Text[] temp = input.GetComponentsInChildren<Text>();
        //foreach (Text text in temp) {
        //    text.color = defaultColor;

        //    switch (text.gameObject.name.Length) {

        //        case 13:
        //            if (text.gameObject.name[8] == 'P') {
        //                text.text = "";
        //            }
        //            break;
        //        case 14:
        //            if (text.gameObject.name[9] == 'P') {
        //                text.text = "";
        //            }
        //            break;
        //        case 15:
        //            if (text.gameObject.name[10] == 'P') {
        //                text.text = "Name";
        //            }
        //            break;
        //        case 23:
        //            if (text.gameObject.name[18] == 'P') {
        //                text.text = "";
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
    //}

        //Text[] temp = input.GetComponentsInChildren<Text>();
        //foreach (Text text in temp) {
        //    text.color = Color.red;

        //    switch (text.gameObject.name.Length) {

        //        case 13:
        //            if (text.gameObject.name[8] == 'P') {
        //                text.text = "E";
        //            }
        //            break;
        //        case 14:
        //            if (text.gameObject.name[9] == 'P') {
        //                text.text = "E";
        //            }
        //            break;
        //        case 15:
        //            if (text.gameObject.name[10] == 'P') {
        //                text.text = "Error";
        //            }
        //            break;
        //        case 23:
        //            if (text.gameObject.name[18] == 'P') {
        //                text.text = "E";
        //            }
        //            break;
        //        default:
        //            break;
        //    }
        //}
    //}
}
