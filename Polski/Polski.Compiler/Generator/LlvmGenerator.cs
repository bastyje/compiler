using Polski.Compiler.Common;

namespace Polski.Compiler.Generator;

public static class LlvmGenerator
{
    public static string AllocateVariable(string name, string type)
    {
        var llvmType = LlvmDataType.MapFromPolski(type);
        return $"  %{name} = alloca {llvmType}\n";
    }

    public static string StoreValue(string name, string type, string value)
    {
        var llvmType = LlvmDataType.MapFromPolski(type);
        return $"  store {llvmType} %{value}, {llvmType}* %{name}\n";
    }
    
    public static string LoadValue(string resultName, string name, string type)
    {
        var llvmType = LlvmDataType.MapFromPolski(type);
        return $"  %{resultName} = load {llvmType}, {llvmType}* %{name}\n";
    }

    public static string StorePrimitiveValue(string name, string type, string value)
    {
        var llvmType = LlvmDataType.MapFromPolski(type);
        return $"  store {llvmType} {value}, {llvmType}* %{name}\n";
    }
    
    public static string InitializeStandardFunctions() => string.Join(
        '\n',
        AddI32,
        AddFloat,
        SubI32,
        SubFloat,
        MulI32,
        MulFloat,
        DivI32,
        DivFloat);
    
    #region Main
    
    public static string MainFunctionOpen() => "define i32 @main() nounwind {";
    public static string MainFunctionClose() =>
        """
          ret i32 0
        }
        """;
    
    #endregion
    
    #region Arithmetic

    #region Calls
    
    public static string CallAddI32(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = call i32 @add_i32(i32 {left}, i32 {right})\n";
    }
    
    public static string CallAddFloat(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = call float @add_float(float {left}, float {right})\n";
    }
    
    public static string CallSubI32(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = call i32 @sub_i32(i32 {left}, i32 {right})\n";
    }
    
    public static string CallSubFloat(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = call float @sub_float(float {left}, float {right})\n";
    }
    
    public static string CallMulI32(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = call i32 @mul_i32(i32 {left}, i32 {right})\n";
    }
    
    public static string CallMulFloat(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = call float @mul_float(float {left}, float {right})\n";
    }
    
    public static string CallDivI32(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = call i32 @div_i32(i32 {left}, i32 {right})\n";
    }

    public static string CallDivFloat(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = call float @div_float(float {left}, float {right})\n";
    }

    #endregion

    #region Definitions
    
    private const string AddI32 =
        """
        define i32 @add_i32(i32 %left, i32 %right) {
          %ret = add i32 %left, %right
          ret i32 %ret
        }
        """;

    private const string AddFloat =
        """
        define float @add_float(float %left, float %right) {
          %ret = fadd float %left, %right
          ret float %ret
        }
        """;

    private const string SubI32 =
        """
        define i32 @sub_i32(i32 %left, i32 %right) {
          %ret = sub i32 %left, %right
          ret i32 %ret
        }
        """;

    private const string SubFloat =
        """
        define float @sub_float(float %left, float %right) {
          %ret = fsub float %left, %right
          ret float %ret
        }
        """;

    private const string MulI32 =
        """
        define i32 @mul_i32(i32 %left, i32 %right) {
          %ret = mul i32 %left, %right
          ret i32 %ret
        }
        """;

    private const string MulFloat =
        """
        define float @mul_float(float %left, float %right) {
          %ret = fmul float %left, %right
          ret float %ret
        }
        """;

    private const string DivI32 =
        """
        define i32 @div_i32(i32 %left, i32 %right) {
          %ret = sdiv i32 %left, %right
          ret i32 %ret
        }
        """;

    private const string DivFloat =
        """
        define float @div_float(float %left, float %right) {
          %ret = fdiv float %left, %right
          ret float %ret
        }
        """;
    
    #endregion
    
    #endregion
}