﻿using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public interface GenericParameterApiMask_I
    {
        SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I boundModel, BoundEnsureContext context);
    }
}