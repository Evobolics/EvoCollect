﻿using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedTypeDefinitionWithConstructors_I : BoundTypeDefinitionWithConstructorsMask_I, ConvertedTypeDefinition_I
    {
        new ConvertedTypeDefinitionConstructors Constructors { get; set; }
    }
}