﻿using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.TypeParameters
{
    public interface TypeParameterApiMask_I
    {
	    BuildingApiMask_I Building { get; }

	    void Add(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions,
		    SemanticGenericParameterTypeDefinitionMask_I typeParameter);

	    void Create();

	    void Add(InfrastructureModelMask_I conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions,
		    List<SemanticGenericParameterTypeDefinitionMask_I> inputList);

	    void Clear(ILConversion conversion, SemanticGenericParameterTypeDefinitionsMask_I definitions);

	    SemanticGenericParameterTypeDefinitionMask_I Get(InfrastructureModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions, string name);

	    SemanticGenericParameterTypeDefinitionMask_I Get(InfrastructureModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions, int position);

	    string[] GetNames(InfrastructureModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions);

	    SemanticGenericParameterTypeDefinitionMask_I GetOrThrow(InfrastructureModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions, string name);

	    SemanticGenericParameterTypeDefinitionMask_I GetOrThrow(InfrastructureModelMask_I conversion,
		    SemanticGenericParameterTypeDefinitionsMask_I definitions, int position);

	    BoundTypeDefinitionMask_I Resolve(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I declaringType,
		    GenericParameter parameter);

	    BoundTypeDefinitionMask_I Resolve(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I declaringType,
		    MethodDefinition methodDefinition, GenericParameter parameter);
    }
}
