namespace System
open System.Reflection

[<assembly: AssemblyTitleAttribute("FSharp.Data.TeamCity")>]
[<assembly: AssemblyProductAttribute("FSharp.Data.TeamCity")>]
[<assembly: AssemblyDescriptionAttribute("TeamCity Type Provider")>]
[<assembly: AssemblyVersionAttribute("1.0")>]
[<assembly: AssemblyFileVersionAttribute("1.0")>]
do ()

module internal AssemblyVersionInformation =
    let [<Literal>] Version = "1.0"
