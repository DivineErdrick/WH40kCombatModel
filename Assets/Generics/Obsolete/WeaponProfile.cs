using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class WeaponProfile {

    public enum Type { Assault, Heavy, RapidFire, Grenade, Pistol }

    public string Name { get; set; }
    public List<string> Keywords { get; set; }
    public int PointsValue { get; set; }
    public bool MeleeWeapon { get; set; }
    public int Range { get; set; }
    public Type WeaponType { get; set; }
    public int Shots { get; set; }
    public bool UsesWieldersStrength { get; set; }
    public bool UsesTwiceTheWieldersStrength { get; set; }
    public int Strength { get; set; }
    public int ArmourPenetration { get; set; }
    public int Damage { get; set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
