using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("PutioConsole")]
[assembly: AssemblyDescription("Sample console application for Put.io .NET API")]
[assembly: AssemblyCompany("Hüseyin Tüfekçilerli")]
[assembly: AssemblyProduct("PutioConsole")]
[assembly: AssemblyCopyright("Copyright © Hüseyin Tüfekçilerli 2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("afb2d076-9a9c-47ea-b149-ec038af1e629")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("0.1.0.0")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#elif RELEASE
[assembly: AssemblyConfiguration("Release")]
#else
[assembly: AssemblyConfiguration("Unknown")]
#endif