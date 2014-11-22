namespace ProviderImplementation

open Microsoft.FSharp.Core.CompilerServices
open ProviderImplementation.ProvidedTypes
open System
open System.Net
open System.Xml

[<TypeProvider>]
type TeamCityProvider (cfg: TypeProviderConfig) as this =
  inherit DisposableTypeProviderForNamespaces()

  let asm, version, replacer = AssemblyResolver.init cfg
  let ns = "FSharp.Data"

  let buildType (typeName: string) (args: obj[]) =
    let t = ProvidedTypeDefinition(asm, ns, typeName, Some typeof<obj>)

    let host = args.[0] :?> string
    let port = args.[1] :?> int
    let user = args.[2] :?> string
    let password = args.[3] :?> string

    let serverUri = new Uri(sprintf "http://%s:%d/httpAuth/app/rest/server/" host port)
    let webClient = new WebClient()
    webClient.Credentials <- new System.Net.NetworkCredential(user, password)
    let serverXml = webClient.DownloadString(serverUri)
    let serverDoc = XmlDocument()
    serverDoc.LoadXml(serverXml)

    let versionMajor = Int32.Parse(serverDoc.DocumentElement.Attributes.["versionMajor"].Value)

    let versionMajorProperty = ProvidedProperty("VersionMajor", typeof<int>, IsStatic = true, GetterCode = (fun args -> <@@ versionMajor @@>))
    t.AddMember(versionMajorProperty)

    t

  do
    let parameters =
      [ ProvidedStaticParameter("host", typeof<string>)
        ProvidedStaticParameter("port", typeof<int>)
        ProvidedStaticParameter("user", typeof<string>)
        ProvidedStaticParameter("password", typeof<string>) ]
    let teamcityType = ProvidedTypeDefinition(asm, ns, "TeamCity", Some typeof<obj>)
    teamcityType.DefineStaticParameters(parameters, buildType)
    this.AddNamespace(ns, [ teamcityType ])