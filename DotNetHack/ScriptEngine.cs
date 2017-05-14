using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using DotNetHack.Definitions;
using Microsoft.CSharp;

namespace DotNetHack
{
    /// <summary>
    /// ScriptEngine
    /// </summary>
    public class ScriptEngine
    {
        /// <summary>
        /// Gets the engine.
        /// </summary>
        /// <value>
        /// The engine.
        /// </value>
        public Engine Engine { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptEngine"/> class.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <exception cref="ArgumentNullException">engine</exception>
        public ScriptEngine(Engine engine)
        {
            if (engine == null)
            {
                throw new ArgumentNullException(nameof(engine));
            }

            Engine = engine;
        }

        /// <summary>
        /// The compiler parameters
        /// </summary>
        private readonly CompilerParameters compilerParameters = new CompilerParameters
        {
            GenerateExecutable = false,
            GenerateInMemory = true,

            // only include debug information if a compiler is attachedk
            IncludeDebugInformation = Debugger.IsAttached,
        };

        /// <summary>
        /// Compiles this instance.
        /// </summary>
        public void Compile()
        {
            var scriptBlock = GenerateCode();

            using (var provider = new CSharpCodeProvider())
            {
                // link in the executing assembly
                compilerParameters.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);

                var compilerResults = provider.CompileAssemblyFromSource(compilerParameters, scriptBlock);

                OnBuildErrorEvent(new BuildEventArgs(scriptBlock, compilerResults));

                Assembly = compilerResults.CompiledAssembly;
            }
        }

        /// <summary>
        /// Gets or sets the assembly.
        /// </summary>
        /// <value>
        /// The assembly.
        /// </value>
        public Assembly Assembly { get; set; }

        /// <summary>
        /// Raises the <see cref="E:BuildErrorEvent" /> event.
        /// </summary>
        /// <param name="e">The <see cref="BuildEventArgs"/> instance containing the event data.</param>
        protected virtual void OnBuildErrorEvent(BuildEventArgs e)
        {
            BuildErrorEvent?.Invoke(this, e);
        }

        /// <summary>
        /// Occurs when [build error event].
        /// </summary>
        public event EventHandler<BuildEventArgs> BuildErrorEvent;

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
        private string GenerateCode()
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

            AppendScriptSection("items", codeBlock, Engine.Package.Items);

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
    }
}