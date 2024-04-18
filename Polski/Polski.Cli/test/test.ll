  declare i32 @printf(i8*, ...)
  declare i32 @__isoc99_scanf(i8*, ...)
  @.str.printf.i32 = private unnamed_addr constant [4 x i8] c"%d\0A\00", align 1
  @.str.printf.i64 = private unnamed_addr constant [6 x i8] c"%lld\0A\00", align 1
  @.str.printf.double = private unnamed_addr constant [5 x i8] c"%lf\0A\00", align 1
  @.str.scanf.i32 = private unnamed_addr constant [3 x i8] c"%d\00", align 1
  @.str.scanf.i64 = private unnamed_addr constant [5 x i8] c"%lld\00", align 1
  @.str.scanf.double = private unnamed_addr constant [4 x i8] c"%lf\00", align 1

define i32 @test(i32 %0, i32 %1) {
  br label %3

3:
  %4 = icmp sgt i32 %0, %1
  br i1 %4, label %5, label %38

5:
  %6 = sub i32 %0, 1
  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @.str.printf.i32, i32 0, i32 0), i32 %0)
  %8 = icmp slt i32 %0, 3
  %9 = icmp eq i32 %1, 5
  %10 = xor i1 %9, true
  %11 = alloca i1
  br i1 %8, label %12, label %14

12:
  br i1 %10, label %13, label %14

13:
  store i1 true, i1* %11
  br label %15

14:
  store i1 false, i1* %11
  br label %15

15:
  %16 = load i1, i1* %11
  br i1 %16, label %17, label %21

17:
  %18 = alloca i32
  store i32 6, i32* %18
  %19 = load i32, i32* %18
  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @.str.printf.i32, i32 0, i32 0), i32 %19)
  br label %22

21:
  br label %22

22:
  %23 = icmp eq i32 %0, 3
  %24 = icmp ne i32 %1, 5
  %25 = alloca i1
  br i1 %23, label %26, label %27

26:
  br i1 %24, label %29, label %28

27:
  br i1 %24, label %28, label %29

28:
  store i1 true, i1* %25
  br label %30

29:
  store i1 false, i1* %25
  br label %30

30:
  %31 = load i1, i1* %25
  br i1 %31, label %32, label %36

32:
  %33 = alloca i32
  store i32 3, i32* %33
  %34 = load i32, i32* %33
  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @.str.printf.i32, i32 0, i32 0), i32 %34)
  br label %37

36:
  br label %37

37:
  br label %3

38:
  %39 = add i32 %0, %1
  ret i32 %39
}
define i32 @main() nounwind {
  %1 = alloca i32
  store i32 10, i32* %1
  %2 = load i32, i32* %1
  %3 = call i32 @test(i32 %2, i32 5)
  call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* @.str.printf.i32, i32 0, i32 0), i32 %3)
  ret i32 0
}
