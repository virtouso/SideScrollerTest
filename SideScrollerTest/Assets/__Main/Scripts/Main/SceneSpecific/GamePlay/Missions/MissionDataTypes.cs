using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager.SinglePlayer.Missions
{
    public enum MissionTypes
    {
        KillSomeOne,
        RescueHostage,
        DefuseBomb,
        ReachPlace,
        DestroyPlace,
        FindInformation,
        GetExtracted,
        ProtectPlace,
        ProtectPerson
    }

    [System.Flags]
    public enum MissionPriorityType : byte
    {
        Primary = 0,
        Secondary = 1
    }

    public enum MissionGroupId
    {
        NoId,
        M1,
        M2,
        M3,
        M4,
        M5,
        M6,
        M7,
        M8,
        M9
    }
}