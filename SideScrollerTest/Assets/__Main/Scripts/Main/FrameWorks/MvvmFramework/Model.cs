using System;

namespace MVVM
{
    public class Model<T> 
    {
        private T _data;
        public Action<T> Action;

        public T Data
        {
            get => _data;
            set
            {
                _data = value;
                Action?.Invoke(_data);
            }
        }


        public Model(T data)
        {
            _data = data;
        }
    }


    public class AdditiveModel<T> where T : IComparable
    {
        private T _data;
        public Action<T> Action;
        public Action<T, T> AdditiveAction;

        public T Data
        {
            get => _data;
            set
            {
                _data = value;
                Action?.Invoke(_data);
            }
        }
        
        
        public T AdditiveData
        {
            get => _data;
            set
            {
                T newData = Add(_data, value);
               AdditiveAction?.Invoke(_data, newData);
                _data = newData;
            }
        }


        public AdditiveModel(T data)
        {
            _data = data;
        }


        static T Add<T>(T x, T y)
        {
            dynamic dx = x, dy = y;
            return dx + dy;
        }
    }
}