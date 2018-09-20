using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Profile {

    public string Name { get; set; }
    public List<string> Keywords { get; set; }
    public int PointsValue { get; set; }
    public int DamageCharts { get; set; }
    public int[] Move { get; set; }
    public int[] WeaponSkill { get; set; }
    public int[] BallisticSkill { get; set; }
    public int[] Strength { get; set; }
    public int[] Toughness { get; set; }
    public int[] Wounds { get; set; }
    public int[] Attacks { get; set; }
    public int[] Leadership { get; set; }
    public int[] Save { get; set; }

    public Profile (int damageCharts) {
        DamageCharts = damageCharts;
        Move = new int[DamageCharts+1];
        WeaponSkill = new int[DamageCharts+1];
        BallisticSkill = new int[DamageCharts+1];
        Strength = new int[DamageCharts+1];
        Toughness = new int[DamageCharts+1];
        Wounds = new int[DamageCharts+1];
        Attacks = new int[DamageCharts+1];
        Leadership = new int[DamageCharts+1];
        Save = new int[DamageCharts+1];
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
