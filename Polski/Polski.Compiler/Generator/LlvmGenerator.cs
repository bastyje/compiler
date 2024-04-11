using System.Text;
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

    public static string Header() => new StringBuilder()
        .AppendLine(DeclarePrintf())
        .AppendLine(DeclareScanf())
        .AppendLine(DeclarePrintI32Format())
        .AppendLine(DeclarePrintI64Format())
        .AppendLine(DeclarePrintFloatFormat())
        .AppendLine(DeclarePrintDoubleFormat())
        .AppendLine(DeclareScanI32Format())
        .AppendLine(DeclareScanI64Format())
        .AppendLine(DeclareScanFloatFormat())
        .AppendLine(DeclareScanDoubleFormat())
        .ToString();
    
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

    #region IO

    #region Print
    
    public static string Print(Member member) => LlvmDataType.MapFromPolski(member.LlvmType) switch
    {
        LlvmDataType.Int32 => PrintInt32(member),
        LlvmDataType.Int64 => PrintInt64(member),
        LlvmDataType.Float => PrintFloat(member),
        LlvmDataType.Double => PrintDouble(member),
        _ => throw new InvalidOperationException()
    };
    
    private static string PrintInt32(Member member)
    {
        return $"  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @.str.printf.i32, i32 0, i32 0), i32 %{member.LlvmName})\n";
    }
    
    private static string PrintInt64(Member member)
    {
        return $"  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([6 x i8], [6 x i8]* @.str.printf.i64, i32 0, i32 0), i64 %{member.LlvmName})\n";
    }
    
    private static string PrintFloat(Member member)
    {
        return $"  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @.str.printf.float, i32 0, i32 0), float %{member.LlvmName})\n";
    }
    
    private static string PrintDouble(Member member)
    {
        return $"  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @.str.printf.double, i32 0, i32 0), double %{member.LlvmName})\n";
    }
    
    private static string DeclarePrintf() =>
        """
          declare i32 @printf(i8*, ...)
        """;
    
    #endregion

    #region Scan
    
    public static string Scan(Member member) => LlvmDataType.MapFromPolski(member.LlvmType) switch
    {
        LlvmDataType.Int32 => ScanInt32(member),
        LlvmDataType.Int64 => ScanInt64(member),
        LlvmDataType.Float => ScanFloat(member),
        LlvmDataType.Double => ScanDouble(member),
        _ => throw new InvalidOperationException()
    };
    
    private static string ScanInt32(Member member)
    {
        return $"  call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @.str.scanf.i32, i32 0, i32 0), i32* %{member.LlvmName})\n";
    }
    
    private static string ScanInt64(Member member)
    {
        return $"  call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([5 x i8], [5 x i8]* @.str.scanf.i64, i32 0, i32 0), i64* %{member.LlvmName})\n";
    }
    
    private static string ScanFloat(Member member)
    {
        return $"  call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([3 x i8], [3 x i8]* @.str.scanf.float, i32 0, i32 0), float* %{member.LlvmName})\n";
    }
    
    private static string ScanDouble(Member member)
    {
        return $"  call i32 (i8*, ...) @__isoc99_scanf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @.str.scanf.double, i32 0, i32 0), double* %{member.LlvmName})\n";
    }

    private static string DeclareScanf() =>
        """
          declare i32 @__isoc99_scanf(i8*, ...)
        """;

    #endregion

    #region FormatStrings
    
    private static string DeclarePrintI32Format() =>
        """
          @.str.printf.i32 = private unnamed_addr constant [4 x i8] c"%d\0A\00", align 1
        """;
    
    private static string DeclarePrintI64Format() =>
        """
          @.str.printf.i64 = private unnamed_addr constant [6 x i8] c"%lld\0A\00", align 1
        """;
    
    private static string DeclarePrintFloatFormat() =>
        """
          @.str.printf.float = private unnamed_addr constant [4 x i8] c"%f\0A\00", align 1
        """;
    
    private static string DeclarePrintDoubleFormat() =>
        """
          @.str.printf.double = private unnamed_addr constant [5 x i8] c"%lf\0A\00", align 1
        """;
    
    private static string DeclareScanI32Format() =>
        """
          @.str.scanf.i32 = private unnamed_addr constant [3 x i8] c"%d\00", align 1
        """;
    
    private static string DeclareScanI64Format() =>
        """
          @.str.scanf.i64 = private unnamed_addr constant [5 x i8] c"%lld\00", align 1
        """;
    
    private static string DeclareScanFloatFormat() =>
        """
          @.str.scanf.float = private unnamed_addr constant [3 x i8] c"%f\00", align 1
        """;
    
    private static string DeclareScanDoubleFormat() =>
        """
          @.str.scanf.double = private unnamed_addr constant [4 x i8] c"%lf\00", align 1
        """;
    
    #endregion
    
    #endregion
}