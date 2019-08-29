using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class ButtonWeapon : MonoBehaviour {

    public Weapon Weapon { get; set; }

    GameManager instance;
    WeaponLoader loader;
    WeaponSetter setter;
    WeaponUI ui;

    // Use this for initialization
    void Start () {

        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Can not find Game Manger.");
        loader = FindObjectOfType<WeaponLoader>();
        Assert.IsNotNull(loader, "Can not find Rule Loader.");
        setter = FindObjectOfType<WeaponSetter>();
        Assert.IsNotNull(setter, "Can not find Rule Setter.");
        ui = FindObjectOfType<WeaponUI>();
        Assert.IsNotNull(ui, "Can not find Rule UI.");

        GetComponent<Button>().onClick.AddListener(LoadRule);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadRule () {

        //Debug.Log("Clicked!");
        if (Weapon != null) {

            setter.CurrentWeapon = Weapon;
            loader.ResetLoad(Weapon);
        }
    }
}
