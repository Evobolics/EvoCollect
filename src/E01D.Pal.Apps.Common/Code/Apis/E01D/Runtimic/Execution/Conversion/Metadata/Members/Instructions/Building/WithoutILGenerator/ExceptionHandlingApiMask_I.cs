﻿using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator
{
    public interface ExceptionHandlingApiMask_I
    {
        bool GetExceptionHandlerList(ILConversion conversion, ConvertedRoutine convertedRoutine);
    }
}
