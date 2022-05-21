namespace CalculatorApp.WebApi
{
    public static class CalculatorAppHelpercs
    {
        public static bool ValidateOperations(string operation)
        {         
                List<string> allowedOperation = new List<string> { "Add", "Subtract", "Multiply", "Divide" };

                if ( !allowedOperation.Contains(operation))
                {
                    return false;
                }
                return true;

        }
    }
}
