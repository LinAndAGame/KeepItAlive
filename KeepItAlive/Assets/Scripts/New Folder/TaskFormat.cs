using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNameSpace {
    public class TaskFormat{
        private string m_TaskDescription;
        private string m_TaskName;

        public string TaskName { get => m_TaskName; set => m_TaskName = value; }
        public string TaskDescription { get => m_TaskDescription; set => m_TaskDescription = value; }
    }
}