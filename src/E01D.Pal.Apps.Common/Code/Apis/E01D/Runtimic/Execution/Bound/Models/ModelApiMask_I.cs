﻿using Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models.Types;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models
{
    public interface ModelApiMask_I
    {
        ModelAssembliesApiMask_I Assemblies { get; }

        ModelModulesApiMask_I Modules { get; }

        ModelTypesApiMask_I Types { get; }

        
        

        //void AddAssemblyDefinition(SemanticModelMask_I semanticModel, AssemblyDefinition assemblyDefinition);
    }
}
