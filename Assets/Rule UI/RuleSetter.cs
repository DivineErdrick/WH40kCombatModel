using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleSetter : MonoBehaviour
{
    public Rule CurrentRule { get; set; }

    public string InputName { get; set; }

    //Use flags
    public bool UseDeployment { get; set; }
    public bool UseStartOfGame { get; set; }
    public bool UseYourTurn { get; set; }
    public bool UseOpponentsTurn { get; set; }
    public bool UseStartOfTurn { get; set; }
    public bool UseMove { get; set; }
    public bool UsePsychic { get; set; }
    public bool UseShooting { get; set; }
    public bool UseCharge { get; set; }
    public bool UseFight { get; set; }
    public bool UseMorale { get; set; }
    public bool UseEndOfTurn { get; set; }
    public bool UseEndOfGame { get; set; }

    //Activation
    public int ActivationType { get; set; }

    //Triggers
    public int MoveTriggers { get; set; }
    public int PsychicTriggers { get; set; }
    public int ShootingTriggers { get; set; }
    public int ChargeTriggers { get; set; }
    public int FightTriggers { get; set; }
    public int MoraleTriggers { get; set; }

    //Specific Triggers
    public int AttackTriggers { get; set; }
    public int WoundTriggers { get; set; }
    public int PowerTriggers { get; set; }
    public int DenyTriggers { get; set; }
    public int SpecificChargeTriggers { get; set; }
    public int SpecificFightsTriggers { get; set; }
    public int RollTrigger { get; set; }

    //Target
    public int RuleTarget { get; set; }
    public string InputKeyword { get; set; }
    public int KeywordTarget { get; set; }
    public int RuleType { get; set; }

    //Properties
    public int Range { get; set; }
    public int Damage { get; set; }
    public int Roll { get; set; }

    //Reserves
    public bool ReserveOutsideEnemy { get; set; }
    public bool ReserveFromObject { get; set; }
    public bool ReserveRerollCharges { get; set; }
    public bool ReserveDealsMortal { get; set; }
    public int ReserveDamageRange { get; set; }

    //Stat Profile
    public int StatProfile { get; set; }
    public int Modifier { get; set; }
    public int ReRolls { get; set; }
    public int Change { get; set; }
    public bool OrHigher { get; set; }
    public bool OrLower { get; set; }

    //Pass Roll
    public int RollModified { get; set; }
    public int ModifiedBy { get; set; }
    public int RollModifier { get; set; }

    //Ignore Penalties
    public int PenaltyIgnored { get; set; }

    //Additional Attack
    public bool OnlyAdditionalAttack { get; set; }
    public bool CanExplode { get; set; }

    //Mortal Wounds
    public bool SlayTheModel { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        CurrentRule = new Rule();
        InputName = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
