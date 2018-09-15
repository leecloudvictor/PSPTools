﻿/*
This file is part of pspsharp.

pspsharp is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

pspsharp is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with pspsharp.  If not, see <http://www.gnu.org/licenses/>.
 */
namespace pspsharp.format.rco.type
{
	using VSMX = pspsharp.format.rco.vsmx.VSMX;

	//using Logger = org.apache.log4j.Logger;

	public class BaseType
	{
		protected internal static readonly Logger log = VSMX.log;
		protected internal int value;

		public virtual int size()
		{
			return 4;
		}

		protected internal virtual int read8(RCOContext context)
		{
			return context.buffer[context.offset++] & 0xFF;
		}

		protected internal virtual int read16(RCOContext context)
		{
			return read8(context) | (read8(context) << 8);
		}

		protected internal virtual int read32(RCOContext context)
		{
			return read16(context) | (read16(context) << 16);
		}

		public virtual void read(RCOContext context)
		{
			value = read32(context);
		}

		public virtual void init(RCOContext context)
		{
		}

		public virtual int IntValue
		{
			get
			{
				return value;
			}
			set
			{
				this.value = value;
			}
		}


		public virtual float FloatValue
		{
			get
			{
				return (float) value;
			}
			set
			{
				this.value = (int) value;
			}
		}


		public override string ToString()
		{
			return string.Format("value=0x{0:X}", IntValue);
		}
	}

}