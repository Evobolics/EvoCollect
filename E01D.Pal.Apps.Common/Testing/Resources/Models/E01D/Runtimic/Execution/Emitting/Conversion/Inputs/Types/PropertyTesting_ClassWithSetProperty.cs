﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class PropertyTesting_ClassWithSetProperty
	{
		private string _Message;

		public object Execute()
		{
			Message = "Howdy";

			return _Message;
		}

		public string Message
		{
			set { _Message = value; }
		}
	}
}
