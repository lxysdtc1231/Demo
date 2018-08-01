using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Player
{
    //角色信息类
    public class RoleInfo
    { 
        //角色ID
        public int RoleID { get; set; }
        //角色昵称
        public string RoleName { get; set; }
        //角色血量
        public int HP { get; set; }
        //角色等级
        public int Level { get; set; }
        //角色坐标
        public float PosX { get; set; }
        public float PosY { get; set; }
        public float PosZ { get; set; }
        //角色面向
        public float RotX { get; set; }
        public float RotY { get; set; }
        public float RotZ { get; set; }



    }
}
