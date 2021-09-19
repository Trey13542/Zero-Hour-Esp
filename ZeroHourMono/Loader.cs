using UnityEngine;

namespace ZeroHourMono
{
    public class Loader
    {
        private static GameObject LoadObj = new GameObject();
        public static void Load()
        {
            LoadObj.AddComponent<Main>();
            LoadObj.AddComponent<ESP>();
            LoadObj.AddComponent<Menu>();
            Object.DontDestroyOnLoad(LoadObj);
        }
        public static void Unload()
        {
            Object.Destroy(LoadObj);
        }
    }
}