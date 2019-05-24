using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public List<Profile> Profiles { get; set; }
    public List<Rule> Rules { get; set; }
    public List<Weapon> Weapons { get; set; }
    public List<Power> Powers { get; set; }
    public List<Model> Models { get; set; }
    public List<Unit> Units { get; set; }

    ProfileUI profileUI;

    public Profile ActiveProfile { get; set; }
    public Rule ActiveRule { get; set; }
    public Weapon ActiveWeapon { get; set; }
    public Power ActivePower { get; set; }
    public Model ActiveModel { get; set; }
    public Unit ActiveUnit { get; set; }

    //Movement
    //public int PointsValue { get; set; }
    //public string Name { get; set; }
    //public int DamageCharts { get; set; }
    //public int[] M { get; set; }
    //public int[] WS { get; set; }
    //public int[] BS { get; set; }
    //public int[] S { get; set; }
    //public int[] T { get; set; }
    //public int[] W { get; set; }
    //public int[] A { get; set; }
    //public int[] Ld { get; set; }
    //public int[] Sv { get; set; }
    //public bool Fly { get; set; }
    //public bool MinimumMove { get; set; }
    //public bool Reserves { get; set; }
    //public bool ReserveMarker { get; set; }
    //public bool DeepStrike { get; set; }
    //public int DeepStrikeDistance { get; set; }
    //public bool DeepStrikeDamage { get; set; }
    //public int DeepStrikeDamageDistance { get; set; }
    //public int DeepStrikeDamageOf1 { get; set; }
    //public int DeepStrikeDamageOn1 { get; set; }
    //public int DeepStrikeDamageOf2 { get; set; }
    //public int DeepStrikeDamageOn2 { get; set; }
    //public int DeepStrikeDamageOf3 { get; set; }
    //public int DeepStrikeDamageOn3 { get; set; }
    //public bool DeepStrikeDamageNoCharge { get; set; }
    //public bool Transport { get; set; }
    //public bool AdvanceAndCharge { get; set; }
    //public bool CanMoveInShooting { get; set; }
    //public bool CanAdvanceInShooting { get; set; }
    //public bool MultipleDiceOnAdvance { get; set; }
    //public int NumberOfAdvanceDice { get; set; }
    //public bool HasSpecialFallbackRules { get; set; }
    //public bool FallbackAndShoot { get; set; }
    //public bool FallbackAndCharge { get; set; }
    //public bool Redeploys { get; set; }
    //public bool DoublesAdvanceRoll { get; set; }
    //public bool Titanic { get; set; }
    //public bool BonusToAdvanceRoll { get; set; }
    //public int AdvanceBonus { get; set; }
    //public bool FlyOver { get; set; }
    //public int FlyOverDamage { get; set; }
    //public int FlyOverRoll { get; set; }
    //public bool FlyOverSpawn { get; set; }
    //public int FlyOverModel { get; set; }
    //public bool Overdrive { get; set; }
    //public int OverdriveDamage { get; set; }
    //public int OverdriveRoll { get; set; }
    //public bool OverdriveEach { get; set; }
    //public bool OverdriveAdvance { get; set; }
    //public bool OverdriveShoot { get; set; }
    //public bool OverdriveCharge { get; set; }

    ////Shooting
    //public bool BonusToHit { get; set; }
    //public int HitBonus { get; set; }
    //public bool RerollHitRolls { get; set; }
    //public int RerollHitRollsOf { get; set; }
    //public bool RerollMisses { get; set; }
    //public bool BonusToWound { get; set; }
    //public int WoundBonus { get; set; }
    //public bool RerollWoundRolls { get; set; }
    //public int RerollWoundRollsOf { get; set; }
    //public bool RerollFailedWounds { get; set; }
    //public bool OpponentsShootAt { get; set; }
    //public int MinusToHit { get; set; }
    //public bool OpponentsWoundAt { get; set; }
    //public int MinusToWound { get; set; }
    //public bool Braced { get; set; }
    //public int BracedBonus { get; set; }
    //public bool ShootsTwice { get; set; }
    //public bool ShootsTwiceNoMove { get; set; }
    //public bool Fortified { get; set; }
    //public bool BracedReroll { get; set; }
    //public int BracedRerollOn { get; set; }
    //public bool BracedRerollMisses { get; set; }
    //public bool NoPenaltiesToHit { get; set; }
    //public bool NoPenaltiesToWound { get; set; }
    //public bool DenyCover { get; set; }
    //public int DenyCoverWithin { get; set; }
    //public bool DenyAllCover { get; set; }
    //public bool Biovore { get; set; }
    //public int Sporemine { get; set; }

    ////Charges
    //public bool RerollCharges { get; set; }
    //public bool ReserveReroll { get; set; }
    //public bool BonusOnChargeRolls { get; set; }
    //public int ChargeBonus { get; set; }
    //public bool Ram { get; set; }
    //public int RamRoll { get; set; }
    //public int RamDamage { get; set; }
    //public bool RamInfantry { get; set; }
    //public int RamInfantryDamage { get; set; }
    //public bool RamVehicle { get; set; }
    //public int RamVehicleDamage { get; set; }
    //public bool RamEach { get; set; }
    //public bool BonusToHitOnCharge { get; set; }
    //public int ChargeHitBonus { get; set; }
    //public bool BonusToAttackOnCharge { get; set; }
    //public int ChargeAttackBonus { get; set; }
    //public bool Detonates { get; set; }
    //public int DetonateDistance { get; set; }
    //public int DetonateDamage { get; set; }
    //public bool DetonateHitsOneUnit { get; set; }
    //public bool DetonateHitsAllUnits { get; set; }
    //public int DetonateRoll { get; set; }
    //public bool DetonateBonusDamageOnRoll { get; set; }
    //public int DetonateBonusDamageRoll { get; set; }
    //public int DetonateBonusDamage { get; set; }
    //public bool DiesOnDetonate { get; set; }
    //public bool Scream { get; set; }
    //public int ScreamDistance { get; set; }
    //public bool Agile { get; set; }
    //public int AgileDice { get; set; }
    //public bool AgileDropTheLowest { get; set; }
    //public int AgileDropThisManyDice { get; set; }

    ////Fight
    //public bool FightBonusToHit { set; get; }
    //public int FightHitBonus { set; get; }
    //public bool FightRerollHits { set; get; }
    //public int FightRerollHitsOn { set; get; }
    //public bool FightRerollMisses { set; get; }
    //public bool FightBonusToWound { set; get; }
    //public int FightWoundBonus { set; get; }
    //public bool FightRerollWounds { set; get; }
    //public int FightRerollWoundsOn { set; get; }
    //public bool FightRerollFailedWounds { set; get; }
    //public bool FightOpponentsHitAt { set; get; }
    //public int FightHitPenalty { set; get; }
    //public bool FightOpponentsWoundAt { set; get; }
    //public int FightWoundPenalty { set; get; }
    //public bool FightNoHitPenalty { set; get; }
    //public bool FightNoWoundPenalty { set; get; }
    //public bool Miasma { set; get; }
    //public bool MiasmaForOneUnit { set; get; }
    //public bool MiasmaForEachUnit { set; get; }
    //public int MiasmaRange { set; get; }
    //public int MiasmaDamage { set; get; }
    //public int MiasmaRollOn { set; get; }
    //public bool AcidBlood { set; get; }
    //public int AcidBloodRoll { set; get; }
    //public bool AcidBloodOnLast { set; get; }
    //public int AcidBloodDamage { set; get; }
    //public bool FightsFirst { set; get; }
    //public bool OpponentFightsLast { set; get; }
    //public bool Implant { set; get; }
    //public int ImplantDamage { set; get; }
    //public int ImplantRoll { set; get; }
    //public bool FightsTwice { set; get; }
    //public bool FightExtraDamage { set; get; }
    //public int FightExtraDamageOf { set; get; }
    //public int FightExtraDamageOn { set; get; }
    //public bool MoveAtEndOfFight { set; get; }
    //public bool AdvanceAtEndOfFight { set; get; }
    //public bool MoveAtEndIfSlays { set; get; }

    ////Resolutions
    //public bool RerollSaves { get; set; }
    //public int RerollSavesOf { get; set; }
    //public bool RerollFailedSaves { get; set; }
    //public bool Invuln { get; set; }
    //public int InvulnRoll { get; set; }
    //public bool RerollInvulns { get; set; }
    //public int RerollInvulnsOf { get; set; }
    //public bool RerollFailedInvulns { get; set; }
    //public bool ShootingSave { get; set; }
    //public int ShootingSaveAt { get; set; }
    //public bool MeleeSave { get; set; }
    //public int MeleeSaveAt { get; set; }
    //public bool ShootingInvuln { get; set; }
    //public int ShootingInvulnAt { get; set; }
    //public bool MeleeInvuln { get; set; }
    //public int MeleeInvulnAt { get; set; }
    //public bool CoverSave { get; set; }
    //public int CoverSaveBonus { get; set; }
    //public bool ReduceDamage { get; set; }
    //public int ReduceDamageBy { get; set; }
    //public bool ReduceDamageTaken { get; set; }
    //public int ReduceDamageTakenTo { get; set; }
    //public bool ReduceDamageTakenTo1 { get; set; }
    //public bool FeelNoPain { get; set; }
    //public int FeelNoPainOf { get; set; }
    //public bool Regenerate { get; set; }
    //public int RegenerateAmount { get; set; }
    //public int RegenerateRoll { get; set; }
    //public bool RegenerateEachTurn { get; set; }
    //public bool RegenerateYourTurn { get; set; }
    //public bool RegenerateEachMove { get; set; }
    //public bool RegenerateYourMove { get; set; }
    //public bool RegenerateEachMoveEnd { get; set; }
    //public bool RegenerateYourMoveEnd { get; set; }
    //public bool Explodes { get; set; }
    //public int ExplodesRoll { get; set; }
    //public int ExplodesRange { get; set; }
    //public int ExplodesDamage { get; set; }
    //public bool MoraleBonus { get; set; }
    //public int MoraleBonusOf { get; set; }
    //public bool RerollMorales { get; set; }
    //public int RerollMoralesOf { get; set; }
    //public bool RerollAnyMorale { get; set; }
    //public bool PassMorale { get; set; }
    //public bool Terror { get; set; }
    //public int TerrorRange { get; set; }
    //public int TerrorPenalty { get; set; }
    //public bool TerrorAlternate { get; set; }

    bool initialLoad = true;
    public bool InitialLoad {
        get { return initialLoad; }
    }
    bool movementRulesSet = false;
    public bool MovementRulesSet {
        get { return movementRulesSet; }
    }
    bool shootingRulesSet = false;
    public bool ShootingRulesSet {
        get { return shootingRulesSet; }
    }
    bool chargeRulesSet = false;
    public bool ChargeRulesSet {
        get { return chargeRulesSet; }
    }
    bool fightRulesSet = false;
    public bool FightRulesSet {
        get { return fightRulesSet; }
    }
    bool saveRulesSet = false;
    public bool SaveRulesSet {
        get { return saveRulesSet; }
    }

    void Awake () {
        if (instance != null) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }

        Profiles = new List<Profile>();
        Rules = new List<Rule>();
        Models = new List<Model>();
        Units = new List<Unit>();
    }

	// Use this for initialization
	void Start () {
        LoadProfiles();
        LoadRules();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnEnable () {

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded (Scene scene, LoadSceneMode mode) {

        switch (scene.name) {

            //case "Profile UI":
            //    profileUI = FindObjectOfType<ProfileUI>();
            //    //Debug.Log(profileUI.name + " loaded.");
            //    if ( ! initialLoad) {
            //        Load();
            //    }
            //    break;

            //case "Move UI":
            //    Save();
            //    initialLoad = false;
            //    break;

            //case "Shoot UI":
            //    movementRulesSet = true;
            //    break;

            //case "Charge UI":
            //    shootingRulesSet = true;
            //    break;

            //case "Fight UI":
            //    chargeRulesSet = true;
            //    break;

            default:
                break;
        }
    }

    public void OnDisable () {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void SaveProfiles () {

        Debug.Log("Attempting to save profiles to file.");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/WH40KProfiles.dat");

        if (file != null) {
            Debug.Log("WH40KProfiles.dat created.");
        }

        TesterData data = new TesterData();
        data.Profiles = Profiles;
        //data.Rules = Rules;
        //data.FileData.Add("This");
        //data.FileData.Add(" is ");
        //data.FileData.Add("data.");
        //set desired save data

        bf.Serialize(file, data);
        file.Close();
    }

    public void SaveRules()
    {

        Debug.Log("Attempting to save rules to file.");

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/WH40KRules.dat");

        if (file != null)
        {
            Debug.Log("WH40KRules.dat created.");
        }

        TesterData data = new TesterData();
        data.Rules = Rules;
        //data.FileData.Add("This");
        //data.FileData.Add(" is ");
        //data.FileData.Add("data.");
        //set desired save data

        bf.Serialize(file, data);
        file.Close();
    }


    public void LoadProfiles () {

        Debug.Log("Attempting to load data.");

        if (File.Exists(Application.persistentDataPath + "/WH40KProfiles.dat")) {

            Debug.Log("WH40kProfiles.dat exists.");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/WH40KProfiles.dat", FileMode.Open);
            TesterData data = (TesterData)bf.Deserialize(file);

            //set desired data to be loaded
            //Debug.Log(data.FileData[0] + data.FileData[1] + data.FileData[2]);
            Profiles = data.Profiles;
            //Rules = data.Rules;

            if (Profiles[0] != null) Debug.Log("Profiles have been loaded.");

            file.Close();
        }
    }

    public void LoadRules()
    {
        Debug.Log("Attempting to load data.");

        if (File.Exists(Application.persistentDataPath + "/WH40KRules.dat"))
        {

            Debug.Log("WH40KRules.dat exists.");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/WH40KRules.dat", FileMode.Open);
            TesterData data = (TesterData)bf.Deserialize(file);

            Rules = data.Rules;

            if (Profiles[0] != null) Debug.Log("Rules have been loaded.");

            file.Close();
        }
    }

    public void Exit () {

        OnDisable();
        Application.Quit();
    }
}

[Serializable]
class TesterData {
    //desired save data
    public List<Profile> Profiles { get; set; }
    public List<Rule> Rules { get; set; }

    public TesterData (){
        Profiles = new List<Profile>();
        Rules = new List<Rule>();
    }
}
