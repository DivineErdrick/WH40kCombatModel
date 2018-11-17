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

    public void CheckValue (string value) {

        ProfileUI profileUI = GetComponent<ProfileUI>();
        ProfileSetter profileSetter = GetComponent<ProfileSetter>();

        Debug.Log("Checking profile Name from Profile Value Checker.");
        if (profileName == "Name") {

            if (value.Length > 0) {
                Debug.Log("Saving profile Name to Profile.");
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
