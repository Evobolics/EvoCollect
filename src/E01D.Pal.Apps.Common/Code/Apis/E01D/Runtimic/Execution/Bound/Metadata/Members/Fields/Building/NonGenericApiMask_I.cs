﻿using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Fields.Building
{
	public interface NonGenericApiMask_I
	{
		void BuildFields(BoundRuntimicModelMask_I semanticModel, BoundTypeDefinition_I input);

		void BuildField(BoundRuntimicModelMask_I semanticModel, BoundTypeDefinitionWithFields_I typeWithFields,
			FieldDefinition field, FieldInfo fieldInfo);
	}
}
