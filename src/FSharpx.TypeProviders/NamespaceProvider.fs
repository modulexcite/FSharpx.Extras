﻿module FSharpx.TypeProviders.NamespaceProvider

open System.Reflection
open Microsoft.FSharp.Core.CompilerServices
open Samples.FSharp.ProvidedTypes
open System.Text.RegularExpressions

[<TypeProvider>]
type public FSharpxProvider(cfg:TypeProviderConfig) as this =
    inherit TypeProviderForNamespaces()

    do this.AddNamespace(
        Settings.rootNamespace, 
        [RegexTypeProvider.regexTy
         MiniCsvProvider.csvType cfg
         FilesTypeProvider.typedFileSystem
         XmlTypeProvider.xmlType this cfg
         JsonProvider.jsonType cfg
         RegistryProvider.typedRegistry
         XamlProvider.xamlFileTypeUninstantiated this cfg
         XamlProvider.xamlTextTypeUninstantiated cfg
         AppSettingsTypeProvider.typedAppSettings cfg
         ExcelProvider.typExcel cfg ])

[<TypeProviderAssembly>]
do ()