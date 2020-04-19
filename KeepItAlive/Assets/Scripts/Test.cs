using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;
using MyGameKernel;
using MyGameGlobal;

namespace DefaultNameSpace {
    public class Test : MonoBehaviour {


        private void Start() {
            //List<DialogFormat> dia= DialogData.GetNextDialogDatas(ENUM_DialogType.Introduce_Start);
            //foreach (DialogFormat item in dia) {
            //    Debug.Log(item.ToString());
            //}
            TestDialogData();
        }

        private void Update() {
            //TestGoosipData();
        }

        private void TestGoosipData() {
            //Debug.Log(GossipData.GetGossipData(ENUM_GossipType.DecreaseRP, 0));
            UITool.CreateGossipUI(ENUM_GossipType.DecreaseRP,0);
        }

        private void TestDialogData() {
            //DialogFormat dialog= DialogData.GetNextDialogData(ENUM_DialogType.PlayerTrigger_A);
            //Debug.Log(dialog.DialogContent);
            //dialog = DialogData.GetNextDialogData(ENUM_DialogType.PlayerTrigger_A);
            //Debug.Log(dialog.DialogContent);
            //dialog = DialogData.GetNextDialogData(ENUM_DialogType.PlayerTrigger_A);
            //Debug.Log(dialog.DialogContent);
            //dialog = DialogData.GetNextDialogData(ENUM_DialogType.PlayerTrigger_A);
            //Debug.Log(dialog.DialogContent);
        }
    }
}