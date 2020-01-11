using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartUI : MonoBehaviour {

    public enum NavigationType { next, previous, up, down, left, right }

    GameManager instance;

    [SerializeField] Button profile, rule, weapon, powers, model, unit, test, exit;

    void Awake () {

        Assert.IsNotNull(profile, "The Button Profile object has not been assigned to the Start UI object.");
        Assert.IsNotNull(rule, "The Button Rule object has not been assigned to the Start UI object.");
        Assert.IsNotNull(weapon, "The Button Weapon object has not been assigned to the Start UI object.");
        Assert.IsNotNull(powers, "The Button Powers object has not been assigned to the Start UI object.");
        Assert.IsNotNull(model, "The Button Model object has not been assigned to the Start UI object.");
        Assert.IsNotNull(unit, "The Button Unit object has not been assigned to the Start UI object.");
        Assert.IsNotNull(test, "The Button Test object has not been assigned to the Start UI object.");
        Assert.IsNotNull(exit, "The Button Exit object has not been assigned to the Start UI object.");
    }

    // Use this for initialization
    void Start () {

        instance = GameManager.instance;

        if (instance.Rules.Count > 0)
        {
            powers.interactable = true;
        }
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
    void Update () 
    {
        GameObject uiObject = EventSystem.current.currentSelectedGameObject;
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                Debug.Log("Checking if a UI Object is selected.");
                if (uiObject)
                {
                    KeyboardNavigation(uiObject, NavigationType.previous);
                }
                else
                {
                    Debug.Log("No game object is selected.");
                    SelectUIElement(NavigationType.previous);
                }
            }
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            Debug.Log("Checking if a UI Object is selected.");
            if (uiObject)
            {
                KeyboardNavigation(uiObject, NavigationType.next);
            }
            else
            {
                Debug.Log("No game object is selected.");
                SelectUIElement(NavigationType.next);
            }
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Debug.Log("Checking if a UI Object is selected.");
            if (uiObject)
            {
                KeyboardNavigation(uiObject, NavigationType.left);
            }
            else
            {
                Debug.Log("No game object is selected.");
                SelectUIElement(NavigationType.left);
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Debug.Log("Checking if a UI Object is selected.");
            if (uiObject)
            {
                KeyboardNavigation(uiObject, NavigationType.right);
            }
            else
            {
                Debug.Log("No game object is selected.");
                SelectUIElement(NavigationType.right);
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Debug.Log("Checking if a UI Object is selected.");
            if (uiObject)
            {
                KeyboardNavigation(uiObject, NavigationType.up);
            }
            else
            {
                Debug.Log("No game object is selected.");
                SelectUIElement(NavigationType.up);
            }
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Debug.Log("Checking if a UI Object is selected.");
            if (uiObject)
            {
                KeyboardNavigation(uiObject, NavigationType.down);
            }
            else
            {
                Debug.Log("No game object is selected.");
                SelectUIElement(NavigationType.down);
            }
        }
    }

    public void SelectUIElement(NavigationType navigate = NavigationType.next)
    {
        Debug.Log("Navigating from no selected object.");
        if (navigate == NavigationType.up || navigate == NavigationType.previous)
        {
            EventSystem.current.SetSelectedGameObject(exit.gameObject);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(profile.gameObject);
        }
    }

    public void KeyboardNavigation(GameObject currentObject, NavigationType navigate = NavigationType.next)
    {
        Debug.Log("Navigating from a selected object.");
        //profile, rule, weapon, powers, model, unit, test, exit
        switch (navigate)
        {
            case NavigationType.previous:
            case NavigationType.left:
            case NavigationType.up:
                if (currentObject == profile)
                {
                    EventSystem.current.SetSelectedGameObject(exit.gameObject);
                }
                else if (currentObject == rule)
                {
                    EventSystem.current.SetSelectedGameObject(profile.gameObject);
                }
                else if (currentObject == weapon)
                {
                    EventSystem.current.SetSelectedGameObject(rule.gameObject);
                }
                else if (currentObject == powers)
                {
                    EventSystem.current.SetSelectedGameObject(weapon.gameObject);
                }
                else if (currentObject == model)
                {
                    if (powers.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(powers.gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(weapon.gameObject);
                    }
                }
                else if (currentObject == unit)
                {
                    EventSystem.current.SetSelectedGameObject(model.gameObject);
                }
                else if (currentObject == test)
                {
                    EventSystem.current.SetSelectedGameObject(unit.gameObject);
                }
                else
                {
                    if (test.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(test.gameObject);
                    }
                    else if (unit.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(unit.gameObject);
                    }
                    else if (model.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(model.gameObject);
                    }
                    else if (powers.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(powers.gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(weapon.gameObject);
                    }
                }
                break;
            case NavigationType.next:
            case NavigationType.down:
            case NavigationType.right:
            default:
                if (currentObject == profile)
                {
                    EventSystem.current.SetSelectedGameObject(rule.gameObject);
                }
                else if (currentObject == rule)
                {
                    EventSystem.current.SetSelectedGameObject(weapon.gameObject);
                }
                else if (currentObject == weapon)
                {
                    if (powers.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(powers.gameObject);
                    }
                    else if (model.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(model.gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(exit.gameObject);
                    }
                }
                else if (currentObject == powers)
                {
                    if (model.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(model.gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(exit.gameObject);
                    }
                }
                else if (currentObject == model)
                {
                    if (unit.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(unit.gameObject);
                    }
                    else if (test.isActiveAndEnabled)
                    {
                        EventSystem.current.SetSelectedGameObject(test.gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(exit.gameObject);
                    }
                }
                else if (currentObject == unit)
                {
                    EventSystem.current.SetSelectedGameObject(test.gameObject);
                }
                else if (currentObject == test)
                {
                    EventSystem.current.SetSelectedGameObject(exit.gameObject);
                }
                else
                {
                    EventSystem.current.SetSelectedGameObject(exit.gameObject);
                }
                break;
        }
    }

    public void LoadScene (string level) {

        SceneManager.LoadScene(level);
    }
}
