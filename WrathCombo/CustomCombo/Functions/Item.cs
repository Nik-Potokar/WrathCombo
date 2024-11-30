using FFXIVClientStructs;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using System.Collections.Generic;
using System;
using WrathCombo.Data;
using ECommons.DalamudServices;
using WrathCombo.Combos.PvE;

namespace WrathCombo.CustomComboNS.Functions
{
    internal abstract partial class CustomComboFunctions
    {
        /*
        public unsafe bool CanUsePotion(bool canpot)
        {
            int PotionCDGroup = 68;
            var PotionRecastInfo = FFXIVClientStructs.FFXIV.Client.Game.ActionManager.Instance()->GetRecastGroupDetail(PotionCDGroup)->IsActive == 0;
            if (PotionRecastInfo == true)
                return true;
            return PotionRecastInfo;
        }
        public unsafe void UseItem(uint itemId)
        {
            FFXIVClientStructs.FFXIV.Client.Game.ActionManager.Instance()->UseAction(FFXIVClientStructs.FFXIV.Client.Game.ActionType.Item, itemId, 0xE0000000, 65535, 0, 0, null);
        }
        */

        /*
        public static unsafe uint GetItemStatus(uint itemID) => ActionManager.Instance() is null ? uint.MaxValue : ActionManager.Instance()->GetActionStatus(ActionType.Item, itemID);
        public static unsafe bool UseItem(uint itemID) => ActionManager.Instance() is not null &&
        GetItemStatus(itemID + 1000000) is 0 && ActionManager.Instance()->UseAction(ActionType.Item, itemID + 1000000) ||
        (GetItemStatus(itemID) is 0 && ActionManager.Instance()->UseAction(ActionType.Item, itemID));
        */

        /*
        public static unsafe bool UseItem(uint itemID)
        {
            var actionManager = ActionManager.Instance();
            if (actionManager is null) return false;

            var itemStatus = GetItemStatus(itemID + 1000000);
            var itemToUse = itemID + 1000000;
            if (itemStatus != 0)
            {
                itemStatus = GetItemStatus(itemID);
                itemToUse = itemID;
                if (itemStatus != 0) return false;
            }

            return actionManager->UseAction(ActionType.Item, itemToUse);
        }
        */

        /*
        public static unsafe bool UseItem(uint itemID) =>
            ActionManager.Instance() is not null &&
            (GetItemStatus(itemID + 1000000) is 0 && ActionManager.Instance()->UseAction(ActionType.Item, itemID + 1000000) ||
            (GetItemStatus(itemID) is 0 && ActionManager.Instance()->UseAction(ActionType.Item, itemID)));


        // Testing to see if this fixes potion ghosting issue
        public static unsafe class ItemManager
        {
            public static bool CanUseItem(ActionType actionType, uint actionID) => ActionManager.Instance()->GetActionStatus(actionType, actionID) == 0;

            public static bool UseItem(uint itemID) => ActionManager.Instance()->UseAction(ActionType.Item, itemID, 0xFFFF, 65535);

        }
        public static unsafe bool UsePotion(uint ItemID)
        {
            if(ItemManager.CanUseItem(ActionType.Item, ItemID) && (CanWeave(ActionWatching.LastWeaponskill) || CanSpellWeave(ActionWatching.LastSpell)))
            {
                ItemManager.UseItem(ItemID);
            }
            return false;
        }


        /// <summary>
        /// Gets item's status. Is it ready to use?
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public static unsafe uint GetItemStatus(uint itemID)
        {
            var actionManager = ActionManager.Instance();
            return actionManager is null ? uint.MaxValue : actionManager->GetActionStatus(ActionType.Item, itemID);
        }

        /// <summary>
        /// Auto uses action/item
        /// </summary>
        /// <param name="actionID"></param>
        /// <returns></returns>
        public static unsafe bool AutoUseAction(uint actionID)
        {
            var actionManager = ActionManager.Instance();
            if (actionManager is null) return false;

            var actionStatus = actionManager->GetActionStatus(ActionType.Action, actionID);
            var actionToUse = actionID;
            if (actionStatus != 0)
            {
                if (actionStatus != 0) return false;
            }

            return actionManager->UseAction(ActionType.Action, actionToUse);
        }
        */

        #region Cached Testing

        public static unsafe class ItemManager
        {
            // Cache the ActionManager instance in a static field
            public static readonly ActionManager* _actionManagerInstance;

            // Cache for action status with timestamp
            private static Dictionary<uint, (uint status, DateTime lastChecked)> _actionStatusCache = new Dictionary<uint, (uint, DateTime)>();

            // Cache
            static ItemManager()
            {
                _actionManagerInstance = ActionManager.Instance();
            }

            public static bool CanUseItem(ActionType actionType, uint actionID)
            {
                // Check if we already have the action status cached within the last 500ms
                if (_actionStatusCache.TryGetValue(actionID, out var cache) && (DateTime.Now - cache.lastChecked).TotalMilliseconds < 500)
                {
                    return cache.status == 0;
                }

                // Get the current action status and cache it
                uint status = _actionManagerInstance->GetActionStatus(actionType, actionID);
                _actionStatusCache[actionID] = (status, DateTime.Now);
                return status == 0;
            }

            public static bool UseItem(uint itemID)
            {
                return _actionManagerInstance->UseAction(ActionType.Item, itemID, 0xFFFF, 65535);
            }
        }

        public static unsafe bool UsePotion(uint itemID)
        {
            if (!ItemManager.CanUseItem(ActionType.Item, itemID)) return false;

            // Evaluate weaving conditions only when necessary
            bool canWeaveWeaponskill = CanWeave(ActionWatching.LastWeaponskill);
            bool canWeaveSpell = CanSpellWeave(ActionWatching.LastSpell);

            if (canWeaveWeaponskill || canWeaveSpell)
            {
                Svc.Log.Debug($"USE ITEM FUNCTION WORKS");

                return ItemManager.UseItem(itemID);
            }

            return false;
        }

        /// <summary>
        /// Gets item's status. Is it ready to use?
        /// </summary>
        /// <param name="itemID"></param>
        /// <returns></returns>
        public static unsafe uint GetItemStatus(uint itemID)
        {
            // Access the cached action manager instance and check the action status
            return ItemManager._actionManagerInstance is null ? uint.MaxValue : ItemManager._actionManagerInstance->GetActionStatus(ActionType.Item, itemID);
        }

        #endregion
    }

}
