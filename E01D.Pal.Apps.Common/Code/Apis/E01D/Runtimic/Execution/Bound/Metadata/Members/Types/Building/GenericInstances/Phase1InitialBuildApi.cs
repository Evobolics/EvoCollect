﻿using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Building.GenericInstances
{
	public class Phase1InitialBuildApi<TContainer> : BindingApiNode<TContainer>, Phase1InitialBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		///// <summary>
		///// Assigns the generic blueprint and the type arguments to the generic instance type.
		///// </summary>
		///// <param name="conversion"></param>
		///// <param name="converted"></param>
		///// <returns></returns>
		//public void Build(ILConversion conversion, ConvertedGenericTypeDefinition_I converted, Type[] typeArgumentTypes)
		//{
		//	throw new Exception();
		//}
	}
}