using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Experimental.Rendering.Universal;
using MyGameKernel;

namespace DefaultNameSpace {
    public class CautionLightController : MonoBehaviour {
        private Light2D m_Light2D = null;
        private float m_Timer = 0;
        private float m_Delay = 0;
        private const float m_Duration = 1;
        private float m_LightIntensity = 0;
        private float m_TimeDifference = 0;

        private void Start() {
            m_Delay = Random.Range(0f, 4f);
            m_Light2D = this.GetComponentInChildren<Light2D>();
            m_LightIntensity = m_Light2D.intensity;
        }

        private void Update() {
            m_Timer += Time.deltaTime;
            if (m_Timer >= m_Delay) {
                m_TimeDifference = m_Timer - m_Delay;
                if (m_TimeDifference <= m_Duration / 2) {
                    m_Light2D.intensity = Mathf.Lerp(m_LightIntensity, 0, Ease.EaseValue(m_TimeDifference, m_Duration / 2, EaseType.SinIn));
                }
                else if (m_Duration / 2 < m_TimeDifference && m_TimeDifference <= m_Duration) {
                    m_Light2D.intensity = Mathf.Lerp(0, m_LightIntensity, Ease.EaseValue(m_TimeDifference-m_Duration/2, m_Duration / 2, EaseType.SinOut));
                }
                else {
                    m_Timer = m_Delay;
                }
            }
        }
    }
}