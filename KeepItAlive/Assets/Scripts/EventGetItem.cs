using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using MyGameGlobal;

namespace DefaultNameSpace {
    public class EventGetItem : MonoBehaviour {
        public ENUM_ItemType m_ItemType;

        private GameObject m_Tip = null;

        private bool m_EnterTriggerRange = false;
        private void Start(){
            
        }
        
        private void Update(){
            if (m_EnterTriggerRange==true) {
                TipFollow();
                if (Input.GetKeyDown(KeyCode.F)) {
                    switch (m_ItemType) {
                        case ENUM_ItemType.Food:
                            ++PlayerInfo.Food;
                            break;
                        case ENUM_ItemType.Intection:
                            ++PlayerInfo.Intection;
                            break;
                        case ENUM_ItemType.Data:
                            PlayerInfo.GetData = true;
                            break;
                        default:
                            break;
                    }
                    Destroy(this.gameObject);
                }
            }
        }


        private void OnTriggerEnter2D(Collider2D collision) {
            if (collision.tag=="Player") {
                m_EnterTriggerRange = true;
                m_Tip=UITool.CreateTipUI("F");
            }
        }

        private void OnTriggerExit2D(Collider2D collision) {
            if (collision.tag=="Player") {
                m_EnterTriggerRange = false;
                if (m_Tip!=null) {
                    Destroy(m_Tip);
                }
            }
        }

        private void TipFollow() {
            if (m_Tip != null) {
                m_Tip.GetComponent<RectTransform>().anchoredPosition = Camera.main.WorldToScreenPoint(this.transform.position) - new Vector3(Screen.width / 2, Screen.height / 2, 0);
            }
        }

    }
}