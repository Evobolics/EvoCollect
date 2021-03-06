﻿using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public interface CreationApiMask_I
	{
		ConvertedAssembly CreateConvertedAssembly(ILConversion conversion);



		ConvertedAssembly CreateConvertedAssembly(ILConversion conversion, string name, ConvertedAssemblyNode assenblyNode);

	}
}
