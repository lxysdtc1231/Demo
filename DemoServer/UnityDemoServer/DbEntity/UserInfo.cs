﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemoServer.DbEntity
{
    class UserInfo
    {
		public Guid Id { get; set; }
		public string UserName { get; set; }
		public string PassWord { get; set; }
	}
}
