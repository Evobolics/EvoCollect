﻿using System.Reflection;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting.FromMethodInfo
{
	public interface DefinitionApiMask_I
	{
		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.  This method first gets the type definition associated with the 
		/// type reference.
		/// </summary>
		MethodDefinition GetMethodDefinition(InfrastructureModelMask_I model, TypeReference typeReference, MethodInfo method);

		/// <summary>
		/// Gets the method definition that is associated with the MethodInfo.
		/// </summary>
		/// <param name="model"></param>
		/// <param name="typeDefinition"></param>
		/// <param name="method"></param>
		/// <returns></returns>
		MethodDefinition GetMethodDefinition(InfrastructureModelMask_I model, TypeDefinition typeDefinition, MethodInfo method);
	}
}
