﻿
using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Assemblies;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata
{
    public class MetadataApi<TContainer> : ExecutionApiNode<TContainer>, MetadataApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public AssemblyApi_I<TContainer> Assemblies { get; set; }
        AssemblyApiMask_I MetadataApiMask_I.Assemblies => Assemblies;
    }
}
