using Polski.Compiler.Generator;

namespace Polski.Compiler.Tests.Generator;

public class LlvmDataTypeTests
{
    [Theory]
    [InlineData("int", "i32")]
    [InlineData("float", "float")]
    public void MapFromPolski_WhenPolskiTypeIsGiven_ShouldReturnLlvmType(string polskiType, string llvmType)
    {
        // act
        var result = LlvmDataType.MapFromPolski(polskiType);
        
        // assert
        Assert.Equal(llvmType, result);
    }

    [Fact]
    public void MapFromPolski_WhenUnknownTypeIsGiven_ShouldThrowException()
    {
        // act
        void Action() => LlvmDataType.MapFromPolski("unknown");

        // assert
        Assert.Throws<Exception>(Action);
    }
}