﻿using System;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Apis.E01D;
using Root.Code.Domains;
using Root.Code.Models.E01D.Containment;
using Root.Code.Domains.E01D;
using Root.Code.Exts.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.PI.E01D;

namespace Root.Testing.Code.Apis.E01D.Runtimic.Emitting.Conversion
{
    public class TestApi<TContainer> :Api<TContainer> where TContainer : Container_I
    {
	    public object CreateTypeAndExecute(Action<ILGenerator> action)
	    {
		    return CreateTypeAndExecute(action, new ILConversionOptions());
	    }


		public object CreateTypeAndExecute(Action<ILGenerator> action, ILConversionOptions options)
        {
            var assemblyName1 = CreateTestType(action);

            Assembly assemblyLoaded = Assembly.LoadFrom(assemblyName1 + ".dll");

            var types = assemblyLoaded.GetTypes();

            var testType = GetTestType(types);


            var constructor = testType.GetConstructor(Type.EmptyTypes);

            var instance = constructor.Invoke(new object[0]);

			var methodInfo = testType.GetMethod("Execute");

	        if (methodInfo == null)
		        throw new Exception($"Could not find method named '{"Execute"}' on class named '{testType.Name}'");

	        //var bytes = methodInfo.GetInstructions();

	        //for (int i = 0; i < bytes.Count; i++)
	        //{
	        // Debug.WriteLine(bytes[i]);

	        //}

	        var result1 = methodInfo.Invoke(instance, new object[0]);

			// Convert the type. The test api code will check to make sure the instance is not null.
			var result2 = ConvertCreateCall(testType, "Execute", options);

            return result2;
        }


        private Type GetTestType(Type[] types)
        {
            for (int i = 0; i < types.Length; i++)
            {
                var type = types[i];

                if (type.Name == "TestType")
                {
                    return type;
                }
            }

            return null;
        }

        public string CreateTestType(Action<ILGenerator> generatorMethod)
        {
	        var assemblyName1 = $"ReflectionEmitDelegateTest_testtype{Guid.NewGuid().ToString("N")}";

			var assemblyName = new AssemblyName
            {
                Version = new Version(1, 0, 0, 0),
                Name = assemblyName1
			};

            

            

            var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Save);


            var modbuilder = assemblyBuilder.DefineDynamicModule(assemblyName1, assemblyName1 + ".dll", true);

            var typeBuilder = modbuilder.DefineType("TestType", TypeAttributes.Class | 
                                                            TypeAttributes.Public | 
                                                            TypeAttributes.AnsiClass | 
                                                            TypeAttributes.AutoClass, typeof(System.Object));

            var methodBuilder = typeBuilder.DefineMethod("Execute", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual, typeof(bool), new Type[0]);

            var ilGenerator = methodBuilder.GetILGenerator();

            generatorMethod(ilGenerator);

            typeBuilder.CreateType();

            

            

            assemblyBuilder.Save(assemblyName1 + ".dll");

            return assemblyName1;


        }

	    public object ConvertCreateCall(Type type, string methodName)
	    {
		    return ConvertCreateCall(type, methodName, new ILConversionOptions());
	    }

	    public object ConvertCreateCall(Type type, string methodName, ILConversionOptions options)
        {
            var convertedType = ConvertSingleType(type, options);

            var instance = CreateInstance(convertedType);

            var methodInfo = convertedType.GetMethod(methodName);

            if (methodInfo == null)
                throw new Exception($"Could not find method named '{methodName}' on class named '{type.Name}'");

	  //      var instructions = methodInfo.GetInstructions();

			//for (int i = 0; i < instructions.Count; i++)
			//{
			//	Debug.WriteLine(instructions[i]);

			//}

			var result = methodInfo.Invoke(instance, new object[0]);

            return result;

        }

	    public object ConvertAndCreateInstance(Type type)
	    {
		    var convertedType = ConvertSingleType(type,  new ILConversionOptions());

