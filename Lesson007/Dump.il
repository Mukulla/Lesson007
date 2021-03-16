
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.8.3928.0




// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Lesson007
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- Следующий настраиваемый атрибут добавлен автоматически, не следует отменять преобразование в комментарий -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 02 00 00 00 00 00 ) 

  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 09 4C 65 73 73 6F 6E 30 30 37 00 00 )       // ...Lesson007..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 09 4C 65 73 73 6F 6E 30 30 37 00 00 )       // ...Lesson007..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 12 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  20 32 30 32 31 00 00 )                            //  2021..
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 33 61 39 36 63 33 35 34 2D 32 38 33 64   // ..$3a96c354-283d
                                                                                                  2D 34 33 38 32 2D 38 65 32 63 2D 37 36 31 38 38   // -4382-8e2c-76188
                                                                                                  39 35 36 38 64 63 38 00 00 )                      // 9568dc8..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 31 2E 30 2E 30 2E 30 00 00 )             // ...1.0.0.0..
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1C 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 37 2E 32 01   // ,Version=v4.7.2.
                                                                                                        00 54 0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73   // .T..FrameworkDis
                                                                                                        70 6C 61 79 4E 61 6D 65 14 2E 4E 45 54 20 46 72   // playName..NET Fr
                                                                                                        61 6D 65 77 6F 72 6B 20 34 2E 37 2E 32 )          // amework 4.7.2
  .hash algorithm 0x00008004
  .ver 1:0:0:0
}
.module Lesson007.exe
// MVID: {F118E8EC-E0B9-4179-A844-B3E18AF4FE18}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00020003    //  ILONLY 32BITPREFERRED
// Image base: 0x004D0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Lesson007.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Размер кода:       29 (0x1d)
    .maxstack  8
    IL_0000:  ldc.i4.s   15
    IL_0002:  newarr     [mscorlib]System.Int32
    IL_0007:  dup
    IL_0008:  ldc.i4.s   -31
    IL_000a:  ldc.i4.s   31
    IL_000c:  call       void Lesson007.Program::SetRandomValues(int32[],
                                                                 int32,
                                                                 int32)
    IL_0011:  call       void Lesson007.Program::Show(int32[])
    IL_0016:  call       int32 [mscorlib]System.Console::Read()
    IL_001b:  pop
    IL_001c:  ret
  } // end of method Program::Main

  .method private hidebysig static void  SetRandomValues(int32[] SomeArray001,
                                                         int32 Min,
                                                         int32 Max) cil managed
  {
    // Размер кода:       41 (0x29)
    .maxstack  5
    .locals init ([0] class [mscorlib]System.Random Rand001,
             [1] int32 i)
    IL_0000:  ldarg.0
    IL_0001:  call       bool Lesson007.Program::CheckArray<int32>(!!0[])
    IL_0006:  brtrue.s   IL_0009

    IL_0008:  ret

    IL_0009:  newobj     instance void [mscorlib]System.Random::.ctor()
    IL_000e:  stloc.0
    IL_000f:  ldc.i4.0
    IL_0010:  stloc.1
    IL_0011:  br.s       IL_0022

    IL_0013:  ldarg.0
    IL_0014:  ldloc.1
    IL_0015:  ldloc.0
    IL_0016:  ldarg.1
    IL_0017:  ldarg.2
    IL_0018:  callvirt   instance int32 [mscorlib]System.Random::Next(int32,
                                                                      int32)
    IL_001d:  stelem.i4
    IL_001e:  ldloc.1
    IL_001f:  ldc.i4.1
    IL_0020:  add
    IL_0021:  stloc.1
    IL_0022:  ldloc.1
    IL_0023:  ldarg.0
    IL_0024:  ldlen
    IL_0025:  conv.i4
    IL_0026:  blt.s      IL_0013

    IL_0028:  ret
  } // end of method Program::SetRandomValues

  .method private hidebysig static void  Show(int32[] SomeArray001) cil managed
  {
    // Размер кода:       34 (0x22)
    .maxstack  2
    .locals init ([0] int32[] V_0,
             [1] int32 V_1)
    IL_0000:  ldarg.0
    IL_0001:  call       bool Lesson007.Program::CheckArray<int32>(!!0[])
    IL_0006:  brtrue.s   IL_0009

    IL_0008:  ret

    IL_0009:  ldarg.0
    IL_000a:  stloc.0
    IL_000b:  ldc.i4.0
    IL_000c:  stloc.1
    IL_000d:  br.s       IL_001b

    IL_000f:  ldloc.0
    IL_0010:  ldloc.1
    IL_0011:  ldelem.i4
    IL_0012:  call       void [mscorlib]System.Console::WriteLine(int32)
	IL_0015:  call       void [mscorlib]System.Console::WriteLine()
    IL_0017:  ldloc.1
    IL_0018:  ldc.i4.1
    IL_0019:  add
    IL_001a:  stloc.1
    IL_001b:  ldloc.1
    IL_001c:  ldloc.0
    IL_001d:  ldlen
    IL_001e:  conv.i4
    IL_001f:  blt.s      IL_000f

    IL_0021:  ret
  } // end of method Program::Show

  .method private hidebysig static bool  CheckArray<T>(!!T[] SomeArray001) cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brtrue.s   IL_0005

    IL_0003:  ldc.i4.0
    IL_0004:  ret

    IL_0005:  ldc.i4.1
    IL_0006:  ret
  } // end of method Program::CheckArray

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Размер кода:       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Program::.ctor

} // end of class Lesson007.Program


// =============================================================

// *********** ДИЗАССЕМБЛИРОВАНИЕ ЗАВЕРШЕНО ***********************
// ВНИМАНИЕ: создан файл ресурсов Win32 C:\Git\Lessons\Lesson007\Lesson007\Dump.res
