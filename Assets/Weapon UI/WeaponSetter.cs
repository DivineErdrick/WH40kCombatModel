using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetter : MonoBehaviour
{
    public Weapon CurrentWeapon;

    public string Name { get; set; }

    public int Type { get; set; }
    public bool StrengthIsVar { get; set; }
    public int Strength { get; set; }
    public int VarStrength { get; set; }
    public bool APIsVar { get; set; }
    public int AP { get; set; }
    public int VarAP { get; set; }
    public bool DamageIsVar { get; set; }
    public int Damage { get; set; }
    public int VarDamage { get; set; }
    public bool RangeIsVar { get; set; }
    public int Range { get; set; }
    public int VarRange { get; set; }
    public bool ShotsAreVar { get; set; }
    public int Shots { get; set; }
    public int VarShots { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RangeStringToInt (string StringRange)
    {
        Range = ReadIntString(StringRange);
    }

    public void ShotsStringToInt(string StringShots)
    {
        Shots = ReadIntString(StringShots);
    }

    public void StrengthStringToInt(string StringStrength)
    {
        Strength = ReadIntString(StringStrength);
    }

    public void APStringToInt(string StringAP)
    {
        AP = ReadIntString(StringAP);
    }

    public void DamageStringToInt(string StringDamage)
    {
        Damage = ReadIntString(StringDamage);
    }

    int ReadIntString(string value)
    {

        int nValue;
        if (!int.TryParse(value, out nValue))
        { 
            nValue = 0;
        }
        return nValue;
    }
}
