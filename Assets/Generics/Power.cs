using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Power {
	public int Version { get; set; }

	public Power ()
	{
		Version = 0;
	}
}
