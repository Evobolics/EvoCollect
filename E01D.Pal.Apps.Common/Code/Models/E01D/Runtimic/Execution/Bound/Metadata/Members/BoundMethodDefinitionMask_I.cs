﻿using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundMethodDefinitionMask_I: BoundMethodMask_I, BoundRoutineDefinitionMask_I, SemanticMethodMask_I
    {
        MethodInfo UnderlyingMethod { get; }

        
    }
}
