using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

namespace DefaultNameSpace {
    public class ValueTextController : MonoBehaviour {
        private Text m_TxtValue = null;
        private Vector2 m_OriginRectPos;
        private Color m_OriginColor;
        private float m_Timer = 0;
        private float m_Duration = 0.5f;

        private void Start(){
            m_TxtValue = this.GetComponent<Text>();
            m_OriginRectPos = m_TxtValue.rectTransform.anchoredPosition;
            m_OriginColor = m_TxtValue.color;
        }
        
        private void Update(){
            m_Timer += Time.deltaTime;
            if (m_Timer>=m_Duration) {
                Destroy(this.gameObject);
            }
            m_TxtValue.rectTransform.anchoredPosition = Vector2.Lerp(m_OriginRectPos,m_OriginRectPos+new Vector2 (0,150), m_Timer);
            m_TxtValue.color = Color.Lerp(m_OriginColor,m_OriginColor-new Color(0,0,0,0.5f),m_Timer);
        }
    }
}