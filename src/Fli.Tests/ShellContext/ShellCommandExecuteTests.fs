module Fli.ShellContext.ShellCommandExecuteTests

open NUnit.Framework
open FsUnit
open Fli
open System


[<Test>]
let ``Hello World with CMD`` () =
    if OperatingSystem.IsWindows() then
        cli {
            Shell CMD
            Command "echo Hello World!"
        }
        |> Command.execute
        |> should equal "Hello World!\r\n"
    else
        Assert.Pass()

[<Test>]
let ``Hello World with PS`` () =
    if OperatingSystem.IsWindows() then
        cli {
            Shell PS
            Command "Write-Host Hello World!"
        }
        |> Command.execute
        |> should equal "Hello World!\n"
    else
        Assert.Pass()

[<Test>]
let ``Hello World with PWSH`` () =
    if OperatingSystem.IsWindows() then
        cli {
            Shell PWSH
            Command "Write-Host Hello World!"
        }
        |> Command.execute
        |> should equal "Hello World!\r\n"
    else
        Assert.Pass()

[<Test>]
let ``Hello World with BASH`` () =
    if OperatingSystem.IsWindows() |> not then
        cli {
            Shell BASH
            Command "\"echo Hello World!\""
        }
        |> Command.execute
        |> should equal "Hello World!\n"
    else
        Assert.Pass()