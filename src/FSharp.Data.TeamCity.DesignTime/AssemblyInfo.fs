namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp.Data.TeamCity.DesignTime")>]
[<assembly: AssemblyProductAttribute("FSharp.Data.TeamCity")>]
[<assembly: AssemblyDescriptionAttribute("Library of F# type providers for TeamCity")>]
[<assembly: AssemblyVersionAttribute("0.1.0.0")>]
[<assembly: AssemblyFileVersionAttribute("0.1.0.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "0.1.0.0"
