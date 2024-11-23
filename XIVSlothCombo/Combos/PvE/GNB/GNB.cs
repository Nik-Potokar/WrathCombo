using Dalamud.Game.ClientState.JobGauge.Types;
using Dalamud.Game.ClientState.Statuses;
using XIVSlothCombo.Combos.PvE.Content;
using XIVSlothCombo.Core;
using XIVSlothCombo.CustomComboNS;
using XIVSlothCombo.Data;

namespace XIVSlothCombo.Combos.PvE
{
    internal partial class GNB //Our Job Definitions
    {
        public const byte JobID = 37; //Our JobID

        public const uint //Our Actions (AIDs)
            //Offensive
            KeenEdge = 16137, //Lv1, instant, GCD, range 3, single-target, targets=hostile
            NoMercy = 16138, //Lv2, instant, 60.0s CD (group 10), range 0, single-target, targets=self
            BrutalShell = 16139, //Lv4, instant, GCD, range 3, single-target, targets=hostile
            DemonSlice = 16141, //Lv10, instant, GCD, range 0, AOE 5 circle, targets=self
            LightningShot = 16143, //Lv15, instant, GCD, range 20, single-target, targets=hostile
            DangerZone = 16144, //Lv18, instant, 30.0s CD (group 4), range 3, single-target, targets=hostile
            SolidBarrel = 16145, //Lv26, instant, GCD, range 3, single-target, targets=hostile
            BurstStrike = 16162, //Lv30, instant, GCD, range 3, single-target, targets=hostile
            DemonSlaughter = 16149, //Lv40, instant, GCD, range 0, AOE 5 circle, targets=self
            SonicBreak = 16153, //Lv54, instant, 60.0s CD (group 13/57), range 3, single-target, targets=hostile
            GnashingFang = 16146, //Lv60, instant, 30.0s CD (group 5/57), range 3, single-target, targets=hostile, animLock=0.700
            SavageClaw = 16147, //Lv60, instant, GCD, range 3, single-target, targets=hostile, animLock=0.500
            WickedTalon = 16150, //Lv60, instant, GCD, range 3, single-target, targets=hostile, animLock=0.770
            BowShock = 16159, //Lv62, instant, 60.0s CD (group 11), range 0, AOE 5 circle, targets=self
            AbdomenTear = 16157, //Lv70, instant, 1.0s CD (group 0), range 5, single-target, targets=hostile
            JugularRip = 16156, //Lv70, instant, 1.0s CD (group 0), range 5, single-target, targets=hostile
            EyeGouge = 16158, //Lv70, instant, 1.0s CD (group 0), range 5, single-target, targets=hostile
            Continuation = 16155, //Lv70, instant, 1.0s CD (group 0), range 0, single-target, targets=self, animLock=???
            FatedCircle = 16163, //Lv72, instant, GCD, range 0, AOE 5 circle, targets=self
            Bloodfest = 16164, //Lv76, instant, 120.0s CD (group 14), range 25, single-target, targets=hostile
            BlastingZone = 16165, //Lv80, instant, 30.0s CD (group 4), range 3, single-target, targets=hostile
            Hypervelocity = 25759, //Lv86, instant, 1.0s CD (group 0), range 5, single-target, targets=hostile
            DoubleDown = 25760, //Lv90, instant, 60.0s CD (group 12/57), range 0, AOE 5 circle, targets=self
            FatedBrand = 36936, //Lv96, instant, 1.0s CD, (group 0), range 5, AOE, targets=hostile
            ReignOfBeasts = 36937, //Lv100, instant, GCD, range 3, single-target, targets=hostile
            NobleBlood = 36938, //Lv100, instant, GCD, range 3, single-target, targets=hostile
            LionHeart = 36939, //Lv100, instant, GCD, range 3, single-target, targets=hostile

            //Utility
            Camouflage = 16140, //Lv6, instant, 90.0s CD (group 15), range 0, single-target, targets=self
            RoyalGuard = 16142, //Lv10, instant, 2.0s CD (group 1), range 0, single-target, targets=self
            ReleaseRoyalGuard = 32068, //Lv10, instant, 1.0s CD (group 1), range 0, single-target, targets=self
            Nebula = 16148, //Lv38, instant, 120.0s CD (group 21), range 0, single-target, targets=self
            Aurora = 16151, //Lv45, instant, 60.0s CD (group 19/71), range 30, single-target, targets=self/party/alliance/friendly
            Superbolide = 16152, //Lv50, instant, 360.0s CD (group 24), range 0, single-target, targets=self
            HeartOfLight = 16160, //Lv64, instant, 90.0s CD (group 16), range 0, AOE 30 circle, targets=self
            HeartOfStone = 16161, //Lv68, instant, 25.0s CD (group 3), range 30, single-target, targets=self/party
            Trajectory = 36934, //Lv56, instant, 30.0s CD (group 9/70) (2? charges), range 20, single-target, targets=hostile
            HeartOfCorundum = 25758, //Lv82, instant, 25.0s CD (group 3), range 30, single-target, targets=self/party
            GreatNebula = 36935, //Lv92, instant, 120.0s CD, range 0, single-target, targeets=self

            //Limit Break
            GunmetalSoul = 17105; //LB3, instant, range 0, AOE 50 circle, targets=self, animLock=3.860

        public static class Buffs //Our Buffs (SIDs)
        {
            public const ushort
                    BrutalShell = 1898, //applied by Brutal Shell to self
                    NoMercy = 1831, //applied by No Mercy to self
                    ReadyToRip = 1842, //applied by Gnashing Fang to self
                    SonicBreak = 1837, //applied by Sonic Break to target
                    BowShock = 1838, //applied by Bow Shock to target
                    ReadyToTear = 1843, //applied by Savage Claw to self
                    ReadyToGouge = 1844, //applied by Wicked Talon to self
                    ReadyToBlast = 2686, //applied by Burst Strike to self
                    Nebula = 1834, //applied by Nebula to self
                    Rampart = 1191, //applied by Rampart to self
                    Camouflage = 1832, //applied by Camouflage to self
                    ArmsLength = 1209, //applied by Arm's Length to self
                    HeartOfLight = 1839, //applied by Heart of Light to self
                    Aurora = 1835, //applied by Aurora to self
                    Superbolide = 1836, //applied by Superbolide to self
                    HeartOfCorundum = 2683, //applied by Heart of Corundum to self
                    ClarityOfCorundum = 2684, //applied by Heart of Corundum to self
                    CatharsisOfCorundum = 2685, //applied by Heart of Corundum to self
                    RoyalGuard = 1833, //applied by Royal Guard to self
                    GreatNebula = 3838, //applied by Nebula to self
                    ReadyToRaze = 3839, //applied by Fated Circle to self
                    ReadyToBreak = 3886, //applied by No mercy to self
                    ReadyToReign = 3840; //applied by Bloodfest to target
        }

        public static class Debuffs //Our Debuffs (target SIDs)
        {
            public const ushort
                BowShock = 1838, //applied by Bow Shock to target
                SonicBreak = 1837; //applied by Sonic Break to target
        }

        public static int MaxCartridges(byte level) => level >= 88 ? 3 : 2; //Level Check for Maximum Ammo

