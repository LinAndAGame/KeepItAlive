using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNameSpace {
    public class CameraFollow : MonoBehaviour {
        public Transform m_Target = null;

        private void Start(){
            
        }
        
        private void Update(){
            this.transform.position = new Vector3(m_Target.position.x,m_Target.position.y,this.transform.position.z);
        }
    }
}