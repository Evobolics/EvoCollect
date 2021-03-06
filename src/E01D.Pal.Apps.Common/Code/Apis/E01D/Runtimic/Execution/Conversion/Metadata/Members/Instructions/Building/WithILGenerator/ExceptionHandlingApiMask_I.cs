﻿using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL;
using ExceptionHandler = Root.Code.Libs.Mono.Cecil.Cil.ExceptionHandler;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithILGenerator
{
    public interface ExceptionHandlingApiMask_I
    {
	    void Preprocess(ILConversion conversion, ConvertedRoutine routine);

        void AddEvent(ILConversion conversion, ExceptionBlockEventKind eventKind,
            ExceptionHandlingInfo handlingInfo, int offset, ExceptionBlock exceptionBlock,
            ExceptionHandler exceptionHandler);

        void AddEvent(ILConversion conversion, ExceptionBlockEventKind eventKind,
            ExceptionHandlingInfo handlingInfo, int offset, ExceptionBlock exceptionBlock);

	    void ProcessInstruction(ILConversion conversion, ConvertedRoutine routine, Instruction instruction);

    }
}
