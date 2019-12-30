using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ProfileUI : MonoBehaviour {

    public enum CloseType { basic, loadPanelClose, loadPanelLoad, nameCheckLoad, nameCheckSave }
    public enum NavigationType { next, previous, up, down, left, right }

    public Text textMessage;
    public GameObject[] unitCard;
    public Text textDamage;
    public Dropdown dropdownDamage;
    public Button buttonLoad;
    public GameObject panelLoad;
    public GameObject contentLoad;
    public GameObject panelNameCheck;
    public GameObject buttonProfile;
    public Button save;
    public Button load;

    //public int PointsValue { get; set; }
    //public string Name { get; set; }
    //public int[] M { get; set; }
    //public int[] WS { get; set; }
    //public int[] BS { get; set; }
    //public int[] S { get; set; }
    //public int[] T { get; set; }
    //public int[] W { get; set; }
    //public int[] A { get; set; }
    //public int[] Ld { get; set; }
    //public int[] Sv { get; set; }

    //public int DamageCharts { get; set; }

    ButtonProfile[] buttonProfiles;

    GameManager instance;
    ProfileMessager messanger;
    ProfileValueChecker valueChecker;
    ProfileSetter setter;
    InputField searchField;
    Color defaultColor;

    int profileToLoad;

    void Awake () {
        Assert.IsNotNull(textMessage, "The Message text has not been assigned to the UI manager.");
        Assert.IsTrue(unitCard.Length > 0, "Unit card panels have not been assigned to the UI Manager.");
        Assert.IsNotNull(textDamage, "Text Damage has not been assigned to the UI Manager.");
        Assert.IsNotNull(dropdownDamage, "Dropdown Damage has not been assinged to the UI Manager.");
        Assert.IsNotNull(buttonLoad, "Load Button has not been assigned to the UI Manager.");
        Assert.IsNotNull(panelLoad, "Load Panel has not been assigned to the UI Manager.");
        Assert.IsNotNull(contentLoad, "Load Content object has not been assigned to the UI Manager.");
        Assert.IsNotNull(panelNameCheck, "Overwrite Name Check has not been assigned to the UI Manager.");
        Assert.IsNotNull(buttonProfile, "Profile Button has not been assigned to the UI Manager.");
        Assert.IsNotNull(save, "Save button has not been assigned to the UI Manager.");
        Assert.IsNotNull(load, "Load button has not been assigned to the UI Manager.");

        //M = new int[unitCard.Length]; WS = new int[unitCard.Length]; BS = new int[unitCard.Length]; S = new int[unitCard.Length]; T = new int[unitCard.Length]; W = new int[unitCard.Length]; A = new int[unitCard.Length];
        //Ld = new int[unitCard.Length]; Sv = new int[unitCard.Length];

        buttonProfiles = new ButtonProfile[0];
    }

	// Use this for initialization
	void Start () {

        instance = GameManager.instance;
        Assert.IsNotNull(instance, "Can not find Game Manager.");
        messanger = FindObjectOfType<ProfileMessager>();
        valueChecker = GetComponent<ProfileValueChecker>();
        Assert.IsNotNull(valueChecker, "Can not find Value Checker.");
        setter = GetComponent<ProfileSetter>();
        Assert.IsNotNull(valueChecker, "Can not find Profile Setter.");

        defaultColor = unitCard[1].GetComponentInChildren<Text>().color;
        //if ( ! instance.InitialLoad) {
        //    Profile profile = instance.ActiveProfile;
        //    //ResetLoad(profile);
        //    //DamageCharts = profile.DamageCharts;
        //    //dropdownDamage.value = DamageCharts;
        //    //for (int i = 1; i <= DamageCharts; i++) {
        //    //    unitCard[i].SetActive(true);
        //    //}
        //    //UpdateProfiles(profile.DamageCharts);
        //}

        if (instance.Profiles.Count > 0) {
            buttonLoad.interactable = true;
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
        else if (Input.GetKeyUp(KeyCode.UpArrow) && ! uiObject.transform.IsChildOf(dropdownDamage.transform))
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
        else if (Input.GetKeyUp(KeyCode.DownArrow) && !uiObject.transform.IsChildOf(dropdownDamage.transform))
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

    public void CreateDamageProfiles () {

        Debug.Log("Adjusting visible profiles based on current profiles Damage Charts.");
        
        for (int i = 1; i < unitCard.Length; i++) {

            unitCard[i].SetActive(false);
        }
        for (int i = 1; i <= setter.CurrentProfile.DamageCharts; i++) {

            unitCard[i].SetActive(true);
        }

        Debug.Log("Loading Current Profile into visible profiles.");

        ReadProfile();
        //UpdateProfiles(profileSetter.CurrentProfile.DamageCharts);
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

    public void SetColor (string profileName, bool correctEntry) {

        foreach (GameObject card in unitCard) {

            if (card.activeInHierarchy) {

                InputField[] inputs = card.GetComponentsInChildren<InputField>();
                foreach (InputField input in inputs) {

                    profileName = (profileName == "S0") ? "Input S0" : profileName;
                    profileName = (profileName == "S1") ? "Input S1" : profileName;
                    profileName = (profileName == "S2") ? "Input S2" : profileName;
                    profileName = (profileName == "S3") ? "Input S3" : profileName;
                    profileName = (profileName == "S4") ? "Input S4" : profileName;

                    if (input.gameObject.name.Contains(profileName)) {

                        Text[] texts = input.GetComponentsInChildren<Text>();
                        foreach (Text text in texts) {

                            text.color = (correctEntry) ? defaultColor : Color.red;
                            if (text.gameObject.name.Contains("Place")) {
                                
                                if (profileName == "Name") {
                                    text.text = (correctEntry) ? "Name" : "Error";
                                } else {
                                    text.text = (correctEntry) ? "" : "E";
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public void ReadProfile () {

        if (setter.CurrentProfile != null) {

            foreach (GameObject card in unitCard) {

                if (card.activeInHierarchy) {
                    Debug.Log("Profile panel " + card.name + " is active.");

                    InputField[] inputs = card.GetComponentsInChildren<InputField>();
                    foreach (InputField input in inputs) {
                        Debug.Log("Attempting to fill " + input.gameObject.name + ".");

                        Text[] texts = input.gameObject.GetComponentsInChildren<Text>();
                        switch (input.gameObject.name) {                            

                            case "Input Name":
                                Debug.Log("Setting Input Name in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Name;
                                break;
                            case "Input M0":
                                Debug.Log("Setting Move[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Move[0].ToString();
                                break;
                            case "Input M1":
                                Debug.Log("Setting Move[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Move[1].ToString();
                                break;
                            case "Input M2":
                                Debug.Log("Setting Move[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Move[2].ToString();
                                break;
                            case "Input M3":
                                Debug.Log("Setting Move[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Move[3].ToString();
                                break;
                            case "Input M4":
                                Debug.Log("Setting Move[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Move[4].ToString();
                                break;
                            case "Input WS0":
                                Debug.Log("Setting Weapon Skill[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.WeaponSkill[0].ToString();
                                break;
                            case "Input WS1":
                                Debug.Log("Setting Weapon Skill[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.WeaponSkill[1].ToString();
                                break;
                            case "Input WS2":
                                Debug.Log("Setting Weapon Skill[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.WeaponSkill[2].ToString();
                                break;
                            case "Input WS3":
                                Debug.Log("Setting Weapon Skill[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.WeaponSkill[3].ToString();
                                break;
                            case "Input WS4":
                                Debug.Log("Setting Weapon Skill[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.WeaponSkill[4].ToString();
                                break;
                            case "Input BS0":
                                Debug.Log("Setting Ballistic Skill[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.BallisticSkill[0].ToString();
                                break;
                            case "Input BS1":
                                Debug.Log("Setting Ballistic Skill[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.BallisticSkill[1].ToString();
                                break;
                            case "Input BS2":
                                Debug.Log("Setting Ballistic Skill[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.BallisticSkill[2].ToString();
                                break;
                            case "Input BS3":
                                Debug.Log("Setting Ballistic Skill[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.BallisticSkill[3].ToString();
                                break;
                            case "Input BS4":
                                Debug.Log("Setting Ballistic Skill[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.BallisticSkill[4].ToString();
                                break;
                            case "Input S0":
                                Debug.Log("Setting Strength[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Strength[0].ToString();
                                break;
                            case "Input S1":
                                Debug.Log("Setting Strength[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Strength[1].ToString();
                                break;
                            case "Input S2":
                                Debug.Log("Setting Strength[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Strength[2].ToString();
                                break;
                            case "Input S3":
                                Debug.Log("Setting Strength[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Strength[3].ToString();
                                break;
                            case "Input S4":
                                Debug.Log("Setting Strength[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Strength[4].ToString();
                                break;
                            case "Input T0":
                                Debug.Log("Setting Toughness[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Toughness[0].ToString();
                                break;
                            case "Input T1":
                                Debug.Log("Setting Toughness[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Toughness[1].ToString();
                                break;
                            case "Input T2":
                                Debug.Log("Setting Toughness[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Toughness[2].ToString();
                                break;
                            case "Input T3":
                                Debug.Log("Setting Toughness[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Toughness[3].ToString();
                                break;
                            case "Input T4":
                                Debug.Log("Setting Toughness[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Toughness[4].ToString();
                                break;
                            case "Input W0":
                                Debug.Log("Setting Wounds[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Wounds[0].ToString();
                                break;
                            case "Input W1":
                                Debug.Log("Setting Wounds[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Wounds[1].ToString();
                                break;
                            case "Input W2":
                                Debug.Log("Setting Wounds[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Wounds[2].ToString();
                                break;
                            case "Input W3":
                                Debug.Log("Setting Wounds[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Wounds[3].ToString();
                                break;
                            case "Input W4":
                                Debug.Log("Setting Wounds[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Wounds[4].ToString();
                                break;
                            case "Input A0":
                                Debug.Log("Setting Attacks[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Attacks[0].ToString();
                                break;
                            case "Input A1":
                                Debug.Log("Setting Attacks[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Attacks[1].ToString();
                                break;
                            case "Input A2":
                                Debug.Log("Setting Attacks[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Attacks[2].ToString();
                                break;
                            case "Input A3":
                                Debug.Log("Setting Attacks[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Attacks[3].ToString();
                                break;
                            case "Input A4":
                                Debug.Log("Setting Attacks[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Attacks[4].ToString();
                                break;
                            case "Input Ld0":
                                Debug.Log("Setting Leadership[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Leadership[0].ToString();
                                break;
                            case "Input Ld1":
                                Debug.Log("Setting Leadership[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Leadership[1].ToString();
                                break;
                            case "Input Ld2":
                                Debug.Log("Setting Leadership[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Leadership[2].ToString();
                                break;
                            case "Input Ld3":
                                Debug.Log("Setting Leadership[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Leadership[3].ToString();
                                break;
                            case "Input Ld4":
                                Debug.Log("Setting Leadership[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Leadership[4].ToString();
                                break;
                            case "Input Sv0":
                                Debug.Log("Setting Save[0] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Save[0].ToString();
                                break;
                            case "Input Sv1":
                                Debug.Log("Setting Save[1] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Save[1].ToString();
                                break;
                            case "Input Sv2":
                                Debug.Log("Setting Save[2] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Save[2].ToString();
                                break;
                            case "Input Sv3":
                                Debug.Log("Setting Save[3] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Save[3].ToString();
                                break;
                            case "Input Sv4":
                                Debug.Log("Setting Save[4] in " + input.gameObject.name + ".");
                                input.text = setter.CurrentProfile.Save[4].ToString();
                                break;
                        }
                    }
                }
            }
        }
    }

    public void OutputProfileError (string profileName, int index) {

        InputField[] inputs = unitCard[index].GetComponentsInChildren<InputField>();
        foreach (InputField input in inputs) {
            if (input.gameObject.name == profileName) {

                SetColor(input.gameObject.name, false);                
            }
        }
    }

    //public void SetCombatProfile (bool overwrite) {

    //    if (ProfileCorrectlySet()) { //Include damage charts

    //        Profile profile = new Profile();
    //        {
    //            profile.PointsValue = PointsValue;
    //            profile.Name = Name;

    //            //M
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.Move[i] = M[i];
    //            }
    //            //WS
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.WeaponSkill[i] = WS[i];
    //            }
    //            //BS
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.BallisticSkill[i] = BS[i];
    //            }
    //            //S
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.Strength[i] = S[i];
    //            }
    //            //T
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.Toughness[i] = T[i];
    //            }
    //            //W
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.Wounds[i] = W[i];
    //            }
    //            //A
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.Attacks[i] = A[i];
    //            }
    //            //Ld
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.Leadership[i] = Ld[i];
    //            }
    //            //Sv
    //            for (int i = 0; i <= DamageCharts; i++) {
    //                profile.Save[i] = Sv[i];
    //            }
    //        }
    //        Debug.Log("Combat profile for " + profile.Name + ", " + profile.PointsValue + " points.");

    //        for (int i = 0; i <= profile.DamageCharts; i++) {
    //            Debug.Log("Damage Chart " + i + "- M:" + profile.Move[i] + " WS: " + profile.WeaponSkill[i] + " BS: " + profile.BallisticSkill[i] + " S: " + profile.Strength[i] +
    //                      " T: " + profile.Toughness[i] + " W: " + profile.Wounds[i] + " A: " + profile.Attacks[i] + " Ld: " + profile.Leadership[i] + " Sv: " + profile.Save[i]);
    //        }
    //        textMessage.text = "";

    //        instance.ActiveProfile = profile;
    //        bool nameCheck = true;
    //        for (int i = 0; i < instance.Profiles.Count; i++) {
    //            if (Name == instance.Profiles[i].Name) {
    //                nameCheck = false;
    //                profileToLoad = i;
    //            }
    //        }

    //        if (nameCheck) {
    //            instance.Profiles.Add(profile);
    //            instance.Save();
    //            buttonLoad.interactable = true;
    //        } else if (overwrite) {
    //            instance.Profiles[profileToLoad] = profile;
    //            overwritePanel.SetActive(false);
    //            instance.Save();
    //        } else {
    //            overwritePanel.SetActive(true);
    //        }

    //    } else {
    //        textMessage.text = "Unit Profile is not complete. Please finish the card for all rows of the damage chart.";
    //    }
    //}

    //public void UpdateProfiles (int damageCharts) {

    //    int nTemp;

    //    //M
    //    nTemp = Mathf.Min(damageCharts+1, M.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input M" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = M[i].ToString();
    //    }
    //    //WS
    //    nTemp = Mathf.Min(damageCharts+1, WS.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input WS" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = WS[i].ToString();
    //    }
    //    //BS
    //    nTemp = Mathf.Min(damageCharts+1, BS.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input BS" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = BS[i].ToString();
    //    }
    //    //S
    //    nTemp = Mathf.Min(damageCharts+1, S.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input S" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = S[i].ToString();
    //    }
    //    //T
    //    nTemp = Mathf.Min(damageCharts+1, T.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input T" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = T[i].ToString();
    //    }
    //    //W
    //    nTemp = Mathf.Min(damageCharts+1, W.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input W" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = W[i].ToString();
    //    }
    //    //A
    //    nTemp = Mathf.Min(damageCharts+1, A.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input A" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = A[i].ToString();
    //    }
    //    //Ld
    //    nTemp = Mathf.Min(damageCharts+1, Ld.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input Ld" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = Ld[i].ToString();
    //    }
    //    //Sv
    //    nTemp = Mathf.Min(damageCharts+1, Sv.Count(i => i != 0));
    //    for (int i = 0; i < nTemp; i++) {
    //        string sTemp = "Input Sv" + i;
    //        GameObject.Find(sTemp).GetComponent<InputField>().text = Sv[i].ToString();
    //    }
    //}

    //bool ProfileCorrectlySet () {

    //    bool currentProfileCorrect = true;
    //    InputField inputTemp = GameObject.Find("Input Points Value").GetComponent<InputField>();
    //    Text[] tTemp = inputTemp.gameObject.GetComponentsInChildren<Text>();
    //    int nTemp;
    //    if (int.TryParse(inputTemp.text, out nTemp)) {

    //        if (nTemp >= 0) {
    //            PointsValue = nTemp;
    //            foreach (Text text in tTemp) {
    //                text.color = defaultText;
    //            }
    //        } else {
    //            OutputError(tTemp);
    //            currentProfileCorrect = false;
    //        }
    //    } else {
    //        OutputError(tTemp);
    //        currentProfileCorrect = false;
    //    }

    //    inputTemp = GameObject.Find("Input Name").GetComponent<InputField>();
    //    Name = inputTemp.text;
    //    if (Name.Length == 0) {
    //        Text[] taTemp = inputTemp.GetComponentsInChildren<Text>();
    //        OutputError(taTemp);
    //        currentProfileCorrect = false;
    //    }

    //    for (int i = 0; i <= DamageCharts; i++) {

    //        if (unitCard[i].activeSelf) {

    //            //M
    //            if (ValueCheckNotNegative("Input M", i, out nTemp)) {
    //                M[i] = nTemp;
    //                Debug.Log("M" + i + ": " + M[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }

    //            //WS
    //            if (ValueCheckDice("Input WS", i, out nTemp)) {
    //                WS[i] = nTemp;
    //                Debug.Log("WS" + i + ": " + WS[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }

    //            //BS
    //            if (ValueCheckDice("Input BS", i, out nTemp)) {
    //                BS[i] = nTemp;
    //                Debug.Log("BS" + i + ": " + BS[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }

    //            //S
    //            if (ValueCheckPositive("Input S", i, out nTemp)) {
    //                S[i] = nTemp;
    //                Debug.Log("S" + i + ": " + S[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }

    //            //T
    //            if (ValueCheckPositive("Input T", i, out nTemp)) {
    //                T[i] = nTemp;
    //                Debug.Log("T" + i + ": " + T[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }

    //            //W
    //            if (ValueCheckPositive("Input W", i, out nTemp)) {
    //                W[i] = nTemp;
    //                Debug.Log("W" + i + ": " + W[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }
    //            if (i > 0) {
    //                if (W[i] >= W[i-1]) {
    //                    Debug.Log("W" + i + " is not less than W" + (i - 1) + ". Please check that wound chart values are correct.");
    //                    string sTemp = "Input W" + i;
    //                    Text[] textTemp = GameObject.Find(sTemp).GetComponentsInChildren<Text>();
    //                    for (int n = 0; n < textTemp.Length; n++) {
    //                        textTemp[n].color = Color.red;
    //                    }
    //                    currentProfileCorrect = false;
    //                }
    //            }

    //            //A
    //            if (ValueCheckPositive("Input A", i, out nTemp)) {
    //                A[i] = nTemp;
    //                Debug.Log("A" + i + ": " + A[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }

    //            //Ld
    //            if (ValueCheckPositive("Input Ld", i, out nTemp)) {
    //                Ld[i] = nTemp;
    //                Debug.Log("Ld" + i + ": " + Ld[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }

    //            //Sv
    //            if (ValueCheckDice("Input Sv", i, out nTemp)) {
    //                Sv[i] = nTemp;
    //                Debug.Log("Sv" + i + ": " + Sv[i]);
    //            } else {
    //                currentProfileCorrect = false;
    //            }

    //            //if (! includeDamageCharts) {
    //            //    break;
    //            //}

    //        } else if (i == 0) {
    //            currentProfileCorrect = false;
    //        }
    //    }
    //    textMessage.text = "";
    //    return currentProfileCorrect;
    //}

    //bool ValueCheckDice (string name, int i, out int value) {
    //    int nTemp;
    //    string sTemp = name + i;
    //    InputField inputTemp = GameObject.Find(sTemp).GetComponent<InputField>();
    //    Text[] tTemp = inputTemp.gameObject.GetComponentsInChildren<Text>();
    //    if (int.TryParse(inputTemp.text, out nTemp)) {

    //        if (0 < nTemp && nTemp < 7) {
    //            value = nTemp;
    //            foreach (Text text in tTemp) {
    //                text.color = defaultText;
    //            }
    //            return true;
    //        } else {
    //            value = 0;
    //            OutputError(tTemp);
    //            return false;
    //        }
    //    } else {
    //        value = 0;
    //        OutputError(tTemp);
    //        return false;
    //    }
    //}

    //bool ValueCheckPositive (string name, int i, out int value) {
    //    int nTemp;
    //    string sTemp = name + i;
    //    InputField inputTemp = GameObject.Find(sTemp).GetComponent<InputField>();
    //    Text[] tTemp = inputTemp.gameObject.GetComponentsInChildren<Text>();
    //    if (int.TryParse(inputTemp.text, out nTemp)) {

    //        if (nTemp > 0) {
    //            value = nTemp;
    //            foreach (Text text in tTemp) {
    //                text.color = defaultText;
    //            }
    //            return true;
    //        } else {
    //            value = 0;
    //            OutputError(tTemp);
    //            return false;
    //        }
    //    } else {
    //        value = 0;
    //        OutputError(tTemp);
    //        return false;
    //    }
    //}

    //bool ValueCheckNotNegative (string name, int i, out int value) {
    //    int nTemp;
    //    string sTemp = name + i;
    //    InputField inputTemp = GameObject.Find(sTemp).GetComponent<InputField>();
    //    Text[] tTemp = inputTemp.gameObject.GetComponentsInChildren<Text>();
    //    if (int.TryParse(inputTemp.text, out nTemp)) {

    //        if (nTemp >= 0) {
    //            value = nTemp;
    //            foreach (Text text in tTemp) {
    //                text.color = defaultText;
    //            }
    //            return true;
    //        } else {
    //            value = 0;
    //            OutputError(tTemp);
    //            return false;
    //        }
    //    } else {
    //        value = 0;
    //        OutputError(tTemp);
    //        return false;
    //    }
    //}

    //void OutputError(Text[] temp) {
    //    foreach (Text text in temp) {
    //        text.color = Color.red;
    //    }
    //    textMessage.text = "Profile contains illegal values.";
    //    Debug.Log("Value of " + name + " is not legal.");
    //}

    //public void ResetLoad(Profile profile) {
    //    textMessage.text = "";

    //    PointsValue = profile.PointsValue;
    //    GameObject inputPointsValue = GameObject.Find("Input Points Value");
    //    if (inputPointsValue) {
    //        inputPointsValue.GetComponent<InputField>().text = profile.PointsValue.ToString();
    //    }
    //    Name = profile.Name;
    //    GameObject inputName = GameObject.Find("Input Name");
    //    if (inputName) {
    //        inputName.GetComponent<InputField>().text = profile.Name;
    //    }

    //    //M
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        M[i] = profile.Move[i];
    //    }
    //    //WS
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        WS[i] = profile.WeaponSkill[i];
    //    }
    //    //BS
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        BS[i] = profile.BallisticSkill[i];
    //    }
    //    //S
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        S[i] = profile.Strength[i];
    //    }
    //    //T
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        T[i] = profile.Toughness[i];
    //    }
    //    //W
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        W[i] = profile.Wounds[i];
    //    }
    //    //A
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        A[i] = profile.Attacks[i];
    //    }
    //    //Ld
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        Ld[i] = profile.Leadership[i];
    //    }
    //    //Sv
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        Sv[i] = profile.Save[i];
    //    }

    //    DamageCharts = profile.DamageCharts;
    //    dropdownDamage.value = DamageCharts;
    //    for (int i = 1; i <= DamageCharts; i++) {
    //        unitCard[i].SetActive(true);
    //    }
    //    UpdateProfiles(profile.DamageCharts);

    //    Debug.Log(Name + " Points Value: " + PointsValue);
    //    for (int i = 0; i <= profile.DamageCharts; i++) {
    //        Debug.Log("Chart Line " + i + " - M: " + M[i] + " WS: " + WS[i] + " BS: " + BS[i] + " S: " + S[i] + " T: " + W[i] + " W: " + A[i] + " Ld: " + Ld[i] + " Sv: " + Sv[i]);
    //    }
    //}
    
    public void SelectUIElement (NavigationType navigate = NavigationType.next)
    {
        GameObject lastCell;
        Debug.Log("Selecting the UIElement.");
        if (navigate == NavigationType.previous)
        {
            if (unitCard[4].activeInHierarchy)
            {
                lastCell = unitCard[4].transform.GetChild(8).gameObject;
                Debug.Log("Select UI Element found " + lastCell.name);
                EventSystem.current.SetSelectedGameObject(lastCell);
            }
            else if (unitCard[3].activeInHierarchy)
            {
                lastCell = unitCard[3].transform.GetChild(8).gameObject;
                Debug.Log("Select UI Element found " + lastCell.name);
                EventSystem.current.SetSelectedGameObject(lastCell);
            }
            else if (unitCard[2].activeInHierarchy)
            {
                lastCell = unitCard[2].transform.GetChild(8).gameObject;
                Debug.Log("Select UI Element found " + lastCell.name);
                EventSystem.current.SetSelectedGameObject(lastCell);
            }
            else if (unitCard[1].activeInHierarchy)
            {
                lastCell = unitCard[1].transform.GetChild(8).gameObject;
                Debug.Log("Select UI Element found " + lastCell.name);
                EventSystem.current.SetSelectedGameObject(lastCell);
            }
            else
            {
                lastCell = unitCard[0].transform.GetChild(19).gameObject;
                Debug.Log("Select UI Element found " + lastCell.name);
                EventSystem.current.SetSelectedGameObject(lastCell);
            }
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
        }
    }
    public void KeyboardNavigation (GameObject currentObject, NavigationType navigate = NavigationType.next)
    {
        int childIndex = currentObject.transform.GetSiblingIndex();
        Debug.Log("Attempting to navigate " + navigate + " from keyboard.");
        if (currentObject == dropdownDamage || currentObject.transform.IsChildOf(dropdownDamage.transform))
        {
            switch (navigate) 
            {
                case NavigationType.previous:
                case NavigationType.up:
                case NavigationType.left:
                    SelectUIElement(NavigationType.previous);
                    break;
                default:
                    dropdownDamage.Hide();
                    EventSystem.current.SetSelectedGameObject(unitCard[0].transform.GetChild(1).gameObject);
                    break;
            }
        }
        else if (currentObject.transform.parent.gameObject == unitCard[0])
        {
            Debug.Log("Navigating from Unit Card Panel.");
            switch (navigate)
            {
                case NavigationType.next:
                case NavigationType.right:
                    if (childIndex >= 18)
                    {
                        if (unitCard[1].activeInHierarchy)
                        {
                            EventSystem.current.SetSelectedGameObject(unitCard[1].transform.GetChild(0).gameObject);
                        }
                        else
                        {
                            EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                        }
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[0].transform.GetChild(childIndex + 2).gameObject);
                    }
                    break;
                case NavigationType.previous:
                case NavigationType.left:
                    if (childIndex <= 1)
                    {
                        EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[0].transform.GetChild(childIndex - 2).gameObject);
                    }
                    break;
                case NavigationType.down:
                    if (unitCard[1].activeInHierarchy)
                    {
                        childIndex = Mathf.Clamp(Mathf.RoundToInt(childIndex / 2 - 1), 0, 8);
                        EventSystem.current.SetSelectedGameObject(unitCard[1].transform.GetChild(childIndex).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    }
                    break;
                default:
                    EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    break;
            }
        }
        else if (currentObject.transform.parent.gameObject == unitCard[1])
        {
            Debug.Log("Navigating from Unit Card Panel.");
            switch (navigate)
            {
                case NavigationType.next:
                case NavigationType.right:
                    if (childIndex >= 8)
                    {
                        if (unitCard[2].activeInHierarchy)
                        {
                            EventSystem.current.SetSelectedGameObject(unitCard[2].transform.GetChild(0).gameObject);
                        }
                        else
                        {
                            EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                        }
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[1].transform.GetChild(childIndex + 1).gameObject);
                    }
                    break;
                case NavigationType.previous:
                case NavigationType.left:
                    if (childIndex <= 0)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[0].transform.GetChild(19).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[1].transform.GetChild(childIndex - 1).gameObject);
                    }
                    break;
                case NavigationType.up:
                    EventSystem.current.SetSelectedGameObject(unitCard[0].transform.GetChild(childIndex * 2 + 3).gameObject);
                    break;
                case NavigationType.down:
                    if (unitCard[2].activeInHierarchy)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[2].transform.GetChild(childIndex).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    }
                    break;
                default:
                    EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    break;
            }
        }
        else if (currentObject.transform.parent.gameObject == unitCard[2])
        {
            Debug.Log("Navigating from Unit Card Panel.");
            switch (navigate)
            {
                case NavigationType.next:
                case NavigationType.right:
                    if (childIndex >= 8)
                    {
                        if (unitCard[3].activeInHierarchy)
                        {
                            EventSystem.current.SetSelectedGameObject(unitCard[3].transform.GetChild(0).gameObject);
                        }
                        else
                        {
                            EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                        }
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[2].transform.GetChild(childIndex + 1).gameObject);
                    }
                    break;
                case NavigationType.previous:
                case NavigationType.left:
                    if (childIndex <= 0)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[1].transform.GetChild(8).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[2].transform.GetChild(childIndex - 1).gameObject);
                    }
                    break;
                case NavigationType.up:
                    EventSystem.current.SetSelectedGameObject(unitCard[1].transform.GetChild(childIndex).gameObject);
                    break;
                case NavigationType.down:
                    if (unitCard[3].activeInHierarchy)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[3].transform.GetChild(childIndex).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    }
                    break;
                default:
                    EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    break;
            }
        }
        else if (currentObject.transform.parent.gameObject == unitCard[3])
        {
            Debug.Log("Navigating from Unit Card Panel.");
            switch (navigate)
            {
                case NavigationType.next:
                case NavigationType.right:
                    if (childIndex >= 8)
                    {
                        if (unitCard[4].activeInHierarchy)
                        {
                            EventSystem.current.SetSelectedGameObject(unitCard[4].transform.GetChild(0).gameObject);
                        }
                        else
                        {
                            EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                        }
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[3].transform.GetChild(childIndex + 1).gameObject);
                    }
                    break;
                case NavigationType.previous:
                case NavigationType.left:
                    if (childIndex <= 0)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[2].transform.GetChild(8).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[3].transform.GetChild(childIndex - 1).gameObject);
                    }
                    break;
                case NavigationType.up:
                    EventSystem.current.SetSelectedGameObject(unitCard[2].transform.GetChild(childIndex).gameObject);
                    break;
                case NavigationType.down:
                    if (unitCard[4].activeInHierarchy)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[4].transform.GetChild(childIndex).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    }
                    break;
                default:
                    EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    break;
            }
        }
        else if (currentObject.transform.parent.gameObject == unitCard[4])
        {
            Debug.Log("Navigating from Unit Card Panel.");
            switch (navigate)
            {
                case NavigationType.next:
                case NavigationType.right:
                    if (childIndex >= 8)
                    {
                        if (unitCard[3].activeInHierarchy)
                        {
                            EventSystem.current.SetSelectedGameObject(unitCard[3].transform.GetChild(0).gameObject);
                        }
                        else
                        {
                            EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                        }
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[2].transform.GetChild(childIndex + 1).gameObject);
                    }
                    break;
                case NavigationType.previous:
                case NavigationType.left:
                    if (childIndex <= 0)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[1].transform.GetChild(8).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[2].transform.GetChild(childIndex - 1).gameObject);
                    }
                    break;
                case NavigationType.up:
                    EventSystem.current.SetSelectedGameObject(unitCard[1].transform.GetChild(childIndex).gameObject);
                    break;
                case NavigationType.down:
                    if (unitCard[3].activeInHierarchy)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[3].transform.GetChild(childIndex).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    }
                    break;
                default:
                    EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    break;
            }
        }
        else if (currentObject.transform.parent.gameObject == unitCard[3])
        {
            Debug.Log("Navigating from Unit Card Panel.");
            switch (navigate)
            {
                case NavigationType.next:
                case NavigationType.right:
                    if (childIndex >= 8)
                    {
                        EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[4].transform.GetChild(childIndex + 1).gameObject);
                    }
                    break;
                case NavigationType.previous:
                case NavigationType.left:
                    if (childIndex <= 0)
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[3].transform.GetChild(8).gameObject);
                    }
                    else
                    {
                        EventSystem.current.SetSelectedGameObject(unitCard[4].transform.GetChild(childIndex - 1).gameObject);
                    }
                    break;
                case NavigationType.up:
                    EventSystem.current.SetSelectedGameObject(unitCard[3].transform.GetChild(childIndex).gameObject);
                    break;
                default:
                    EventSystem.current.SetSelectedGameObject(dropdownDamage.gameObject);
                    break;
            }
        }
        else
        {
            SelectUIElement();
        }
    }

    public void OpenNameCheckPanel () {

        SetInteractable(false);
        panelNameCheck.SetActive(true);
        messanger.DisplayMessage("A Profile with that name has been found.", true);
    }

    public void EnableLoad () {

        buttonLoad.interactable = true;
    }

    public void Load () {

        SetInteractable(false);
        panelLoad.SetActive(true);
        messanger.DisplayMessage("Select the profile to load or search by the model's name.", false);

        panelLoad.GetComponent<ProfileLoadPanel>().CreateLoadButtons();
    }

    public void LoadSavedProfile () {
        //ResetLoad(instance.Profiles[profileToLoad]);
        panelNameCheck.SetActive(false);
    }

    public void Close (CloseType closeType) {

        if (closeType == CloseType.loadPanelClose || closeType == CloseType.loadPanelLoad) {
            Button[] buttons = contentLoad.GetComponentsInChildren<Button>();
            for (int i = 0; i < buttons.Length; i++) {
                Destroy(buttons[i].gameObject);
            }

            searchField = null;
            panelLoad.SetActive(false);

        } else {

            panelNameCheck.SetActive(false);
        }
        SetInteractable(true);
        messanger.ReturnToCurrentState();

        if (closeType == CloseType.nameCheckSave) {

            StartCoroutine(messanger.DisplayTemporaryMessage("Profile saved.", false));

        } else if (closeType == CloseType.nameCheckLoad || closeType == CloseType.loadPanelLoad) {

            StartCoroutine(messanger.DisplayTemporaryMessage(setter.CurrentProfile.Name + " loaded.", false));
        }
    }

    public void SetInteractable (bool interactable) {

        dropdownDamage.interactable = interactable;

        foreach (GameObject card in unitCard) {

            InputField[] inputs = card.GetComponentsInChildren<InputField>();
            foreach (InputField input in inputs) {
                input.interactable = interactable;
            }
        }
        save.interactable = interactable;
        load.interactable = interactable;
    }

    public void Back () {

        SceneManager.LoadScene("Start");
    }

    public void Exit () {
        instance.OnDisable();
        Application.Quit();
    }
}
