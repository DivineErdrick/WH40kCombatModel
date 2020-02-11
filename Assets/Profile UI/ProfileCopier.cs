using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfileCopier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Profile CopyProfile(Profile currentProfile) {

        GameManager instance = FindObjectOfType<GameManager>(); ;

        Profile profileCopy = new Profile
        {

            DamageCharts = currentProfile.DamageCharts,
            Name = currentProfile.Name,
        };

        for (int i = 0; i <= profileCopy.DamageCharts; i++) {

            profileCopy.MinMove[i] = currentProfile.MinMove[i];
            profileCopy.Move[i] = currentProfile.Move[i];
            profileCopy.WeaponSkill[i] = currentProfile.WeaponSkill[i];
            profileCopy.BallisticSkill[i] = currentProfile.BallisticSkill[i];
            profileCopy.Strength[i] = currentProfile.Strength[i];
            profileCopy.Toughness[i] = currentProfile.Toughness[i];
            profileCopy.Wounds[i] = currentProfile.Wounds[i];
            profileCopy.Attacks[i] = currentProfile.Attacks[i];
            profileCopy.Leadership[i] = currentProfile.Leadership[i];
            profileCopy.Save[i] = currentProfile.Save[i];
        }

        return profileCopy;
    }
}
