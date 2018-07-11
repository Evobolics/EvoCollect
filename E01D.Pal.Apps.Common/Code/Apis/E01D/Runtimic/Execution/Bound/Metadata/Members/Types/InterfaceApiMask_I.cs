﻿using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
    public interface InterfaceApiMask_I
    {
        BoundTypeDefinitionInterfaces GetInterfaces(InfrastructureModelMask_I semanticModel, TypeDefinition typeDefinition);
    }
}
