﻿using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building
{
	public class RuntimeCreatedApi<TContainer> : ConversionApiNode<TContainer>, RuntimeCreatedApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		public void BuildMethods(ILConversion conversion, ConvertedGenericTypeDefinition_I input)
		{
			if (!(input is BoundTypeDefinitionWithMethodsMask_I convertedTypeWithMethods))
			{
				return;
			}

			// This MUST use typebuilder.GetMethod and not
			// input.Blueprint.UnderlyingType, as different MethodInfo objects are returned.
			var blueprintMethods = Methods.Getting.GetMethods(input.Blueprint);

			// We chave to get the definition for a generic instance.
			var declaringTypeDefinition = Cecil.Metadata.Members.Types.Getting.GetDefinition(conversion.Model, input.SourceTypeReference);

			for (int i = 0; i < blueprintMethods.Count; i++)
			{
				var blueprintUnderlyingMethodInfo = blueprintMethods[i].UnderlyingMethod;
				var genericInstanceMethodInfo = TypeBuilder.GetMethod(input.UnderlyingType, blueprintUnderlyingMethodInfo);
					
				var methodSearch = new MethodReferenceSearch()
				{ 
					GenericTypeDefinitionMethodInfo = blueprintUnderlyingMethodInfo,
					BoundGenericTypeDefinitionMethod = blueprintMethods[i],
					GenericInstanceMethodInfo = genericInstanceMethodInfo,
					GenericTypeDefinitionMethod = blueprintMethods[i].MethodReference,
					IsGenericTypeDefinitionConverted = true
						
				};
			
				if (methodSearch.GenericInstanceMethodInfo?.DeclaringType != null && methodSearch.GenericInstanceMethodInfo.DeclaringType.IsGenericTypeDefinition)
				{
					throw new System.Exception("You cannot call a method that is part of a generic type definition.  Using this method info will cause a method invocation exeception. ");
				}

				methodSearch.Conversion = conversion;
				methodSearch.GenericInstance = (GenericInstanceType) input.SourceTypeReference;
				methodSearch.GenericTypeDefinition = declaringTypeDefinition;

				var methodReference = GetCorrespondingMethodReference(conversion, methodSearch);

				var methodEntry = BuildMethod(conversion, input, methodSearch.GenericInstanceMethodInfo, methodReference);

				if (!convertedTypeWithMethods.Methods.ByName.TryGetValue(methodEntry.Name, out List<SemanticMethodMask_I> methodList))
				{
					methodList = new List<SemanticMethodMask_I>();

					convertedTypeWithMethods.Methods.ByName.Add(methodEntry.Name, methodList);
				}

				methodList.Add(methodEntry);
			}
		}

		private MethodInfo GetMethodInfoDefinition(MethodInfo method)
		{
			var token = method.MetadataToken;

			if (method.DeclaringType != null && method.DeclaringType.IsGenericType)
			{
				var x = method.DeclaringType.GetGenericTypeDefinition();

				var y = x.GetMethods();

				for (int i = 0; i < y.Length; i++)
				{
					var method1 = y[i];

					if (method1.MetadataToken == token)
					{
						return method1;
					}
				}
			}

			return null;
		}

		private MethodReference GetCorrespondingMethodReference(ILConversion conversion, MethodReferenceSearch search)
		{
			//var methodDefinition =  Methods.Getting.FromMethodInfos.Definitions.GetMethodDefinition(search);
			var methodDefinition = (MethodDefinition)search.GenericTypeDefinitionMethod;

			// CANNOT USE THIS CECIL VERSION AS IT ONLY COMPARES METADATA TOKENS WHICH WILL NOT MATCH WHEN COMPARING DATA LOADED FROM A STATIC TYPE to a METHOD INFO 
			// CREATED FROM A DYNAMIC TYPE.
			//var methodReference = Cecil.Metadata.Members.Methods.Getting.FromMethodInfos.References.GetMethodReference(conversion.Model, input.SourceTypeReference, method);

			return Cecil.Metadata.Members.Methods.Building.MethodDefinitions.MakeGenericInstanceTypeMethodReference(conversion.Model, search.GenericInstance, methodDefinition);
		}

		private MethodReference CreateGenericInstanceMethodReference(ILConversion conversion, MethodReferenceSearch search, MethodDefinition methodDefinition)
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// The goal here is to get the method definition that corresponds to the method
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="declaringType"></param>
		/// <param name="declaringTypeReference"></param>
		/// <param name="declaringTypeDefinition"></param>
		/// <param name="method"></param>
		private ConvertedMethod BuildMethod(ILConversion conversion, ConvertedTypeDefinitionMask_I declaringType, MethodInfo method, MethodReference methodReference)
		{
			ConvertedMethod methodEntry;

			var genericArguments = method.GetGenericArguments();

			// ReSharper disable once ConstantConditionalAccessQualifier - IT CAN BE NULL.
			if (genericArguments?.Length > 0)
			{
				methodEntry = new ConvertedGenericMethod
				{
					MethodReference = methodReference,
					DeclaringType = declaringType,
					Conversion = conversion,
					MethodAttributes = method.Attributes,
					Name = method.Name,
					UnderlyingMethod = method
				};
			}
			else
			{
				methodEntry = new ConvertedBoundMethod
				{
					MethodReference = methodReference,
					DeclaringType = declaringType,
					Conversion = conversion,
					MethodAttributes = method.Attributes,
					Name = method.Name,
					UnderlyingMethod = method
				};
			}

			return methodEntry;

		}


		
	}
}
