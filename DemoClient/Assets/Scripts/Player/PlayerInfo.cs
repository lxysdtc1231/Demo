using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Player
{
    public class PlayerInfo
    {
        //用户名
        public int PlayerID {get;set;}
        //角色昵称
        public string PlayerName { get; set; }
        //用户血量
        public int HP { get; set; }
        //用户等级
        public int Level { get; set; }
        //X轴坐标

    }
}
