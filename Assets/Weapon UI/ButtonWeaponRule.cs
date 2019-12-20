using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonWeaponRule : MonoBehaviour
{
    public Rule Rule { get; set; }
    
    bool RuleAdded = false;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddRemoveRule);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddRemoveRule ()
    {
        if (RuleAdded)
        {
            Debug.Log("Adding rule.");
            Debug.Log("Calling Weapon UI to manage rule panel.");
        }
        else
        {
            Debug.Log("Open remove rule panel.");
        }
    }
}
