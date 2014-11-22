namespace global

open System.Runtime.CompilerServices
open Microsoft.FSharp.Core.CompilerServices

[<assembly:TypeProviderAssembly("FSharp.Data.TeamCity.DesignTime")>]
[<assembly:InternalsVisibleTo("FSharp.Data.TeamCity.Tests")>]
do()
