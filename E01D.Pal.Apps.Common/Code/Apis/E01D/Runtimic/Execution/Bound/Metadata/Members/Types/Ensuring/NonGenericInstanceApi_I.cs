﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Ensuring
{
    public interface NonGenericApi_I<TContainer> : NonGenericInstanceApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {

    }
}
