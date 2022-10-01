﻿module Fli.ProgramCommandConfigTests

open NUnit.Framework
open FsUnit
open Fli
open System


[<Test>]
let ``Check executable name config for executing program`` () =
    cli { Exec "cmd.exe" } |> (fun c -> c.config.Program) |> should equal "cmd.exe"

[<Test>]
let ``Check arguments config for executing program`` () =
    cli {
        Exec "cmd.exe"
        Arguments "echo Hello World!"
    }
    |> fun c -> c.config.Arguments
    |> should equal (Some "echo Hello World!")


[<Test>]
let ``Check arguments list config for executing program`` () =
    cli {
        Exec "cmd.exe"
        Arguments [ "echo"; "Hello World!" ]
    }
    |> fun c -> c.config.Arguments
    |> should equal (Some "echo Hello World!")

[<Test>]
let ``Check working directory config for executing program`` () =
    cli {
        Exec "cmd.exe"
        WorkingDirectory @"C:\Users"
    }
    |> fun c -> c.config.WorkingDirectory
    |> should equal (Some @"C:\Users")

[<Test>]
let ``Check Verb config for executing program`` () =
    cli {
        Exec "cmd.exe"
        Verb "runas"
    }
    |> fun c -> c.config.Verb
    |> should equal (Some "runas")

[<Test>]
let ``Check credentials config for executing program`` () =
    cli {
        Exec "cmd.exe"
        WorkingDirectory @"C:\Users"
        Username "admin"
    }
    |> fun c -> c.config.UserName.Value
    |> should equal "admin"

[<Test>]
let ``Check credentials config for executing program with NetworkCredentials`` () =
    cli {
        Exec "cmd.exe"
        WorkingDirectory @"C:\Users"
        Username "admin@company"
    }
    |> fun c -> c.config.UserName.Value
    |> should equal "admin@company"
