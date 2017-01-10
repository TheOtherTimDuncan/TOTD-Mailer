﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version: 14.0.0.0
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------
namespace TOTD.Mailer.Templates
{
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "C:\Users\tdunc\Code\Projects\TOTD-Mailer\TOTD.Mailer.Templates\DefaultStyles.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public partial class DefaultStyles : DefaultStylesBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("img {\r\n    border: none;\r\n    -ms-interpolation-mode: bicubic;\r\n    max-width: 10" +
                    "0%;\r\n}\r\n\r\nbody {\r\n    background-color: #f6f6f6;\r\n    font-family: sans-serif;\r\n" +
                    "    -webkit-font-smoothing: antialiased;\r\n    font-size: 14px;\r\n    line-height:" +
                    " 1.4;\r\n    margin: 0;\r\n    padding: 0;\r\n    -ms-text-size-adjust: 100%;\r\n    -we" +
                    "bkit-text-size-adjust: 100%;\r\n}\r\n\r\ntable {\r\n    border-collapse: separate;\r\n    " +
                    "mso-table-lspace: 0pt;\r\n    mso-table-rspace: 0pt;\r\n    width: 100%;\r\n}\r\n\r\n    t" +
                    "able td {\r\n        font-family: sans-serif;\r\n        font-size: 14px;\r\n        v" +
                    "ertical-align: top;\r\n    }\r\n/* -------------------------------------\r\n          " +
                    "BODY & CONTAINER\r\n      ------------------------------------- */\r\n.body {\r\n    b" +
                    "ackground-color: #f6f6f6;\r\n    width: 100%;\r\n}\r\n/* Set a max-width, and make it " +
                    "display as block so it will automatically stretch to that width, but will also s" +
                    "hrink down on a phone or something */\r\n.container {\r\n    display: block;\r\n    ma" +
                    "rgin: 0 auto !important;\r\n    /* makes it centered */\r\n    max-width: 580px;\r\n  " +
                    "  padding: 10px;\r\n    width: 580px;\r\n}\r\n/* This should also be a block element, " +
                    "so that it will fill 100% of the .container */\r\n.content {\r\n    box-sizing: bord" +
                    "er-box;\r\n    display: block;\r\n    margin: 0 auto;\r\n    max-width: 580px;\r\n    pa" +
                    "dding: 10px;\r\n}\r\n/* -------------------------------------\r\n          HEADER, FOO" +
                    "TER, MAIN\r\n      ------------------------------------- */\r\n.main {\r\n    backgrou" +
                    "nd: #fff;\r\n    border-radius: 3px;\r\n    width: 100%;\r\n}\r\n\r\n.wrapper {\r\n    box-s" +
                    "izing: border-box;\r\n    padding: 20px;\r\n}\r\n\r\n.footer {\r\n    clear: both;\r\n    pa" +
                    "dding-top: 10px;\r\n    text-align: center;\r\n    width: 100%;\r\n}\r\n\r\n    .footer td" +
                    ",\r\n    .footer p,\r\n    .footer span,\r\n    .footer a {\r\n        color: #999999;\r\n" +
                    "        font-size: 12px;\r\n        text-align: center;\r\n    }\r\n/* ---------------" +
                    "----------------------\r\n          TYPOGRAPHY\r\n      ----------------------------" +
                    "--------- */\r\nh1,\r\nh2,\r\nh3,\r\nh4 {\r\n    color: #000000;\r\n    font-family: sans-se" +
                    "rif;\r\n    font-weight: 400;\r\n    line-height: 1.4;\r\n    margin: 0;\r\n    margin-b" +
                    "ottom: 30px;\r\n}\r\n\r\nh1 {\r\n    font-size: 35px;\r\n    font-weight: 300;\r\n    text-a" +
                    "lign: center;\r\n    text-transform: capitalize;\r\n}\r\n\r\np,\r\nul,\r\nol {\r\n    font-fam" +
                    "ily: sans-serif;\r\n    font-size: 14px;\r\n    font-weight: normal;\r\n    margin: 0;" +
                    "\r\n    margin-bottom: 15px;\r\n}\r\n\r\n    p li,\r\n    ul li,\r\n    ol li {\r\n        lis" +
                    "t-style-position: inside;\r\n        margin-left: 5px;\r\n    }\r\n\r\na {\r\n    color: #" +
                    "3498db;\r\n    text-decoration: underline;\r\n}\r\n/* --------------------------------" +
                    "-----\r\n          BUTTONS\r\n      ------------------------------------- */\r\n.btn {" +
                    "\r\n    box-sizing: border-box;\r\n    width: 100%;\r\n}\r\n\r\n    .btn > tbody > tr > td" +
                    " {\r\n        padding-bottom: 15px;\r\n    }\r\n\r\n    .btn table {\r\n        width: aut" +
                    "o;\r\n    }\r\n\r\n        .btn table td {\r\n            background-color: #ffffff;\r\n  " +
                    "          border-radius: 5px;\r\n            text-align: center;\r\n        }\r\n\r\n   " +
                    " .btn a {\r\n        background-color: #ffffff;\r\n        border: solid 1px #3498db" +
                    ";\r\n        border-radius: 5px;\r\n        box-sizing: border-box;\r\n        color: " +
                    "#3498db;\r\n        cursor: pointer;\r\n        display: inline-block;\r\n        font" +
                    "-size: 14px;\r\n        font-weight: bold;\r\n        margin: 0;\r\n        padding: 1" +
                    "2px 25px;\r\n        text-decoration: none;\r\n        text-transform: capitalize;\r\n" +
                    "    }\r\n\r\n.btn-primary table td {\r\n    background-color: #3498db;\r\n}\r\n\r\n.btn-prim" +
                    "ary a {\r\n    background-color: #3498db;\r\n    border-color: #3498db;\r\n    color: " +
                    "#ffffff;\r\n}\r\n/* -------------------------------------\r\n          OTHER STYLES TH" +
                    "AT MIGHT BE USEFUL\r\n      ------------------------------------- */\r\n.last {\r\n   " +
                    " margin-bottom: 0;\r\n}\r\n\r\n.first {\r\n    margin-top: 0;\r\n}\r\n\r\n.align-center {\r\n   " +
                    " text-align: center;\r\n}\r\n\r\n.align-right {\r\n    text-align: right;\r\n}\r\n\r\n.align-l" +
                    "eft {\r\n    text-align: left;\r\n}\r\n\r\n.clear {\r\n    clear: both;\r\n}\r\n\r\n.mt0 {\r\n    " +
                    "margin-top: 0;\r\n}\r\n\r\n.mb0 {\r\n    margin-bottom: 0;\r\n}\r\n\r\n.preheader {\r\n    color" +
                    ": transparent;\r\n    display: none;\r\n    height: 0;\r\n    max-height: 0;\r\n    max-" +
                    "width: 0;\r\n    opacity: 0;\r\n    overflow: hidden;\r\n    mso-hide: all;\r\n    visib" +
                    "ility: hidden;\r\n    width: 0;\r\n}\r\n\r\n.powered-by a {\r\n    text-decoration: none;\r" +
                    "\n}\r\n\r\nhr {\r\n    border: 0;\r\n    border-bottom: 1px solid #f6f6f6;\r\n    margin: 2" +
                    "0px 0;\r\n}\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "14.0.0.0")]
    public class DefaultStylesBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
