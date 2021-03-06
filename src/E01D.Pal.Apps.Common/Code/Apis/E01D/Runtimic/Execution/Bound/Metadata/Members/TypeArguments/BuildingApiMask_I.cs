﻿using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.TypeArguments
{
	public interface BuildingApiMask_I
	{
		//Type[] Build(BoundRuntimicModelMask_I semanticModel, BoundGenericTypeDefinition_I boundInput, System.Type type);
		BoundTypeDefinitionMask_I[] Build(RuntimicSystemModel semanticModel, GenericInstanceType converted);

		ExecutionTypeNode_I[] Build(ExecutionEnsureContext context, GenericInstanceType inputType,
			out Type[] underlyingTypes);
	}
}
