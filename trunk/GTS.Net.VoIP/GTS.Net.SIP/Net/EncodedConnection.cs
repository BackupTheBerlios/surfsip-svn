// /*
//  * Encoded Connection.cs
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

namespace GTS.Net.SIP
{
	/// <summary>
	/// Encodes all the received data to a specified format (using System.Text.Encoding)
	/// </summary>
	public abstract class EncodedConnection : IConnection
	{
		public abstract event EventHandler<DataReceivedEventArgs> OnDataReceived;

		public event EventHandler<EncodedDataReceivedEventArgs> OnEncodedDataReceived;

		public abstract void Send(byte[] rawData);
		
		public abstract void Connect();
		
		public abstract void Disconnect();
		
		public abstract bool IsConnected { get; protected set; }

		public System.Text.Encoding Encoding { get; set; }

		public EncodedConnection ()
		{
			OnDataReceived += new EventHandler<DataReceivedEventArgs>(NewDataReceived);
			Encoding = System.Text.Encoding.UTF8;

		}

		internal void NewDataReceived(object sender, DataReceivedEventArgs eventArgs)
		{
			if(OnEncodedDataReceived != null)
			{
				EncodedDataReceivedEventArgs encodedDataEventArgs = new EncodedDataReceivedEventArgs();
				encodedDataEventArgs.EncodedData = Encoding.GetString(eventArgs.RawData);
				encodedDataEventArgs.RawData = eventArgs.RawData;

				OnEncodedDataReceived(sender, encodedDataEventArgs);
          	}
		}
	}
}

