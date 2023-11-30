using Licenta.Sdk.Config;
using StackExchange.Redis;
using System.Text.Json;

namespace Licenta.DataAccessService
{
    public class RedisClient
    {
        private IServer _redisServer;
        private IDatabase _redisDatabase;

        /// <summary>
        /// Constructor pentru clasa RedisClient
        /// </summary>
        /// <param name="redisEndpoint">Endpoint-ul de conectare la Redis</param>
        public RedisClient(RedisConfig redisConfig)
        {
            var redis = ConnectionMultiplexer.Connect(
                new ConfigurationOptions
                {
                    EndPoints = { redisConfig.RedisEndpoint }
                });

            _redisServer = redis.GetServer(redisConfig.RedisEndpoint);
            _redisDatabase = redis.GetDatabase();
        }

        /// <summary>
        /// Furnizeaza toate cheile din Redis
        /// </summary>
        /// <returns>Lista tuturor cheilor din Redis</returns>
        public async Task<List<RedisKey>> GetKeys()
        {
            List<RedisKey> keys = new();
            await Task.Run(() => { keys = _redisServer.Keys().ToList(); });
            return keys;
        }

        /// <summary>
        /// Furnizeaza valoarea unei chei din Redis sau default(T) daca 
        /// aceasta nu exista in Redis
        /// </summary>
        /// <typeparam name="T">Tipul valorii ce trebuie intors</typeparam>
        /// <param name="key">Cheia valorii de extras</param>
        /// <returns>Valoarea din Redis care are cheia indicata sau default(T)</returns>
        public async Task<T> Get<T>(string key)
        {
            var str = await _redisDatabase.StringGetAsync(key);

            if (str.IsNull)
                return default(T);

            T val = JsonSerializer.Deserialize<T>(str);

            return val;
        }

        public async Task<string?> Get(string key)
        {
            RedisValue str = await _redisDatabase.StringGetAsync(key);

            if (str.IsNull)
                return null;

            return str;
        }


        /// <summary>
        /// Adauga (sau suprascrie) o cheie in Redis
        /// </summary>
        /// <param name="key">Cheia de salvare in Redis</param>
        /// <param name="value">Valoarea salvata in Redis</param>
        /// <param name="maxAge">Durata cat sunt pastrate datele in cache, exprimata in minute</param>
        /// <returns>Task</returns>
        public async Task Set(string key, object value, int maxAge)
        {
            var str = JsonSerializer.Serialize(value);
            await _redisDatabase.StringSetAsync(key, str, new TimeSpan(0, maxAge, 0));
        }

        /// <summary>
        /// Verifica daca o cheie exista in Redis
        /// </summary>
        /// <param name="key">Cheia a carei existenta in Redis se verifica</param>
        /// <returns>True, daca cheia exista in Redis. False, altfel.</returns>
        public async Task<bool> KeyExists(string key)
        {
            var exists = await _redisDatabase.KeyExistsAsync(key);
            return exists;
        }

        /// <summary>
        /// Copiaza valoarea de la cheia sursa la cheia destinatie
        /// </summary>
        /// <param name="srcKey">Cheia sursa</param>
        /// <param name="destKey">Cheia destinatie</param>
        /// <param name="maxAge">Durata cat sunt pastrate datele in cache</param>
        /// <returns>True, daca copierea s-a realizat cu succes. False, altfel</returns>
        public async Task<bool> CopyValue(string srcKey, string destKey, int maxAge)
        {
            //TODO: de analizat
            var content = await _redisDatabase.StringGetAsync(srcKey);
            var success = await _redisDatabase.StringSetAsync(destKey, content, new TimeSpan(0, maxAge, 0));
            return success;
        }

        /// <summary>
        /// Reseteaza timpul de exirare al cheii in cache (daca aceasta exista deja) 
        /// sau adauga in cache cheia si valoarea obtinuta prin apelul functiei callback
        /// </summary>
        /// <typeparam name="T">Tipul valorii pereche a cheii</typeparam>
        /// <param name="key">Cheia din Redis unde se gaseste/va fi adaugat rezultatul</param>
        /// <param name="callback">Functie ce trebuie apelata pentru a obtine 
        /// rezultatul de adaugat in cache, in cazul in care acesta nu exista deja</param>
        /// <param name="maxAge">Durata cat sunt pastrate datele in cache</param>
        /// <returns>Task</returns>
        public async Task Caching<T>(string key, Func<Task<T>> callback, int maxAge)
        {
            T val = await Get<T>(key);

            if (val == null)
            {
                val = await callback();
            }

            await Set(key, val, maxAge);
        }
    }
}
