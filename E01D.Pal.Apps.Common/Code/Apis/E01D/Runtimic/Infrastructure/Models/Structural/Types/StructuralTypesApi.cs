﻿using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
    public class StructuralTypesApi<TContainer> : SemanticApiNode<TContainer>, StructuralTypesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public CollectionApi_I<TContainer> Collection { get; set; }
		CollectionApiMask_I StructuralTypesApiMask_I.Collection => Collection;

		public ExternalApi_I<TContainer> External { get; set; }
		ExternalApiMask_I StructuralTypesApiMask_I.External => External;

		
        

        

        

        public ModuleDefinition GetModuleFromType(InfrastructureModelMask_I semanticModel, string resolutionName)
        {
            var node = Infrastructure.Models.Unified.Types.GetSemanticEntry(semanticModel, resolutionName);

            return node?.SourceModuleDefinition;
        }

        

       


        //public TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input)
        //{
	       // string resolutionName = Binding.Metadata.Members.Types.Naming.GetResolutionName(input);

        //    TypeReference typeDefinition = Collection.GetStoredTypeReference(model, resolutionName);

        //    if (typeDefinition != null) return typeDefinition;

        //    if (!input.IsGenericType)
        //    {
        //        throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
        //    }

        //    var genericArguments = input.GenericTypeArguments;

        //    if (genericArguments.Length < 1)
        //    {
        //        throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
        //    }

        //    var genericTypeDefinition = input.GetGenericTypeDefinition();

        //    var genericTypeDefinition1 = GetTypeReference(model, genericTypeDefinition);

        //    var genericArgumentReferences = new TypeReference[genericArguments.Length];

        //    for (int i = 0; i < genericArguments.Length; i++)
        //    {
        //        genericArgumentReferences[i] = GetTypeReference(model, genericArguments[i]);
        //    }

        //    var result = genericTypeDefinition1.MakeGenericInstanceType(genericArgumentReferences);

        //    return result;
        //}

        public Type ResolveToType(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I semanticType)
        {
            throw new Exception("resolving a semantic type to a run time is not supported.  A semantic type is designed to be used to create runtime type.  Right now automatic" +
                                "compile support is not present.");
        }


       


    }
}