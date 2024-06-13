using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSiparisUYG
{
	internal static class Connection1
	{
		public static string ConnectionString1 { get; set; }

		public static string ConnectionString()
		{
			return ConnectionString1;

		}
		public static string SetConnection(string con) 
		{
			return con = ConnectionString1;
		}


	}
}
