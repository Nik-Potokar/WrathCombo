using ECommons.DalamudServices;
using System.Collections.Generic;
using System.Linq;
using XIVSlothCombo.CustomComboNS;
using XIVSlothCombo.CustomComboNS.Functions;
using XIVSlothCombo.Data;
using XIVSlothCombo.Services;

namespace XIVSlothCombo.Combos.PvE
{
    internal class All
    {
        public const byte JobID = 0;

        public const uint
            Rampart = 7531,
            SecondWind = 7541,
            TrueNorth = 7546,
            Addle = 7560,
            Swiftcast = 7561,
            LucidDreaming = 7562,
            Resurrection = 173,
            Raise = 125,
            Provoke = 7533,
            Shirk = 7537,
            Reprisal = 7535,
            Esuna = 7568,
            Rescue = 7571,
            SolidReason = 232,
            AgelessWords = 215,
            Sleep = 25880,
            WiseToTheWorldMIN = 26521,
            WiseToTheWorldBTN = 26522,
            LowBlow = 7540,
            Bloodbath = 7542,
            HeadGraze = 7551,
            FootGraze = 7553,
            LegGraze = 7554,
            Feint = 7549,
            Interject = 7538,
            Peloton = 7557,
            LegSweep = 7863,
            Repose = 16560,
            Sprint = 3,
            ArmsLength = 7548,
            Surecast = 7559;
        private const uint
            IsleSprint = 31314;

        public static class Buffs
        {
            public const ushort
                Weakness = 43,
                Medicated = 49,
                Bloodbath = 84,
                Swiftcast = 167,
                Rampart = 1191,
                Peloton = 1199,
                LucidDreaming = 1204,
                TrueNorth = 1250,
                Sprint = 50;
        }

        public static class Debuffs
        {
            public const ushort
                Sleep = 3,
                Bind = 13,
                Heavy = 14,
                Addle = 1203,
                Reprisal = 1193,
                Feint = 1195;
        }

        public static class Config
        {
            public static UserFloat
                All_Custom_Potion_Time1 = new("All_Custom_Potion_Time1", 365),
                All_Custom_Potion_Time2 = new("All_Custom_Potion_Time2", 710),
                All_Custom_Potion_Time3 = new("All_Custom_Potion_Time3", 1080),
                All_Custom_Potion_Time4 = new("All_Custom_Potion_Time4", 1475),
                All_Custom_Potion_Time5 = new("All_Custom_Potion_Time5", 1895);
        }

        /// <summary>
        /// Quick Level, Offcooldown, spellweave, and MP check of Lucid Dreaming
        /// </summary>
        /// <param name="actionID">action id to check weave</param>
        /// <param name="MPThreshold">Player MP less than Threshold check</param>
        /// <param name="weave">Spell Weave check by default</param>
        /// <returns></returns>
        public static bool CanUseLucid(uint actionID, int MPThreshold, bool weave = true) =>
            CustomComboFunctions.ActionReady(LucidDreaming)
            && CustomComboFunctions.LocalPlayer.CurrentMp <= MPThreshold
            && (!weave || CustomComboFunctions.CanSpellWeave(actionID));

