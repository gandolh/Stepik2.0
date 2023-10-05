namespace Licenta.Sdk.Models.Mappers
{
    public abstract class MapperBase<TFirst, TSecond>
    {
        public abstract TFirst Map(TSecond element);
        public abstract TSecond Map(TFirst element);


        #region map single

        public TFirst Map(TSecond element, Action<TFirst> callback = null)
        {
            TFirst newObject = Map(element);
            if (newObject != null && callback != null)
            {
                callback(newObject);
            }
            return newObject;
        }

        public TSecond Map(TFirst element, Action<TSecond> callback = null)
        {
            TSecond newObject = Map(element);
            if (newObject != null && callback != null)
            {
                callback(newObject);
            }
            return newObject;
        }


        #endregion


        #region map multiple
        public List<TFirst> Map(List<TSecond> elements, Action<TFirst> callback = null)
        {
            var objectCollection = new List<TFirst>();
            if (elements != null)
            {
                foreach (TSecond element in elements)
                {
                    TFirst newObject = Map(element);
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

        public List<TSecond> Map(List<TFirst> elements, Action<TSecond> callback = null)
        {
            var objectCollection = new List<TSecond>();

            if (elements != null)
            {
                foreach (TFirst element in elements)
                {
                    TSecond newObject = Map(element);
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

        #endregion
    }
}
