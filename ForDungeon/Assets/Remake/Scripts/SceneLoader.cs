using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Remake {
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadScene(string name)
        {
            SceneManager.LoadScene(name);
        }
    }
}
