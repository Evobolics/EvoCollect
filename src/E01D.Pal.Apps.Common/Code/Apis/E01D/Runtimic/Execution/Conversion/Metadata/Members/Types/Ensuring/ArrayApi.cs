﻿using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public class ArrayApi<TContainer> : ConversionApiNode<TContainer>, ArrayApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, TypeReference input, SemanticTypeDefinitionMask_I declaringType)
        {
	        ArrayType arrayType = (ArrayType)input;

	        var elementType = Execution.Types.Ensuring.Ensure(conversion.Model, arrayType.ElementType, null, null);

	        if (IfAlreadyCreatedReturn(elementType, arrayType.Rank, out SemanticArrayTypeDefinitionMask_I existing))
	        {
		        return existing;
	        }

			ConvertedTypeDefinition converted = Types.Creation.Create(conversion, input);

	        var arrayDef = (ConvertedArrayTypeDefinition_I)converted;

			elementType.Arrays.Add(arrayType.Rank, arrayDef);

	        arrayDef.ElementType = elementType;

			converted.BaseType = (BoundTypeDefinitionMask_I)Execution.Types.Ensuring.Ensure(conversion.Model, typeof(System.Array));

            if (!(arrayDef.ElementType is BoundTypeDefinitionMask_I boundElementType))
            {
                throw new Exception("The element type is not a BoundTypeDefinitionMask_I. ");
            }

            if (arrayType.Rank == 1)
            {
                // Makes a vector
                converted.UnderlyingType = boundElementType.UnderlyingType.MakeArrayType();
            }
            else
            {
                // Makes an multi-dimensional array
                converted.UnderlyingType = boundElementType.UnderlyingType.MakeArrayType(arrayType.Rank);
            }

	        



			Types.Building.UpdateBuildPhase(converted, BuildPhaseKind.TypeCreated);

            return converted;
        }

	    private bool IfAlreadyCreatedReturn(SemanticTypeDefinitionMask_I elementType, int rank, out SemanticArrayTypeDefinitionMask_I existing)
	    {
		    if (elementType.Arrays.TryGetValue(rank, out existing))
		    {
			    return true;
		    }

		    return false;
	    }
	}
}
