using UnityEngine;
using UnityEngine.SceneManagement;


    class LevelSelect : MonoBehaviour
    {
        public void LoadLevel(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }

    }
