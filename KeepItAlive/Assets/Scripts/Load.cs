using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace DefaultNameSpace {
    public class Load : MonoBehaviour {


        private void Start(){
            SceneManager.LoadScene(0);
        }
        
        private void Update(){
            
        }
    }
}