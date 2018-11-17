using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Profile {

    public string Name { get; set; }
    public int PointsValue { get; set; }
    public int DamageCharts { get; set; }
    public List<int> Move { get; set; }
    public List<int> WeaponSkill { get; set; }
    public List<int> BallisticSkill { get; set; }
    public List<int> Strength { get; set; }
    public List<int> Toughness { get; set; }
    public List<int> Wounds { get; set; }
    public List<int> Attacks { get; set; }
    public List<int> Leadership { get; set; }
    public List<int> Save { get; set; }

    public Profile() {
        Name = "";
        Move = new List<int>();
        WeaponSkill = new List<int>();
        BallisticSkill = new List<int>();
        Strength = new List<int>();
        Toughness = new List<int>();
        Wounds = new List<int>();
        Attacks = new List<int>();
        Leadership = new List<int>();
        Save = new List<int>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
