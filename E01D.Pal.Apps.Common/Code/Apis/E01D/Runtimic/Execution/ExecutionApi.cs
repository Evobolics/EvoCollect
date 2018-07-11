﻿using Root.Code.Apis.E01D.Runtimic.Execution.Allocation;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting;
using Root.Code.Apis.E01D.Runtimic.Execution.GarbageCollection;
using Root.Code.Apis.E01D.Runtimic.Execution.JustInTime;
using Root.Code.Apis.E01D.Runtimic.Execution.Metadata;
using Root.Code.Apis.E01D.Runtimic.Execution.VirtualMachines;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution
{
    public class ExecutionApi<TContainer>:RuntimeApiNode<TContainer>, ExecutionApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        /// <summary>
        /// Allocates objects onto the heap.
        /// </summary>
        public AllocationApi_I<TContainer> Allocation { get; set; }

        public BindingApi_I<TContainer> Binding { get; set; }

        public EmittingApi_I<TContainer> Emitting { get; set; }

        public GarbageCollectionApi_I<TContainer> GarbageCollection { get; set; }

        public MetadataApi_I<TContainer> Metadata { get; set; } 

        // ReSharper disable once InconsistentNaming
        public GarbageCollectionApi_I<TContainer> GC => GarbageCollection;

        public JustInTimeApi_I<TContainer> JustInTime { get; set; }

        public JustInTimeApi_I<TContainer> Jit => JustInTime;

        public VirtualMachineApi_I<TContainer> VirtualMachines { get; set; }

        // ReSharper disable once InconsistentNaming
        public VirtualMachineApi_I<TContainer> VM => VirtualMachines;

        AllocationApiMask_I ExecutionApiMask_I.Allocation => Allocation;

        BindingApiMask_I ExecutionApiMask_I.Binding => Binding;

        EmittingApiMask_I ExecutionApiMask_I.Emitting => Emitting;

        GarbageCollectionApiMask_I ExecutionApiMask_I.GarbageCollection => GarbageCollection;

        JustInTimeApiMask_I ExecutionApiMask_I.JustInTime => JustInTime;

        VirtualMachineApiMask_I ExecutionApiMask_I.VirtualMachines => VirtualMachines;

	    
    }
}