        //Simple Mode - Single Target
        internal class GNB_ST_SimpleMode : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_ST_Simple;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is KeenEdge)
                {
                    #region Variables
                    //Gauge
                    var Ammo = GetJobGauge<GNBGauge>().Ammo; //Our cartridge count
                    var GunStep = GetJobGauge<GNBGauge>().AmmoComboStep; //For Gnashing Fang & Reign combo purposes
                    //Cooldown-related
                    var gfCD = GetCooldownRemainingTime(GnashingFang); //GnashingFang's cooldown; 30s total
                    var nmCD = GetCooldownRemainingTime(NoMercy); //NoMercy's cooldown; 60s total
                    var ddCD = GetCooldownRemainingTime(DoubleDown); //Double Down's cooldown; 60s total
                    var bfCD = GetCooldownRemainingTime(Bloodfest); //Bloodfest's cooldown; 120s total
                    var nmLeft = GetBuffRemainingTime(Buffs.NoMercy); //Remaining time for No Mercy buff (20s)
                    var hasNM = nmCD is >= 40 and <= 60; //Checks if No Mercy is active
                    var hasBreak = HasEffect(Buffs.ReadyToBreak); //Checks for Ready To Break buff
                    var hasReign = HasEffect(Buffs.ReadyToReign); //Checks for Ready To Reign buff
                    //Mitigations
                    var hpRemainingNebula = Config.GNB_ST_GreatNebulaThreshold;
                    var hpRemainingBolide = Config.GNB_ST_SuperbolideSelfThreshold;
                    var hpRemainingBolideTarget =
                        Config.GNB_ST_SuperbolideTargetThreshold;
                    var bossRestrictionBolide =
                        (int)Config.GNB_ST_SuperbolideBossRestriction;
                    //Misc
                    var inOdd = bfCD is < 90 and > 20; //Odd Minute
                    var canLateWeave = GetCooldownRemainingTime(actionID) < 1 && GetCooldownRemainingTime(actionID) > 0.6; //SkS purposes
                    var GCD = GetCooldown(KeenEdge).CooldownTotal; //2.5 is base SkS, but can work with 2.4x
                    var nmStop = PluginConfiguration.GetCustomIntValue(Config.GNB_ST_NoMercyStop);
                    #region Minimal Requirements
                    //Ammo-relative
                    var canBS = LevelChecked(BurstStrike) && //Burst Strike is unlocked
                                Ammo > 0; //Has Ammo
                    var canGF = LevelChecked(GnashingFang) && //GnashingFang is unlocked
                                GetCooldownRemainingTime(GnashingFang) < 0.6f && //Gnashing Fang is off cooldown
                                !HasEffect(Buffs.ReadyToBlast) && //to ensure Hypervelocity is spent in case Burst Strike is used before Gnashing Fang
                                GunStep == 0 && //Gnashing Fang or Reign combo is not already active
                                Ammo > 0; //Has Ammo
                    var canFC = LevelChecked(FatedCircle) && //Fated Circle is unlocked
                                Ammo > 0; //Has Ammo
                    var canDD = LevelChecked(DoubleDown) && //Double Down is unlocked
                                GetCooldownRemainingTime(DoubleDown) < 0.6f && //Double Down is off cooldown
                                Ammo > 0; //Has Ammo
                    var canBF = LevelChecked(Bloodfest) && //Bloodfest is unlocked
                                GetCooldownRemainingTime(Bloodfest) < 0.6f; //Bloodfest is off cooldown
                    //Cooldown-relative
                    var canZone = LevelChecked(DangerZone) && //Zone is unlocked
                                GetCooldownRemainingTime(OriginalHook(DangerZone)) < 0.6f; //DangerZone is off cooldown
                    var canBreak = LevelChecked(SonicBreak) && //Sonic Break is unlocked
                                hasBreak; //No Mercy or Ready To Break is active
                    var canBow = LevelChecked(BowShock) && //Bow Shock is unlocked
                                GetCooldownRemainingTime(BowShock) < 0.6f; //BowShock is off cooldown
                    var canContinue = LevelChecked(Continuation); //Continuation is unlocked
                    var canReign = LevelChecked(ReignOfBeasts) && //Reign of Beasts is unlocked
                                GunStep == 0 && //Gnashing Fang or Reign combo is not already active
                                HasEffect(Buffs.ReadyToReign); //Ready To Reign is active
                    #endregion
                    #endregion

                    //Variant Cure
                    if (IsEnabled(CustomComboPreset.GNB_Variant_Cure) && IsEnabled(Variant.VariantCure)
                        && PlayerHealthPercentageHp() <= GetOptionValue(Config.GNB_VariantCure))
                        return Variant.VariantCure;

                    //Ranged Uptime
                    if (LevelChecked(LightningShot) && //Lightning Shot is unlocked
                        !InMeleeRange() && //Out of melee range
                        HasBattleTarget()) //Has target
                        return LightningShot; //Execute Lightning Shot if conditions are met

                    //Mitigations - Max Priority
                    if (IsEnabled(CustomComboPreset.GNB_ST_Mitigation))
                    {
                        //HOC
                        if (IsEnabled(CustomComboPreset.GNB_ST_HOC)
                            && IsOffCooldown(OriginalHook(HeartOfStone))
                            && LevelChecked(HeartOfStone)
                            && ShouldHOCSelf()
                            && LocalPlayer.CurrentMp >= 3000)
                            return OriginalHook(HeartOfStone);

                        //GreatNebula
                        var inGreatNebulaContent =
                            ContentCheck.IsInConfiguredContent(
                                Config.GNB_ST_GreatNebulaDifficulty,
                                Config.GNB_ST_GreatNebulaDifficultyListSet
                            );
                        if (IsEnabled(CustomComboPreset.GNB_ST_GreatNebula)
                            && IsOffCooldown(OriginalHook(Nebula))
                            && LevelChecked(Nebula)
                            && PlayerHealthPercentageHp() <= hpRemainingNebula
                            && inGreatNebulaContent)
                            return OriginalHook(Nebula);

                        //Living Dead
                        var inSuperbolideContent =
                            ContentCheck.IsInConfiguredContent(
                                Config.GNB_ST_SuperbolideDifficulty,
                                Config.GNB_ST_SuperbolideDifficultyListSet
                            );
                        if (IsEnabled(CustomComboPreset.GNB_ST_Superbolide)
                            && IsOffCooldown(Superbolide)
                            && LevelChecked(Superbolide)
                            && PlayerHealthPercentageHp() <= hpRemainingBolide
                            && GetTargetHPPercent() >= hpRemainingBolideTarget
                            && inSuperbolideContent
                            //Checking if the target matches the boss avoidance option
                            && ((bossRestrictionBolide is
                                     (int)Config.BossAvoidance.On
                                 && LocalPlayer.TargetObject is not null
                                 && IsBoss(GNB.LocalPlayer.TargetObject!))
                                || bossRestrictionBolide is
                                    (int)Config.BossAvoidance.Off))
                            return Superbolide;
                    }

                    //No Mercy
                    if (ActionReady(NoMercy) && //No Mercy is ready
                        CanWeave(actionID) && //Weaveable window
                        GetTargetHPPercent() >= nmStop) //target HP is above threshold
                    {
                        if (LevelChecked(DoubleDown)) //Lv100
                        {
                            if ((inOdd && //Odd Minute window
                                (Ammo >= 2 || (lastComboMove is BrutalShell && Ammo == 1))) || //2 Ammo or 1 Ammo with Solid Barrel next in combo
                                (!inOdd && //Even Minute window
                                Ammo != 3)) //Ammo is not full (3)
                                return NoMercy; //Execute No Mercy if conditions are met
                        }
                        if (!LevelChecked(DoubleDown)) //Lv1-89
                        {
                            if (canLateWeave && //Late-weaveable
                                Ammo == MaxCartridges(level)) //Ammo is full
                                return NoMercy; //Execute No Mercy if conditions are met
                        }
                    }

                    //Bloodfest - Forced to prevent combo from spazzing out due to next action possibly requiring Ammo
                    if (canBF && //able to use Bloodfest
                        Ammo == 0) //Only when ammo is empty
                        return Bloodfest; //Execute Bloodfest if conditions are met

                    //oGCDs
                    if (CanWeave(actionID))
                    {
                        //Variant SpiritDart
                        Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
                        if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) &&
                            IsEnabled(Variant.VariantSpiritDart) &&
                            (sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
                            return Variant.VariantSpiritDart;

                        //Variant Ultimatum
                        if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && ActionReady(Variant.VariantUltimatum))
                            return Variant.VariantUltimatum;

                        //Zone
                        if (canZone && //able to use Zone
                            (nmCD is < 57.5f and > 17f) && //Optimal use; twice per minute, 1 in NM, 1 out of NM
                            !JustUsed(NoMercy)) //No Mercy was not just used within 3 seconds
                            return OriginalHook(DangerZone); //Execute Zone if conditions are met

                        //Bow Shock
                        if (canBow && //able to use Bow Shock
                            (nmCD is < 57.5f and > 17f) && //Optimal use; twice per minute, 1 in NM, 1 out of NM
                            !JustUsed(NoMercy)) //No Mercy was not just used within 3 seconds)
                            return BowShock;
                    }

