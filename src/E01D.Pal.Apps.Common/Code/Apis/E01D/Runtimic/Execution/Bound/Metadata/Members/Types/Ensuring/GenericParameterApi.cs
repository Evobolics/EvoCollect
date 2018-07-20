﻿using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public class GenericParameterApi<TContainer> : BoundApiNode<TContainer>, GenericParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I model, TypeReference typeReference)
        {
            if (!typeReference.IsGenericParameter)
            {
                throw new Exception("Should only be used to get a semantic type for a generic argument.");
            }

            GenericParameter parameter = (GenericParameter)typeReference;

            if (parameter.DeclaringType != null)
            {
                var declaringSemanticType = Execution.Types.Ensuring.Ensure(model, parameter.DeclaringType, null, null);

                if (!declaringSemanticType.IsGeneric())
                {
                    throw new Exception("Expected the resolved semantic type to be a generic type.");
                }

                SemanticGenericTypeDefinitionMask_I generic = (SemanticGenericTypeDefinitionMask_I)declaringSemanticType;

                if (!generic.TypeParameters.ByName.TryGetValue(typeReference.Name, out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
                {
                    throw new Exception("Expected the generic type to have a type parameter named.");
                }

                if (!semanticTypeParameter.IsBound())
                {
                    throw new Exception("Expected the generic parameter type to be a bound type.");
                }

                return (BoundTypeDefinitionMask_I)semanticTypeParameter;
            }
			else
            {
	            if (!(parameter.DeclaringMethod is MethodDefinition methodDefinition))
	            {
		            throw new Exception("Expected a method definition");
	            }

	            var declaringType = methodDefinition.DeclaringType;

	            var resolutionName = Types.Naming.GetResolutionName(declaringType);

	            var semanticType = Infrastructure.Models.Semantic.Types.Collection.GetOrThrow(model, resolutionName);

	            if (!(semanticType is BoundTypeDefinitionWithMethodsMask_I withMethods))
	            {
		            throw new Exception("Trying to add a method to a type that does not support methods.");
	            }

	            var method = Methods.Getting.FindMethodByDefinition(model, withMethods, methodDefinition);

	            if (!method.TypeParameters.ByName.TryGetValue(parameter.Name, out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
	            {
		            throw new Exception($"Expected the generic method to have a type parameter named {parameter.Name}.");
	            }

	            if (!semanticTypeParameter.IsBound())
	            {
		            throw new Exception("Expected the generic parameter type to be a bound type.");
	            }

	            return (BoundTypeDefinitionMask_I)semanticTypeParameter;

				
            }

		}
    }
}
