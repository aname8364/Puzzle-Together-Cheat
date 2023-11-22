using UnityEngine;

namespace PuzzleTogetherCheat
{
    public class Loader
    {

        private static GameObject? obj;
        public static void Load()
        {
            Loader.obj = new GameObject();
            Loader.obj.AddComponent<Cheats>();
            UnityEngine.Object.DontDestroyOnLoad(Loader.obj);
        }

        public static void Unload()
        {
            GameObject.Destroy(Loader.obj);
        }
    }
}