using Zenject;

namespace Mvc
{
    public class BaseController<T> where T : BaseModel
    {
        [Inject] protected T Model;

        // public virtual void Setup(T model )
        // {
        //     Model = model;
        // }
        //
        // public virtual void SetupSecondary(params object[] input)
        // {
        //     
        // }
    }
}