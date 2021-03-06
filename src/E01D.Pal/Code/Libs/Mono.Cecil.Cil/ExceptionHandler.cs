//
// Author:
//   Jb Evain (jbevain@gmail.com)
//
// Copyright (c) 2008 - 2015 Jb Evain
// Copyright (c) 2008 - 2011 Novell, Inc.
//
// Licensed under the MIT/X11 license.
//

namespace Root.Code.Libs.Mono.Cecil.Cil {

	public enum ExceptionHandlerType {
		Catch = 0,
		Filter = 1,
		Finally = 2,
		Fault = 4,
	}

	public sealed class ExceptionHandler {

		Instruction try_start;
		Instruction try_end;
		Instruction filter_start;
		Instruction handler_start;
		Instruction handler_end;

		TypeReference catch_type;
		ExceptionHandlerType handler_type;

		/// <summary>
		/// Gets or sets the first instruction that is included in the try catch block
		/// </summary>
		public Instruction TryStart {
			get { return try_start; }
			set { try_start = value; }
		}

		/// <summary>
		/// Gets or sets the first instruction of the catch statement
		/// </summary>
		public Instruction TryEnd {
			get { return try_end; }
			set { try_end = value; }
		}

		public Instruction FilterStart {
			get { return filter_start; }
			set { filter_start = value; }
		}

		public Instruction HandlerStart {
			get { return handler_start; }
			set { handler_start = value; }
		}

		/// <summary>
		/// Gets the first instruction that is outside of the catch statement
		/// </summary>
		public Instruction HandlerEnd {
			get { return handler_end; }
			set { handler_end = value; }
		}

		public TypeReference CatchType {
			get { return catch_type; }
			set { catch_type = value; }
		}

		public ExceptionHandlerType HandlerType {
			get { return handler_type; }
			set { handler_type = value; }
		}

		public ExceptionHandler (ExceptionHandlerType handlerType)
		{
			this.handler_type = handlerType;
		}
	}
}
