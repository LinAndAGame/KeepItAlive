using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNameSpace {
    public class ButtelController : MonoBehaviour {
        private float m_Speed = 10;
        private int m_Damage = 3;

        private void Start(){
        }
        
        private void Update(){
            this.transform.position += this.transform.right * m_Speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag!="Player" && collision.tag!="CreateEnemyTrigger") {
                Destroy(this.gameObject); 
            }
        }

        public int GetDamage() {
            return m_Damage;
        }
    }
}