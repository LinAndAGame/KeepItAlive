using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameGlobal {
   [SerializeField]
    public class DialogFormat {
        private ENUM_DialogType m_DialogType;
        private ENUM_Speaker m_DialogSpeaker;
        private string m_DialogContent;

        public ENUM_DialogType DialogType { get => m_DialogType; set => m_DialogType = value; }
        public ENUM_Speaker DialogSpeaker { get => m_DialogSpeaker; set => m_DialogSpeaker = value; }
        public string DialogContent { get => m_DialogContent; set => m_DialogContent = value; }

        public override string ToString() {
            return  "DialogType:"+ DialogType.ToString()+"\n"+
                    "DialogSpeaker:" + DialogSpeaker.ToString() + "\n"+
                    "DialogContent:" + DialogContent + "\n";
        }
    }

    public enum ENUM_DialogType {
        Introduce_Start,
        Introduce_End,
        PlayerTrigger_A,
        PlayerTrigger_B,
    }

    public enum ENUM_Speaker {
        Interphone,
        Player,
        Scientist_A,
        Scientist_B,
    }
}