using Zenject;

namespace Mvc
{
    public class BaseController<T> where T : BaseModel
    {
        [Inject] protected T Model;

        
    }
}