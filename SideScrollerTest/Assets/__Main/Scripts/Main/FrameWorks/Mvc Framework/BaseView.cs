using System.Runtime.Remoting.Messaging;
using UnityEngine;
using Zenject;


namespace Mvc
{
    public class BaseView<T, M> : MonoBehaviour
        where T : BaseModel
        where M : BaseController<T>, new()
    {
        public T Model;
        protected M Controller;

        [Inject]
        public void Construct([Inject]T model,[Inject] M controller)
        {
            Model = model;
            Controller = controller;
        }
        
        protected virtual void Awake()
        {
            //  Controller = new M();
            // Controller.Setup(Model);
        }
    }
}