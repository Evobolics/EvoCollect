﻿using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
	public class PointerApi<TContainer> : ExecutionApiNode<TContainer>, PointerApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I boundModel, TypeReference typeReference, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType)
		{
			var pointerType = (PointerType)typeReference;

			BoundTypeDefinitionMask_I elementType;

			if (underlyingType == null)
			{
                // Possible element type is a generic instance type
				elementType = Execution.Types.Ensuring.EnsureBound(boundModel, pointerType.ElementType, null);
			}
			else
			{
				// Possible element type is a generic instance type
                elementType = Execution.Types.Ensuring.EnsureBound(boundModel, pointerType.ElementType, underlyingType.GetElementType());
			}

			var node = Unified.Types.Get(boundModel, elementType.ResolutionName);

			if (node.PointerType != null)
			{
				return node.PointerType;
			}

			var bound = Bound.Metadata.Members.Types.Creation.Create(boundModel, typeReference, null);

			bound.SourceTypeReference = typeReference;

			// Add the type instance to the model.  Do not do any recursive calls till this methods is called.
			node.PointerType = bound;

			if (underlyingType != null)
			{
				bound.UnderlyingType = underlyingType;
			}
			else
			{
				bound.UnderlyingType = elementType.UnderlyingType.MakePointerType();
			}

			return bound;
        }
	}
}
