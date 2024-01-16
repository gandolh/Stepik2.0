namespace Licenta.API.Mappers
{
    public abstract class BaseMapper<T1, T2>
    {
        public BaseMapper() { }

        public abstract T1 Map(T2 element);
        public abstract T2 Map(T1 element);


        public List<T1> Map(List<T2> elements, Action<T1> callback = null)
        {
            var objectCollection = new List<T1>();
            if (elements != null)
            {
                foreach (T2 element in elements)
                {
                    T1 newObject = Map(element);
                    if (newObject != null)
                    {
                        if (callback != null)
                            callback(newObject);
                        objectCollection.Add(newObject);
                    }
                }
            }
            return objectCollection;
        }

        public List<T2> Map(List<T1> elements, Action<T2> callback = null)
        {
            var objectCollection = new List<T2>();

            if (elements != null)
            {
                foreach (T1 element in elements)
                {
                    T2 newObject = Map(element);
                    if (newObject != null)
                    {
                        if (callback != null)
                            callback(newObject);
                        objectCollection.Add(newObject);
                    }
                }
            }
            return objectCollection;
        }
    }
}
