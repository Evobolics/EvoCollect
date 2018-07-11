﻿using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public abstract class ConvertedValueTypeDefinition : ConvertedReferenceOrValueTypeDefinition
    {
        public override TypeKind TypeKind => base.TypeKind | TypeKind.ValueType;
    }
}
