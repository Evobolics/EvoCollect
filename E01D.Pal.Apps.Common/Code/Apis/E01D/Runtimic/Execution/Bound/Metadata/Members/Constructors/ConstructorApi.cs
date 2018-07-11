﻿using System;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors.Building;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors
{
	public class ConstructorApi<TContainer> : BindingApiNode<TContainer>, ConstructorApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
	    public BuildingApi_I<TContainer> Building { get; set; }

	    BuildingApiMask_I ConstructorApiMask_I.Building => Building;

		public ConstructorInfo GetConstructorInfo(InfrastructureModelMask_I conversionModel, MemberReference memberReference)
        {
            var declaringBound = Members.GetDeclaringType(conversionModel, memberReference);

            return (ConstructorInfo)FindConstructorBySignature(conversionModel, declaringBound, memberReference);
        }

        public MemberInfo FindConstructorBySignature(InfrastructureModelMask_I conversionModel, BoundTypeDefinitionMask_I typeEntry, MemberReference memberReference)
        {
            switch (memberReference.MetadataToken.TokenType)
            {
                case TokenType.Method:
                case TokenType.MemberRef:
                {
                    return FindConstructorBySignature(conversionModel, typeEntry, (MethodReference)memberReference);

                }
                case TokenType.MethodSpec:
                {
                    throw new System.Exception("Not handled");
                }
                default:
                {
                    throw new System.Exception("Not handled");
                }
            }
        }

        public ConstructorInfo FindConstructorBySignature(InfrastructureModelMask_I conversionModel, BoundTypeDefinitionMask_I declaringType, MethodReference methodReference)
        {
            // NOTE - This version of the method cannot access constructor builders, which are neccessary when building
            //        constructor calls for a converted classes instructions.

            var parameterTypes = Parameters.GetSystemParameterTypes(conversionModel, methodReference);

			// Using the BindingFlags.Instance is important as certain constructors (like System.Attribute) will not show up without it.
            var constructor = declaringType.UnderlyingType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, parameterTypes, null); 

            if (constructor == null)
            {
                throw new System.Exception("Could not find constructor.");
            }

            return constructor;
        }
    }
}
