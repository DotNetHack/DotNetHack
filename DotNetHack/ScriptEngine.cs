using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using DotNetHack.Definitions;
using Microsoft.CSharp;

namespace DotNetHack
{
    /// <summary>
    /// ScriptEngine
    /// </summary>
    public static class ScriptEngine
    {
        /// <summary>
        /// The compiler parameters
        /// </summary>
        private static readonly CompilerParameters compilerParameters = new CompilerParameters
        {
            GenerateExecutable = false,
            GenerateInMemory = true,

            // only include debug information if a compiler is attachedk
            IncludeDebugInformation = Debugger.IsAttached,
        };

        /// <summary>
        /// Compiles this instance.
        /// </summary>
        public static void Compile(Engine engine)
        {
            var scriptBlock = GenerateCode(engine);

            using (var provider = new CSharpCodeProvider())
            {
                // link in the executing assembly
                compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

                var compilerResults = provider.CompileAssemblyFromSource(compilerParameters, scriptBlock);

                OnBuildEvent(new BuildEventArgs(scriptBlock, compilerResults));

                Assembly = compilerResults.CompiledAssembly;
            }

            _scriptContextType = Assembly.ExportedTypes.Single();

            var scriptContextCtor = _scriptContextType.GetConstructor(new[] { typeof(Engine) });
            if (scriptContextCtor == null) throw new InvalidOperationException("missing .ctor");

            ScriptContext = scriptContextCtor.Invoke(new object[] { engine });
        }

        /// <summary>
        /// Gets the scripted method.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public static MethodInfo GetScriptMethod(string methodName)
        {
            return _scriptContextType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }

        /// <summary>
        /// Gets the type of the script context.
        /// </summary>
        /// <value>
        /// The type of the script context.
        /// </value>
        private static Type _scriptContextType;

        /// <summary>
        /// Gets the script context.
        /// </summary>
        /// <value>
        /// The script context.
        /// </value>
        public static object ScriptContext { get; private set; }

        /// <summary>
        /// Gets or sets the assembly.
        /// </summary>
        /// <value>
        /// The assembly.
        /// </value>
        public static Assembly Assembly { get; private set; }



        /// <summary>
        /// Occurs when [build error event].
        /// </summary>
        public static event EventHandler<BuildEventArgs> BuildEvent;

        /// <summary>
        /// BuildEventArgs
        /// </summary>
        /// <seealso cref="System.EventArgs" />
        public class BuildEventArgs : EventArgs
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="T:System.EventArgs" /> class.
            /// </summary>
            /// <param name="codeBlock">The code block.</param>
            /// <param name="results">The results.</param>
            public BuildEventArgs(string codeBlock, CompilerResults results)
            {
                CodeBlock = codeBlock;
                Results = results;
            }

            /// <summary>
            /// Gets or sets the code block.
            /// </summary>
            /// <value>
            /// The code block.
            /// </value>
            public string CodeBlock { get; set; }

            /// <summary>
            /// Gets or sets the results.
            /// </summary>
            /// <value>
            /// The results.
            /// </value>
            public CompilerResults Results { get; set; }
        }

        /// <summary>
        /// Generates the code.
        /// </summary>
        /// <returns></returns>
        private static string GenerateCode(Engine engine)
        {
            var codeBlock = new StringBuilder();

            foreach (var include in includes)
            {
                codeBlock.AppendLine($"using {include};");
            }

            codeBlock.AppendLine("public class ScriptContext {");
            codeBlock.AppendLine("public Engine Engine { get; private set; }");
            codeBlock.AppendLine("\tpublic ScriptContext(Engine engine) {");
            codeBlock.AppendLine("\tEngine = engine;");
            codeBlock.AppendLine("}");

            AppendScriptSection("tiles", codeBlock, engine.Package.TileSet);
            AppendScriptSection("items", codeBlock, engine.Package.Items);

            codeBlock.AppendLine("}");

#if DEBUG
            Console.WriteLine(codeBlock);
#endif

            return codeBlock.ToString();
        }

        /// <summary>
        /// Gets the namespaces.
        /// </summary>
        /// <value>
        /// The namespaces.
        /// </value>
        private static readonly string[] includes =
        {
            "System",
            "DotNetHack",
            "DotNetHack.Core",
        };

        /// <summary>
        /// Appends the script section.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="codeBlock">The code block.</param>
        /// <param name="scripted">The scripted.</param>
        private static void AppendScriptSection(string tag, StringBuilder codeBlock, IEnumerable<IScripted> scripted)
        {
            codeBlock.AppendLine("\t#region " + tag);

            foreach (var itemDef in scripted)
            {
                codeBlock.AppendLine("\t" + itemDef.ScriptBlock);
            }

            codeBlock.AppendLine("\t#endregion");
        }

        /// <summary>
        /// Raises the <see cref="E:BuildErrorEvent" /> event.
        /// </summary>
        /// <param name="e">The <see cref="BuildEventArgs"/> instance containing the event data.</param>
        private static void OnBuildEvent(BuildEventArgs e)
        {
            BuildEvent?.Invoke(null, e);
        }
    }
}