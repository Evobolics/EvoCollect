﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Internal
{
	public interface InternalApiMask_I
	{
		ResultApiMask_I Results { get; }

		ILConversionResult Convert(ILConversion conversion, Assembly assembly);

		ILConversionResult Convert(ILConversion conversion, Assembly[] assembly);

		ILConversionResult Convert(ILConversion conversion, System.Type type);

		ILConversionResult Convert(ILConversion conversion, System.Type type, AssemblyBuilderAccess builderAccess);

		ILConversionResult Convert(ILConversion conversion, System.Type[] type);

		ILConversionResult Convert(ILConversion conversion, Type[] type, AssemblyBuilderAccess builderAccess);

		ILConversionResult Convert(ILConversion conversion, TypeReference typeDefinition);

		ILConversionResult Convert(ILConversion conversion, List<TypeReference> inputTypes);

		ILConversionResult Convert(ILConversion conversion, AssemblyDefinition assemblies);

		ILConversionResult Convert(ILConversion conversion, AssemblyDefinition[] assemblies);
	}
}