using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Model {

    public string Name { get; set; }
    public List<string> Keywords { get; set; }
    public List<string> Weapons { get; set; }
    public List<string> Rules { get; set; }
    public List<string> Powers { get; set; }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
