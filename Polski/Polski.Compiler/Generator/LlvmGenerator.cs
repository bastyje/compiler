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
    
    #region Main
    
    public static string MainFunctionOpen() => "define i32 @main() nounwind {";
    public static string MainFunctionClose() =>
        """
          ret i32 0
        }
        """;
    
    #endregion
    
    #region Arithmetic
    
    public static string CallAdd(Member resultMember, Operand left, Operand right) => LlvmDataType.MapFromPolski(resultMember.LlvmType) switch
    {
        LlvmDataType.Int32 => AddInt32(resultMember.LlvmName, left, right),
        LlvmDataType.Int64 => AddInt64(resultMember.LlvmName, left, right),
        LlvmDataType.Float => AddFloat(resultMember.LlvmName, left, right),
        LlvmDataType.Double => AddDouble(resultMember.LlvmName, left, right),
        _ => throw new InvalidOperationException()
    };
    
    public static string CallSub(Member resultMember, Operand left, Operand right) => LlvmDataType.MapFromPolski(resultMember.LlvmType) switch
    {
        LlvmDataType.Int32 => SubInt32(resultMember.LlvmName, left, right),
        LlvmDataType.Int64 => SubInt64(resultMember.LlvmName, left, right),
        LlvmDataType.Float => SubFloat(resultMember.LlvmName, left, right),
        LlvmDataType.Double => SubDouble(resultMember.LlvmName, left, right),
        _ => throw new InvalidOperationException()
    };
    
    public static string CallMul(Member resultMember, Operand left, Operand right) => LlvmDataType.MapFromPolski(resultMember.LlvmType) switch
    {
        LlvmDataType.Int32 => MulInt32(resultMember.LlvmName, left, right),
        LlvmDataType.Int64 => MulInt64(resultMember.LlvmName, left, right),
        LlvmDataType.Float => MulFloat(resultMember.LlvmName, left, right),
        LlvmDataType.Double => MulDouble(resultMember.LlvmName, left, right),
        _ => throw new InvalidOperationException()
    };
    
    public static string CallDiv(Member resultMember, Operand left, Operand right) => LlvmDataType.MapFromPolski(resultMember.LlvmType) switch
    {
        LlvmDataType.Int32 => DivInt32(resultMember.LlvmName, left, right),
        LlvmDataType.Int64 => DivInt64(resultMember.LlvmName, left, right),
        LlvmDataType.Float => DivFloat(resultMember.LlvmName, left, right),
        LlvmDataType.Double => DivDouble(resultMember.LlvmName, left, right),
        _ => throw new InvalidOperationException()
    };
    
    private static string AddInt32(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = add i32 {left}, {right}\n";
    }
    
    private static string AddInt64(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = add i64 {left}, {right}\n";
    }
    
    private static string AddFloat(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = fadd float {left}, {right}\n";
    }
    
    private static string AddDouble(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = fadd double {left}, {right}\n";
    }
    
    private static string SubInt32(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = sub i32 {left}, {right}\n";
    }
    
    private static string SubInt64(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = sub i64 {left}, {right}\n";
    }
    
    private static string SubFloat(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = fsub float {left}, {right}\n";
    }
    
    private static string SubDouble(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = fsub double {left}, {right}\n";
    }
    
    private static string MulInt32(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = mul i32 {left}, {right}\n";
    }
    
    private static string MulInt64(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = mul i64 {left}, {right}\n";
    }
    
    private static string MulFloat(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = fmul float {left}, {right}\n";
    }
    
    private static string MulDouble(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = fmul double {left}, {right}\n";
    }
    
    private static string DivInt32(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = sdiv i32 {left}, {right}\n";
    }
    
    private static string DivInt64(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = sdiv i64 {left}, {right}\n";
    }
    
    private static string DivFloat(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = fdiv float {left}, {right}\n";
    }
    
    private static string DivDouble(string resultIdentifier, Operand left, Operand right)
    {
        return $"  %{resultIdentifier} = fdiv double {left}, {right}\n";
    }
    
    
    #endregion
    
    #region define
    public static string DefinePrint() => "declare i32 @printf(i8*, ...)";
    public static string DefineScanf() => "declare i32 @scanf(i8*, ...)";
    #endregion
    
    #region inputoutput

    public static string PrintLiteral(string strValue, ref int strCounter)
    {
        var strLabel = $"@.str{strCounter++}";
        var llvmCode = $"{strLabel} = private unnamed_addr constant [{strValue.Length + 1} x i8] c\"{strValue}\\00\", align 1\n";
        llvmCode += $"call i32 (i8*, ...) @printf(i8* getelementptr ([{strValue.Length + 1} x i8], [{strValue.Length + 1} x i8]* {strLabel}, i32 0, i32 0))\n";
        return llvmCode;
    }

    public static string PrintfVariable(string resultName, string variableType, ref int strCounter)
    {
        var formatSpecifier = GetFormatSpecifier(variableType);
        var formatStrLabel = $"@.str{strCounter++}";
        var llvmCode = $"{formatStrLabel} = private unnamed_addr constant [4 x i8] c\"{formatSpecifier}\\00\", align 1\n";
        llvmCode += $"call i32 (i8*, ...) @printf(i8* getelementptr ([4 x i8], [4 x i8]* {formatStrLabel}, i32 0, i32 0), {variableType} %{resultName})\n";
        return llvmCode;
    }

    public static string ScanfVariable(string variableName, string variableType, ref int strCounter)
    {
        var formatSpecifier = GetFormatSpecifier(variableType);
        var formatStrLabel = $"@.str{strCounter++}";
        var llvmCode = $"{formatStrLabel} = private unnamed_addr constant [3 x i8] c\"{formatSpecifier}\\00\", align 1\n";
        llvmCode += $"call i32 (i8*, ...) @scanf(i8* getelementptr ([3 x i8], [3 x i8]* {formatStrLabel}, i32 0, i32 0), {variableType}* %{variableName})\n";
        return llvmCode;
    }

    private static string GetFormatSpecifier(string llvmType)
    {
        switch (llvmType)
        {
            case "i32": return "%d";
            case "float": return "%f";
            default: throw new NotImplementedException($"No scanf or printf format specifier for LLVM type: {llvmType}");
        }
    }
    #endregion
}