// <copyright>
//   Copyright (c) 2010 Huseyin Tufekcilerli. All rights reserved.
//   
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   
//       http://www.apache.org/licenses/LICENSE-2.0
//   
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <author>Huseyin Tufekcilerli</author>

using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("Putio")]
[assembly: AssemblyDescription(".NET API for Put.io HTTP RPC")]
[assembly: AssemblyCompany("Hüseyin Tüfekçilerli")]
[assembly: AssemblyProduct("Putio")]
[assembly: AssemblyCopyright("Copyright © Hüseyin Tüfekçilerli 2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("40b0315c-88b6-4c70-918f-80b280489193")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("1.1.0.0")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#elif RELEASE
[assembly: AssemblyConfiguration("Release")]
#else
[assembly: AssemblyConfiguration("Unknown")]
#endif