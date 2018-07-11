﻿using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types
{
    public interface AdditionApiMask_I
    {
	    SemanticTypeMask_I Add(InfrastructureModelMask_I semanticModel, SemanticModuleMask_I module,
		    SemanticTypeDefinitionMask_I entry);

    }
}