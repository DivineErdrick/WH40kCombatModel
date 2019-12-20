using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Profile {
    public int Version { get; set; }    

    public string Name { get; set; }
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

    public Profile() {
        Version = 0;

        Name = "";
        Move = new int[5];
        WeaponSkill = new int[5];
        BallisticSkill = new int[5];
        Strength = new int[5];
        Toughness = new int[5];
        Wounds = new int[5];
        Attacks = new int[5];
        Leadership = new int[5];
        Save = new int[5];
    }
}
