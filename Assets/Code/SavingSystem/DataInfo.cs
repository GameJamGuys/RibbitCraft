using UnityEngine;

    public abstract class DataInfo<T>
    {
        protected string id;
        protected T value;
        
        public abstract void Save(T value);
        public abstract T Load();
    }
