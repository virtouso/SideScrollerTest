using UnityEngine;

namespace Mvc.Example
{
    
    public interface IWeaponView{}
    
    public class WeaponView<T, M> : BaseView<T, M>, IWeaponView
        where T : WeaponModel
        where M : WeaponController<T>, new()
    {
        [Header("Prefabs")] // --------------------------------------
        public Transform shotPrefab;

        // Rigidbody ---------------------------------------

        public Rigidbody Rigidbody
        {
            get
            {
                if (_myRigidbody == null)
                {
                    GetRigidbody();
                }

                return _myRigidbody;
            }
        }

        private Rigidbody _myRigidbody;

        // ----------------------------------------------------------

        public void Update()
        {
            if (Input.GetButtonDown("Shoot"))
            {
                ShootTrigger(true);
            }

            if (Input.GetButtonUp("Shoot"))
            {
                ShootTrigger(false);
            }
        }

        public virtual void ShootTrigger(bool isPressed)
        {
            if (Controller.ShootTrigger(isPressed, Time.time))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            if (Rigidbody != null)
            {
                Rigidbody.AddForce(-transform.forward * Model.recoil, ForceMode.Impulse);
            }

            InstantiateShot(transform.rotation);
        }

        public virtual void InstantiateShot(Quaternion rot)
        {
            Transform shot = Instantiate(shotPrefab, transform.position, rot) as Transform;
        }

        private void GetRigidbody()
        {
            _myRigidbody = GetComponent<Rigidbody>();
            if (_myRigidbody == null)
            {
                Debug.LogError("Wanted to get rigidbody on weapon, but couldn't find one on: " + this.gameObject);
            }
        }
    }
}