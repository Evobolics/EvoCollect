﻿using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Creation
{
    public interface CecilApiMask_I
    {


        SemanticTypeDefinition CreateType(InfrastructureModelMask_I model, SemanticModuleMask_I moduleEntry,
            TypeReference typeReference);
    }
}