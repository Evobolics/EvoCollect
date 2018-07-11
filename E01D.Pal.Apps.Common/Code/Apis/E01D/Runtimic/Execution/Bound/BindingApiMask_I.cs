﻿using System;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Models;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding
{
    public interface BindingApiMask_I
    {
        MetadataApiMask_I Metadata { get; }

        ModelApiMask_I Models { get; }

	    System.Type MakeGenericType(BoundTypeDefinitionMask_I boundType, Type[] typeParameters);

    }
}
