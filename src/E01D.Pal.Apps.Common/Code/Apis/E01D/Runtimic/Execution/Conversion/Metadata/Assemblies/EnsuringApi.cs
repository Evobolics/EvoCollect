﻿using System;
using System.IO;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
	public class EnsuringApi<TContainer> : ConversionApiNode<TContainer>, EnsuringApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void Ensure(ILConversion conversion, Stream[] streams)
		{
			foreach (var stream in streams)
			{
				Ensure(conversion, stream);
			}
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, Assembly assembly)
		{
			var assemblyNode = Cecil.Assemblies.Ensuring.Ensure(conversion.Model, assembly);

			return Ensure(conversion, assemblyNode);

			//if (semanticAssembly is ConvertedAssembly_I converted)
			//{
			//	converted.Assembly = assembly;
			//}
			//else if (semanticAssembly is BoundAssembly_I bound)
			//{
			//	bound.Assembly = assembly;
			//}

			//return semanticAssembly;
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, Stream stream)
		{
			var assemblyNode = Cecil.Assemblies.Ensuring.Ensure(conversion.Model, stream);

			return Ensure(conversion, assemblyNode);
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, IMetadataScope assemblyNameReference)
		{
			var assemblyNode = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensuring.Ensure(conversion.Model, assemblyNameReference);

			return Ensure(conversion, assemblyNode);
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, string typeReferenceFullName)
		{
			var typeReference = Cecil.Types.Getting.GetStoredTypeReference(conversion.Model, typeReferenceFullName, out UnifiedTypeNode basicNode);

			if (typeReference == null)
			{
				throw new Exception($"Could not locate a type in the model named '{typeReferenceFullName}'");
			}

			return Ensure(conversion, basicNode.AssemblyNode);
		}

		public SemanticAssemblyMask_I Ensure(ILConversion conversion, TypeReference typeReference)
		{
			var assemblyNode = Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensuring.Ensure(conversion.Model, typeReference);

			return Ensure(conversion, assemblyNode);
		}



		/// <summary>
		/// Creates a bound or converted assembly depending if isonvered is set to true.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="assemblyNode"></param>
		/// <returns></returns>
		public SemanticAssemblyMask_I Ensure(ILConversion conversion, UnifiedAssemblyNode assemblyNode)
		{
			if (assemblyNode.Semantic != null)
			{
				return assemblyNode.Semantic;
			}

			var assemblyDefinition = assemblyNode.SourceAssemblyDefinition;

			var name = Assemblies.Naming.GetAssemblyName(conversion, assemblyDefinition.Name.FullName);

			if (!Assemblies.Query.IsConverted(conversion, name))
			{
				return Binding.Metadata.Assemblies.Ensuring.Ensure(conversion.Model, assemblyDefinition);
			}

			var convertedAssembly = Assemblies.Creation.CreateConvertedAssembly(conversion, name, assemblyDefinition);

			// Ensure all the module entries are added.
			//Modules.Ensuring.EnsureModuleEntries(convertedAssembly);
			throw new Exception("Debug");

			return convertedAssembly;
		}








		





		
	}
}