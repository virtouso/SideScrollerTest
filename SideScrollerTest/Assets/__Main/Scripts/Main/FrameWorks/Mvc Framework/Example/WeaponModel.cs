using UnityEngine;

namespace Mvc.Example
{

    public interface IWeaponModel
    {
        
    }
    
    [System.Serializable]
    public class WeaponModel : BaseModel, IWeaponModel
    {

        [Header("Shooting")] public float shotCooldown;
        public bool isSingleShot;

        public bool isTriggerDown { get; set; }
        public float NextShotAvailable { get; set; }

        [Header("Physics")] public float recoil = 0f;

    }
}