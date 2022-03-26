using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using GamePlay.Elements.Player;
using Mvc;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GamePlay.Elements
{
    public interface IFollowCamera
    {
    }

    public class FollowCameraModel : BaseModel
    {
        public float Speed = 0.2f;
        public float ZOffset = -10;
    }

    public class FollowCameraController : BaseController<FollowCameraModel>
    {
        public Vector3 SetInitPosition(Transform goalTransform)
        {
            Vector3 goalPosition = new Vector3(goalTransform.position.x, goalTransform.position.y, Model.ZOffset);
            return goalPosition;
        }

        public Vector3 MoveToGoal(Transform ownTransform, Transform goalTransform)
        {
            Vector3 goalPosition = new Vector3(goalTransform.position.x, goalTransform.position.y, Model.ZOffset);
            return Vector3.MoveTowards(ownTransform.position, goalPosition, Model.Speed);
        }
    }

    public class FollowCamera : BaseView<FollowCameraModel, FollowCameraController>, IFollowCamera
    {
        [Inject] private IPlayerCharacterController _characterController;

        private Transform _cachedTransform;

        protected override void Awake()
        {
            base.Awake();
            _cachedTransform = transform;
        }

        async Task RunTaskAsync()
        {
            Debug.Log("Started task...");
            await Task.Delay(2000);
            _cachedTransform.position = Controller.SetInitPosition(_characterController.Transform);
        }


        private void Start() 
        {
        }

        private void Update()
        {
            _cachedTransform.position =
                Controller.MoveToGoal(_cachedTransform, _characterController.Transform);
      
        }
    }
}