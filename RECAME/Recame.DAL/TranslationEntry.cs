//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recame.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class TranslationEntry
    {
        public int TranslationId { get; set; }
        public string LanguageId { get; set; }
        public string Text { get; set; }
        public System.DateTimeOffset Modified { get; set; }
        public int SessionId { get; set; }
        public byte[] UpdateVersion { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual Translation Translation { get; set; }
    }
}
