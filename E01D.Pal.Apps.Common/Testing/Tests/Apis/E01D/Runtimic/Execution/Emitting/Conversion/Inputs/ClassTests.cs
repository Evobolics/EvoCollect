﻿using System.Linq;
using System.Reflection;
using Root.Code.Attributes.E01D;
using Root.Code.Domains;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types;

namespace Root.Testing.Tests.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Inputs
{
    
    public class ClassTests
    {
        [Test]
        public void CanCreateBasicStructWithInt32Field()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(BasicStructWithInt32Field));

            var type = instance.GetType();

            var field = type.GetField("TestField");

            field.SetValue(instance, 1);

            Assert.AreEqual(1, (int)field.GetValue(instance));


        }

        [Test]
        public void CanCreateClassWithObjectField()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(BasicClassWithObjectField));

            var type = instance.GetType();

            var field = type.GetField("TestField");

            field.SetValue(instance, new object());

            Assert.IsNotNull(field.GetValue(instance));


        }

        [Test]
        public void CanCreateBareBonesClass()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(SimpleClass));

            


        }

        [Test]
        public void CanCreateBareBonesClassWithBaseType()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(SimpleClassWithBase));




        }

        [Test]
        public void CanCreateBareBonesClassWithSingleInterface()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(SimpleClassWithBaseAndInterface));




        }



        [Test]
        public void CanCreateBareBonesClassWithMultipleInterfaces()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(SimpleClassWithBaseAndInterfaces));




        }

        [Test]
        public void CanCreateBareBonesClassWithNestedClass()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(SimpleClassWithNestedClass));

            var x = instance.GetType().GetNestedType("SimpleClassWithNestedClass/NestedClass");

            Assert.IsNotNull(x);


        }

        [Test]
        public void CanCreateBareBonesGenericClass()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertSingleType(typeof(SimpleGenericClass<>));

            //

            Assert.IsNotNull(type);


        }

        [Test]
        public void CanCreateBareBonesGenericClassWithObject()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertSingleType(typeof(SimpleGenericClass<object>));

            //

            Assert.IsNotNull(type);


        }

        [Test]
        public void CanCreateGenericClassWithInterface1()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertSingleType(typeof(SimpleGenericClassWithInterface1<Interface1Class>));

            //

            Assert.IsNotNull(type);


        }

        [Test]
        public void CanCreateBareBonesInterface()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertSingleType(typeof(Interface1));

            //

            Assert.IsNotNull(type);


        }

        [Test]
        public void CanCreateBareBonesGenericStruct()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertSingleType(typeof(SimpleGenericStruct<>));

            //

            Assert.IsNotNull(type);


        }

        [Test]
        public void CanCreateGenericClassWithConstraints()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertSingleType(typeof(GenericClassWithConstraints<>));

            Assert.IsNotNull(type);
        }

        [Test]
        public void CanCreateBaseBonesDelegate()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertSingleType(typeof(SimpleDelegate));

            Assert.IsNotNull(type);
        }

        [Test]
        public void GenericClassWithMembersThatTakeInGenericClassParameters()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var instance = test.Api.ConvertAndCreateInstance(typeof(GenericClassWithMembersThatTakeInGenericClassParameters<Class1>), out Assembly assembly, out System.Type convertedType);

            var class1Instance = test.Api.CreateInstance(assembly, typeof(Class1));

            var method = convertedType.GetMethod("Method");

            var result = method.Invoke(instance, new[] {class1Instance});

            Assert.AreSame(class1Instance, result);

            method = convertedType.GetMethod("SetAndGetProperty");

            result = method.Invoke(instance, new[] { class1Instance });

            Assert.AreSame(class1Instance, result);
        }

        /// <summary>
        /// This test makes sure that consturctor builders are being found for incomplete types that cannot directly 
        /// supply a consturctor info using normal type methods.
        /// </summary>
        [Test]
        public void ComplicatedGenericClass()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertSingleType(typeof(ComplicatedGeneric<Class1, Class2, Class3>));

            Assert.IsNotNull(type);
        }

        /// <summary>
        /// This tests whether the constructor finding logic for a single constructor is working. 
        /// </summary>
        [Test]
        public void ComplicatedGenericWithOneArgBaseConstructorCall()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertAndCreateInstance(typeof(ComplicatedGenericWithOneArgBaseConstructorCall<Class1, Class2, Class3>));

            Assert.IsNotNull(type);
        }

        /// <summary>
        /// This tests whether the constructor finding logic for a single constructor is working. 
        /// </summary>
        [Test]
        public void ComplicatedGenericWithTwoBaseConstructors()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertAndCreateInstance(typeof(ComplicatedGenericWithTwoBaseConstructors<Class1, Class2, Class3>));

            Assert.IsNotNull(type);
        }

        /// <summary>
        /// This tests whether the constructor finding logic for a single constructor is working. 
        /// </summary>
        [Test]
        public void ComplicatedGenericWithConstructorWithArgumentSetToDefaultValue()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var type = test.Api.ConvertAndCreateInstance(typeof(ComplicatedGenericWithConstructorWithArgumentSetToDefaultValue));

            Assert.IsNotNull(type);
        }

        /// <summary>
        /// This test checks to see if a value is passed from constructor, and if a base method can be found.
        /// </summary>
        [Test]
        public void ComplicatedGenericWithOneArgBaseConstructorCall_TestExecuteWithReturnValue()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(ComplicatedGenericWithOneArgBaseConstructorCall<Class1, Class2, Class3>), "Execute");

            Assert.AreEqual("test message", (string)result);
        }


        

        [Test]
        public void ClassWithReferenceToGenreicField()
        {
            // Create a test container
            var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

            // Convert the type. The test api code will check to make sure the instance is not null.
            var result = test.Api.ConvertCreateCall(typeof(ClassWithReferenceToGenreicField), "Execute");

            Assert.AreEqual("Howdy", (string)result);
        }

	    [Test]
	    public void ClassWithGenericField()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertAndCreateInstance(typeof(ClassWithGenericField<string>));

		    test.Api.TestField(result, "GenericField", "Howdy");

		    
	    }

	    [Test]
	    public void ClassWithGenericFieldAndMethodReference()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var instance = test.Api.ConvertAndCreateInstance(typeof(ClassWithGenericFieldAndMethodReference<string>));

		    test.Api.TestField(instance, "GenericField", "Howdy");
		    test.Api.TestMethod(instance, "Execute");


		}

	    [Test]
	    public void ClassWithFieldsWithDifferentAccessModifiers()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var instance = test.Api.ConvertAndCreateInstance(typeof(ClassWithFieldsWithDifferentAccessModifiers));

			var result = test.Api.TestMethod(instance, "Execute");
			
			Assert.AreEqual("Howdy", (string)result);

		    test.Api.HasField(instance, "Public", FieldAttributes.Public);
		    test.Api.HasField(instance, "Internal", FieldAttributes.Assembly);
		    test.Api.HasField(instance, "Protected", FieldAttributes.Family);
		    test.Api.HasField(instance, "Private", FieldAttributes.Private);

		}

	    [Test]
	    public void ClassWithDifferentKindsOfFields()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var instance = test.Api.ConvertAndCreateInstance(typeof(ClassWithDifferentKindsOfFields));

		    var result = test.Api.TestMethod(instance, "Execute");

		    Assert.AreEqual("Howdy", (string)result);

		    test.Api.HasField(instance, "Public", FieldAttributes.Public);
		    test.Api.HasField(instance, "Internal", FieldAttributes.Assembly);
		    test.Api.HasField(instance, "Protected", FieldAttributes.Family);
		    test.Api.HasField(instance, "Private", FieldAttributes.Private);

		    test.Api.HasField(instance, "StaticPublic", FieldAttributes.Public | FieldAttributes.Static);
		    test.Api.HasField(instance, "StaticInternal", FieldAttributes.Assembly | FieldAttributes.Static);
		    test.Api.HasField(instance, "StaticProtected", FieldAttributes.Family | FieldAttributes.Static);
		    test.Api.HasField(instance, "StaticPrivate", FieldAttributes.Private | FieldAttributes.Static);

		    
		}

	    [Test]
	    public void GenericTesting_WithNonGenericExecuteMethod()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(GenericClassWithNonGenericExecuteMethod<Class1>), "Execute");
	    }

		[Test]
		public void GenericTesting_GenericClassWithRecursiveMember()
	    {
			// Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(GenericClassWithRecursiveMember<Class1>), "Execute");
		}

	    [Test]
	    public void GenericTesting_GenericClassWithRecursiveMembers()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(GenericClassWithRecursiveMembers<Class1>), "Execute");
	    }

		[Test]
	    public void ClassWithMethod()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(ClassWithMethod), "Execute");

		    //Assert.AreEqual("Howdy", (string)result);
	    }

	    [Test]
	    public void ClassWithPrimitiveTypeMethods()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(ClassWithPrimitiveTypeMethods), "Execute");

		    Assert.AreEqual(true, (bool)result);
	    }

	    [Test]
	    public void ClassWithMethod_RefParameter()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(ClassWithMethod_RefParameter), "Execute");

			

		    Assert.AreEqual(4, (int)result);
	    }

	    [Test]
	    public void ClassWithMethod_OutParameter()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(ClassWithMethod_OutParameter), "Execute");

		    Assert.AreEqual(4, (int)result);
	    }

	    [Test]
	    public void MethodTesting_NonGenericClassWithTwoMethodsNamedTheSame()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(MethodTesting_NonGenericClassWithTwoMethodsNamedTheSame), "Execute");

		    Assert.AreEqual(5, (int)result);
	    }

	    [Test]
	    public void MethodTesting_GenericClassWithTwoMethodsNamedTheSame()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(MethodTesting_GenericClassWithTwoMethodsNamedTheSame<Class1>), "Execute");

		    Assert.AreEqual(5, (int)result);
	    }

	    [Test]
	    public void MethodTesting_GenericClassTwoMethodsNamedTheSame_DifferentGenericArgumentLength()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var result = test.Api.ConvertCreateCall(typeof(MethodTesting_TwoMethodsNamedTheSame_DifferentGenericArgumentLength<Class1>), "Execute");

		    Assert.AreEqual(5, (int)result);
	    }

	    [Test]
	    public void ClassTesting_ClassWithBlankAttribute()
	    {
		    // Create a test container
		    var test = XCommonAppPal.Api.Containment.CreateContainer<ILConversionTestContainer>(false);

		    // Convert the type. The test api code will check to make sure the instance is not null.
		    var instance = test.Api.ConvertAndCreateInstance(typeof(ClassTesting_ClassWithBlankAttribute));

		    var type = instance.GetType();

		    //TypeInfo x = (TypeInfo) type;

		    //var y = x.GetCustomAttributesData();

		    //var x1 = x.GetCustomAttributes();
			var attributes = type.CustomAttributes.ToList();
			

		    Assert.AreEqual(1, attributes.Count);
	    }
	}
}