﻿using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
	public class CreationApi<TContainer> : ConversionApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public ConvertedModule Create(ILConversion conversion, ConvertedModuleNode moduleNode)
		{
			var assemblyNode = moduleNode.AssemblyNode;

			ModuleDefinition moduleDefinition = moduleNode.InputStructuralDefinition.CecilModuleDefinition;

			string name;

			if (assemblyNode.Guid != Guid.Empty)
			{
				name = moduleDefinition.Name;

				var lower = name.ToLower();

				if (lower.EndsWith(".dll") || lower.EndsWith(".exe"))
				{
					var subName = name.Substring(0, lower.Length - 4);

					var ending = name.Substring(lower.Length - 4, 4);

					// When saving an assemlby, the module name has to equal the file name, as you are specifiying what module to save.  
					// You cannot specify what directory to save the assembly, so it is saved in the execution directory which can contain the source assembly with the 
					// same name.  To prevent this, the module name has the assemblies guid appended to its name to prevent a name conflict.  
					name = $"{subName}_{assemblyNode.Guid.ToString("N")}{ending}";
				}
				else
				{
					name = $"{name}_{assemblyNode.Guid.ToString("N")}";
				}
			}
			else
			{
				name = moduleDefinition.Name;
			}

			var module = new ConvertedModule()
			{
			    ModuleBuilder = assemblyNode.ConvertedAssembly.AssemblyBuilder.DefineDynamicModule(name),
                Name = name,
			    Assembly = assemblyNode.ConvertedAssembly,
			    SourceModuleDefinition = moduleDefinition,
			    Conversion = conversion,
			};
            
			

			return module;
		}
	}
}
