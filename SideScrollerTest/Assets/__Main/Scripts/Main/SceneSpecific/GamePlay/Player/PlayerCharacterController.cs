using System;
using System.Collections;
using System.Collections.Generic;
using GamePlay.Manager;
using Mvc;
using MVVM;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


namespace GamePlay.Elements.Player
{
    public interface IPlayerCharacterController
    {
        Transform Transform { get; }

        void Init(Vector3 position);
    }

    [System.Serializable]
    public class PlayerCharacterControllerModel : BaseModel
    {
        public float HorizontalSpeed;
        public float JumpForce;
        public float FireRate;
        public float GroundDectectionDistance;
        public LayerMask GroundMask;
        public Vector2 GroundDetectionBoxSize;

        [SerializeField] public Transform ShootMuzzle;

        [SerializeField] public Rigidbody2D Rigidbody;
        [SerializeField] public Transform LegsTransform;
        [SerializeField] public int InitialHealth;

        public int SkyJumpLimit;

        public bool IsGrounded;
        public int JumpCounter;
        public float ShootTimer;
    }

    public class PlayerCharacterControllerController : BaseController<PlayerCharacterControllerModel>
    {
        [Inject] private IBullet.Pool _bulletPool;
        [Inject] private ISinglePlayerMissionsManager _missionsManager;
        public void Move(float input, Transform characterTransform)
        {
            characterTransform.position+=(new Vector3(input * Model.HorizontalSpeed * Time.deltaTime, 0, 0));

            if (input > 0)
                characterTransform.rotation = Quaternion.Euler(0, 0, 0);
            else if (input < 0)
                characterTransform.rotation = Quaternion.Euler(0, 180, 0);
        }

        public void Jump(Rigidbody2D rigidBody)
        {
            Debug.Log(Model.JumpCounter);
            if (Model.JumpCounter > Model.SkyJumpLimit) return;
            Model.JumpCounter++;
            Model.Rigidbody.AddForce(Vector3.up * Model.JumpForce, ForceMode2D.Impulse);
        }


        public void Shoot(Vector3 position, Vector3 direction, IActorGroup actor)
        {
            if (Model.ShootTimer < Model.FireRate) return;
            Model.ShootTimer = 0;
            var instance = _bulletPool.Spawn();
            instance.Shoot(position, direction, 0, actor);
        }


        public void Escape()
        {
            _missionsManager.PlayerPaused();
        }

        public bool CheckGrounded()
        {
            var result =
                Physics2D.BoxCast(Model.LegsTransform.position,
                    Model.GroundDetectionBoxSize, 0, Vector3.down, Model.GroundDectectionDistance,
                    Model.GroundMask);

            return result;
        }

        
        
        
        public void DisplayLogGroundDetector()
        {
            if (Model.IsGrounded)
                Gizmos.color = Color.red;
            else Gizmos.color = Color.blue;
            Gizmos.DrawCube(Model.LegsTransform.position + Vector3.down * Model.GroundDectectionDistance,
                Model.GroundDetectionBoxSize);
        }
    }


    public class PlayerCharacterController :
        BaseView<PlayerCharacterControllerModel, PlayerCharacterControllerController>, IPlayerCharacterController
    {
        private Transform _cachedTransform;
        public Transform Transform => _cachedTransform;


        public void Init(Vector3 position)
        {
            _cachedTransform.position = position;
        }

        [Inject] private BaseInputReader InputReader;
        [Inject] private IInputMediator InputMediator;
        [Inject] private IActorGroup _actorGroup;
        [Inject] private IDamageable _damageable;
        [Inject] private IGamePlayUiManager _uiManager;
        [Inject] private ISinglePlayerMissionsManager _missionsManager; 
        
        private void Awake()
        {
            _cachedTransform = transform;
        }


        private void Start()
        {
            this.InputReader.Init();

            this.InputMediator.Jump += delegate { Controller.Jump(Model.Rigidbody); };
            this.InputMediator.HorizontalMove += delegate(float f) { Controller.Move(f, _cachedTransform); };
            this.InputMediator.Shoot += delegate { Controller.Shoot(Model.ShootMuzzle.position, Model.ShootMuzzle.right, _actorGroup); };
            this.InputMediator.Escape+= delegate { Controller.Escape(); };
            _damageable.CurrentHealth = new Model<int>(Model.InitialHealth);
            _uiManager.SetMaximumHealth(_damageable.CurrentHealth.Data);
            _damageable.CurrentHealth.Action += _uiManager.SetHealth;
            _damageable.OnDeath += _missionsManager.PlayerFailed;
            
        }

        public void Update()
        {
            Model.IsGrounded = Controller.CheckGrounded();
            if (Model.IsGrounded)
                Model.JumpCounter = 0;

            Model.ShootTimer += Time.deltaTime;
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying) return;
            Controller.DisplayLogGroundDetector();
        }
    }
}