using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ProfileSetter : MonoBehaviour {

    public Profile CurrentProfile { get; set; }

    ProfileUI profileUI;
    ProfileValueChecker valueChecker;

    void Awake () {

        CurrentProfile = new Profile();
    }

    // Use this for initialization
    void Start () {

        profileUI = FindObjectOfType<ProfileUI>();
        Assert.IsNotNull(profileUI, "Could not find Profile UI.");
        valueChecker = FindObjectOfType<ProfileValueChecker>();
        Assert.IsNotNull(valueChecker, "Could not find Profile Setter.");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetDamageCharts (int damageCharts) {
        Debug.Log("Setting Damage Charts to " + damageCharts + ".");
        CurrentProfile.DamageCharts = damageCharts;
        profileUI.CreateDamageProfiles();
    }

    //public void ClearExcessDamageChartEntries () {

    //    Debug.Log("Checking to see if there are possibly more entries than Damage Chart values.");

    //    if (CurrentProfile.DamageCharts < 4) {

    //        Debug.Log("Clearing additional entries.");

    //        for (int i = 4; i > CurrentProfile.DamageCharts; i--) {

    //            CurrentProfile.Move[i] = 0;
    //            CurrentProfile.WeaponSkill[i] = 0;
    //            CurrentProfile.BallisticSkill[i] = 0;
    //            CurrentProfile.Strength[i] = 0;
    //            CurrentProfile.Toughness[i] = 0;
    //            CurrentProfile.Wounds[i] = 0;
    //            CurrentProfile.Attacks[i] = 0;
    //            CurrentProfile.Leadership[i] = 0;
    //            CurrentProfile.Save[i] = 0;
    //        }
    //    }
    //}

    public void SetProfile (string inputName, int value) {

        /* The names being used in the ProfileValueChecker are formatted
         so that characters can be set apart to determine both the value
         and position in the array.*/        
        
        if (inputName == "Points") {

            CurrentProfile.PointsValue = value;

        } else {

            if (inputName.Length == 2) {
                Debug.Log("Profile Setter is attempting to set M, S, T, W, or A.");

                int profileIndex = valueChecker.ReadIntString(inputName[1].ToString());
                Debug.Log("Profile Index is " + profileIndex);

                switch (inputName[0]) {

                    case 'M':
                        CurrentProfile.Move[profileIndex] = value;
                        break;
                    case 'S':
                        CurrentProfile.Strength[profileIndex] = value;
                        break;
                    case 'T':
                        CurrentProfile.Toughness[profileIndex] = value;
                        break;
                    case 'W':
                        CurrentProfile.Wounds[profileIndex] = value;
                        break;
                    case 'A':
                        CurrentProfile.Attacks[profileIndex] = value;
                        break;
                }
            } else if (inputName.Length == 3) {

                int profileIndex = valueChecker.ReadIntString(inputName[2].ToString());

                switch (inputName[0]) {
                    case 'W':
                        CurrentProfile.WeaponSkill[profileIndex] = value;
                        break;
                    case 'B':
                        CurrentProfile.BallisticSkill[profileIndex] = value;
                        break;
                    case 'L':
                        CurrentProfile.Leadership[profileIndex] = value;
                        break;
                    case 'S':
                        CurrentProfile.Save[profileIndex] = value;
                        break;
                }
            }
        }        

        /* The names of the input objects have been formatted so that
         the character array can be easily read. This method grabs the
         first character of the profile characteristic name and the
         number of the damage chart and then uses it to set the property
         values in the Current Profile. */

        //char cTemp = inputName[6];

        //if (inputName.Length <= 9) {
        //    int nTemp = (inputName.Length == 9) ? (int)char.GetNumericValue(inputName, 8) : (int)char.GetNumericValue(inputName, 7);

        //    switch (cTemp) {
        //        case 'M':
        //            if (CurrentProfile.Move.Capacity <= nTemp) CurrentProfile.Move.Capacity++;
        //            CurrentProfile.Move[nTemp] = value;
        //            break;
        //        case 'B':
        //            if (CurrentProfile.BallisticSkill.Capacity <= nTemp) CurrentProfile.BallisticSkill.Capacity++;
        //            CurrentProfile.BallisticSkill[nTemp] = value;
        //            break;
        //        case 'T':
        //            if (CurrentProfile.Toughness.Capacity <= nTemp) CurrentProfile.Toughness.Capacity++;
        //            CurrentProfile.Toughness[nTemp] = value;
        //            break;
        //        case 'A':
        //            if (CurrentProfile.Attacks.Capacity <= nTemp) CurrentProfile.Attacks.Capacity++;
        //            CurrentProfile.Attacks[nTemp] = value;
        //            break;
        //        case 'L':
        //            if (CurrentProfile.Leadership.Capacity <= nTemp) CurrentProfile.Leadership.Capacity++;
        //            CurrentProfile.Leadership[nTemp] = value;
        //            break;
        //        case 'W':
        //            if (inputName.Length == 9) {
        //                if (CurrentProfile.WeaponSkill.Capacity <= nTemp) CurrentProfile.WeaponSkill.Capacity++;
        //                CurrentProfile.WeaponSkill[nTemp] = value;
        //            } else {
        //                if (CurrentProfile.Wounds.Capacity <= nTemp) CurrentProfile.Wounds.Capacity++;
        //                CurrentProfile.Wounds[nTemp] = value;
        //            }
        //            break;
        //        case 'S':
        //            if (inputName.Length == 9) {
        //                if (CurrentProfile.Save.Capacity <= nTemp) CurrentProfile.Save.Capacity++;
        //                CurrentProfile.Save[nTemp] = value;
        //            } else {
        //                if (CurrentProfile.Strength.Capacity <= nTemp) CurrentProfile.Strength.Capacity++;
        //                CurrentProfile.Strength[nTemp] = value;
        //            }
        //            break;
        //    }
        //} else {
        //    CurrentProfile.PointsValue = value;
        //}
    }

    public void SetProfile (string name, string value) {
        switch (name) {
            case "Name":
                CurrentProfile.Name = value;
                break;
        }
    }
}
