﻿namespace Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Instructions
{
    public class InstructionTest_AddOvf
    {
        public int Execute()
        {
            int a = 2;
            int b = 2;
            int c;
            checked
            {
                
                c = a + b;
            }

            return c;

        }
    }
}
