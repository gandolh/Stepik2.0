using Microsoft.Extensions.Localization;
using System.Collections.Frozen;

namespace Licenta.SDK.Localization
{
    /// <summary>
    /// structura ce se ocupa cu accesarea traducerilor. 
    /// Este un dictionar custom pentru a trada cazurile in care cheia nu se afla in traduceri.
    /// </summary>
    public class MyStringLocalizer
    {
        private readonly FrozenDictionary<string, string> stringMap;


        public MyStringLocalizer(FrozenDictionary<string, string> stringMap)
        {
            this.stringMap = stringMap;
        }

        public LocalizedString this[string name]
        {
            get
            {
                if (stringMap.ContainsKey(name))
                    return new LocalizedString(name, stringMap[name]);
                else
                    return new LocalizedString(name, name);
            }
        }

        public LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                return new LocalizedString(name, string.Format(stringMap[name], arguments));
            }
        }
    }
}
