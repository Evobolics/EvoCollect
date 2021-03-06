﻿using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator.IL;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator
{
    public interface WithoutILGeneratorApiMask_I
    {
        ExceptionHandlingApiMask_I ExceptionHandling { get; }

        ILApiMask_I IL { get; }

        LocalVariableSignatureApiMask_I LocalVariableSignatures { get; }

        bool BuildBody(ILConversion conversion, ConvertedRoutine convertedConstructor);
    }
}