                    //Hypervelocity - Forced to prevent loss
                    if (JustUsed(BurstStrike, 5f) && //Burst Strike was just used within 5 seconds
                        LevelChecked(Hypervelocity) && //Hypervelocity is unlocked
                        HasEffect(Buffs.ReadyToBlast) && //Ready To Blast buff is active
                        nmCD > 1) //Priority hack to prevent Hypervelocity from being used before No Mercy
                        return Hypervelocity; //Execute Hypervelocity if conditions are met

                    //Continuation protection - Forced to prevent loss
                    if (canContinue && //able to use Continuation
                        (HasEffect(Buffs.ReadyToRip) || //after Gnashing Fang
                        HasEffect(Buffs.ReadyToTear) || //after Savage Claw
                        HasEffect(Buffs.ReadyToGouge) || //after Wicked Talon
                        HasEffect(Buffs.ReadyToBlast) || //after Burst Strike
                        HasEffect(Buffs.ReadyToRaze))) //after Fated Circle
                        return OriginalHook(Continuation); //Execute appopriate Continuation action if conditions are met

                    //TODO: code below is rather ass; refactor
                    //Lv100 - every 3rd NM window
                    if (LevelChecked(ReignOfBeasts) &&
                        HasEffect(Buffs.NoMercy) &&
                        GunStep == 0 &&
                        LevelChecked(BurstStrike) &&
                        lastComboMove is BrutalShell &&
                        Ammo == 1)
                        return SolidBarrel;
                    //Lv90 - every 3rd NM window
                    if (!LevelChecked(ReignOfBeasts) &&
                        HasEffect(Buffs.NoMercy) &&
                        GunStep == 0 &&
                        LevelChecked(BurstStrike) &&
                        (lastComboMove is BrutalShell || JustUsed(BurstStrike)) &&
                        Ammo == 1)
                        return SolidBarrel;

                    //GnashingFang
                    if (canGF && //able to use Gnashing Fang
                        ((nmCD is > 17 and < 35) || //30s Optimal use
                        (JustUsed(NoMercy, 6f)))) //No Mercy was just used within 4 seconds
                        return GnashingFang;

                    //Double Down
                    if (canDD && //able to use Double Down
                        IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                        hasNM) //No Mercy is active
                        return DoubleDown;

                    //Sonic Break
                    if (canBreak && //able to use Sonic Break
                        ((IsOnCooldown(GnashingFang) && IsOnCooldown(DoubleDown)) || //Gnashing Fang and Double Down are both on cooldown
                        nmLeft <= GCD)) //No Mercy buff is about to expire
                        return SonicBreak; //Execute Sonic Break if conditions are met

                    //Reign of Beasts
                    if (canReign && //able to use Reign of Beasts
                        IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                        IsOnCooldown(DoubleDown) && //Double Down is on cooldown
                        !HasEffect(Buffs.ReadyToBreak) && //Ready To Break is not active
                        GunStep == 0) //Gnashing Fang or Reign combo is not active or finished
                        return OriginalHook(ReignOfBeasts); //Execute Reign of Beasts if conditions are met

                    //Burst Strike
                    if (canBS && //able to use Burst Strike
                        HasEffect(Buffs.NoMercy) && //No Mercy is active
                        IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                        IsOnCooldown(DoubleDown) && //Double Down is on cooldown
                        !HasEffect(Buffs.ReadyToBreak) && //Ready To Break is not active
                        !HasEffect(Buffs.ReadyToReign) && //Ready To Reign is not active
                        GunStep == 0) //Gnashing Fang or Reign combo is not active or finished
                        return BurstStrike; //Execute Burst Strike if conditions are met

                    //Lv100 2cart forced 2min starter
                    if (LevelChecked(ReignOfBeasts) && //Lv100
                        ((nmCD <= GCD || ActionReady(NoMercy)) && //No Mercy is ready or about to be
                        Ammo is 3 && //Ammo is full
                        (bfCD < GCD * 12 || ActionReady(Bloodfest)))) //Bloodfest is ready or about to be
                        return BurstStrike;

                    //Gauge Combo Steps
                    if (GunStep is 1 or 2) //Gnashing Fang combo is only for 1 and 2
                        return OriginalHook(GnashingFang); //Execute Gnashing Fang combo if conditions are met
                    if (GunStep is 3 or 4) //Reign of Beasts combo is only for 3 and 4
                        return OriginalHook(ReignOfBeasts); //Execute Reign of Beasts combo if conditions are met

                    //123 (overcap included)
                    if (comboTime > 0) //we're in combo
                    {
                        if (LevelChecked(BrutalShell) && //Brutal Shell is unlocked
                            lastComboMove == KeenEdge) //just used first action in combo
                            return BrutalShell; //Execute Brutal Shell if conditions are met

                        if (LevelChecked(SolidBarrel) && //Solid Barrel is unlocked
                            lastComboMove == BrutalShell) //just used second action in combo
                        {
                            //holds Hypervelocity if NM comes up in time
                            if (LevelChecked(Hypervelocity) && //Hypervelocity is unlocked
                                HasEffect(Buffs.ReadyToBlast) && //Ready To Blast buff is active
                                (nmCD is > 1 or <= 0.1f || //Priority hack to prevent Hypervelocity from being used before No Mercy
                                GetTargetHPPercent() < nmStop)) //target HP is below threshold
                                return Hypervelocity; //Execute Hypervelocity if conditions are met

                            //Overcap protection
                            if (LevelChecked(BurstStrike) && //Burst Strike is unlocked
                                Ammo == MaxCartridges(level)) //Ammo is full relaive to level
                                return BurstStrike; //Execute Burst Strike if conditions are met

                            return SolidBarrel; //Execute Solid Barrel if conditions are met
                        }
                    }

