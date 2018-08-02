using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class RolePanel:PanelBase
    {
        #region 生命周期
        //初始化
        public override void Init(params object[] args)
        {
            base.Init(args);
            skinPath = "Skin/LoginPanel";
            layer = PanelLayer.Panel;
        }

        public override void OnShowing()
        {
            base.OnShowing();
            Transform skinTrans = skin.transform;
            //idInput = skinTrans.Find("Input_UserID").GetComponent<InputField>();
            //pwInput = skinTrans.Find("Input_Passwaord").GetComponent<InputField>();
            //loginBtn = skinTrans.Find("Btn_Login").GetComponent<Button>();
            //regBtn = skinTrans.Find("Btn_Registered").GetComponent<Button>();

            //loginBtn.onClick.AddListener(OnLoginClick);
            //regBtn.onClick.AddListener(OnRegClick);
        }
        #endregion
    }
}
