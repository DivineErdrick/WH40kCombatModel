using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Unit {
	public int Version { get; set; }

    public string Name { get; set; }
    public int Power { get; set; }
    public List<string> UnitLines { get; set; }

    public Unit ()
    {
        Version = 0;
    }
}
