﻿using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using FieldAttributes = System.Reflection.FieldAttributes;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Fields.Building
{
	public class NonGenericApi<TContainer> : ConversionApiNode<TContainer>, NonGenericApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public void BuildFields(ILConversion conversion, ConvertedTypeDefinition_I input)
		{



			// Done on purpose to find errors
			var typeDefinition = (TypeDefinition)input.SourceTypeReference;

			if (!typeDefinition.HasFields) return;

			for (int i = 0; i < typeDefinition.Fields.Count; i++)
			{
				var field = typeDefinition.Fields[i];

				BuildField(conversion, input, field);
			}
		}

		public void BuildField(ILConversion conversion, ConvertedTypeDefinition_I input, FieldDefinition field)
		{
			if (!(input is ConvertedTypeDefinitionWithFields_I typeWithFields))
			{
				throw new Exception("Trying to build a field on a type that does not support fields.");
			}

			var fieldAttributes = GetFieldAttributes(field);

			var boundFieldType = Execution.Types.Ensuring.EnsureToType(conversion, field.FieldType, out BoundTypeDefinitionMask_I semanticFieldType);

			var builder = typeWithFields.TypeBuilder.DefineField(field.Name, boundFieldType, fieldAttributes);

			if (field.HasConstant)
			{
				builder.SetConstant(field.Constant);
			}

			var convertedField = new ConvertedField()
			{
				FieldType = semanticFieldType,
				Conversion = conversion,
				FieldDefinition = field,
				FieldBuilder = builder,
				UnderlyingField = builder,
				Name = field.Name,
			};

			typeWithFields.Fields.ByName.Add(convertedField.Name, convertedField);

			CustomAttributes.BuildCustomAttributes(conversion, input, convertedField);
		}

		public System.Reflection.FieldAttributes GetFieldAttributes(FieldDefinition fieldDefinition)
		{
			var attributes = fieldDefinition.Attributes;

			var newAttributes = System.Reflection.FieldAttributes.PrivateScope;

			if ((attributes & Mono.Cecil.FieldAttributes.Public) == Mono.Cecil.FieldAttributes.Public)
			{
				newAttributes |= System.Reflection.FieldAttributes.Public;
			}
			if ((attributes & Mono.Cecil.FieldAttributes.Family) == Mono.Cecil.FieldAttributes.Family)
			{
				newAttributes |= System.Reflection.FieldAttributes.Family;
			}
			if ((attributes & Mono.Cecil.FieldAttributes.FamANDAssem) == Mono.Cecil.FieldAttributes.FamANDAssem)
			{
				newAttributes |= System.Reflection.FieldAttributes.FamANDAssem;
			}
			if ((attributes & Mono.Cecil.FieldAttributes.Private) == Mono.Cecil.FieldAttributes.Private)
			{
				newAttributes |= System.Reflection.FieldAttributes.Private;
			}
			if ((attributes & Mono.Cecil.FieldAttributes.Assembly) == Mono.Cecil.FieldAttributes.Assembly)
			{
				newAttributes |= System.Reflection.FieldAttributes.Assembly;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.FamORAssem) == Mono.Cecil.FieldAttributes.FamORAssem)
			{
				newAttributes |= System.Reflection.FieldAttributes.FamORAssem;
			}




			if ((attributes & Mono.Cecil.FieldAttributes.CompilerControlled) == Mono.Cecil.FieldAttributes.CompilerControlled)
			{
				newAttributes |= System.Reflection.FieldAttributes.PrivateScope;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.HasDefault) == Mono.Cecil.FieldAttributes.HasDefault)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasDefault;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.HasFieldMarshal) == Mono.Cecil.FieldAttributes.HasFieldMarshal)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasFieldMarshal;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.HasFieldRVA) == Mono.Cecil.FieldAttributes.HasFieldRVA)
			{
				newAttributes |= System.Reflection.FieldAttributes.HasFieldRVA;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.InitOnly) == Mono.Cecil.FieldAttributes.InitOnly)
			{
				newAttributes |= System.Reflection.FieldAttributes.InitOnly;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.Literal) == Mono.Cecil.FieldAttributes.Literal)
			{
				newAttributes |= System.Reflection.FieldAttributes.Literal;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.NotSerialized) == Mono.Cecil.FieldAttributes.NotSerialized)
			{
				newAttributes |= System.Reflection.FieldAttributes.NotSerialized;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.PInvokeImpl) == Mono.Cecil.FieldAttributes.PInvokeImpl)
			{
				newAttributes |= System.Reflection.FieldAttributes.PinvokeImpl;
			}





			if ((attributes & Mono.Cecil.FieldAttributes.RTSpecialName) == Mono.Cecil.FieldAttributes.RTSpecialName)
			{
				newAttributes |= System.Reflection.FieldAttributes.RTSpecialName;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.SpecialName) == Mono.Cecil.FieldAttributes.SpecialName)
			{
				newAttributes |= System.Reflection.FieldAttributes.SpecialName;
			}

			if ((attributes & Mono.Cecil.FieldAttributes.Static) == Mono.Cecil.FieldAttributes.Static)
			{
				newAttributes |= FieldAttributes.Static;
			}

			return newAttributes;

		}
	}
}
