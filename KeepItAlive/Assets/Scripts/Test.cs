using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace DefaultNameSpace {
    public class Test : MonoBehaviour {
        public NavMeshAgent m_Nav = null;
        public Transform m_Target = null;
        private void Start(){
            
        }
        
        private void Update(){
            m_Nav.SetDestination(m_Target.position);
        }
    }
}