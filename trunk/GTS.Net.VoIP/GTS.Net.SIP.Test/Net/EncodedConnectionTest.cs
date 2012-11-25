// /*
//  * ${file_name}
//  * 
//  * Copyright (c) 2012, Simon Fetzel. All rights reserved.
//  *
//  * This library is free software; you can redistribute it and/or
//  * modify it under the terms of the GNU Lesser General Public
//  * License as published by the Free Software Foundation; either
//  * version 2.1 of the License, or (at your option) any later version.
//  *
//  * This library is distributed in the hope that it will be useful,
//  * but WITHOUT ANY WARRANTY; without even the implied warranty of
//  * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
//  * Lesser General Public License for more details.
//  *
//  * You should have received a copy of the GNU Lesser General Public
//  * License along with this library; if not, write to the Free Software
//  * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
//  * MA 02110-1301  USA
//  */
//
using NUnit.Framework;
using System;
using GTS.Net.SIP;

namespace GTS.Net.SIP.Test
{
	[TestFixture()]
	public class EncodedConnectionTest
	{
		[Test()]
		public void ConstructorTest ()
		{
			EncodedConnectionMock connection = new EncodedConnectionMock();
			Assert.IsNotNull(connection.Encoding);
		}

		[Test()]
		public void NewDataReceivedTest()
		{
			string testString = "The big black dog ate the small white cat";
			EncodedConnectionMock connection = new EncodedConnectionMock();
			byte[] data = connection.Encoding.GetBytes(testString);

			connection.OnEncodedDataReceived += (object sender, EncodedDataReceivedEventArgs eventArgs) =>
			{
				Assert.AreEqual(testString, eventArgs.EncodedData);
			};
			connection.SimulateReceivement(data);
		}

		[Test()]
		public void NewDataReceived_EventIsNullTest()
		{
			EncodedConnectionMock mock = new EncodedConnectionMock();
			mock.SimulateReceivement(null);
		}
	}
}

