﻿using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building
{
	public class MethodDefinitionApi<TContainer> : CecilApiNode<TContainer>, MethodDefinitionApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public MethodDefinition MakeGenericInstanceTypeMethodReference(InfrastructureRuntimicModelMask_I model, GenericInstanceType declaringType, MethodDefinition methodDefinition)
		{
			if (declaringType == null) throw new Exception("Expected a declaring type.");

			var typeArgumentReferences = declaringType.GenericArguments.ToArray();

			if (typeArgumentReferences == null || typeArgumentReferences.Length < 1) return methodDefinition;

			var returnType = ResolveTypeParameterIfPresent(model, typeArgumentReferences, methodDefinition.ReturnType);

			var resolvedMethodDefinition = new MethodDefinition(methodDefinition.Name, methodDefinition.Attributes, returnType);

			// Add any method, not type, generic parameters
			AddGenericParameters(model, methodDefinition, resolvedMethodDefinition);

			for (int i = 0; i < methodDefinition.Parameters.Count; i++)
			{
				var inputParameter = methodDefinition.Parameters[i];

				var inputParameterType = inputParameter.ParameterType;

				var outputParameterType = ResolveTypeParameterIfPresent(model, typeArgumentReferences, inputParameterType);

				var outputParameter = Parameters.Create(inputParameter, outputParameterType);

				resolvedMethodDefinition.Parameters.Add(outputParameter);
			}

			return resolvedMethodDefinition;
		}

		public MethodDefinition MakeGenericInstanceTypeMethodReference(InfrastructureRuntimicModelMask_I model, MethodDefinition methodDefinition, Type memberDeclaringType)
		{
			if (memberDeclaringType == null) throw new Exception("Expected a declaring type.");

			Type[] typeArguments = memberDeclaringType.GenericTypeArguments;

			if (typeArguments == null || typeArguments.Length < 1) return methodDefinition;

			TypeReference[] typeArgumentReferences = ResolveGenericArguments(model, typeArguments);

			var returnType = ResolveTypeParameterIfPresent(model, typeArgumentReferences, methodDefinition.ReturnType);

			var resolvedMethodDefinition = new MethodDefinition(methodDefinition.Name, methodDefinition.Attributes, returnType);

			AddGenericParameters(model, methodDefinition, resolvedMethodDefinition);

			for (int i = 0; i < methodDefinition.Parameters.Count; i++)
			{
				var inputParameter = methodDefinition.Parameters[i];

				var inputParameterType = inputParameter.ParameterType;

				var outputParameterType = ResolveTypeParameterIfPresent(model, typeArgumentReferences, inputParameterType);

				var outputParameter = Parameters.Create(inputParameter, outputParameterType);

				resolvedMethodDefinition.Parameters.Add(outputParameter);
			}

			return resolvedMethodDefinition;
		}

		private TypeReference[] ResolveGenericArguments(InfrastructureRuntimicModelMask_I model, Type[] typeArguments)
		{
			TypeReference[] references = new TypeReference[typeArguments.Length];

			for (int i = 0; i < typeArguments.Length; i++)
			{
				references[i] = ResolveClassTypeArgument(model, typeArguments[i]);
			}

			return references;
		}

		public TypeReference ResolveClassTypeArgument(InfrastructureRuntimicModelMask_I model, Type typeToResolve)
		{
			if (!typeToResolve.IsGenericParameter)
			{
				return Types.Getting.GetInternalTypeReference(model, typeToResolve);
			}

			var x = typeToResolve.GetType();

			throw new NotImplementedException();
		}

		public TypeReference ResolveTypeParameterIfPresent(InfrastructureRuntimicModelMask_I model, TypeReference[] typeArguments, TypeReference typeToResolve)
		{
			if (!typeToResolve.IsGenericParameter)
			{
				return Types.Getting.GetInternalTypeReference(model, typeToResolve);
			}

			var genericParameter= (GenericParameter) typeToResolve;

			return typeArguments[genericParameter.Position];
		}


		private void AddGenericParameters(InfrastructureRuntimicModelMask_I model, MethodDefinition input, MethodDefinition output)
		{
			for (int i = 0; i < input.GenericParameters.Count; i++)
			{
				output.GenericParameters.Add(input.GenericParameters[i]);
			}
		}
	}
}