        internal class ALL_IslandSanctuary_Sprint : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_IslandSanctuary_Sprint;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Sprint && Svc.ClientState.TerritoryType is 1055) return IsleSprint;
                else return actionID;
            }
        }

        //Tank Features
        internal class ALL_Tank_Interrupt : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Tank_Interrupt;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is LowBlow or PLD.ShieldBash)
                {
                    if (CanInterruptEnemy() && ActionReady(Interject))
                        return Interject;
                    if (ActionReady(LowBlow))
                        return LowBlow;
                    if (actionID == PLD.ShieldBash && IsOnCooldown(LowBlow))
                        return actionID;
                }

                return actionID;
            }
        }

        internal class ALL_Tank_Reprisal : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Tank_Reprisal;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Reprisal)
                {
                    if (TargetHasEffectAny(Debuffs.Reprisal) && IsOffCooldown(Reprisal))
                        return OriginalHook(11);
                }

                return actionID;
            }
        }

        //Healer Features
        internal class ALL_Healer_Raise : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Healer_Raise;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if ((actionID is WHM.Raise or AST.Ascend or SGE.Egeiro)
                    || (actionID is SCH.Resurrection && LocalPlayer.ClassJob.Value.RowId is SCH.JobID))
                {
                    if (ActionReady(Swiftcast))
                        return Swiftcast;

                    if (actionID == WHM.Raise && IsEnabled(CustomComboPreset.WHM_ThinAirRaise) && ActionReady(WHM.ThinAir) && !HasEffect(WHM.Buffs.ThinAir))
                        return WHM.ThinAir;

                    return actionID;
                }

                return actionID;
            }
        }

        //Caster Features
        internal class ALL_Caster_Addle : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Caster_Addle;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Addle)
                {
                    if (TargetHasEffectAny(Debuffs.Addle) && IsOffCooldown(Addle))
                        return OriginalHook(11);
                }

                return actionID;
            }
        }

        internal class ALL_Caster_Raise : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Caster_Raise;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if ((actionID is BLU.AngelWhisper or RDM.Verraise)
                    || (actionID is SMN.Resurrection && LocalPlayer.ClassJob.RowId is SMN.JobID))
                {
                    if (HasEffect(Buffs.Swiftcast) || HasEffect(RDM.Buffs.Dualcast))
                        return actionID;
                    if (IsOffCooldown(Swiftcast))
                        return Swiftcast;
                    if (LocalPlayer.ClassJob.RowId is RDM.JobID &&
                        ActionReady(RDM.Vercure))
                        return RDM.Vercure;
                }

                return actionID;
            }
        }

        //Melee DPS Features
        internal class ALL_Melee_Feint : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Melee_Feint;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is Feint)
                {
                    if (TargetHasEffectAny(Debuffs.Feint) && IsOffCooldown(Feint))
                        return OriginalHook(11);
                }

                return actionID;
            }
        }

        internal class ALL_Melee_TrueNorth : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Melee_TrueNorth;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is TrueNorth)
                {
                    if (HasEffect(Buffs.TrueNorth))
                        return OriginalHook(11);
                }

                return actionID;
            }
        }

        //Ranged Physical Features
        internal class ALL_Ranged_Mitigation : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Ranged_Mitigation;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is BRD.Troubadour or MCH.Tactician or DNC.ShieldSamba)
                {
                    if ((HasEffectAny(BRD.Buffs.Troubadour) || HasEffectAny(MCH.Buffs.Tactician) || HasEffectAny(DNC.Buffs.ShieldSamba)) && IsOffCooldown(actionID))
                        return OriginalHook(11);
                }

                return actionID;
            }
        }

        internal class ALL_Ranged_Interrupt : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Ranged_Interrupt;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                return (actionID is FootGraze && CanInterruptEnemy() && ActionReady(HeadGraze)) ? HeadGraze : actionID;
            }
        }

        #region Potion 
        //Triggers - TODO COMPLETE AND OPTIMIZE THE LIST
        public static readonly HashSet<uint> OpenerSkills = new HashSet<uint>
        {   
            // Tanks
            // WAR
            CustomComboFunctions.OriginalHook(WAR.StormsEye),
            // DRK
            CustomComboFunctions.OriginalHook(DRK.Unmend),
            CustomComboFunctions.OriginalHook(DRK.HardSlash),
            CustomComboFunctions.OriginalHook(DRK.SyphonStrike),
            CustomComboFunctions.OriginalHook(DRK.Souleater),
            // PLD
            CustomComboFunctions.OriginalHook(PLD.RiotBlade),
            CustomComboFunctions.OriginalHook(PLD.FastBlade),
            // GNB
            CustomComboFunctions.OriginalHook(GNB.KeenEdge),
            // Melees
            // MNK
            CustomComboFunctions.OriginalHook(MNK.DragonKick),
            CustomComboFunctions.OriginalHook(MNK.Bootshine),
            // DRG

            // NIN
            CustomComboFunctions.OriginalHook(NIN.AeolianEdge),
            CustomComboFunctions.OriginalHook(NIN.ArmorCrush),
            // RPR
            CustomComboFunctions.OriginalHook(RPR.ShadowOfDeath),
            CustomComboFunctions.OriginalHook(RPR.SoulSlice),
            CustomComboFunctions.OriginalHook(RPR.Slice),
            CustomComboFunctions.OriginalHook(RPR.InfernalSlice),
            CustomComboFunctions.OriginalHook(RPR.WaxingSlice),
            // VPR
            CustomComboFunctions.OriginalHook(VPR.SteelFangs),
            
            // SAM
            CustomComboFunctions.OriginalHook(SAM.Gekko),
            CustomComboFunctions.OriginalHook(SAM.Hakaze),
            CustomComboFunctions.OriginalHook(SAM.Ikishoten),
            //pRANGED
            //BRD
            //MCH
            CustomComboFunctions.OriginalHook(MCH.Reassemble),
            CustomComboFunctions.OriginalHook(MCH.SlugShot),
            CustomComboFunctions.OriginalHook(MCH.SplitShot),
            CustomComboFunctions.OriginalHook(MCH.CleanShot),
            //DNC

            //Caster
            //BLM
            CustomComboFunctions.OriginalHook(BLM.Fire3),
            CustomComboFunctions.OriginalHook(BLM.Fire4),
            CustomComboFunctions.OriginalHook(BLM.Blizzard),
            //SMN
            CustomComboFunctions.OriginalHook(SMN.SummonBahamut),
            CustomComboFunctions.OriginalHook(SMN.Ruin),
            CustomComboFunctions.OriginalHook(SMN.AstralImpulse),

            //PCT
            CustomComboFunctions.OriginalHook(PCT.HolyInWhite),
            CustomComboFunctions.OriginalHook(PCT.CreatureMotif),
            CustomComboFunctions.OriginalHook(PCT.WingMotif),
            
            //RDM
            CustomComboFunctions.OriginalHook(RDM.Jolt),
            //BLU

            //Healer
            //AST
            CustomComboFunctions.OriginalHook(AST.Malefic),
            //WHM
            CustomComboFunctions.OriginalHook(WHM.Stone1),
            CustomComboFunctions.OriginalHook(WHM.Glare3),
            //SCH
            CustomComboFunctions.OriginalHook(SCH.Ruin),
            //SGE
            CustomComboFunctions.OriginalHook(SGE.Dosis),
            CustomComboFunctions.OriginalHook(SGE.Dosis3),


        };

        public static readonly HashSet<uint> RotationSkills = new HashSet<uint>
        {   
            // Tanks
            // WAR
            CustomComboFunctions.OriginalHook(WAR.StormsEye),
            CustomComboFunctions.OriginalHook(WAR.Maim),
            CustomComboFunctions.OriginalHook(WAR.HeavySwing),
            CustomComboFunctions.OriginalHook(WAR.StormsPath),
            CustomComboFunctions.OriginalHook(WAR.FellCleave),
            // DRK
            CustomComboFunctions.OriginalHook(DRK.Unmend),
            CustomComboFunctions.OriginalHook(DRK.HardSlash),
            CustomComboFunctions.OriginalHook(DRK.SyphonStrike),
            CustomComboFunctions.OriginalHook(DRK.Souleater),
            // PLD
            CustomComboFunctions.OriginalHook(PLD.RiotBlade),
            CustomComboFunctions.OriginalHook(PLD.FastBlade),
            // GNB
            CustomComboFunctions.OriginalHook(GNB.BrutalShell),
            CustomComboFunctions.OriginalHook(GNB.KeenEdge),
            CustomComboFunctions.OriginalHook(GNB.SolidBarrel),
            // Melees
            // MNK
            CustomComboFunctions.OriginalHook(MNK.DragonKick),
            CustomComboFunctions.OriginalHook(MNK.Bootshine),
            // DRG

            // NIN
            CustomComboFunctions.OriginalHook(NIN.AeolianEdge),
            CustomComboFunctions.OriginalHook(NIN.ArmorCrush),
            // RPR
            CustomComboFunctions.OriginalHook(RPR.ShadowOfDeath),
            CustomComboFunctions.OriginalHook(RPR.SoulSlice),
            CustomComboFunctions.OriginalHook(RPR.Slice),
            CustomComboFunctions.OriginalHook(RPR.InfernalSlice),
            CustomComboFunctions.OriginalHook(RPR.WaxingSlice),
            // VPR
            CustomComboFunctions.OriginalHook(VPR.SteelFangs),
            CustomComboFunctions.OriginalHook(VPR.Vicewinder),
            CustomComboFunctions.OriginalHook(VPR.ReavingFangs),
            CustomComboFunctions.OriginalHook(VPR.HuntersCoil),
            CustomComboFunctions.OriginalHook(VPR.SwiftskinsCoil),
            
            // SAM
            CustomComboFunctions.OriginalHook(SAM.Gekko),
            CustomComboFunctions.OriginalHook(SAM.Hakaze),
            CustomComboFunctions.OriginalHook(SAM.Ikishoten),
            //pRANGED
            //BRD
            //MCH
            CustomComboFunctions.OriginalHook(MCH.SlugShot),
            CustomComboFunctions.OriginalHook(MCH.SplitShot),
            CustomComboFunctions.OriginalHook(MCH.CleanShot),
            //DNC

            //Caster
            //BLM
            CustomComboFunctions.OriginalHook(BLM.Fire3),
            CustomComboFunctions.OriginalHook(BLM.Fire4),
            CustomComboFunctions.OriginalHook(BLM.Blizzard),
            //SMN
            CustomComboFunctions.OriginalHook(SMN.SummonBahamut),
            CustomComboFunctions.OriginalHook(SMN.Ruin),
            CustomComboFunctions.OriginalHook(SMN.AstralImpulse),
            CustomComboFunctions.OriginalHook(SMN.Ruin4),
            CustomComboFunctions.OriginalHook(SMN.Ruin3),
            CustomComboFunctions.OriginalHook(SMN.RubyRuin3),
            CustomComboFunctions.OriginalHook(SMN.RubyRuin1),
            CustomComboFunctions.OriginalHook(SMN.TopazRuin3),
            CustomComboFunctions.OriginalHook(SMN.TopazRuin1),

            //PCT
            CustomComboFunctions.OriginalHook(PCT.RainbowDrip),
            CustomComboFunctions.OriginalHook(PCT.FireInRed),
            //RDM
            CustomComboFunctions.OriginalHook(RDM.Jolt),
            //BLU

            //Healer
            //AST
            CustomComboFunctions.OriginalHook(AST.Malefic),
            //WHM
            CustomComboFunctions.OriginalHook(WHM.Stone1),
            //SCH
            CustomComboFunctions.OriginalHook(SCH.Ruin),
            //SGE
            CustomComboFunctions.OriginalHook(SGE.Dosis)


        };

        // Strength Potion
        internal class ALL_Strength_Potion : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.StrengthPotion;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                uint strengthPotion = (uint)Service.Configuration.StrengthPotion;

                float[] potionTimes;

                if (IsEnabled(CustomComboPreset.PotionCustomTime))
                {

                    // Get custom potion times if enabled
                    potionTimes = new float[]
                    {
                        Config.All_Custom_Potion_Time1,
                        Config.All_Custom_Potion_Time2,
                        Config.All_Custom_Potion_Time3,
                        Config.All_Custom_Potion_Time4,
                        Config.All_Custom_Potion_Time5

                    }.Where(time => time > 0).ToArray(); // Ensure times are positive
                }
                else if (IsEnabled(CustomComboPreset.PotionAllowUnbuffed))
                {
                    potionTimes = new float[] { 365, 710, 980, 1080 };
                }
                else
                {
                    potionTimes = new float[] { 365, 710, 1080 };
                }

                // Cache current combat time to avoid redundant calculations
                float currentTime = (float)CombatEngageDuration().TotalSeconds;

                // Determine if it's the opener phase (within the first 15 seconds)
                bool isOpenerPhase = currentTime <= 15 &&
                                     OpenerSkills.Any(action => CanWeave(action) &&
                                     (WasLastWeaponskill(action) || WasLastSpell(action)));

                // Check if we are in a valid potion window
                bool isInPotionWindow = potionTimes.Any(time => currentTime >= time && currentTime <= time + 30);

                // Determine if we should use a potion during rotation
                bool shouldUseRotationPotion = isInPotionWindow &&
                                               RotationSkills.Any(action => CanWeave(action));

                // Exit early if potion usage is disabled or we're not in combat
                if (!IsEnabled(CustomComboPreset.StrengthPotion) || !InCombat() || GetItemStatus(strengthPotion) != 0)
                    return actionID;

                // Check if we should only use in raid and if we're in a raid
                bool isInRaid = !IsEnabled(CustomComboPreset.UsePotionOnlyInRaid) || IsInRaid();

                uint[] validIds = { 21, 19, 32, 37, 20, 39 };

                // Check job-specific conditions and decide on potion use
                if (isInRaid && validIds.Contains(LocalPlayer.ClassJob.RowId) && CanWeave(ActionWatching.LastAction))
                {
                    if (isOpenerPhase || shouldUseRotationPotion)
                    {
                        UsePotion(strengthPotion);
                    }
                }

                return actionID;
            }
        }

        // Dex Potion
        internal class ALL_Dexterity_Potion : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.DexterityPotion;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                uint dexterityPotion = (uint)Service.Configuration.DexterityPotion;

                float[] potionTimes;

                if (IsEnabled(CustomComboPreset.PotionCustomTime))
                {

                    // Get custom potion times if enabled
                    potionTimes = new float[]
                    {
                        Config.All_Custom_Potion_Time1,
                        Config.All_Custom_Potion_Time2,
                        Config.All_Custom_Potion_Time3,
                        Config.All_Custom_Potion_Time4,
                        Config.All_Custom_Potion_Time5

                    }.Where(time => time > 0).ToArray(); // Ensure times are positive
                }
                else if (IsEnabled(CustomComboPreset.PotionAllowUnbuffed))
                {
                    potionTimes = new float[] { 365, 710, 980, 1080 };
                }
                else
                {
                    potionTimes = new float[] { 365, 710, 1080 };
                }

                // Cache current combat time to avoid redundant calculations
                float currentTime = (float)CombatEngageDuration().TotalSeconds;

                // Determine if it's the opener phase (within the first 15 seconds)
                bool isOpenerPhase = currentTime <= 15 &&
                                     OpenerSkills.Any(action => CanWeave(action) &&
                                     (WasLastWeaponskill(action) || WasLastSpell(action)));

                // Check if we are in a valid potion window
                bool isInPotionWindow = potionTimes.Any(time => currentTime >= time && currentTime <= time + 30);

                // Determine if we should use a potion during rotation
                bool shouldUseRotationPotion = isInPotionWindow &&
                                               RotationSkills.Any(action => CanWeave(action));

                // Exit early if potion usage is disabled or we're not in combat
                if (!IsEnabled(CustomComboPreset.DexterityPotion) || !InCombat() || GetItemStatus(dexterityPotion) != 0)
                    return actionID;

                // Check if we should only use in raid and if we're in a raid
                bool isInRaid = !IsEnabled(CustomComboPreset.UsePotionOnlyInRaid) || IsInRaid();

                uint[] validIds = { 22, 30, 41, 5, 31, 38 };

                // Check job-specific conditions and decide on potion use
                if (isInRaid && validIds.Contains(LocalPlayer.ClassJob.RowId) && CanWeave(ActionWatching.LastAction))
                {
                    if (isOpenerPhase || shouldUseRotationPotion)
                    {
                        UsePotion(dexterityPotion);
                    }
                }

                return actionID;
            }
        }


        internal class ALL_Intelligence_Potion : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.IntelligencePotion;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                uint intelligencePotion = (uint)Service.Configuration.InteligencePotion;

                float[] potionTimes;

                if (IsEnabled(CustomComboPreset.PotionCustomTime))
                {

                    // Get custom potion times if enabled
                    potionTimes = new float[]
                    {
                        Config.All_Custom_Potion_Time1,
                        Config.All_Custom_Potion_Time2,
                        Config.All_Custom_Potion_Time3,
                        Config.All_Custom_Potion_Time4,
                        Config.All_Custom_Potion_Time5

                    }.Where(time => time > 0).ToArray(); // Ensure times are positive
                }
                else if (IsEnabled(CustomComboPreset.PotionAllowUnbuffed))
                {
                    potionTimes = new float[] { 365, 710, 980, 1080 };
                }
                else
                {
                    potionTimes = new float[] { 365, 710, 1080 };
                }

                // Cache current combat time to avoid redundant calculations
                float currentTime = (float)CombatEngageDuration().TotalSeconds;

                // Determine if it's the opener phase (within the first 15 seconds)
                bool isOpenerPhase = currentTime <= 15 &&
                                     OpenerSkills.Any(action => CanWeave(action) &&
                                     (WasLastWeaponskill(action) || WasLastSpell(action)));

                // Check if we are in a valid potion window
                bool isInPotionWindow = potionTimes.Any(time => currentTime >= time && currentTime <= time + 30);

                // Determine if we should use a potion during rotation
                bool shouldUseRotationPotion = isInPotionWindow &&
                                               RotationSkills.Any(action => CanWeave(action));

                // Exit early if potion usage is disabled or we're not in combat
                if (!IsEnabled(CustomComboPreset.IntelligencePotion) || !InCombat() || GetItemStatus(intelligencePotion) != 0)
                    return actionID;

                // Check if we should only use in raid and if we're in a raid
                bool isInRaid = !IsEnabled(CustomComboPreset.UsePotionOnlyInRaid) || IsInRaid();

                uint[] validIds = { 7, 27, 35, 36, 42 };

                // Check job-specific conditions and decide on potion use
                if (isInRaid && validIds.Contains(LocalPlayer.ClassJob.RowId) && CanWeave(ActionWatching.LastAction))
                {
                    if (isOpenerPhase || shouldUseRotationPotion)
                    {
                        UsePotion(intelligencePotion);
                    }
                }

                return actionID;
            }
        }

        internal class ALL_Mind_Potion : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.MindPotion;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                uint mindPotion = (uint)Service.Configuration.MindPotion;

                float[] potionTimes;

                if (IsEnabled(CustomComboPreset.PotionCustomTime))
                {

                    // Get custom potion times if enabled
                    potionTimes = new float[]
                    {
                        Config.All_Custom_Potion_Time1,
                        Config.All_Custom_Potion_Time2,
                        Config.All_Custom_Potion_Time3,
                        Config.All_Custom_Potion_Time4,
                        Config.All_Custom_Potion_Time5

                    }.Where(time => time > 0).ToArray(); // Ensure times are positive
                }
                else if (IsEnabled(CustomComboPreset.PotionAllowUnbuffed))
                {
                    potionTimes = new float[] { 365, 710, 980, 1080 };
                }
                else
                {
                    potionTimes = new float[] { 365, 710, 1080 };
                }

                // Cache current combat time to avoid redundant calculations
                float currentTime = (float)CombatEngageDuration().TotalSeconds;

                // Determine if it's the opener phase (within the first 15 seconds)
                bool isOpenerPhase = currentTime <= 15 &&
                                     OpenerSkills.Any(action => CanWeave(action) &&
                                     (WasLastWeaponskill(action) || WasLastSpell(action)));

                // Check if we are in a valid potion window
                bool isInPotionWindow = potionTimes.Any(time => currentTime >= time && currentTime <= time + 30);

                // Determine if we should use a potion during rotation
                bool shouldUseRotationPotion = isInPotionWindow &&
                                               RotationSkills.Any(action => CanWeave(action));

                // Exit early if potion usage is disabled or we're not in combat
                if (!IsEnabled(CustomComboPreset.MindPotion) || !InCombat() || GetItemStatus(mindPotion) != 0)
                    return actionID;

                // Check if we should only use in raid and if we're in a raid
                bool isInRaid = !IsEnabled(CustomComboPreset.UsePotionOnlyInRaid) || IsInRaid();


                uint[] validIds = { 24, 28, 40, 33 };


                // Check job-specific conditions and decide on potion use
                if (isInRaid && validIds.Contains(LocalPlayer.ClassJob.RowId) && CanWeave(ActionWatching.LastAction))
                {
                    if (isOpenerPhase || shouldUseRotationPotion)
                    {
                        UsePotion(mindPotion);
                    }
                }

                return actionID;
            }
        }

        #endregion


        #region KB QOL

        // Dynamic knockback depending on the current class
        internal class ALL_Dynamic_Knockback_Immunity : CustomCombo
        {
            private static readonly List<int> ArmsLengthJobs = new()
            {
                WAR.JobID, DRK.JobID, PLD.JobID, GNB.JobID, MNK.JobID, DRG.JobID,
                NIN.JobID, SAM.JobID, RPR.JobID, DNC.JobID, MCH.JobID, BRD.JobID, VPR.JobID
            };

            private static readonly List<int> SurecastJobs = new()
            {
                BLM.JobID, SMN.JobID, RDM.JobID, BLU.JobID, WHM.JobID, SCH.JobID,
                AST.JobID, SGE.JobID, PCT.JobID
            };

            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_Dynamic_Knockback_Immunity;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                if (actionID is All.ArmsLength or All.Surecast)
                {
                    int playerJobId = (int)LocalPlayer.ClassJob.RowId;

                    if (ArmsLengthJobs.Contains(playerJobId))
                    {
                        return All.ArmsLength;
                    }

                    if (SurecastJobs.Contains(playerJobId))
                    {
                        return All.Surecast;
                    }

                }
                return actionID;

            }
        }

        #endregion

        #region DEBUG

        // Custom ingame action changer. Change actions on the fly
        internal class ALL_CustomActionChanger : CustomCombo
        {
            protected internal override CustomComboPreset Preset { get; } = CustomComboPreset.ALL_CustomActionChanger;

            protected override uint Invoke(uint actionID, uint lastComboMove, float comboTime, byte level)
            {
                var startingAction = Service.Configuration.cActionId;
                var adjustedAction = Service.Configuration.aActionId;
                if (actionID == startingAction)
                {
                    if (LocalPlayer != null)
                    {
                        return adjustedAction;
                    }

                }
                return actionID;
            }
        }

        #endregion
    }
}

