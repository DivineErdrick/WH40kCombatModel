using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileLoadPanel : MonoBehaviour
{
    GameManager instance;

    public GameObject buttonProfile;
    public GameObject contentLoad;

    ButtonProfile[] buttonProfiles;
    InputField searchField;
    
    // Start is called before the first frame update
    void Start()
    {
        searchField = GetComponentInChildren<InputField>();
        buttonProfiles = GetComponentsInChildren<ButtonProfile>();
    }

    // Update is called once per frame
    void Update()
    {
        if (searchField) {

            string searchTerm = searchField.GetComponent<InputField>().text;

            for (int i = 0; i < buttonProfiles.Length; i++) {
                buttonProfiles[i].gameObject.SetActive(true);
            }

            if (searchTerm.Length > 0) {

                for (int i = 0; i < searchTerm.Length; i++) {

                    for (int n = 0; n < buttonProfiles.Length; n++) {

                        string sTemp = buttonProfiles[n].Profile.Name;
                        if (searchTerm.Length > sTemp.Length) {

                            buttonProfiles[n].gameObject.SetActive(false);

                        } else if (searchTerm[i] != sTemp[i]) {

                            buttonProfiles[n].gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

    public void CreateLoadButtons () {

        instance = FindObjectOfType<GameManager>();

        if (instance.Profiles.Count > 6) {
            contentLoad.GetComponent<RectTransform>().offsetMin = new Vector2(0, -48 * (instance.Profiles.Count - 6));
        }
        for (int i = 0; i < instance.Profiles.Count; i++) {
            string profileName = instance.Profiles[i].Name;
            GameObject profileButton = Instantiate(buttonProfile);
            profileButton.transform.SetParent(contentLoad.transform);
            profileButton.GetComponent<ButtonProfile>().Profile = instance.Profiles[i];
            profileButton.GetComponent<RectTransform>().localScale = Vector3.one;
            profileButton.GetComponentInChildren<Text>().text = profileName;
        }

        searchField = GetComponentInChildren<InputField>();
        buttonProfiles = FindObjectsOfType<ButtonProfile>();
    }
}
