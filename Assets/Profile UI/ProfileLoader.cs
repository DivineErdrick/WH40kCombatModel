using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadProfile(Profile profile) {
        Debug.Log("Attempting to Load the original profile.");

        ProfileCopier copier = FindObjectOfType<ProfileCopier>();
        ProfileSetter setter = FindObjectOfType<ProfileSetter>();
        ProfileUI UI = FindObjectOfType<ProfileUI>();

        Debug.Log("Loading profile named " + profile.Name + ".");

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
    }
}
