using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileUI : MonoBehaviour {

    public GameObject[] unitCard;
    public Text textDamage;
    public Dropdown dropdownDamage;
    public Button buttonLoad;
    public GameObject panelLoad;
    public GameObject contentLoad;
    public GameObject overwritePanel;
    public GameObject buttonProfile;
    public Button save;
    public Button load;

    public int PointsValue { get; set; }
    public string Name { get; set; }
    public int[] M { get; set; }
    public int[] WS { get; set; }
    public int[] BS { get; set; }
    public int[] S { get; set; }
    public int[] T { get; set; }
    public int[] W { get; set; }
    public int[] A { get; set; }
    public int[] Ld { get; set; }
    public int[] Sv { get; set; }

    public int DamageCharts { get; set; }

    ButtonProfile[] buttonProfiles;

    GameManager instance;
    InputField searchField;
    int profileToLoad;

    Color defaultText;
        
    void Awake () {
        Assert.IsTrue(unitCard.Length > 0, "Unit card panels have not been assigned to the UI Manager.");
        Assert.IsNotNull(textDamage, "Text Damage has not been assigned to the UI Manager.");
        Assert.IsNotNull(dropdownDamage, "Dropdown Damage has not bee assinged to the UI Manager.");

        M = new int[unitCard.Length]; WS = new int[unitCard.Length]; BS = new int[unitCard.Length]; S = new int[unitCard.Length]; T = new int[unitCard.Length]; W = new int[unitCard.Length]; A = new int[unitCard.Length];
        Ld = new int[unitCard.Length]; Sv = new int[unitCard.Length];

        buttonProfiles = new ButtonProfile[0];
    }

	// Use this for initialization
	void Start () {

        instance = GameManager.instance;

        defaultText = dropdownDamage.gameObject.GetComponentInChildren<Text>().color;
        if ( ! instance.InitialLoad) {
            Profile profile = instance.ActiveProfile;
            ResetLoad(profile);
            //DamageCharts = profile.DamageCharts;
            //dropdownDamage.value = DamageCharts;
            //for (int i = 1; i <= DamageCharts; i++) {
            //    unitCard[i].SetActive(true);
            //}
            //UpdateProfiles(profile.DamageCharts);
        }

        if (instance.Profiles.Count > 0) {
            buttonLoad.interactable = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
        if (searchField) {

            string searchTerm = searchField.GetComponent<InputField>().text;

            for (int i = 0; i < buttonProfiles.Length; i++) {
                buttonProfiles[i].gameObject.SetActive(true);
            }

            if (searchTerm.Length > 0) {

                for (int i = 0; i < searchTerm.Length; i++) {

                    for (int n = 0; n < buttonProfiles.Length; n++) {

                        string sTemp = buttonProfiles[n].Profile.Name;
                        if (searchTerm[i] != sTemp[i]) {

                            buttonProfiles[n].gameObject.SetActive(false);
                        } 
                    }
                }
            }
        }
	}

    public void CreateDamageProfiles () {
        
        for (int i = 1; i < unitCard.Length; i++) {

            unitCard[i].SetActive(false);
        }
        for (int i = 1; i <= DamageCharts; i++) {

            unitCard[i].SetActive(true);
        }
        UpdateProfiles(DamageCharts);
        //Vector2 vMin = new Vector2(textDamage.rectTransform.anchorMin.x, 0.75f - 0.05f * (float)damageCharts);
        //Vector2 vMax = new Vector2(textDamage.rectTransform.anchorMax.x, 0.8f - 0.05f * (float)damageCharts);
        //textDamage.rectTransform.anchorMin = vMin;
        //textDamage.rectTransform.anchorMax = vMax;
        //vMin = new Vector2(dropdownDamage.GetComponent<RectTransform>().anchorMin.x, 0.75f - 0.05f * (float)damageCharts);
        //vMax = new Vector2(dropdownDamage.GetComponent<RectTransform>().anchorMax.x, 0.8f - 0.05f * (float)damageCharts);
        //dropdownDamage.GetComponent<RectTransform>().anchorMin = vMin;
        //dropdownDamage.GetComponent<RectTransform>().anchorMax = vMax;
        //textDamage.rectTransform.offsetMin = new Vector2(0, 0);
        //textDamage.rectTransform.offsetMax = new Vector2(0, 0);
        //dropdownDamage.GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
        //dropdownDamage.GetComponent<RectTransform>().offsetMax = new Vector2(0, 0);
    }

    public void SetCombatProfile (bool overwrite) {

        if (ProfileCorrectlySet()) { //Include damage charts

            Profile profile = new Profile(DamageCharts);
            {
                profile.PointsValue = PointsValue;
                profile.Name = Name;

                //M
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.Move[i] = M[i];
                }
                //WS
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.WeaponSkill[i] = WS[i];
                }
                //BS
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.BallisticSkill[i] = BS[i];
                }
                //S
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.Strength[i] = S[i];
                }
                //T
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.Toughness[i] = T[i];
                }
                //W
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.Wounds[i] = W[i];
                }
                //A
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.Attacks[i] = A[i];
                }
                //Ld
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.Leadership[i] = Ld[i];
                }
                //Sv
                for (int i = 0; i <= DamageCharts; i++) {
                    profile.Save[i] = Sv[i];
                }
            }
            Debug.Log("Combat profile for " + profile.Name + ", " + profile.PointsValue + " points.");

            for (int i = 0; i <= profile.DamageCharts; i++) {
                Debug.Log("Damage Chart " + i + "- M:" + profile.Move[i] + " WS: " + profile.WeaponSkill[i] + " BS: " + profile.BallisticSkill[i] + " S: " + profile.Strength[i] +
                          " T: " + profile.Toughness[i] + " W: " + profile.Wounds[i] + " A: " + profile.Attacks[i] + " Ld: " + profile.Leadership[i] + " Sv: " + profile.Save[i]);
            }

            instance.ActiveProfile = profile;
            bool nameCheck = true;
            for (int i = 0; i < instance.Profiles.Count; i++) {
                if (Name == instance.Profiles[i].Name) {
                    nameCheck = false;
                    profileToLoad = i;
                }
            }

            if (nameCheck) {
                instance.Profiles.Add(profile);
                instance.Save();
                buttonLoad.interactable = true;
            } else if (overwrite) {
                instance.Profiles[profileToLoad] = profile;
                overwritePanel.SetActive(false);
                instance.Save();
            } else {
                overwritePanel.SetActive(true);
            }
                       
        } else {

            Debug.Log("Unit Profile is not complete. Please finish the card for all rows of the damage chart.");
        }
    }

    public void UpdateProfiles (int damageCharts) {

        int nTemp;

        //M
        nTemp = Mathf.Min(damageCharts+1, M.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input M" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = M[i].ToString();
        }
        //WS
        nTemp = Mathf.Min(damageCharts+1, WS.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input WS" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = WS[i].ToString();
        }
        //BS
        nTemp = Mathf.Min(damageCharts+1, BS.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input BS" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = BS[i].ToString();
        }
        //S
        nTemp = Mathf.Min(damageCharts+1, S.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input S" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = S[i].ToString();
        }
        //T
        nTemp = Mathf.Min(damageCharts+1, T.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input T" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = T[i].ToString();
        }
        //W
        nTemp = Mathf.Min(damageCharts+1, W.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input W" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = W[i].ToString();
        }
        //A
        nTemp = Mathf.Min(damageCharts+1, A.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input A" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = A[i].ToString();
        }
        //Ld
        nTemp = Mathf.Min(damageCharts+1, Ld.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input Ld" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = Ld[i].ToString();
        }
        //Sv
        nTemp = Mathf.Min(damageCharts+1, Sv.Count(i => i != 0));
        for (int i = 0; i < nTemp; i++) {
            string sTemp = "Input Sv" + i;
            GameObject.Find(sTemp).GetComponent<InputField>().text = Sv[i].ToString();
        }
    }

    bool ProfileCorrectlySet () {

        bool currentProfileCorrect = true;
        InputField inputTemp = GameObject.Find("Input Points Value").GetComponent<InputField>();
        Text[] tTemp = inputTemp.gameObject.GetComponentsInChildren<Text>();
        int nTemp;
        if (int.TryParse(inputTemp.text, out nTemp)) {

            if (nTemp >= 0) {
                PointsValue = nTemp;
                foreach (Text text in tTemp) {
                    text.color = defaultText;
                }
            } else {
                OutputError(tTemp);
                currentProfileCorrect = false;
            }
        } else {
            OutputError(tTemp);
            currentProfileCorrect = false;
        }

        inputTemp = GameObject.Find("Input Name").GetComponent<InputField>();
        Name = inputTemp.text;
        if (Name.Length == 0) {
            Text[] taTemp = inputTemp.GetComponentsInChildren<Text>();
            OutputError(taTemp);
            currentProfileCorrect = false;
        }

        for (int i = 0; i <= DamageCharts; i++) {

            if (unitCard[i].activeSelf) {

                //M
                if (ValueCheckNotNegative("Input M", i, out nTemp)) {
                    M[i] = nTemp;
                    Debug.Log("M" + i + ": " + M[i]);
                } else {
                    currentProfileCorrect = false;
                }

                //WS
                if (ValueCheckDice("Input WS", i, out nTemp)) {
                    WS[i] = nTemp;
                    Debug.Log("WS" + i + ": " + WS[i]);
                } else {
                    currentProfileCorrect = false;
                }

                //BS
                if (ValueCheckDice("Input BS", i, out nTemp)) {
                    BS[i] = nTemp;
                    Debug.Log("BS" + i + ": " + BS[i]);
                } else {
                    currentProfileCorrect = false;
                }

                //S
                if (ValueCheckPositive("Input S", i, out nTemp)) {
                    S[i] = nTemp;
                    Debug.Log("S" + i + ": " + S[i]);
                } else {
                    currentProfileCorrect = false;
                }

                //T
                if (ValueCheckPositive("Input T", i, out nTemp)) {
                    T[i] = nTemp;
                    Debug.Log("T" + i + ": " + T[i]);
                } else {
                    currentProfileCorrect = false;
                }

                //W
                if (ValueCheckPositive("Input W", i, out nTemp)) {
                    W[i] = nTemp;
                    Debug.Log("W" + i + ": " + W[i]);
                } else {
                    currentProfileCorrect = false;
                }
                if (i > 0) {
                    if (W[i] >= W[i-1]) {
                        Debug.Log("W" + i + " is not less than W" + (i - 1) + ". Please check that wound chart values are correct.");
                        string sTemp = "Input W" + i;
                        Text[] textTemp = GameObject.Find(sTemp).GetComponentsInChildren<Text>();
                        for (int n = 0; n < textTemp.Length; n++) {
                            textTemp[n].color = Color.red;
                        }
                        currentProfileCorrect = false;
                    }
                }

                //A
                if (ValueCheckPositive("Input A", i, out nTemp)) {
                    A[i] = nTemp;
                    Debug.Log("A" + i + ": " + A[i]);
                } else {
                    currentProfileCorrect = false;
                }

                //Ld
                if (ValueCheckPositive("Input Ld", i, out nTemp)) {
                    Ld[i] = nTemp;
                    Debug.Log("Ld" + i + ": " + Ld[i]);
                } else {
                    currentProfileCorrect = false;
                }

                //Sv
                if (ValueCheckDice("Input Sv", i, out nTemp)) {
                    Sv[i] = nTemp;
                    Debug.Log("Sv" + i + ": " + Sv[i]);
                } else {
                    currentProfileCorrect = false;
                }

                //if (! includeDamageCharts) {
                //    break;
                //}

            } else if (i == 0) {
                currentProfileCorrect = false;
            }
        }
        return currentProfileCorrect;
    }

    bool ValueCheckDice (string name, int i, out int value) {
        int nTemp;
        string sTemp = name + i;
        InputField inputTemp = GameObject.Find(sTemp).GetComponent<InputField>();
        Text[] tTemp = inputTemp.gameObject.GetComponentsInChildren<Text>();
        if (int.TryParse(inputTemp.text, out nTemp)) {

            if (0 < nTemp && nTemp < 7) {
                value = nTemp;
                foreach (Text text in tTemp) {
                    text.color = defaultText;
                }
                return true;
            } else {
                value = 0;
                OutputError(tTemp);
                return false;
            }
        } else {
            value = 0;
            OutputError(tTemp);
            return false;
        }
    }

    bool ValueCheckPositive (string name, int i, out int value) {
        int nTemp;
        string sTemp = name + i;
        InputField inputTemp = GameObject.Find(sTemp).GetComponent<InputField>();
        Text[] tTemp = inputTemp.gameObject.GetComponentsInChildren<Text>();
        if (int.TryParse(inputTemp.text, out nTemp)) {

            if (nTemp > 0) {
                value = nTemp;
                foreach (Text text in tTemp) {
                    text.color = defaultText;
                }
                return true;
            } else {
                value = 0;
                OutputError(tTemp);
                return false;
            }
        } else {
            value = 0;
            OutputError(tTemp);
            return false;
        }
    }

    bool ValueCheckNotNegative (string name, int i, out int value) {
        int nTemp;
        string sTemp = name + i;
        InputField inputTemp = GameObject.Find(sTemp).GetComponent<InputField>();
        Text[] tTemp = inputTemp.gameObject.GetComponentsInChildren<Text>();
        if (int.TryParse(inputTemp.text, out nTemp)) {

            if (nTemp >= 0) {
                value = nTemp;
                foreach (Text text in tTemp) {
                    text.color = defaultText;
                }
                return true;
            } else {
                value = 0;
                OutputError(tTemp);
                return false;
            }
        } else {
            value = 0;
            OutputError(tTemp);
            return false;
        }
    }

    void OutputError(Text[] temp) {
        foreach (Text text in temp) {
            text.color = Color.red;
        }
        Debug.Log("Value of " + name + " is not legal.");
    }
    
    public void ResetLoad(Profile profile) {

        PointsValue = profile.PointsValue;
        GameObject inputPointsValue = GameObject.Find("Input Points Value");
        if (inputPointsValue) {
            inputPointsValue.GetComponent<InputField>().text = profile.PointsValue.ToString();
        }
        Name = profile.Name;
        GameObject inputName = GameObject.Find("Input Name");
        if (inputName) {
            inputName.GetComponent<InputField>().text = profile.Name;
        }

        //M
        for (int i = 0; i <= profile.DamageCharts; i++) {
            M[i] = profile.Move[i];
        }
        //WS
        for (int i = 0; i <= profile.DamageCharts; i++) {
            WS[i] = profile.WeaponSkill[i];
        }
        //BS
        for (int i = 0; i <= profile.DamageCharts; i++) {
            BS[i] = profile.BallisticSkill[i];
        }
        //S
        for (int i = 0; i <= profile.DamageCharts; i++) {
            S[i] = profile.Strength[i];
        }
        //T
        for (int i = 0; i <= profile.DamageCharts; i++) {
            T[i] = profile.Toughness[i];
        }
        //W
        for (int i = 0; i <= profile.DamageCharts; i++) {
            W[i] = profile.Wounds[i];
        }
        //A
        for (int i = 0; i <= profile.DamageCharts; i++) {
            A[i] = profile.Attacks[i];
        }
        //Ld
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Ld[i] = profile.Leadership[i];
        }
        //Sv
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Sv[i] = profile.Save[i];
        }

        DamageCharts = profile.DamageCharts;
        dropdownDamage.value = DamageCharts;
        for (int i = 1; i <= DamageCharts; i++) {
            unitCard[i].SetActive(true);
        }
        UpdateProfiles(profile.DamageCharts);

        Debug.Log(Name + " Points Value: " + PointsValue);
        for (int i = 0; i <= profile.DamageCharts; i++) {
            Debug.Log("Chart Line " + i + " - M: " + M[i] + " WS: " + WS[i] + " BS: " + BS[i] + " S: " + S[i] + " T: " + W[i] + " W: " + A[i] + " Ld: " + Ld[i] + " Sv: " + Sv[i]);
        }
    }

    public void Load () {
        save.interactable = false;
        load.interactable = false;

        panelLoad.SetActive(true);
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

        buttonProfiles = FindObjectsOfType<ButtonProfile>();
        searchField = panelLoad.GetComponentInChildren<InputField>();
    }

    public void LoadSavedProfile () {
        ResetLoad(instance.Profiles[profileToLoad]);
        overwritePanel.SetActive(false);
    }

    public void Close (bool overwrite) {
        if ( ! overwrite) {
            Button[] buttons = contentLoad.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++) {
                Destroy(buttons[i].gameObject);
            }

            save.interactable = true;
            load.interactable = true;
            searchField = null;
            panelLoad.SetActive(false);
        } else {
            overwritePanel.SetActive(false);
        }
    }

    public void Back () {

        SceneManager.LoadScene("Start");
    }

    public void Exit () {
        instance.OnDisable();
        Application.Quit();
    }
}
