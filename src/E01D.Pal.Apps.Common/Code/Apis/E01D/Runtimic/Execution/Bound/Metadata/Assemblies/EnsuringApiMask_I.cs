﻿using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
    public interface EnsuringApiMask_I
    {
        SemanticAssemblyMask_I Ensure(InfrastructureRuntimicModelMask_I semanticModel, TypeReference typeReference);

        SemanticAssemblyMask_I Ensure(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition);

        

        
    }
}
