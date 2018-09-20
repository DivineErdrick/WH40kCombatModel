using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class Rule {

    public enum Use { Deployment, GameStart, YourTurn, OpponentsTurn, StartOfTurn, Move, Psychic, Shoot, Charge, Fight, Morale, EndOfTurn }
    public enum UseType { Passive, User, Triggered }
    public enum Trigger {StartOfMove, Moves, Advances, EndOfMove,

                          StartOfPsychic, PyschicTest, PsychicTestFailed, DenyTheWitch, DenyRolls, PowerDenied, DenyFailed, PowerManifested, Perils, EndOfPsychic,

                          StartOfShoot, ShootTargets, ShootRollShots, ShootRollHit, ShootMisses, ShootHits, ShootWeaponHits,
                          ShootRollWound, ShootFailWound, ShootWounds, ShootTargetSaves, ShootTargetWounded, 
                          ShootTargetModelDies, ShootTargetUnitDies, EndOfShoot,

                          StartOfCharge, ChargeTargets, Overwatch,
                          OverwatchShots, OverwatchRollHit, OverwatchMisses, OverwatchHits, 
                          OverwatchRollWound, OverwatchFailWound, OverwatchWounds, OverwatchTargetSaves, 
                          OverwatchTargetWounded, OverwatchTargetModelDies, OverwatchTargetUnitDies,
                          RollCharge, FailedCharge, ChargeSuccessful, HeroicIntervention, EndOfCharge,

                          StartOfFight, InCombat, FirstUnitsFight, OtherUnitsFight, LastUnitsFight, ChooseToFight, FightTargets,
                          FightAttacks, FightRollHit, FightMisses, FightHits,
                          FightRollWound, FightFailWound, FightWounds, FightTargetSaves, FightTargetWounded,
                          FightTargetModelDies, FightTargetUnitDies, PileIn, Consolidate, EndOfFight,

                          StartOfMorale, MoraleRolled, MoralePassed, MoraleModelFlees, MoraleUnitDestroyed, EndOfMorale
    }

    public enum Modifier { Bonus, Penalty, Become }

    public string Name { get; set; }
    public List<string> Keywords { get; set; }
    public List<Use> UseTimes { get; set; }
    public UseType RuleUseType { get; set; }
    public List<Trigger> Triggers { get; set; }
    public bool AffectUnit { get; set; }
    public bool AffectFriendlyUnit { get; set; }
    public bool AffectEnemyUnit { get; set; }
    public bool AffectAllEligible { get; set; }
    public List<string> OnlyUseableWithWeapons { get; set; }
    public bool ChangeProfile { get; set; }
    public List<string> ProfileToChange { get; set; }
    public List<Modifier> ProfileModifier { get; set; }
    public List<int> ProfileChange { get; set; }
    public int Range { get; set; }
    public int Damage { get; set; }
    public List<int> TriggeredByNaturalRoll { get; set; }
    public int TriggerByRoll { get; set; }
    public int Roll { get; set; }
    public bool PassesRoll { get; set; }
    public bool Reserves { get; set; }
    public bool Invuln { get; set; }
    public bool FeelNoPain { get; set; }
    public bool DestroyUnit { get; set; }
    public bool AllowShooting { get; set; }
    public bool AllowCharge { get; set; }
    public bool NegatePenalty { get; set; }
    public bool AdditionalAttack { get; set; }
    public bool CannotSelectWeapon { get; set; }
    public bool MortalWounds { get; set; }

    public Rule () {

        Keywords = new List<string>();
        UseTimes = new List<Use>();
        Triggers = new List<Trigger>();
        OnlyUseableWithWeapons = new List<string>();
        ProfileToChange = new List<string>();
        ProfileModifier = new List<Modifier>();
        ProfileChange = new List<int>();
        TriggeredByNaturalRoll = new List<int>();
    }
}