                    return KeenEdge;
                }

                return actionID;
            }
        } 

        //Advanced Mode - Single Target
        internal class GNB_ST_AdvancedMode : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_ST_Advanced;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is KeenEdge)
                {
                    #region Variables
                    //Gauge
                    var Ammo = GetJobGauge<GNBGauge>().Ammo; //Our cartridge count
                    var GunStep = GetJobGauge<GNBGauge>().AmmoComboStep; //For Gnashing Fang & Reign combo purposes
                    //Cooldown-related
                    var gfCD = GetCooldownRemainingTime(GnashingFang); //GnashingFang's cooldown; 30s total
                    var nmCD = GetCooldownRemainingTime(NoMercy); //NoMercy's cooldown; 60s total
                    var ddCD = GetCooldownRemainingTime(DoubleDown); //Double Down's cooldown; 60s total
                    var bfCD = GetCooldownRemainingTime(Bloodfest); //Bloodfest's cooldown; 120s total
                    var nmLeft = GetBuffRemainingTime(Buffs.NoMercy); //Remaining time for No Mercy buff (20s)
                    var hasNM = nmCD is >= 40 and <= 60; //Checks if No Mercy is active
                    var hasBreak = HasEffect(Buffs.ReadyToBreak); //Checks for Ready To Break buff
                    var hasReign = HasEffect(Buffs.ReadyToReign); //Checks for Ready To Reign buff

                    //Misc
                    var inOdd = bfCD is < 90 and > 20; //Odd Minute
                    var canLateWeave = GetCooldownRemainingTime(actionID) < 1 && GetCooldownRemainingTime(actionID) > 0.6; //SkS purposes
                    var GCD = GetCooldown(KeenEdge).CooldownTotal; //2.5 is base SkS, but can work with 2.4x
                    var nmStop = PluginConfiguration.GetCustomIntValue(Config.GNB_ST_NoMercyStop);
                    #region Minimal Requirements
                    //Ammo-relative
                    var canBS = LevelChecked(BurstStrike) && //Burst Strike is unlocked
                                Ammo > 0; //Has Ammo
                    var canGF = LevelChecked(GnashingFang) && //GnashingFang is unlocked
                                GetCooldownRemainingTime(GnashingFang) < 0.6f && //Gnashing Fang is off cooldown
                                !HasEffect(Buffs.ReadyToBlast) && //to ensure Hypervelocity is spent in case Burst Strike is used before Gnashing Fang
                                GunStep == 0 && //Gnashing Fang or Reign combo is not already active
                                Ammo > 0; //Has Ammo
                    var canFC = LevelChecked(FatedCircle) && //Fated Circle is unlocked
                                Ammo > 0; //Has Ammo
                    var canDD = LevelChecked(DoubleDown) && //Double Down is unlocked
                                GetCooldownRemainingTime(DoubleDown) < 0.6f && //Double Down is off cooldown
                                Ammo > 0; //Has Ammo
                    var canBF = LevelChecked(Bloodfest) && //Bloodfest is unlocked
                                GetCooldownRemainingTime(Bloodfest) < 0.6f; //Bloodfest is off cooldown
                    //Cooldown-relative
                    var canZone = LevelChecked(DangerZone) && //Zone is unlocked
                                GetCooldownRemainingTime(OriginalHook(DangerZone)) < 0.6f; //DangerZone is off cooldown
                    var canBreak = LevelChecked(SonicBreak) && //Sonic Break is unlocked
                                hasBreak; //No Mercy or Ready To Break is active
                    var canBow = LevelChecked(BowShock) && //Bow Shock is unlocked
                                GetCooldownRemainingTime(BowShock) < 0.6f; //BowShock is off cooldown
                    var canContinue = LevelChecked(Continuation); //Continuation is unlocked
                    var canReign = LevelChecked(ReignOfBeasts) && //Reign of Beasts is unlocked
                                GunStep == 0 && //Gnashing Fang or Reign combo is not already active
                                HasEffect(Buffs.ReadyToReign); //Ready To Reign is active
                    #endregion
                    #endregion

                    //Variant Cure
                    if (IsEnabled(CustomComboPreset.GNB_Variant_Cure) && IsEnabled(Variant.VariantCure)
                        && PlayerHealthPercentageHp() <= GetOptionValue(Config.GNB_VariantCure))
                        return Variant.VariantCure;

                    //Ranged Uptime
                    if (IsEnabled(CustomComboPreset.GNB_ST_RangedUptime) && //Ranged Uptime option is enabled
                        LevelChecked(LightningShot) && //Lightning Shot is unlocked
                        !InMeleeRange() && //Out of melee range
                        HasBattleTarget()) //Has target
                        return LightningShot; //Execute Lightning Shot if conditions are met

                    //No Mercy
                    if (IsEnabled(CustomComboPreset.GNB_ST_Advanced_CooldownsGroup) && //Cooldowns option is enabled
                        IsEnabled(CustomComboPreset.GNB_ST_NoMercy) && //No Mercy option  is enabled
                        ActionReady(NoMercy) && //No Mercy is ready
                        CanWeave(actionID) && //Weaveable window
                        GetTargetHPPercent() >= nmStop) //target HP is above threshold
                    {
                        if (LevelChecked(DoubleDown)) //Lv100
                        {
                            if ((inOdd && //Odd Minute window
                                (Ammo >= 2 || (lastComboMove is BrutalShell && Ammo == 1))) || //2 Ammo or 1 Ammo with Solid Barrel next in combo
                                (!inOdd && //Even Minute window
                                Ammo != 3)) //Ammo is not full (3)
                                return NoMercy; //Execute No Mercy if conditions are met
                        }
                        if (!LevelChecked(DoubleDown)) //Lv1-89
                        {
                            if (canLateWeave && //Late-weaveable
                                Ammo == MaxCartridges(level)) //Ammo is full
                                return NoMercy; //Execute No Mercy if conditions are met
                        }
                    }

                    //Bloodfest - Forced to prevent combo from spazzing out due to next action possibly requiring Ammo
                    if (IsEnabled(CustomComboPreset.GNB_ST_Bloodfest) && //Bloodfest option is enabled
                        canBF && //able to use Bloodfest
                        Ammo == 0) //Only when ammo is empty
                        return Bloodfest; //Execute Bloodfest if conditions are met

                    //oGCDs
                    if (CanWeave(actionID))
                    {
                        //Variant SpiritDart
                        Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
                        if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) &&
                            IsEnabled(Variant.VariantSpiritDart) &&
                            (sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
                            return Variant.VariantSpiritDart;

                        //Variant Ultimatum
                        if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && ActionReady(Variant.VariantUltimatum))
                            return Variant.VariantUltimatum;

                        //Cooldowns
                        if (IsEnabled(CustomComboPreset.GNB_ST_Advanced_CooldownsGroup)) //Cooldowns option is enabled
                        {
                            //Zone
                            if (IsEnabled(CustomComboPreset.GNB_ST_BlastingZone) && //Zone option is enabled
                                canZone && //able to use Zone
                                (nmCD is < 57.5f and > 17f) && //Optimal use; twice per minute, 1 in NM, 1 out of NM
                                !JustUsed(NoMercy)) //No Mercy was not just used within 3 seconds
                                return OriginalHook(DangerZone); //Execute Zone if conditions are met

                            //Bow Shock
                            if (IsEnabled(CustomComboPreset.GNB_ST_BowShock) && //Bow Shock option is enabled
                                canBow && //able to use Bow Shock
                                (nmCD is < 57.5f and > 17f) && //Optimal use; twice per minute, 1 in NM, 1 out of NM
                                !JustUsed(NoMercy)) //No Mercy was not just used within 3 seconds)
                                return BowShock;
                        }
                    }

                    //Hypervelocity - Forced to prevent loss
                    if (IsEnabled(CustomComboPreset.GNB_ST_Continuation) && //Continuation option is enabled
                        JustUsed(BurstStrike, 5f) && //Burst Strike was just used within 5 seconds
                        LevelChecked(Hypervelocity) && //Hypervelocity is unlocked
                        HasEffect(Buffs.ReadyToBlast) && //Ready To Blast buff is active
                        nmCD > 1) //Priority hack to prevent Hypervelocity from being used before No Mercy
                        return Hypervelocity; //Execute Hypervelocity if conditions are met

                    //Continuation protection - Forced to prevent loss
                    if (IsEnabled(CustomComboPreset.GNB_ST_Continuation) && //Continuation option is enabled
                        canContinue && //able to use Continuation
                        (HasEffect(Buffs.ReadyToRip) || //after Gnashing Fang
                        HasEffect(Buffs.ReadyToTear) || //after Savage Claw
                        HasEffect(Buffs.ReadyToGouge) || //after Wicked Talon
                        HasEffect(Buffs.ReadyToBlast) || //after Burst Strike
                        HasEffect(Buffs.ReadyToRaze))) //after Fated Circle
                        return OriginalHook(Continuation); //Execute appopriate Continuation action if conditions are met

                    //TODO: code below is rather ass; refactor
                    //Lv100 - every 3rd NM window
                    if (LevelChecked(ReignOfBeasts) && 
                        HasEffect(Buffs.NoMercy) && 
                        GunStep == 0 && 
                        LevelChecked(BurstStrike) && 
                        lastComboMove is BrutalShell && 
                        Ammo == 1)
                        return SolidBarrel;
                    //Lv90 - every 3rd NM window
                    if (!LevelChecked(ReignOfBeasts) &&
                        HasEffect(Buffs.NoMercy) &&
                        GunStep == 0 &&
                        LevelChecked(BurstStrike) &&
                        (lastComboMove is BrutalShell || JustUsed(BurstStrike)) && 
                        Ammo == 1)
                        return SolidBarrel;

                    //GCDs
                    if (IsEnabled(CustomComboPreset.GNB_ST_Advanced_CooldownsGroup)) //Cooldowns option is enabled
                    {
                        //GnashingFang
                        if (IsEnabled(CustomComboPreset.GNB_ST_Gnashing) && //Gnashing Fang option is enabled
                            canGF && //able to use Gnashing Fang
                            ((nmCD is > 17 and < 35) || //30s Optimal use
                            (JustUsed(NoMercy, 6f)))) //No Mercy was just used within 4 seconds
                            return GnashingFang;

                        //Double Down
                        if (IsEnabled(CustomComboPreset.GNB_ST_DoubleDown) && //Double Down option is enabled
                            canDD && //able to use Double Down
                            IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                            hasNM) //No Mercy is active
                            return DoubleDown;

                        //Sonic Break
                        if (IsEnabled(CustomComboPreset.GNB_ST_SonicBreak) && //Sonic Break option is enabled
                            canBreak && //able to use Sonic Break
                            ((IsOnCooldown(GnashingFang) && IsOnCooldown(DoubleDown)) || //Gnashing Fang and Double Down are both on cooldown
                            nmLeft <= GCD)) //No Mercy buff is about to expire
                            return SonicBreak; //Execute Sonic Break if conditions are met

                        //Reign of Beasts
                        if (IsEnabled(CustomComboPreset.GNB_ST_Reign) && //Reign of Beasts option is enabled
                            canReign && //able to use Reign of Beasts
                            IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                            IsOnCooldown(DoubleDown) && //Double Down is on cooldown
                            !HasEffect(Buffs.ReadyToBreak) && //Ready To Break is not active
                            GunStep == 0) //Gnashing Fang or Reign combo is not active or finished
                            return OriginalHook(ReignOfBeasts); //Execute Reign of Beasts if conditions are met

                        //Burst Strike
                        if (IsEnabled(CustomComboPreset.GNB_ST_BurstStrike) && //Burst Strike option is enabled
                            canBS && //able to use Burst Strike
                            HasEffect(Buffs.NoMercy) && //No Mercy is active
                            IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                            IsOnCooldown(DoubleDown) && //Double Down is on cooldown
                            !HasEffect(Buffs.ReadyToBreak) && //Ready To Break is not active
                            !HasEffect(Buffs.ReadyToReign) && //Ready To Reign is not active
                            GunStep == 0) //Gnashing Fang or Reign combo is not active or finished
                            return BurstStrike; //Execute Burst Strike if conditions are met
                    }

                    //Lv100 2cart forced 2min starter
                    if (IsEnabled(CustomComboPreset.GNB_ST_Advanced_CooldownsGroup) && //Cooldowns option is enabled
                        IsEnabled(CustomComboPreset.GNB_ST_BurstStrike) && //Burst Strike option is enabled
                        GetTargetHPPercent() > nmStop && //target HP is above threshold
                        LevelChecked(ReignOfBeasts) && //Lv100
                        ((nmCD <= GCD || ActionReady(NoMercy)) && //No Mercy is ready or about to be
                        Ammo is 3 && //Ammo is full
                        (bfCD < GCD * 12 || ActionReady(Bloodfest)))) //Bloodfest is ready or about to be
                        return BurstStrike;

                    //Gauge Combo Steps
                    if (IsEnabled(CustomComboPreset.GNB_ST_Gnashing) && //Gnashing Fang option is enabled
                        GunStep is 1 or 2) //Gnashing Fang combo is only for 1 and 2
                        return OriginalHook(GnashingFang); //Execute Gnashing Fang combo if conditions are met
                    if (GunStep is 3 or 4) //Reign of Beasts combo is only for 3 and 4
                        return OriginalHook(ReignOfBeasts); //Execute Reign of Beasts combo if conditions are met

                    //123 (overcap included)
                    if (comboTime > 0) //we're in combo
                    {
                        if (LevelChecked(BrutalShell) && //Brutal Shell is unlocked
                            lastComboMove == KeenEdge) //just used first action in combo
                            return BrutalShell; //Execute Brutal Shell if conditions are met

                        if (LevelChecked(SolidBarrel) && //Solid Barrel is unlocked
                            lastComboMove == BrutalShell) //just used second action in combo
                        {
                            //holds Hypervelocity if NM comes up in time
                            if (IsEnabled(CustomComboPreset.GNB_ST_Continuation) && //Continuation option is enabled
                                LevelChecked(Hypervelocity) && //Hypervelocity is unlocked
                                HasEffect(Buffs.ReadyToBlast) && //Ready To Blast buff is active
                                (nmCD is > 1 or <= 0.1f || //Priority hack to prevent Hypervelocity from being used before No Mercy
                                GetTargetHPPercent() < nmStop)) //target HP is below threshold
                                return Hypervelocity; //Execute Hypervelocity if conditions are met

                            //Overcap protection
                            if (IsEnabled(CustomComboPreset.GNB_ST_Overcap) && //Overcap option is enabled
                                LevelChecked(BurstStrike) && //Burst Strike is unlocked
                                Ammo == MaxCartridges(level)) //Ammo is full relaive to level
                                return BurstStrike; //Execute Burst Strike if conditions are met

                            return SolidBarrel; //Execute Solid Barrel if conditions are met
                        }
                    }

                    return KeenEdge;
                }

                return actionID;
            }
        }

        //Gnashing Fang Features
        internal class GNB_GF_Features : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_GF_Features;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is KeenEdge)
                {
                    #region Variables
                    //Gauge
                    var Ammo = GetJobGauge<GNBGauge>().Ammo; //Our cartridge count
                    var GunStep = GetJobGauge<GNBGauge>().AmmoComboStep; //For Gnashing Fang & Reign combo purposes
                    //Cooldown-related
                    var gfCD = GetCooldownRemainingTime(GnashingFang); //GnashingFang's cooldown; 30s total
                    var nmCD = GetCooldownRemainingTime(NoMercy); //NoMercy's cooldown; 60s total
                    var ddCD = GetCooldownRemainingTime(DoubleDown); //Double Down's cooldown; 60s total
                    var bfCD = GetCooldownRemainingTime(Bloodfest); //Bloodfest's cooldown; 120s total
                    var nmLeft = GetBuffRemainingTime(Buffs.NoMercy); //Remaining time for No Mercy buff (20s)
                    var hasNM = nmCD is >= 40 and <= 60; //Checks if No Mercy is active
                    var hasBreak = HasEffect(Buffs.ReadyToBreak); //Checks for Ready To Break buff
                    var hasReign = HasEffect(Buffs.ReadyToReign); //Checks for Ready To Reign buff

                    //Misc
                    var inOdd = bfCD is < 90 and > 20; //Odd Minute
                    var canLateWeave = GetCooldownRemainingTime(actionID) < 1 && GetCooldownRemainingTime(actionID) > 0.6; //SkS purposes
                    var GCD = GetCooldown(KeenEdge).CooldownTotal; //2.5 is base SkS, but can work with 2.4x
                    var nmStop = PluginConfiguration.GetCustomIntValue(Config.GNB_ST_NoMercyStop);
                    #region Minimal Requirements
                    //Ammo-relative
                    var canBS = LevelChecked(BurstStrike) && //Burst Strike is unlocked
                                Ammo > 0; //Has Ammo
                    var canGF = LevelChecked(GnashingFang) && //GnashingFang is unlocked
                                GetCooldownRemainingTime(GnashingFang) < 0.6f && //Gnashing Fang is off cooldown
                                !HasEffect(Buffs.ReadyToBlast) && //to ensure Hypervelocity is spent in case Burst Strike is used before Gnashing Fang
                                GunStep == 0 && //Gnashing Fang or Reign combo is not already active
                                Ammo > 0; //Has Ammo
                    var canFC = LevelChecked(FatedCircle) && //Fated Circle is unlocked
                                Ammo > 0; //Has Ammo
                    var canDD = LevelChecked(DoubleDown) && //Double Down is unlocked
                                GetCooldownRemainingTime(DoubleDown) < 0.6f && //Double Down is off cooldown
                                Ammo > 0; //Has Ammo
                    var canBF = LevelChecked(Bloodfest) && //Bloodfest is unlocked
                                GetCooldownRemainingTime(Bloodfest) < 0.6f; //Bloodfest is off cooldown
                    //Cooldown-relative
                    var canZone = LevelChecked(DangerZone) && //Zone is unlocked
                                GetCooldownRemainingTime(OriginalHook(DangerZone)) < 0.6f; //DangerZone is off cooldown
                    var canBreak = LevelChecked(SonicBreak) && //Sonic Break is unlocked
                                hasBreak; //No Mercy or Ready To Break is active
                    var canBow = LevelChecked(BowShock) && //Bow Shock is unlocked
                                GetCooldownRemainingTime(BowShock) < 0.6f; //BowShock is off cooldown
                    var canContinue = LevelChecked(Continuation); //Continuation is unlocked
                    var canReign = LevelChecked(ReignOfBeasts) && //Reign of Beasts is unlocked
                                GunStep == 0 && //Gnashing Fang or Reign combo is not already active
                                HasEffect(Buffs.ReadyToReign); //Ready To Reign is active
                    #endregion
                    #endregion

                    //No Mercy
                    if (IsEnabled(CustomComboPreset.GNB_GF_Features) && //Cooldowns option is enabled
                        IsEnabled(CustomComboPreset.GNB_GF_NoMercy) && //No Mercy option  is enabled
                        ActionReady(NoMercy) && //No Mercy is ready
                        CanWeave(actionID)) //Weaveable window
                    {
                        if (LevelChecked(DoubleDown)) //Lv100
                        {
                            if ((inOdd && //Odd Minute window
                                (Ammo >= 2 || (lastComboMove is BrutalShell && Ammo == 1))) || //2 Ammo or 1 Ammo with Solid Barrel next in combo
                                (!inOdd && //Even Minute window
                                Ammo != 3)) //Ammo is not full (3)
                                return NoMercy; //Execute No Mercy if conditions are met
                        }
                        if (!LevelChecked(DoubleDown)) //Lv1-89
                        {
                            if (canLateWeave && //Late-weaveable
                                Ammo == MaxCartridges(level)) //Ammo is full
                                return NoMercy; //Execute No Mercy if conditions are met
                        }
                    }

                    //Bloodfest - Forced to prevent combo from spazzing out due to next action possibly requiring Ammo
                    if (IsEnabled(CustomComboPreset.GNB_GF_Bloodfest) && //Bloodfest option is enabled
                        canBF && //able to use Bloodfest
                        Ammo == 0) //Only when ammo is empty
                        return Bloodfest; //Execute Bloodfest if conditions are met

                    //oGCDs
                    if (CanWeave(actionID))
                    {
                        //Variant SpiritDart
                        Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
                        if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) &&
                            IsEnabled(Variant.VariantSpiritDart) &&
                            (sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
                            return Variant.VariantSpiritDart;

                        //Variant Ultimatum
                        if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && ActionReady(Variant.VariantUltimatum))
                            return Variant.VariantUltimatum;

                        //Cooldowns
                        if (IsEnabled(CustomComboPreset.GNB_GF_Features)) //Cooldowns option is enabled
                        {
                            //Zone
                            if (IsEnabled(CustomComboPreset.GNB_GF_Zone) && //Zone option is enabled
                                canZone && //able to use Zone
                                (nmCD is < 57.5f and > 17f) && //Optimal use; twice per minute, 1 in NM, 1 out of NM
                                !JustUsed(NoMercy)) //No Mercy was not just used within 3 seconds
                                return OriginalHook(DangerZone); //Execute Zone if conditions are met

                            //Bow Shock
                            if (IsEnabled(CustomComboPreset.GNB_GF_BowShock) && //Bow Shock option is enabled
                                canBow && //able to use Bow Shock
                                (nmCD is < 57.5f and > 17f) && //Optimal use; twice per minute, 1 in NM, 1 out of NM
                                !JustUsed(NoMercy)) //No Mercy was not just used within 3 seconds)
                                return BowShock;
                        }
                    }

                    //Hypervelocity - Forced to prevent loss
                    if (IsEnabled(CustomComboPreset.GNB_GF_Continuation) && //Continuation option is enabled
                        JustUsed(BurstStrike, 5f) && //Burst Strike was just used within 5 seconds
                        LevelChecked(Hypervelocity) && //Hypervelocity is unlocked
                        HasEffect(Buffs.ReadyToBlast) && //Ready To Blast buff is active
                        nmCD > 1) //Priority hack to prevent Hypervelocity from being used before No Mercy
                        return Hypervelocity; //Execute Hypervelocity if conditions are met

                    //Continuation protection - Forced to prevent loss
                    if (IsEnabled(CustomComboPreset.GNB_GF_Continuation) && //Continuation option is enabled
                        canContinue && //able to use Continuation
                        (HasEffect(Buffs.ReadyToRip) || //after Gnashing Fang
                        HasEffect(Buffs.ReadyToTear) || //after Savage Claw
                        HasEffect(Buffs.ReadyToGouge) || //after Wicked Talon
                        HasEffect(Buffs.ReadyToBlast) || //after Burst Strike
                        HasEffect(Buffs.ReadyToRaze))) //after Fated Circle
                        return OriginalHook(Continuation); //Execute appopriate Continuation action if conditions are met

                    //TODO: code below is rather ass; refactor
                    //Lv100 - every 3rd NM window
                    if (LevelChecked(ReignOfBeasts) &&
                        HasEffect(Buffs.NoMercy) &&
                        GunStep == 0 &&
                        LevelChecked(BurstStrike) &&
                        lastComboMove is BrutalShell &&
                        Ammo == 1)
                        return SolidBarrel;
                    //Lv90 - every 3rd NM window
                    if (!LevelChecked(ReignOfBeasts) &&
                        HasEffect(Buffs.NoMercy) &&
                        GunStep == 0 &&
                        LevelChecked(BurstStrike) &&
                        (lastComboMove is BrutalShell || JustUsed(BurstStrike)) &&
                        Ammo == 1)
                        return SolidBarrel;

                    //GCDs
                    if (IsEnabled(CustomComboPreset.GNB_GF_Features)) //Cooldowns option is enabled
                    {
                        //GnashingFang
                        if (canGF && //able to use Gnashing Fang
                            ((nmCD is > 17 and < 35) || //30s Optimal use
                            (JustUsed(NoMercy, 6f)))) //No Mercy was just used within 4 seconds
                            return GnashingFang;

                        //Double Down
                        if (IsEnabled(CustomComboPreset.GNB_GF_DoubleDown) && //Double Down option is enabled
                            canDD && //able to use Double Down
                            IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                            hasNM) //No Mercy is active
                            return DoubleDown;

                        //Sonic Break
                        if (IsEnabled(CustomComboPreset.GNB_GF_SonicBreak) && //Sonic Break option is enabled
                            canBreak && //able to use Sonic Break
                            ((IsOnCooldown(GnashingFang) && IsOnCooldown(DoubleDown)) || //Gnashing Fang and Double Down are both on cooldown
                            nmLeft <= GCD)) //No Mercy buff is about to expire
                            return SonicBreak; //Execute Sonic Break if conditions are met

                        //Reign of Beasts
                        if (IsEnabled(CustomComboPreset.GNB_GF_Reign) && //Reign of Beasts option is enabled
                            canReign && //able to use Reign of Beasts
                            IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                            IsOnCooldown(DoubleDown) && //Double Down is on cooldown
                            !HasEffect(Buffs.ReadyToBreak) && //Ready To Break is not active
                            GunStep == 0) //Gnashing Fang or Reign combo is not active or finished
                            return OriginalHook(ReignOfBeasts); //Execute Reign of Beasts if conditions are met

                        //Burst Strike
                        if (IsEnabled(CustomComboPreset.GNB_GF_BurstStrike) && //Burst Strike option is enabled
                            canBS && //able to use Burst Strike
                            HasEffect(Buffs.NoMercy) && //No Mercy is active
                            IsOnCooldown(GnashingFang) && //Gnashing Fang is on cooldown
                            IsOnCooldown(DoubleDown) && //Double Down is on cooldown
                            !HasEffect(Buffs.ReadyToBreak) && //Ready To Break is not active
                            !HasEffect(Buffs.ReadyToReign) && //Ready To Reign is not active
                            GunStep == 0) //Gnashing Fang or Reign combo is not active or finished
                            return BurstStrike; //Execute Burst Strike if conditions are met
                    }

                    //Lv100 2cart forced 2min starter
                    if (IsEnabled(CustomComboPreset.GNB_GF_Features) && //Cooldowns option is enabled
                        IsEnabled(CustomComboPreset.GNB_GF_BurstStrike) && //Burst Strike option is enabled
                        GetTargetHPPercent() > nmStop && //target HP is above threshold
                        LevelChecked(ReignOfBeasts) && //Lv100
                        ((nmCD <= GCD || ActionReady(NoMercy)) && //No Mercy is ready or about to be
                        Ammo is 3 && //Ammo is full
                        (bfCD < GCD * 12 || ActionReady(Bloodfest)))) //Bloodfest is ready or about to be
                        return BurstStrike;

                    //Gauge Combo Steps
                    if (GunStep is 1 or 2) //Gnashing Fang combo is only for 1 and 2
                        return OriginalHook(GnashingFang); //Execute Gnashing Fang combo if conditions are met
                    if (GunStep is 3 or 4) //Reign of Beasts combo is only for 3 and 4
                        return OriginalHook(ReignOfBeasts); //Execute Reign of Beasts combo if conditions are met

                    return KeenEdge;
                }

                return actionID;
            }
        }

        //Simple Mode - AoE
        internal class GNB_AoE_SimpleMode : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_AoE_Simple;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {

                if (actionID == DemonSlice)
                {
                    var Ammo = GetJobGauge<GNBGauge>().Ammo; //Our carts
                    var GunStep = GetJobGauge<GNBGauge>().AmmoComboStep; //For GnashingFang & (possibly) ReignCombo purposes
                    var bfCD = GetCooldownRemainingTime(Bloodfest); //Bloodfest's cooldown; 120s total
                    var gfCD = GetCooldownRemainingTime(GnashingFang); //GnashingFang's cooldown; 30s total
                    float GCD = GetCooldown(KeenEdge).CooldownTotal; //2.5 is base SkS, but can work with 2.4x

                    //Variant Cure
                    if (IsEnabled(CustomComboPreset.GNB_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.GNB_VariantCure))
                        return Variant.VariantCure;

                    if (InCombat())
                    {
                        if (CanWeave(actionID))
                        {
                            //Variant SpiritDart
                            Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
                            if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) &&
                                IsEnabled(Variant.VariantSpiritDart) &&
                                (sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
                                return Variant.VariantSpiritDart;

                            //Variant Ultimatum
                            if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && ActionReady(Variant.VariantUltimatum))
                                return Variant.VariantUltimatum;

                            //NoMercy
                            if (ActionReady(NoMercy)) //use on CD
                                return NoMercy;
                            //BowShock
                            if (ActionReady(BowShock) && LevelChecked(BowShock) && HasEffect(Buffs.NoMercy)) //use on CD under NM
                                return BowShock;
                            //Zone
                            if (ActionReady(DangerZone) && (HasEffect(Buffs.NoMercy) || gfCD <= GCD * 7)) //use on CD after first usage in NM
                                return OriginalHook(DangerZone);
                            //Bloodfest
                            if (Ammo == 0 && ActionReady(Bloodfest) && LevelChecked(Bloodfest) && HasEffect(Buffs.NoMercy)) //use when Ammo is 0 in burst
                                return Bloodfest;
                            //Continuation
                            if (LevelChecked(FatedBrand) && HasEffect(Buffs.ReadyToRaze) && JustUsed(FatedCircle) && LevelChecked(FatedBrand)) //FatedCircle weave
                                return FatedBrand;
                        }

                        //SonicBreak
                        if (HasEffect(Buffs.ReadyToBreak) && !HasEffect(Buffs.ReadyToRaze) && HasEffect(Buffs.NoMercy)) //use on CD
                            return SonicBreak;
                        //DoubleDown
                        if (Ammo >= 1 && ActionReady(DoubleDown) && HasEffect(Buffs.NoMercy)) //use on CD under NM
                            return DoubleDown;
                        //Reign
                        if (LevelChecked(ReignOfBeasts)) //because leaving this out anywhere is a waste
                        {
                            if ((GetBuffRemainingTime(Buffs.ReadyToReign) > 0 && !ActionReady(DoubleDown) && GunStep == 0) ||
                               (GunStep is 3 or 4))
                                return OriginalHook(ReignOfBeasts);
                        }
                        //FatedCircle - if not LevelChecked, use BurstStrike
                        if (Ammo > 0 && LevelChecked(FatedCircle) &&
                            (HasEffect(Buffs.NoMercy) && !ActionReady(DoubleDown) && GunStep == 0) || //use when under NM after DD & ignores GF
                            (bfCD < 6)) //Bloodfest prep
                            return FatedCircle;
                        if (Ammo > 0 && !LevelChecked(FatedCircle) && LevelChecked(BurstStrike) &&
                            (HasEffect(Buffs.NoMercy) && !ActionReady(DoubleDown) && GunStep == 0)) //use when under NM after DD & ignores GF
                            return BurstStrike;
                    }

                    //1-2
                    if (comboTime > 0)
                    {
                        if (lastComboMove == DemonSlice && LevelChecked(DemonSlaughter))
                        {
                            if (Ammo == MaxCartridges(level))
                            {
                                if (LevelChecked(FatedCircle))
                                    return FatedCircle;
                                if (!LevelChecked(FatedCircle))
                                    return BurstStrike;
                            }
                            if (Ammo != MaxCartridges(level))
                            {
                                return DemonSlaughter;
                            }
                        }
                    }

                    return DemonSlice;
                }

                return actionID;
            }
        }

        //Simple Mode - AoE
        internal class GNB_AoE_AdvancedMode : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_AoE_Advanced;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID == DemonSlice)
                {
                    var Ammo = GetJobGauge<GNBGauge>().Ammo; //Our carts
                    var GunStep = GetJobGauge<GNBGauge>().AmmoComboStep; //For GnashingFang & (possibly) ReignCombo purposes
                    var bfCD = GetCooldownRemainingTime(Bloodfest); //Bloodfest's cooldown; 120s total
                    var gfCD = GetCooldownRemainingTime(GnashingFang); //GnashingFang's cooldown; 30s total
                    float GCD = GetCooldown(KeenEdge).CooldownTotal; //2.5 is base SkS, but can work with 2.4x
                    int nmStop = PluginConfiguration.GetCustomIntValue(Config.GNB_AoE_NoMercyStop);

                    //Variant Cure
                    if (IsEnabled(CustomComboPreset.GNB_Variant_Cure) && IsEnabled(Variant.VariantCure) && PlayerHealthPercentageHp() <= GetOptionValue(Config.GNB_VariantCure))
                        return Variant.VariantCure;

                    if (InCombat())
                    {
                        if (CanWeave(actionID))
                        {
                            //Variant SpiritDart
                            Status? sustainedDamage = FindTargetEffect(Variant.Debuffs.SustainedDamage);
                            if (IsEnabled(CustomComboPreset.GNB_Variant_SpiritDart) &&
                                IsEnabled(Variant.VariantSpiritDart) &&
                                (sustainedDamage is null || sustainedDamage?.RemainingTime <= 3))
                                return Variant.VariantSpiritDart;

                            //Variant Ultimatum
                            if (IsEnabled(CustomComboPreset.GNB_Variant_Ultimatum) && IsEnabled(Variant.VariantUltimatum) && ActionReady(Variant.VariantUltimatum))
                                return Variant.VariantUltimatum;

                            //NoMercy
                            if (IsEnabled(CustomComboPreset.GNB_AoE_NoMercy) && ActionReady(NoMercy) && GetTargetHPPercent() > nmStop) //use on CD
                                return NoMercy;
                            //BowShock
                            if (IsEnabled(CustomComboPreset.GNB_AoE_BowShock) && ActionReady(BowShock) && LevelChecked(BowShock) && HasEffect(Buffs.NoMercy)) //use on CD under NM
                                return BowShock;
                            //Zone
                            if (IsEnabled(CustomComboPreset.GNB_AoE_DangerZone) && ActionReady(DangerZone) && (HasEffect(Buffs.NoMercy) || gfCD <= GCD * 7)) //use on CD after first usage in NM
                                return OriginalHook(DangerZone);
                            //Bloodfest
                            if (IsEnabled(CustomComboPreset.GNB_AoE_Bloodfest) && Ammo == 0 && ActionReady(Bloodfest) && LevelChecked(Bloodfest) && HasEffect(Buffs.NoMercy)) //use when Ammo is 0 in burst
                                return Bloodfest;
                            //Continuation
                            if (LevelChecked(FatedBrand) && HasEffect(Buffs.ReadyToRaze) && JustUsed(FatedCircle) && LevelChecked(FatedBrand)) //FatedCircle weave
                                return FatedBrand;
                        }

                        //SonicBreak
                        if (IsEnabled(CustomComboPreset.GNB_AoE_SonicBreak) && HasEffect(Buffs.ReadyToBreak) && !HasEffect(Buffs.ReadyToRaze) && HasEffect(Buffs.NoMercy)) //use on CD
                            return SonicBreak;
                        //DoubleDown
                        if (IsEnabled(CustomComboPreset.GNB_AoE_DoubleDown) && Ammo >= 1 && ActionReady(DoubleDown) && HasEffect(Buffs.NoMercy)) //use on CD under NM
                            return DoubleDown;
                        //Reign
                        if (IsEnabled(CustomComboPreset.GNB_AoE_Reign) && LevelChecked(ReignOfBeasts)) //because leaving this out anywhere is a waste
                        {
                            if ((GetBuffRemainingTime(Buffs.ReadyToReign) > 0 && !ActionReady(DoubleDown) && GunStep == 0) ||
                               (GunStep is 3 or 4))
                                return OriginalHook(ReignOfBeasts);
                        }
                        //FatedCircle - if not LevelChecked, use BurstStrike
                        if (Ammo > 0 && LevelChecked(FatedCircle) &&
                            ((IsEnabled(CustomComboPreset.GNB_AoE_FatedCircle) && HasEffect(Buffs.NoMercy) && !ActionReady(DoubleDown) && GunStep == 0) || //use when under NM after DD & ignores GF
                            (IsEnabled(CustomComboPreset.GNB_AoE_Bloodfest) && bfCD < 6))) //Bloodfest prep
                            return FatedCircle;
                        if (IsEnabled(CustomComboPreset.GNB_AoE_noFatedCircle) && Ammo > 0 && !LevelChecked(FatedCircle) && LevelChecked(BurstStrike) &&
                            (HasEffect(Buffs.NoMercy) && GunStep == 0)) //Bloodfest prep
                            return BurstStrike;
                    }

                    //1-2
                    if (comboTime > 0)
                    {
                        if (lastComboMove == DemonSlice && LevelChecked(DemonSlaughter))
                        {
                            if (Ammo == MaxCartridges(level))
                            {
                                if (IsEnabled(CustomComboPreset.GNB_AoE_Overcap) && LevelChecked(FatedCircle))
                                    return FatedCircle;
                                if (IsEnabled(CustomComboPreset.GNB_AoE_BSOvercap) && !LevelChecked(FatedCircle))
                                    return BurstStrike;
                            }
                            if (Ammo != MaxCartridges(level) ||
                                (Ammo == MaxCartridges(level) && !LevelChecked(FatedCircle) && !IsEnabled(CustomComboPreset.GNB_AoE_BSOvercap)))
                            {
                                return DemonSlaughter;
                            }
                        }
                    }

                    return DemonSlice;
                }

                return actionID;
            }
        } 

        //Burst Strike Features
        internal class GNB_BS_Features : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_BS_Features;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is BurstStrike)
                {
                    var Ammo = GetJobGauge<GNBGauge>().Ammo; //Our carts
                    var GunStep = GetJobGauge<GNBGauge>().AmmoComboStep; //For GnashingFang & (possibly) ReignCombo purposes
                    var bfCD = GetCooldownRemainingTime(Bloodfest); //Bloodfest's cooldown; 120s total
                    var ddCD = GetCooldownRemainingTime(DoubleDown); //Double Down's cooldown; 60s total

                    if (IsEnabled(CustomComboPreset.GNB_BS_Continuation) && HasEffect(Buffs.ReadyToBlast) && LevelChecked(Hypervelocity))
                        return Hypervelocity;
                    if (IsEnabled(CustomComboPreset.GNB_BS_Bloodfest) && Ammo is 0 && LevelChecked(Bloodfest) && !HasEffect(Buffs.ReadyToBlast) && bfCD < 0.3f)
                        return Bloodfest;
                    if (IsEnabled(CustomComboPreset.GNB_BS_DoubleDown) && HasEffect(Buffs.NoMercy) && ddCD < 0.6f && Ammo >= 1 && LevelChecked(DoubleDown))
                        return DoubleDown;
                    if (IsEnabled(CustomComboPreset.GNB_BS_Reign) && (LevelChecked(ReignOfBeasts)))
                    {
                        if ((HasEffect(Buffs.ReadyToReign) && GetBuffRemainingTime(Buffs.ReadyToReign) > 0 && !ActionReady(DoubleDown) && GunStep == 0) ||
                            (GunStep is 3 or 4))
                            return OriginalHook(ReignOfBeasts);
                    }
                }

                return actionID;
            }
        }

        //Fated Circle Features
        internal class GNB_FC_Features : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_FC_Features;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is FatedCircle)
                {
                    var Ammo = GetJobGauge<GNBGauge>().Ammo; //carts

                    if (IsEnabled(CustomComboPreset.GNB_FC_Continuation) && HasEffect(Buffs.ReadyToRaze) && LevelChecked(FatedBrand) && CanWeave(actionID))
                        return FatedBrand;
                    if (IsEnabled(CustomComboPreset.GNB_FC_Bloodfest) && Ammo is 0 && LevelChecked(Bloodfest) && !HasEffect(Buffs.ReadyToRaze))
                        return Bloodfest;
                    if (IsEnabled(CustomComboPreset.GNB_FC_DoubleDown) && GetCooldownRemainingTime(DoubleDown) < 0.6f && Ammo >= 1 && LevelChecked(DoubleDown))
                        return DoubleDown;
                }

                return actionID;
            }
        }

        //No Mercy Features
        internal class GNB_NM_Features : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_NM_Features;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID == NoMercy)
                {
                    var Ammo = GetJobGauge<GNBGauge>().Ammo; //carts
                    var GunStep = GetJobGauge<GNBGauge>().AmmoComboStep; //GF/Reign combo
                    var gfCD = GetCooldownRemainingTime(GnashingFang); //GnashingFang's cooldown; 30s total

                    if (JustUsed(NoMercy, 20f) && InCombat())
                    {
                        //oGCDs
                        if (CanWeave(ActionWatching.LastWeaponskill))
                        {
                            if (IsEnabled(CustomComboPreset.GNB_NM_Bloodfest) && ActionReady(Bloodfest) && Ammo == 0)
                                return Bloodfest;
                            if (IsEnabled(CustomComboPreset.GNB_NM_Zone) && ActionReady(OriginalHook(DangerZone)) && (HasEffect(Buffs.NoMercy) || gfCD > 17))
                                return OriginalHook(DangerZone);
                            if (IsEnabled(CustomComboPreset.GNB_NM_BS) && ActionReady(BowShock) && HasEffect(Buffs.NoMercy))
                                return BowShock;
                        }

                        //GCDs
                        if (IsEnabled(CustomComboPreset.GNB_NM_SB) && HasEffect(Buffs.ReadyToBreak))
                            return SonicBreak;
                        if (IsEnabled(CustomComboPreset.GNB_NM_DD) && LevelChecked(DoubleDown) && ActionReady(DoubleDown) && Ammo >= 1 && LevelChecked(DoubleDown))
                            return DoubleDown;
                        if (IsEnabled(CustomComboPreset.GNB_NM_Reign) && (LevelChecked(ReignOfBeasts)))
                        {
                            if ((HasEffect(Buffs.ReadyToReign) && GetBuffRemainingTime(Buffs.ReadyToReign) > 0 && !ActionReady(DoubleDown) && GunStep == 0) ||
                                (GunStep is 3 or 4))
                                return OriginalHook(ReignOfBeasts);
                        }
                    }
                }

                return actionID;
            }
        }

        //Aurora Protection
        internal class GNB_AuroraProtection : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.GNB_AuroraProtection;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Aurora)
                {
                    if ((HasFriendlyTarget() && TargetHasEffectAny(Buffs.Aurora)) || (!HasFriendlyTarget() && HasEffectAny(Buffs.Aurora)))
                        return OriginalHook(11);
                }
                return actionID;
            }
        }
    }
}