using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace DefaultNameSpace {
    public class RestartGame : MonoBehaviour {

        private void Start() {
        }

        public void RestratGame() {
            //this.transform.parent.gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }

        public void ExitGame() {
            Application.Quit();
        }
    }
}