		    return CreateInstance(convertedType);
	    }

		public object ConvertAndCreateInstance(Type type, AssemblyBuilderAccess buidlerAccess)
		{
			var options = new ILConversionOptions()
			{
				BuilderAccess = buidlerAccess
			};

            var convertedType = ConvertSingleType(type, options);

            return CreateInstance(convertedType);
        }

	    public object ConvertAndCreateInstance(Type type, ILConversionOptions conversionOptions)
	    {
		    var convertedType = ConvertSingleType(type, conversionOptions);

		    return CreateInstance(convertedType);
	    }

		public object ConvertAndCreateInstance(Type type, out Type convertedType)
        {
            convertedType = ConvertSingleType(type);

            return CreateInstance(convertedType);
        }

        public object ConvertAndCreateInstance(Type type, out Assembly assembly, out Type convertedType)
        {
            convertedType = ConvertSingleType(type, new ILConversionOptions(), out assembly);

            return CreateInstance(convertedType);
        }

	    public object ConvertAndCreateInstance(Type type, out Assembly assembly, out Type convertedType, ILConversionOptions options)
	    {
		    convertedType = ConvertSingleType(type, options, out assembly);

		    return CreateInstance(convertedType);
	    }

		public System.Type ConvertSingleType(System.Type type)
	    {
		    return ConvertSingleType(type, new ILConversionOptions(), out Assembly collectibleAssembly);
	    }

		public System.Type ConvertSingleType(System.Type type, ILConversionOptions options)
        {
            return ConvertSingleType(type, options, out Assembly collectibleAssembly);
        }

	    


		public System.Type ConvertSingleType(System.Type type, ILConversionOptions options, out Assembly collectibleAssembly)
        {
            // Use the default static api to create a container to do the conversion.
            var container = EvoAssembly.CreateContainer();

            // do the conversion
            var conversionResult = container.Convert(type, options);

            Assert.IsNotNull(conversionResult);

	        var output = (ILConversionTypesOutput)conversionResult.Output;

			var collectibleType = output.Types[0];

	        collectibleAssembly = collectibleType.Assembly;

			Assert.IsTrue(collectibleAssembly.IsDynamic);

			Assert.IsNotNull(collectibleType);

	        if (options.BuilderAccess == AssemblyBuilderAccess.RunAndSave)
	        {
		        var saveAssembly = conversionResult.Output.Assemblies[0];

				if (saveAssembly is AssemblyBuilder builder)
		        {
			        var modules = collectibleAssembly.GetModules();

			        var module = modules[0];

			        var fileName = module.ScopeName;


					builder.Save(fileName);
				}

	        }

			return collectibleType;

        }

        public System.Type GetType(Assembly assembly, System.Type pattern)
        {
            return XCommonAppPal.Api.Runtimic.Execution.Metadata.Assemblies.GetTypeInAssembly(assembly, pattern);
        }



        public object CreateInstance(Assembly assembly, Type pattern)
        {
            var converted = GetType(assembly, pattern);

            return CreateInstance(converted);
        }

        public object CreateInstance(Type type)
        {
            var instance = XCommonAppPal.Api.Activation.CreateInstance(type);

            Assert.IsNotNull(instance);

            return instance;
        }

	    public void TestField<T>(object result, string fieldName, T howdy)
	    {
		    var type = result.GetType();

		    var field = type.GetField(fieldName);

			field.SetValue(result, howdy);

			Assert.AreSame(howdy, (T)field.GetValue(result));
	    }

	    public object TestMethod(object instance, string methodName)
	    {
			var type = instance.GetType();

		    var method = type.GetMethod(methodName);

		    return method.Invoke(instance, new object[]{});
		}

	    public void HasField(object instance, string fieldName, FieldAttributes attributes)
	    {
			var type = instance.GetType();

		    var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

			Assert.IsNotNull(field);

		    Assert.IsTrue((field.Attributes & attributes) == attributes);
	    }

	    
	}
}
