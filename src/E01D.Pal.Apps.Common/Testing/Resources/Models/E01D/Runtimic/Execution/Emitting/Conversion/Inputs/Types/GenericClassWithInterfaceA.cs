﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types
{
	public class GenericClassWithInterfaceA<TContainer>: GenericClassWithInterfaceA_I<TContainer>
		where TContainer: GenericClassWithInterfaceA_I<TContainer>
	{
	}
}