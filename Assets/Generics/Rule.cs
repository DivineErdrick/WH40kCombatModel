using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Rule {

    public enum Uses { Deployment, StartOfGame, YourTurn, OpponentsTurn, StartOfTurn, Move, Psychic, Shooting, Charge, Fight, Morale, EndOfTurn, EndOfGame }

    public enum ActivationTypes { Passive, User, Triggered }

    public enum MoveTriggers { StartOfMove, Moves, Advances, EndOfMove }
    public enum PsychicTriggers { StartOfPsychic, PyschicPower, DenyTheWitch, EndOfPsychic }
    public enum ShootingTriggers { StartOfShooting, Shooting, Wounding, EndOfShooting }
    public enum ChargeTriggers { StartOfCharge, Charge, Overwatch, Wounding, EndOfCharge }
    public enum FightTriggers { StartOfFight, FirstUnitsFight, PickedUnitsFight, LastUnitsFight, Hits, Wounds, EndOfFight }
    public enum MoraleTriggers { StartOfMorale, UnitChosen, MoraleRolled, MoraleRollOf, MoraleModelFlees, MoraleUnitDestroyed, EndOfMorale }

    public enum AttackTriggers { UnitChosen, TargetsChosen, HitRoll, RollOf, Misses, Hits }
    public enum WoundTriggers { WoundRolls, RollOf, FailToWound, Wounds, DamageRolls, ModelKilled, UnitDestroyed }
    public enum PowerTriggers { PowerChosen, TargetsChosen, PsychicTest, RollOf, TestFailed, Perils, Manifests }
    public enum DenyTriggers { DenyRoll, RollOf, DenyFailed, PowerDenied }
    public enum SpecificChargeTriggers { UnitChosen, TargetsChosen, ChargeRolls, RollOf, FailedCharge, Successful, ChargeMove }
    public enum SpecificFightsTriggers { UnitChosen, PileIn, Consolidate }

    public enum Targets { NotChosen, All, AllAllies, AllEnemies, TargetUnit, TargetAlly, TargetEnemy, NearestAlly, NearestEnemy, Unit, Model, Keyword }
    public enum KeywordTargets { All, AllAllies, AllEnemies, TargetUnit, TargetAlly, TargetEnemy, NearestAlly, NearestEnemy }

    public enum RuleTypes { NotChosen, Reserves, Invuln, IgnoreWounds, ChangeProfile, Roll, IgnorePenaly, AllowShooting, AllowCharge, AdditionalAttack, MortalWounds }

    public enum StatProfiles { M, WS, BS, S, T, W, A, Ld, Sv, Psychic, Cover, Range, AP, D }
    public enum Modifiers { Bonus, Penalty, Become }

    public enum Rolls { Advance, Psychic, Deny, Hit, Wound, Charge, Morale }
    public enum RollModifiers { ReRoll, Bonus, Penalty, RollAndDrop, AlwaysPass }

    public enum IgnoreProfiles { Psychic, Deny, Hit, Wound, Morale, M, WS, BS, S, T, W, A, Ld, Sv, Cover, Range, AP, D }

    public enum Dice { D3, D6, e2D6 }


    public string Name { get; set; }
    public List<Uses> UseTimes { get; set; }

    public ActivationTypes ActivationType { get; set; }

    public MoveTriggers MoveTrigger { get; set; }
    public PsychicTriggers PsychicTrigger { get; set; }
    public ShootingTriggers ShootingTrigger { get; set; }
    public ChargeTriggers ChargeTrigger { get; set; }
    public FightTriggers FightTrigger { get; set; }
    public MoraleTriggers MoraleTrigger { get; set; }

    public AttackTriggers AttackTrigger { get; set; }
    public WoundTriggers WoundTrigger { get; set; }
    public PowerTriggers PowerTrigger { get; set; }
    public DenyTriggers DenyTrigger { get; set; }
    public SpecificChargeTriggers SpecificChargeTrigger { get; set; }
    public SpecificFightsTriggers SpecificFightsTrigger { get; set; }
    public int RollTrigger { get; set; }

    public Targets Target { get; set; }
    public string Keyword { get; set; }
    public KeywordTargets KeywordTarget { get; set; }

    public RuleTypes RuleType { get; set; }

    public int Range { get; set; }
    public int Damage { get; set; }
    public Dice DamageDice { get; set; }
    public int Roll { get; set; }

    public bool ReserveOutsideEnemy { get; set; }
    public bool ReserveFromObject { get; set; }
    public bool RerollCharges { get; set; }
    public bool ReserveMortalWounds { get; set; }
    public int ReserveRange { get; set; }

    public StatProfiles StatProfile { get; set; }
    public Modifiers Modify { get; set; }
    public int ProfileChange { get; set; }
    public Dice ChangeDice { get; set; }

    public Rolls RollModified { get; set; }
    public RollModifiers RollModifiedBy { get; set; }
    public int RollModifierAmount { get; set; }

    public IgnoreProfiles IgnoreProfile { get; set; }

    public bool AdditionalAttackOnly { get; set; }
    public bool AdditionalAttacksCanExplode { get; set; }

    public bool SlayTheModel { get; set; }

    //public bool AffectUnit { get; set; }
    //public bool AffectFriendlyUnit { get; set; }
    //public bool AffectEnemyUnit { get; set; }
    //public bool AffectAllEligible { get; set; }
    //public List<string> OnlyUseableWithWeapons { get; set; }
    //public bool ChangeProfile { get; set; }
    //public List<string> ProfileToChange { get; set; }
    //public List<int> TriggeredByNaturalRoll { get; set; }
    //public int TriggerByRoll { get; set; }
    //public bool PassesRoll { get; set; }
    //public bool Reserves { get; set; }
    //public bool Invuln { get; set; }
    //public bool FeelNoPain { get; set; }
    //public bool DestroyUnit { get; set; }
    //public bool AllowShooting { get; set; }
    //public bool AllowCharge { get; set; }
    //public bool NegatePenalty { get; set; }
    //public bool AdditionalAttack { get; set; }
    //public bool CannotSelectWeapon { get; set; }
    //public bool MortalWounds { get; set; }

    public Rule() {

        //public List<Uses> UseTimes { get; set; }
        UseTimes = new List<Uses>();

        //public ActivationTypes ActivationType { get; set; }

        //public MoveTriggers MoveTrigger { get; set; }
        //public PsychicTriggers PsychicTrigger { get; set; }
        //public ShootingTriggers ShootingTrigger { get; set; }
        //public ChargeTriggers ChargeTrigger { get; set; }
        //public FightTriggers FightTrigger { get; set; }
        //public MoraleTriggers MoraleTrigger { get; set; }

        //public AttackTriggers AttackTrigger { get; set; }
        //public WoundTriggers WoundTrigger { get; set; }
        //public PowerTriggers PowerTrigger { get; set; }
        //public DenyTriggers DenyTrigger { get; set; }
        //public SpecificChargeTriggers SpecificChargeTrigger { get; set; }
        //public SpecificFightsTriggers SpecificFightsTrigger { get; set; }
        //public int RollTrigger { get; set; }

        //public Targets Target { get; set; }
        //public string Keyword { get; set; }
        //public KeywordTargets KeywordTarget { get; set; }

        //public RuleTypes RuleType { get; set; }

        //public int Range { get; set; }
        //public int Damage { get; set; }
        //public Dice DamageDice { get; set; }
        //public int Roll { get; set; }

        //public bool ReserveOutsideEnemy { get; set; }
        //public bool ReserveFromObject { get; set; }
        //public bool RerollCharges { get; set; }
        //public bool ReserveMortalWounds { get; set; }
        //public int ReserveRange { get; set; }

        //public Profiles Profile { get; set; }
        //public Modifiers Modify { get; set; }
        //public int ProfileChange { get; set; }
        //public Dice ChangeDice { get; set; }

        //public Rolls RollModified { get; set; }
        //public RollModifiers RollModifiedBy { get; set; }
        //public int RollModifierAmount { get; set; }

        //public IgnoreProfiles IgnoreProfile { get; set; }


        //Keywords = new List<string>();
        //Triggers = new List<Trigger>();
        //OnlyUseableWithWeapons = new List<string>();
        //ProfileToChange = new List<string>();
        //ProfileModifier = new List<Modifier>();
        //ProfileChange = new List<int>();
        //TriggeredByNaturalRoll = new List<int>();
    }
}
