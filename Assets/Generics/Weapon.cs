using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Weapon {

    public int Version;

    public enum WeaponTypes { None, Melee, RapidFire, Assault, Heavy, Pistol, Grenade }
    public enum VarStrengths { User, UserX2, D3, D6, TwoD3, TwoD6 }
    public enum VarAPs { None, MinusD3, MinusD6, Minus2D3 }
    public enum VarDamages { None, D3, D6, TwoD3, TwoD6, ThreeD6, FourD6}
    public enum VarRanges { None, D3, D6, TwoD3, TwoD6, ThreeD6, FourD6}
    public enum VarShotTypes { Attacks, AttacksX2, D3, D6, TwoD3, TwoD6, ThreeD6, FourD6 }

    public string Name;

    public List<string> Rules;

    public WeaponTypes WeaponType;

    public bool StrengthIsVar;
    public int Strength;
    public VarStrengths VarStrength;

    public bool APIsVar;
    public int AP;
    public VarAPs VarAP;

    public bool DamageIsVar;
    public int Damage;
    public VarDamages VarDamage;

    public bool RangeIsVar;
    public int Range;
    public VarRanges VarRange;

    public bool ShotsAreVar;
    public int Shots;
    public VarShotTypes VarShots;

    public Weapon ()
    {
        Rules = new List<string>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
