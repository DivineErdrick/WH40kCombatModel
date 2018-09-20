using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour {

    GameManager instance;

    [SerializeField]
    Button model, unit, test;

    void Awake () {

        Assert.IsNotNull(model, "The Button Model object has not been assigned to the Start UI object.");
        Assert.IsNotNull(unit, "The Button Unit object has not been assigned to the Start UI object.");
        Assert.IsNotNull(test, "The Button Test object has not been assigned to the Start UI object.");
    }

    // Use this for initialization
    void Start () {

        instance = GameManager.instance;

        if (instance.Profiles.Count > 0) {

            model.interactable = true;
        }
        if (instance.Models.Count > 0) {

            unit.interactable = true;
        }
        if (instance.Units.Count > 0) {

            test.interactable = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void LoadScene (string level) {

        SceneManager.LoadScene(level);
    }
}
