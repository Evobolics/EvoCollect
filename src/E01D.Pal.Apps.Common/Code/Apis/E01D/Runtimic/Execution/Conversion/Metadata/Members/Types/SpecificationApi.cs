﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class SpecificationApi<TContainer> : ConversionApiNode<TContainer>, SpecificationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public SpecificationApi()
		{
			
		}
	}
}
