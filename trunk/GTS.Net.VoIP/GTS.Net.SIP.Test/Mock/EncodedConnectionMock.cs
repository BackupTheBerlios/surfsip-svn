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
using System;
using System.Collections.Generic;

namespace GTS.Net.SIP.Test
{
	public class EncodedConnectionMock : EncodedConnection
	{
		public override event EventHandler<DataReceivedEventArgs> OnDataReceived;

		public List<byte[]> SentData {
			get;
			set;
		}

		public override bool IsConnected {
			get;
			protected set;
		}

		public EncodedConnectionMock ()
		{
		}

		public override void Send(byte[] data)
		{

		}

		public override void Connect()
		{
			IsConnected = true;
		}

		public override void Disconnect()
		{
			IsConnected = false;
		}

		public void SimulateReceivement(byte[] rawData)
		{
			if(OnDataReceived != null)
			{
				DataReceivedEventArgs eventArgs = new DataReceivedEventArgs();
				eventArgs.RawData = rawData;
				OnDataReceived.Invoke(this, eventArgs);
           	}
		}
	}
}

