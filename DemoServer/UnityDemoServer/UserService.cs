using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityDemoServer
{
    class UserService
    {
  
		public static async Task Login(ClientStatusVariable client)
		{
			//读取请求
			short namelen, pwlen;
			var buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(4);
			try
			{
				if (!await client.conn.FullReceiveAsync(buffer, 4)) throw new Exception();
				(namelen, pwlen) = GetLength(buffer);
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
			}
			string name;
			string pw;
			buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(namelen + pwlen);
			try
			{
				if (!await client.conn.FullReceiveAsync(buffer, namelen + pwlen)) throw new Exception();
				name = GetString(buffer, namelen);
				pw = GetString(IntPtr.Add(buffer, namelen), pwlen);
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
			}
			//处理
			Guid id;
			using (var scope = Config.CreateScope())
			{
				var db = scope.GetService<UnityDemoContext>();
				id = await db.UserInfo.Where(x => x.UserName == name && x.PassWord == pw).Select(x => x.Id).FirstOrDefaultAsync();
			}
			client.UserId = id;
			buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(2);
			try
			{
				SetResult(buffer, id != Guid.Empty);
				if (!await client.conn.FullSendAsync(buffer, 2)) throw new Exception();
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
			}
		}
       
		public static async Task Register(ClientStatusVariable client)
		{
			//读取请求
			short namelen, pwlen;
			var buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(4);
			try
			{
				if (!await client.conn.FullReceiveAsync(buffer, 4)) throw new Exception();
				(namelen, pwlen) = GetLength(buffer);
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
			}
			string name;
			string pw;
			buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(namelen + pwlen);
			try
			{
				if (!await client.conn.FullReceiveAsync(buffer, namelen + pwlen)) throw new Exception();
				name = GetString(buffer, namelen);
				pw = GetString(IntPtr.Add(buffer, namelen), pwlen);
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
			}
			//处理
			if (client.UserId != Guid.Empty) throw new Exception("用户已登陆，不能注册");
			bool r = false;
			using (var scope = Config.CreateScope())
			{
				var db = scope.GetService<UnityDemoContext>();
				db.UserInfo.Add(new DbEntity.UserInfo
				{
					PassWord = pw,
					UserName = name,
				});
				try
				{
					await db.SaveChangesAsync();
					r = true;
				}
				catch { }
			}
			buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(2);
			try
			{
				SetResult(buffer, r);
				if (!await client.conn.FullSendAsync(buffer, 2)) throw new Exception();
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.FreeHGlobal(buffer);
			}
		}
		static unsafe (short namelen, short pwlen) GetLength(IntPtr buffer)
		{
			var b = (short*)buffer;
			if (*b < 0 | *(b + 1) < 0) throw new Exception();
			return (*b, *(b + 1));
		}

		static unsafe string GetString(IntPtr buffer, int length)
		{
			return Encoding.Unicode.GetString((byte*)buffer, length);
		}

		static unsafe void SetResult(IntPtr buffer, bool result)
		{
			*(byte*)buffer = 0x01;
			*(byte*)IntPtr.Add(buffer, 1) = result ? (byte)1 : (byte)0;
		}
    }
}
